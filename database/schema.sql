-- Criando o banco:
DROP SCHEMA IF EXISTS `Banco_Vendas`;
CREATE SCHEMA IF NOT EXISTS `Banco_Vendas` DEFAULT CHARACTER SET utf8;
USE `Banco_Vendas`;

-- Criando tabela Fornecedor:
CREATE TABLE IF NOT EXISTS `Fornecedor` (
  `idFornecedor` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(60) NOT NULL,
  `CNPJ` CHAR(14) NOT NULL,
  PRIMARY KEY (`idFornecedor`),
  UNIQUE INDEX `CNPJ_UNIQUE` (`CNPJ` ASC)
) ENGINE = InnoDB;

-- Criando tabela Produto:
CREATE TABLE IF NOT EXISTS `Produto` (
  `idProduto` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `idFornecedor` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`idProduto`),
  UNIQUE INDEX `nomeProduto_UNIQUE` (`nome` ASC),
  CONSTRAINT `fk_Produto_Fornecedor`
    FOREIGN KEY (`idFornecedor`)
    REFERENCES `Fornecedor` (`idFornecedor`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE = InnoDB;

-- Criando tabela Cliente:
CREATE TABLE IF NOT EXISTS `Cliente` (
  `idCliente` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `CPF` CHAR(11) NOT NULL,
  PRIMARY KEY (`idCliente`),
  UNIQUE INDEX `CPF_UNIQUE` (`CPF` ASC)
) ENGINE = InnoDB;

-- Criando tabela Funcionario:
CREATE TABLE IF NOT EXISTS `Funcionario` (
  `idFuncionario` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cargo` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`idFuncionario`)
) ENGINE = InnoDB;

-- Criando Tabela Venda:
CREATE TABLE IF NOT EXISTS `Venda` (
  `idVenda` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `idCliente` INT UNSIGNED NOT NULL,
  `idProduto` INT UNSIGNED NOT NULL,
  `valor` FLOAT NOT NULL,
  `idFuncionario` INT UNSIGNED NOT NULL,
  `data` DATE NOT NULL,
  PRIMARY KEY (`idVenda`),
  CONSTRAINT `fk_Venda_Cliente`
    FOREIGN KEY (`idCliente`)
    REFERENCES `Cliente` (`idCliente`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Venda_Produto`
    FOREIGN KEY (`idProduto`)
    REFERENCES `Produto` (`idProduto`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Venda_Funcionario`
    FOREIGN KEY (`idFuncionario`)
    REFERENCES `Funcionario` (`idFuncionario`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE = InnoDB;

CREATE TABLE log (
    id INT AUTO_INCREMENT PRIMARY KEY,
    usuario VARCHAR(30) NOT NULL,
    tabela VARCHAR(30) NOT NULL,
    atividade VARCHAR(20) NOT NULL,
    data TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Inserindo dados na tabela Fornecedor:
INSERT INTO `Fornecedor` (`nome`, `CNPJ`) VALUES
('Tech Solutions Ltda', '10456789000199'),
('Mega Alimentos S.A.', '20678932000188'),
('Moda & Estilo Ltda', '30912345000177'),
('Super Construções S.A.', '40123456000166');

-- Inserindo dados na tabela Produto:
INSERT INTO `Produto` (`nome`, `idFornecedor`) VALUES
('Notebook Turbo X', 1),
('Chocolate Premium 70%', 2),
('Camisa Polo Elegance', 3),
('Furadeira Industrial Max', 4);

-- Inserindo dados na tabela Cliente:
INSERT INTO `Cliente` (`nome`, `email`, `CPF`) VALUES
('Lucas Santos', 'lucas.santos@email.com', '12345678910'),
('Bianca Almeida', 'bianca.almeida@email.com', '98765432120'),
('Roberto Ferraz', 'roberto.ferraz@email.com', '45678912330'),
('Fernanda Costa', 'fernanda.costa@email.com', '65432198740');

-- Inserindo dados na tabela Funcionario:
INSERT INTO `Funcionario` (`nome`, `cargo`) VALUES
('Diego Oliveira', 'Consultor de Vendas'),
('Amanda Martins', 'Gerente de Estoque'),
('Leonardo Vasquez', 'Atendimento ao Cliente'),
('Juliana Ribeiro', 'Analista Financeiro');

-- Inserindo dados na tabela Venda:
INSERT INTO `Venda` (`idCliente`, `idProduto`, `valor`, `idFuncionario`, `data`) VALUES
(1, 1, 4599.90, 1, '2025-05-31'),  
(2, 2, 29.99, 3, '2025-05-30'),  
(3, 3, 189.90, 2, '2025-05-29'), 
(4, 4, 799.90, 4, '2025-05-28');  


