create database ShaurmaN0;
use ShaurmaN0;
create table Person(
	Id int primary key identity,
	Name nvarchar(15) not null,
	Surname nvarchar(15) not null,
	Password nvarchar(15) not null
)

create table MenuItem(
	Id int primary key identity,
	Name nvarchar(15) not null,
	Price float not null
)

create table PresonMenuItem(
	Id int primary key identity,
	PersonId int foreign key references Person(Id),
	MenuItemId int foreign key references MenuItem(Id)
)

insert into MenuItem(Name, Price)
values ('Shaurma', 4),('Cola 0.3', 1);