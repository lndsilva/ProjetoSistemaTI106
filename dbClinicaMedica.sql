drop database dbClinicaMedica;

create database dbClinicaMedica;

use dbClinicaMedica;

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

insert into tbPaciente(nome,email,telefone,cpf,
	endereco,numero,cep,complemento,bairro,cidade,
	siglaEst) values('Senac','senac@senac.com',
	'(11) 98574-8582','560.054.738-24','Rua Dr. Antonio Bento','377',
	'04750000','casa','Santo Amaro','São Paulo','sp');

-- Pesquisa por nome

select * from tbPaciente where nome like '%s%';


-- Pesquisa por código

select * from tbPaciente where codpac = 4;




