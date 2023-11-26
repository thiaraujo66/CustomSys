USE	CUSTOMSYS

-- Inserir algumas nacionalidades na tabela Nacionalidades
INSERT INTO Nacionalidades (NCSigla, NCNome) VALUES
('BR', 'Brasileira'),
('US', 'Americana'),
('CA', 'Canadense'),
('MX', 'Mexicana'),
('GB', 'Inglesa'),
('FR', 'Francesa'),
('DE', 'Alemã'),
('IT', 'Italiana'),
('ES', 'Espanhola'),
('PT', 'Portuguesa'),
('JP', 'Japonesa'),
('CN', 'Chinesa');
GO

-- Inserir dados na tabela TipoUsuario
INSERT INTO TipoUsuario (TUNOME, TUDESCRICAO, TUDTCAD, TUUSUCAD)
VALUES
  ('Administrador', 'Usuário com acesso total ao sistema', GETDATE(), 1),
  ('Usuário Padrão', 'Usuário comum com permissões limitadas', GETDATE(), 1),
  ('Convidado', 'Usuário com permissões mínimas', GETDATE(), 1),
  ('Gerente', 'Gerente com acesso moderado', GETDATE(), 1),
  ('Suporte', 'Usuário de suporte técnico', GETDATE(), 1),
  ('Analista', 'Analista de dados', GETDATE(), 1)
GO

-- Inserir dados na tabela Enderecos
INSERT INTO Enderecos (EDLOGRADOURO, EDNUMERO, EDBAIRRO, EDCIDADE, EDUF, EDCOMPL, EDCEP, EDTPEND, EDDTCAD, EDCDUSUCAD)
VALUES
  ('Rua A', '123', 'Centro', 'Cidade A', 'UF', 'Apto 101', '12345678', 0, GETDATE(), 1),
  ('Avenida B', '456', 'Bairro X', 'Cidade B', 'UF', 'Loja 2', '98765432', 1, GETDATE(), 1),
  ('Rua C', '789', 'Vila Y', 'Cidade C', 'UF', 'Casa 3', '87654321', 0, GETDATE(), 1),
  ('Alameda D', '1011', 'Centro', 'Cidade D', 'UF', 'Sala 4', '23456789', 1, GETDATE(), 1),
  ('Avenida E', '1213', 'Bairro Z', 'Cidade E', 'UF', 'Andar 5', '34567890', 0, GETDATE(), 1),
  ('Rua F', '1415', 'Vila W', 'Cidade F', 'UF', 'Apto 6', '45678901', 1, GETDATE(), 1),
  ('Alameda G', '1617', 'Centro', 'Cidade G', 'UF', 'Loja 7', '56789012', 0, GETDATE(), 1),
  ('Avenida H', '1819', 'Bairro K', 'Cidade H', 'UF', 'Casa 8', '67890123', 1, GETDATE(), 1),
  ('Rua I', '2021', 'Vila M', 'Cidade I', 'UF', 'Sala 9', '78901234', 0, GETDATE(), 1),
  ('Alameda J', '2223', 'Centro', 'Cidade J', 'UF', 'Andar 10', '89012345', 1, GETDATE(), 1);
GO

--Inserindo Dados na tabela de Tipo de Cliente
INSERT INTO TipoCliente (TCNome, TCDescricao) 
VALUES
('Físico', 'Pessoa física'),
('Jurídica', 'Pessoa Jurídica'),
('Estrangeiro', 'Pessoa proveniente de outro país')
GO

--Inserindo Dados na tabela de Situação do Cliente
INSERT INTO SituacaoCliente (SCNome, SCDescricao)
VALUES
('Ativo', 'Cliente ativo'),
('Inativo', 'Cliente inativo'),
('Baixa incidência', 'Cliente com baixo índice de atividade')

GO

-- Inserir dados na tabela Clientes
INSERT INTO Clientes (CLID, CLNOME, CLCGC, CLSEXO, CLCDENDERECO, CLEMAIL, CLTELEFONE, CLOBS, CLCDTIPOCLIENTE, CLCDSITUACAO, CLNACIONALIDADE, CLDTNASC, CLDTCAD, CLCDUSUCAD)
VALUES
  ('90894870009', 'Cliente 1', '908.948.700-09', 'M', 1, 'cliente1@email.com', '1112345678', 'Observação cliente 1', 1, 1, 1, '1990-01-01', GETDATE(), 1),
  ('12197161000104', 'Cliente 2', '12.197.161/0001-04', 'M', 2, 'cliente2@email.com', '2223456789', 'Observação cliente 2', 2, 1, 2, '1985-05-05', GETDATE(), 1),
  ('55142225007', 'Cliente 3', '551.422.250-07', 'M', 3, 'cliente3@email.com', '3334567890', 'Observação cliente 3', 1, 1, 3, '1978-10-10', GETDATE(), 1),
  ('82694688000111', 'Cliente 4', '82.694.688/0001-11', 'M', 4, 'cliente4@email.com', '4445678901', 'Observação cliente 4', 2, 1, 4, '1995-03-05', GETDATE(), 1),
  ('70103248080', 'Cliente 5', '701.032.480-80', 'M', 5, 'cliente5@email.com', '5556789012', 'Observação cliente 5', 1, 1, 5, '1980-20-07', GETDATE(), 1),
  ('21824006000153', 'Cliente 6', '21.824.006/0001-53', 'F', 6, 'cliente6@email.com', '6667890123', 'Observação cliente 6', 2, 1, 6, '1992-12-07', GETDATE(), 1),
  ('19054437065', 'Cliente 7', '190.544.370-65', 'F', 7, 'cliente7@email.com', '7778901234', 'Observação cliente 7', 1, 1, 7, '1988-30-04', GETDATE(), 1),
  ('15093585000109', 'Cliente 8', '15.093.585/0001-09', 'F', 8, 'cliente8@email.com', '8889012345', 'Observação cliente 8', 2, 1, 8, '1999-08-05', GETDATE(), 1),
  ('90322778042', 'Cliente 9', '903.227.780-42', 'F', 9, 'cliente9@email.com', '9990123456', 'Observação cliente 9', 1, 1, 9, '1983-06-08', GETDATE(), 1)
GO

SELECT * FROM TipoUsuario
GO

SELECT * FROM Enderecos
GO

SELECT * FROM TipoCliente
GO

SELECT * FROM SituacaoCliente
GO

SELECT * FROM Clientes
GO

USE master