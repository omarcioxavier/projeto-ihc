USE colorcommercedb;

INSERT INTO categoria (ca_descricao, ca_ca_cod) VALUES
('Tintas', 1),
('Tinta Látex', 1),
('Tinta Acrílica', 1),
('Tinta Esmalte', 1),
('Tinta Epóxi', 1),
('Tinta Especial para textura', 1);

INSERT INTO estado (es_nome, es_uf) VALUES
('Acre', 'AC'),
('Alagoas', 'AL'),
('Amazonas', 'AM'),
('Amapá', 'AP'),
('Bahia', 'BA'),
('Ceará', 'CE'),
('Distrito Federal', 'DF'),
('Espírito Santo', 'ES'),
('Goiás', 'GO'),
('Maranhão', 'MA'),
('Minas Gerais', 'MG'),
('Mato Grosso do Sul', 'MS'),
('Mato Garosso', 'MT'),
('Pará', 'PA'),
('Paraíba', 'PB'),
('Pernambuco', 'PE'),
('Piauí', 'PI'),
('Paraná', 'PR'),
('Rio de Janeiro', 'RJ'),
('Rio Grande do Norte', 'RN'),
('Rondônia', 'RO'),
('Roraima', 'RR'),
('Rio Grande do Sul', 'RS'),
('Santa Catarina', 'SC'),
('Sergipe', 'SE'),
('São Paulo', 'SP'),
('Tocantins', 'TO');

INSERT INTO tipoEmitente (te_descricao) VALUES
('Pessoa Física'),
('Pessoa Jurídica');

INSERT INTO tipoUsuario (tu_descricao) VALUES
('Administrador'),
('Usuário');

INSERT INTO unidadeMedida (um_sigla, um_descricao) VALUES
('un','Unidade'),
('kg','Quilo');

INSERT INTO usuario (us_login, us_senha,us_status, us_tu_cod) VALUES
('admin','admin', 1, 1),
('user','user', 1, 2);