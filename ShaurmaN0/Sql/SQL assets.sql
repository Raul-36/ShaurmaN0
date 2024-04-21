create database ShaurmaN0;

use ShaurmaN0;
create table MenuItem(
	Id int primary key identity,
	Name nvarchar(15) not null,
	Price float not null
)
create table Order(
	Id int primary key identity,
	MenuItemId int FOREIGN KEY REFERENCES MenuItem (Id)
)
insert into MenuItem(Name, Price)
values ('Shaurma', 4),('Cola 0.3', 1);