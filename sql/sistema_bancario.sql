CREATE FUNCTION bank_account_apply_income(bank_account_id CHAR(36))
    RETURNS DECIMAL(13,2)
    DETERMINISTIC
BEGIN
    DECLARE income DECIMAL(13,2);
    SELECT 13.20 INTO income FROM user;
    RETURN income;
END;

CREATE FUNCTION bank_account_register_daily_info(bank_account_id CHAR(36), balance_at_date DECIMAL(13,2), bank_account_income DECIMAL(13,2))
    RETURNS INT
BEGIN
   INSERT IGNORE
END;

DROP PROCEDURE IF EXISTS update_bank_account_daily_infos;

CREATE PROCEDURE update_bank_account_daily_infos()
BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE bank_account_id CHAR(36);
    DECLARE income DECIMAL(13,2);

    DECLARE cur1 CURSOR FOR SELECT id FROM user;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

    OPEN cur1;
    read_loop: LOOP
        FETCH cur1 INTO bank_account_id;
        IF done THEN
            LEAVE read_loop;
        END IF;

        -- SELECT  bank_account_apply_income(bank_account_id);
        INSERT INTO user (id, created_at, updated_at, name, email) values (UUID(), CURRENT_DATE, null, 'Teste', 'cassiano.raupp@outlook.com');
    END LOOP;

    CLOSE cur1;
END;

CREATE EVENT update_bank_account_daily_infos_event
    ON SCHEDULE
        EVERY 24 DAY_HOUR
        STARTS CURRENT_DATE
    DO
        INSERT IGNORE INTO user (id, created_at, updated_at, name, email) values (UUID(), CURRENT_DATE, null, 'Teste', 'cassiano.raupp@outlook.com');