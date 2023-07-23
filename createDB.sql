drop database if exists CRUDDemo
create database CRUDDemo
on
(
    NAME = CRUDDemo,
    FILENAME = 'E:\CRUDDemo_Sql\CRUDDemo.mdf',
    SIZE = 100MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 10MB
)
LOG ON
(
    NAME = CRUDDemo_log,
    FILENAME = 'E:\CRUDDemo_Sql\CRUDDemo_log.ldf',
    SIZE = 50MB,
    MAXSIZE = 2GB,
    FILEGROWTH = 5MB
);
go 

use [CRUDDemo];
drop table if exists Product
create table Product(
Id int identity(1,1) primary key,
ProductName nvarchar(200) not null,
Descirption nvarchar(500) not null,
Price decimal(10,2) not null,
CreateDateTime datetime not null,
UpdateDateTime datetime not null
);
go