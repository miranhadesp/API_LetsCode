alter table Companhias drop constraint FK_Companhia_Passagem;
alter table Reserva_Quarto drop constraint FK_ReservaQuarto_Cliente;
alter table Reserva_Quarto drop constraint FK_ReservaQuarto_Quarto;
alter table Venda_Passagem drop constraint FK_VendaPassagem_Cliente;
alter table Venda_Passagem drop constraint FK_VendaPassagem_Passagem;
alter table Quarto drop constraint FK_Hotel_Quarto;

truncate table Hotel;
truncate table Quarto;
truncate table Reserva_Quarto;
truncate table Venda_Passagem;
truncate table Companhias;
truncate table Cliente;
truncate table __EFMigrationsHistory;
truncate table Passagem;

drop table Hotel;
drop table Quarto;
drop table Reserva_Quarto;
drop table Venda_Passagem;
drop table Companhias;
drop table Cliente;
drop table __EFMigrationsHistory;
drop table Passagem;