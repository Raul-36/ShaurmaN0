create database ShaurmaN0;

use ShaurmaN0;
create table MenusCategory(
	Id guid primary key identity,
	Name nvarchar(15) not null
)
create table Menus(
	Id guid primary key identity,
	Name nvarchar(15) not null,
	MenusCategoryId guid FOREIGN KEY REFERENCES MenusCategory(Id),
	Price float not null
)