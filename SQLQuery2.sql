CREATE DATABASE JOINTASK
USE JOINTASK

CREATE TABLE Roles(
 RoleId int primary key identity , 
 Name nvarchar(10) Unique Check (Name in ('admin','moderator','customer')) 	
)


CREATE TABLE [User] (
 UserId int primary key identity,
 Username nvarchar(30)  not null,
 [Password] nvarchar(40) not null, 
 RoleId int foreign key references Roles(RoleId)
)


Insert Into Roles(Name)
Values('admin')

Insert Into Roles(Name)
Values('moderator')

Insert Into Roles(Name)
Values('customer')

Insert Into [User] (Username,[Password],RoleId)
Values ('Asad','asadasad',1)

Insert Into [User] (Username,[Password],RoleId)
Values ('Ceyhun','asadasad',2)

Insert Into [User] (Username,[Password],RoleId)
Values ('Emil','asadasad',2)

Insert Into [User] (Username,[Password],RoleId)
Values ('Anar','asadasad',3)

Insert Into [User] (Username,[Password],RoleId)
Values ('Rasim','asadasad',3)

Select [User].Username ,Roles.Name
From [User]
JOIN Roles ON [User].RoleID = Roles.RoleId;