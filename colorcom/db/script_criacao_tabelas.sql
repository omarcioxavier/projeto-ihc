/*BASE DE DADOS*/
CREATE DATABASE colorcommerce;
USE colorcommerce;

/*TABELA tipoUsuario*/
CREATE TABLE tipoUsuario (
  tu_cod INT NOT NULL IDENTITY PRIMARY KEY,
  tu_descricao VARCHAR(100) NULL DEFAULT NULL);

/*TABELA usuario*/
CREATE TABLE usuario (
  us_cod INT NOT NULL IDENTITY PRIMARY KEY,
  us_login VARCHAR(100) UNIQUE NULL,
  us_senha VARCHAR(100) NULL,
  us_status BIT NULL,
  us_tu_cod INT NOT NULL FOREIGN KEY REFERENCES tipoUsuario(tu_cod));

/*TABELA estado*/
CREATE TABLE estado (
  es_cod INT NOT NULL IDENTITY PRIMARY KEY,
  es_nome VARCHAR(100) NULL,
  es_uf VARCHAR(2) NULL);

/*TABELA cidade*/
CREATE TABLE cidade (
  ci_cod INT NOT NULL IDENTITY PRIMARY KEY,
  ci_nome VARCHAR(100) NULL,
  ci_es_cod INT NOT NULL FOREIGN KEY REFERENCES estado(es_cod));

/*TABELA tipoEmitente*/
CREATE TABLE tipoEmitente (
  te_cod INT NOT NULL IDENTITY PRIMARY KEY,
  te_descricao VARCHAR(100) NULL);

/*TABELA emitente*/
CREATE TABLE emitente (
  em_cod INT NOT NULL IDENTITY PRIMARY KEY,
  em_nome VARCHAR(100) NULL,
  em_nomeFantasia VARCHAR(100) NULL,
  em_documento VARCHAR(18) NULL,
  em_endereco VARCHAR(100) NULL,
  em_telefone VARCHAR(14) NULL,
  em_celular VARCHAR(16) NULL,
  em_email VARCHAR(100) NULL,
  em_status BIT NULL,
  em_inscricaoEstadual VARCHAR(20) NULL,
  em_ci_cod INT NOT NULL FOREIGN KEY REFERENCES cidade(ci_cod),
  em_te_cod INT NOT NULL FOREIGN KEY REFERENCES tipoEmitente(te_cod));

/*TABELA unidadeMedida*/
CREATE TABLE unidadeMedida (
  um_cod INT NOT NULL IDENTITY PRIMARY KEY,
  um_sigla VARCHAR(10) NULL,
  um_descricao VARCHAR(100) NULL);

/*TABELA entradaNF*/
CREATE TABLE entradaNF (
  en_cod INT NOT NULL IDENTITY PRIMARY KEY,
  en_numero INT NULL,
  en_serie INT NULL,
  en_dataentrada DATETIME NULL,
  en_dataemissao DATETIME NULL,
  en_endereco VARCHAR(100) NULL,
  en_us_cod INT NOT NULL FOREIGN KEY REFERENCES usuario(us_cod),
  en_em_cod INT NOT NULL FOREIGN KEY REFERENCES emitente(em_cod),
  en_ci_cod INT NOT NULL FOREIGN KEY REFERENCES cidade(ci_cod));

/*TABELA categoria*/
CREATE TABLE categoria (
  ca_cod INT NOT NULL IDENTITY PRIMARY KEY,
  ca_descricao VARCHAR(100) NULL DEFAULT NULL,
  ca_cod_subcategoria INT NOT NULL FOREIGN KEY REFERENCES categoria(ca_cod));

/*TABELA item*/
CREATE TABLE item (
  it_cod INT NOT NULL IDENTITY PRIMARY KEY,
  it_titulo VARCHAR(40) NULL,
  it_descricao VARCHAR(100) NULL,
  it_ean VARCHAR(100) NULL,
  it_preco_compra FLOAT NULL,
  it_preco_venda FLOAT NULL,
  it_min INT NULL,
  it_max INT NULL,
  it_quantidade INT NULL,
  it_status BIT NULL,
  it_ca_cod INT NOT NULL FOREIGN KEY REFERENCES categoria(ca_cod),
  it_um_cod  INT NOT NULL FOREIGN KEY REFERENCES unidadeMedida(um_cod));

/*TABELA itensPedido*/
CREATE TABLE itensPedido (
  ip_cod INT NOT NULL IDENTITY PRIMARY KEY,
  ip_valor FLOAT NULL,
  ip_descricao VARCHAR(100) NULL,
  ip_quantidade INT NULL,
  ip_it_cod INT NOT NULL FOREIGN KEY REFERENCES item(it_cod));

/*TABELA logItem*/
CREATE TABLE logItem (
  li_cod INT NOT NULL IDENTITY PRIMARY KEY,
  li_preco_novo FLOAT NULL,
  li_datahora DATETIME NULL,
  li_it_cod INT NOT NULL FOREIGN KEY REFERENCES item(it_cod));

/*TABELA pedido */
CREATE TABLE pedido (
  pe_cod INT NOT NULL IDENTITY PRIMARY KEY,
  pe_valor FLOAT NULL,
  pe_dataHora DATETIME NULL,
  pe_us_cod INT NOT NULL FOREIGN KEY REFERENCES usuario(us_cod),
  pe_em_cod INT NOT NULL FOREIGN KEY REFERENCES emitente(em_cod),
  pe_ip_cod INT NOT NULL FOREIGN KEY REFERENCES itensPedido(ip_cod));

/*TABELA saidaNF*/
CREATE TABLE saidaNF (
  sn_cod INT NOT NULL IDENTITY PRIMARY KEY,
  sn_serie INT NULL,
  sn_pe_cod INT NOT NULL FOREIGN KEY REFERENCES pedido(pe_cod));

/*TABELA movimentoEstoque*/
CREATE TABLE movimentoEstoque (
  me_cod INT NOT NULL IDENTITY PRIMARY KEY,
  me_it_cod INT NOT NULL FOREIGN KEY REFERENCES item(it_cod),
  me_sn_cod INT NOT NULL FOREIGN KEY REFERENCES saidaNF(sn_cod),
  me_en_cod INT NOT NULL FOREIGN KEY REFERENCES entradaNF(en_cod));