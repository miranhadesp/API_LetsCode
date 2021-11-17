 create table Cliente
 (
	id int identity (1,1)
	,nome varchar(200)
	,cpf varchar(12)
 );

 create table Companhia
 (
	id int identity (1,1)
	,nome varchar(200)
 );

 create table Hotel
(
	id int identity (1,1)
	,nome varchar(150)
	,check_out varchar(10)
	,check_in varchar(10)
	,estacionamento bit
);

create table Passagem
(
	id int identity (1,1)
	,destino varchar(100)
	,embarque varchar(100)
	,data_reserva varchar(11)
	,valor decimal(4,2)
	,id_companhia int
);

create table Quarto
(
	id int identity (1,1)
	,id_hotel int
	,tipo varchar(50)
	,valor decimal(4,2)
	,info_quarto varchar(500)
);

create table Reserva_Quarto
(
	id int identity (1,1)
	,id_cliente int
	,id_quarto int 
	,data_entrada varchar(11)
	,data_saida varchar(11)
);

create table Venda_Passagem
(
	id int identity (1,1)
	,id_passagem int
	,id_cliente int
);

alter table Cliente add constraint PK_Cliente primary key(id);
alter table Companhia add constraint PK_Companhia primary key(id);
alter table Hotel add constraint PK_Hotel primary key(id);
alter table Passagem add constraint PK_Passagem primary key(id);
alter table Quarto add constraint PK_Quarto primary key(id);
alter table Reserva_Quarto add constraint PK_Reserva_Quarto primary key(id);
alter table Venda_Passagem add constraint PK_Venda_Passagem primary key(id);

alter table Quarto add constraint FK_Quarto_Hotel foreign key (id_hotel) references Hotel (id);
alter table Passagem add constraint FK_Passagem_Companhia foreign key (id_companhia) references Companhia (id);
alter table Reserva_Quarto add constraint FK_Reserva_Quarto_Quarto foreign key (id_quarto) references Quarto (id);
alter table Reserva_Quarto add constraint FK_Reserva_Quarto_Cliente foreign key (id_cliente) references Cliente(id);
alter table Venda_Passagem add constraint FK_Venda_Passagem_Passagem foreign key (id_passagem) references Passagem(id);
alter table Venda_Passagem add constraint FK_Venda_Passagem_Cliente foreign key (id_cliente) references Cliente(id);
