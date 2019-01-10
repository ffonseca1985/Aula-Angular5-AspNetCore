
use KeySystemsERP;

insert into Tenant (nome) values ('Fani');
insert into Modulo (nome) values ('Controle de Acesso');
insert into Metodo (nome) values ('Get');
insert into Api (IdTenant, IdMetodo, IdModulo, EndPoint) values (1, 1, 1,  'http://localhost:3086/api/private/keysystems/erp/ControleDeAcesso/usuario/');
insert into Usuario(DataNascimento, Ativo, Cpf, Email, Nome, SobreNome, Telefone, Hash, IdTenant) values (Now(), true, '33994156807', 'ffonseca1985@gmail.com', 'Fábio', 'Fonseca', '11966815922','', 1);
INSERT INTO metodo (Id, Nome) VALUES ('2', 'Post');
INSERT INTO api (IdTenant, IdMetodo, IdModulo, EndPoint) VALUES ('1', '2', '1', 'http://localhost:3086/api/private/keysystems/erp/ControleDeAcesso/usuario/');
Insert into Empresa(RazaoSocial, NomeBusca, CNPJ) values ('Fani', 'Fani', '123123124');

insert into TipoPgto (descricao) values ('Cheque ');
insert into TipoPgto (descricao) values ('Deposito');
insert into TipoPgto (descricao) values ('Cartão');

insert into TipoTitulo (descricao) values ('Duplicatas');
insert into TipoTitulo (descricao) values ('Contas particulares');