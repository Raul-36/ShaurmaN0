create database ShaurmaN0;

use ShaurmaN0;
create table MenusCategory
(
	Id  UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key,
	Name nvarchar(15) not null
)
create table Menus
(
	Id  UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key,
	Name nvarchar(15) not null,
	MenusCategoryId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MenusCategory(Id),
	Price float not null
)