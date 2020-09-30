CREATE FUNCTION bank_account_apply_income(bank_account_id CHAR(36))
    RETURNS DECIMAL(13,7)
    DETERMINISTIC
BEGIN
    DECLARE percent DOUBLE;
    DECLARE balance DECIMAL(13,7);
    SET percent = 0.000043333;

    SELECT balance INTO balance FROM dbSistemaBancario.bank_account WHERE id = bank_account_id AND active IS TRUE AND balance > 0;

    IF (balance IS NULL) THEN
        SET balance = 0;
    END IF;

    RETURN balance * percent;
END;

CREATE FUNCTION bank_account_register_daily_info(bank_account_id CHAR(36), bank_account_income DECIMAL(13,7))
    RETURNS DECIMAL(13,7)
    DETERMINISTIC
BEGIN
   DECLARE balance_at_date, balance_updated DECIMAL(13,7);
    SELECT balance INTO balance_at_date FROM dbSistemaBancario.bank_account WHERE id = bank_account_id AND active IS TRUE;
    SET balance_updated = balance_at_date + bank_account_income;
    INSERT IGNORE dbSistemaBancario.bank_account_daily_info(id, created_at, updated_at, balance_at_date, income_balance, reference_date, bank_account_id)
    VALUES (UUID(), Now(), null, balance_at_date, bank_account_income, CURRENT_DATE - INTERVAL 1 DAY , bank_account_id);

    RETURN balance_updated;
END;

-- CREATE FUNCTION bank_account_register_transaction_income(bank_account_id char(36), income decimal(13,2))
--     RETURNS INT
-- BEGIN
--     INSERT INTO dbSistemaBancario.transaction(id, created_at, updated_at, description, transation_type, bank_account_id, Value)
--     VALUES (UUID(), NOW(), null, 'Rendimento', 3, bank_account_id, income);

--     RETURN 1;
-- END;

CREATE FUNCTION bank_account_update_balance(bank_account_id char(36), balance_updated decimal(13,7))
    RETURNS DECIMAL(13,7)
    DETERMINISTIC
BEGIN
    UPDATE dbSistemaBancario.bank_account SET balance = balance_updated, updated_at = NOW()
    WHERE id = bank_account_id AND active IS TRUE;

    RETURN balance_updated;
END;

CREATE PROCEDURE update_bank_account_daily_infos()
BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE bank_account_id CHAR(36);
    DECLARE income, balance_updated DECIMAL(13,7);

    DECLARE cur1 CURSOR FOR SELECT id FROM dbSistemaBancario.bank_account WHERE active is TRUE;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

    OPEN cur1;
    read_loop: LOOP
        FETCH cur1 INTO bank_account_id;
        IF done THEN
            LEAVE read_loop;
        END IF;

        SELECT bank_account_apply_income(bank_account_id) INTO income;
        SELECT bank_account_register_daily_info(bank_account_id, income) INTO balance_updated;
        SELECT bank_account_update_balance(bank_account_id, balance_updated);
        -- SELECT bank_account_register_transaction_income(bank_account_id, income);

    END LOOP;

    CLOSE cur1;
END;

CREATE EVENT update_bank_account_daily_infos_event
    ON SCHEDULE
        EVERY 24 DAY_HOUR
        STARTS CURRENT_DATE - interval 1 DAY
    DO
        CALL update_bank_account_daily_infos();

INSERT INTO bank_account(id, created_at, updated_at, agency, account_number, balance, active)
VALUES (UUID(), NOW(), null, 1, 1, 0, true);
