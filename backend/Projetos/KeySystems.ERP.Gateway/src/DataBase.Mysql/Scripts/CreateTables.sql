use KeySystemsERP;

create table Tenant (

	Id int primary key auto_increment, 
    Nome varchar(255)
);

create table Modulo (

	Id int primary key auto_increment, 
    Nome varchar(255)
);

create table Metodo (

	Id int primary key auto_increment, 
    Nome varchar(255)
);

create table Api 
(
	Id int primary key auto_increment, 
	IdTenant int,
    IdMetodo int,
    IdModulo int,
    EndPoint varchar(255),
    constraint FK_Tenant_Api foreign key (IdTenant) references Tenant(Id),
    constraint FK_Tenant_Metodo foreign key (IdMetodo) references Metodo(Id),
    constraint FK_Tenant_Modulo foreign key (IdModulo) references Modulo(Id)  
);

create table Usuario
(
	Id int primary key auto_increment, 
    DataNascimento DateTime, 
    Ativo bool, 
    Cpf varchar(11),
    Email varchar(255),
    Nome varchar(255),
    SobreNome varchar(255),
    Telefone varchar(20),
    Hash varchar(50),
    IdTenant int,
    constraint FK_Tenant_Usuario foreign key (IdTenant) references Tenant(Id)
);

create table Empresa 
(
	Id int primary key auto_increment,
    RazaoSocial varchar(500),
    NomeBusca varchar(500),
    CNPJ varchar(14)
);

create table Fornecedor 
(
	Id int primary key auto_increment,
    RazaoSocial varchar(500),
    NomeBusca varchar(500),
    CNPJ varchar(14)
)

Create table TipoPgto (

	Id integer auto_increment primary key,
    Descricao varchar(500)
);

Create table TipoTitulo (

	Id integer auto_increment primary key,
    Descricao varchar(500)
)


create table Titulo (
	Id int primary key auto_increment,
    IdEmpresa int,
    IdTipoTitulo int,
    IdFornecedor int,
    Total decimal,
    constraint FK_Titulo_Empresa foreign key (IdEmpresa) references Empresa(Id),
    constraint FK_Titulo_TipoTitulo foreign key (IdTipoTitulo) references TipoTitulo(Id),
    constraint FK_Titulo_Fornecedor foreign key (IdFornecedor) references Fornecedor(Id)
);