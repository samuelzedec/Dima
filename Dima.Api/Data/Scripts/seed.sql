INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Alimentação', 'Despesas com alimentos e bebidas', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Saúde', 'Gastos com saúde e bem-estar', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Transporte', 'Custos com transporte e veículos', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Moradia', 'Despesas relacionadas à casa', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Educação', 'Gastos com educação e cursos', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Lazer', 'Despesas com atividades de lazer', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Roupas', 'Gastos com vestuário', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Investimentos', 'Investimentos e aplicações financeiras', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Impostos', 'Pagamentos de impostos e taxas', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Viagem', 'Despesas com viagens e turismo', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Presentes', 'Gastos com presentes e doações', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Beleza', 'Despesas com beleza e cuidados pessoais', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Pets', 'Gastos com animais de estimação', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Telefonia', 'Custos com telefonia e internet', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Seguros', 'Pagamentos de seguros diversos', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Saúde Mental', 'Despesas com psicologia e terapias', 'samuelzedec@gmail.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Fitness', 'Gastos com academia e atividades físicas', 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Compra de supermercado', '2025-01-05', '2025-01-05', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Alimentação'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Mensalidade Academia', '2025-01-10', '2025-01-10', 2, -89.99, (SELECT Id FROM [dbo].[Category] WHERE Title='Fitness'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Passagem de ônibus', '2025-01-15', '2025-01-15', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transporte'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Livros para curso', '2025-01-20', '2025-01-20', 2, -200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Educação'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Salário', '2025-01-25', '2025-01-25', 1, 5000.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Consulta médica', '2025-01-26', '2025-01-26', 2, -250.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Saúde'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Jantar fora', '2025-01-27', '2025-01-27', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Lazer'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Ração para cachorro', '2025-01-28', '2025-01-28', 2, -75.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Pagamento de seguro de vida', '2025-01-29', '2025-01-29', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Seguros'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Mensalidade Netflix', '2025-02-02', '2025-02-02', 2, -45.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Lazer'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Roupa nova', '2025-02-06', '2025-02-06', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Roupas'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Conserto do carro', '2025-02-11', '2025-02-11', 2, -800.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transporte'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Corte de cabelo', '2025-02-15', '2025-02-15', 2, -50.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Beleza'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Compra de livros', '2025-02-18', '2025-02-18', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Educação'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Reembolso de viagem', '2025-02-20', '2025-02-20', 1, 1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Viagem'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Aluguel de fevereiro', '2025-02-25', '2025-02-25', 2, -1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Moradia'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('IPVA', '2025-02-27', '2025-02-27', 2, -400.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Impostos'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Consulta veterinária', '2025-02-28', '2025-02-28', 2, -180.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Jantar de aniversário', '2025-02-28', '2025-02-28', 2, -250.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Lazer'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Salário Mensal', '2025-03-01', '2025-03-01', 1, 5000.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Conta de Luz', '2025-03-02', '2025-03-02', 2, -120.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Moradia'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Conta de Água', '2025-03-05', '2025-03-05', 2, -80.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Moradia'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Mensalidade Escolar', '2025-03-10', '2025-03-10', 2, -600.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Educação'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Compra de Roupas', '2025-03-12', '2025-03-12', 2, -300.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Roupas'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Compra de Suplementos', '2025-03-15', '2025-03-15', 2, -200.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Saúde'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Restaurante com a Família', '2025-03-18', '2025-03-18', 2, -250.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Alimentação'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Plano de Telefonia', '2025-03-20', '2025-03-20', 2, -150.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Telefonia'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Viagem de Fim de Semana', '2025-03-22', '2025-03-22', 2, -800.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Viagem'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Pagamento Seguro Carro', '2025-03-24', '2025-03-24', 2, -400.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Seguros'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Material de Arte', '2025-03-26', '2025-03-26', 2, -150.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Lazer'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Receita de Freelance', '2025-05-02', '2025-05-02', 1, 2200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Conta de Internet', '2025-05-05', '2025-05-05', 2, -89.99, (SELECT Id FROM [dbo].[Category] WHERE Title='Telefonia'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Despesa com Transporte', '2025-05-07', '2025-05-07', 2, -160.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transporte'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Compra de Livros', '2025-05-09', '2025-05-09', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Educação'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Salário', '2025-05-10', '2025-05-10', 1, 4000.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Pagamento do Aluguel', '2025-05-12', '2025-05-12', 2, -1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Moradia'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Gastos com Jantar', '2025-05-15', '2025-05-15', 2, -200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Alimentação'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Consulta Médica', '2025-05-18', '2025-05-18', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Saúde'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Ração para Pet', '2025-05-20', '2025-05-20', 2, -75.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Presente de Aniversário', '2025-05-22', '2025-05-22', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Presentes'), 'samuelzedec@gmail.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Bonificação', '2025-05-24', '2025-05-24', 1, 1200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'samuelzedec@gmail.com');