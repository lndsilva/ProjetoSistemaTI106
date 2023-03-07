drop database dbClinicaMedica;

create database dbClinicaMedica;

use dbClinicaMedica;


create table tbfuncionarios(
codfunc int not null auto_increment,
nomefunc varchar(100),
emailfunc varchar(100),
telefone char(15),
cpf char(15),
primary key(codfunc));

insert into tbfuncionarios(nomefunc,emailfunc, telefone, cpf)
	values('senac','senac@senac.com','(11) 3737-3900','258.258-247-00');

create table tbusuarios(
codUsu int not null auto_increment,
nomeUsu varchar(20) not null,
senhaUsu varchar(20) not null,
codfunc int not null,
primary key(codUsu),
foreign key(codfunc)references tbfuncionarios(codfunc));



create table tbPaciente(
codPac int not null auto_increment,
nome varchar(100) not null,
email varchar(100),
telefone char(14),
cpf char(14) not null,
endereco varchar(100),
numero char(10),
cep char(8),
complemento varchar(50),
bairro varchar(50),
cidade varchar(50),
siglaEst char(2),
primary key(codPac));

create table tbusuarios(
codUsu int not null auto_increment,
nomeUsu varchar(20) not null,
senhaUsu varchar(20) not null,
primary key(codUsu));

insert into tbusuarios(nomeUsu,senhaUsu, codfunc)
	values('senac','senac',1);
insert into tbusuarios(nomeUsu,senhaUsu)
	values('admin','admin');
insert into tbusuarios(nomeUsu,senhaUsu)
	values('visitante','123456');

select * from tbusuarios where 
nomeUsu = 'senac' and senhaUsu = 'senac';


insert into tbPaciente(nome,email,telefone,cpf,
	endereco,numero,cep,complemento,bairro,cidade,
	siglaEst) values('Senac','senac@senac.com',
	'(11) 98574-8582','560.054.738-24','Rua Dr. Antonio Bento','377',
	'04750000','casa','Santo Amaro','São Paulo','sp');

-- Pesquisa por nome

select * from tbPaciente where nome like '%s%';


-- Pesquisa por código

select * from tbPaciente where codpac = 4;



update tbPaciente set nome = '', email = '', telefone = '',
	cpf = '', endereco = '', numero = '', cep = '',
	complemento = '', bairro = '', cidade = '', siglaEst = ''
where codpac = 1;

delete from tbPaciente where codpac = 1;




