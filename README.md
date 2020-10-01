# SistemaBancario

Instruções para rodar o projeto:
1 - Alterar usuário e senha da connection string "SistemaBancario" do appsetting.Development;
2 - Rodar as migrations do projeto SistemaBancario.UI.Web;
3 - Rodar os scripts do arquivo ./sql/sistema_bancario.sql;
4 - Executar o projeto;

Sobre o rendimento:
O rendimento é aplicado todo dia a meia noite (00:00) via event do MySql, as procedures e functions utilizadas estão no arquivo ./sql/sistema_bancario.sql;
