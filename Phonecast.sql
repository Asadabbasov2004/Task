create database ReminderDb
use ReminderDb

create table Users(
Id int primary key identity,
[Name] nvarchar (20) not null,
Surname nvarchar (20) not null,
[Password] nvarchar (20) not null,
PhoneNumber nvarchar (20) not null,
)
insert into Users Values('veli','eli','23','055 222 40 50'),('veli','eli','23','055 222 40 50'),('veli','eli','23','055 222 40 50')
 

create table Method(
Id int primary key identity,
Platforms nvarchar (20) check (Platforms in ('ins','telegram')),
)


drop table Reminder
create table Reminder(
Id int primary key identity,
Content nvarchar(20) not null,
SendAt datetime ,
CreatedAt datetime ,
UpdatedAt datetime,
MethodId int foreign key references Method(Id),
UserId int foreign key references Users(Id),

)

insert into Reminder(Content,CreatedAt,MethodId,UserId) Values ('Oxu',GETDATE(),1,1)
insert into Reminder(Content,SendAt,MethodId,UserId) Values ('Oxudu',GETDATE(),1,2)
insert into Reminder(Content,UpdatedAt,MethodId,UserId) Values ('Yatdi',GETDATE(),2,2)



--1
Select users.id ,[Users].name , Method.Platforms ,REminder.Content, Reminder.CreatedAt ,Reminder.SendAt, Reminder.UpdatedAt,Reminder.UserId ,REminder.MethodId ,users.PhoneNumber
from Reminder
Left join [Users] 
on Reminder.Id = [Users].Id
 Left Join Method 
on Reminder.MethodId= Method.Id

--2
Select [Users].name ,REminder.Content,Reminder.CreatedAt ,Reminder.SendAt,Reminder.UpdatedAt
from Reminder
Left Join [Users] 
on Reminder.Id = [Users].Id

--3
Select users.id ,[Users].name , Method.Platforms ,REminder.Content, Reminder.CreatedAt ,Reminder.SendAt, Reminder.UpdatedAt
from Reminder
Join [Users] 
on Reminder.Id = [Users].Id
Join Method 
on Reminder.MethodId= Method.Id
Where Method.Platforms ='telegram'

Create function FormatPhoneNumber(@phoneNumber nvarchar(50))
Returns nvarchar (50)
as
Begin
Declare @FixedPhoneNumber as nvarchar(50) 
Select @FixedPhoneNumber = FORMAT( cast (@phoneNumber as numeric ),'+### (##) ###-##-##') Where LEN(@phoneNumber) >10
Select @FixedPhoneNumber = FORMAT( cast (@phoneNumber as numeric ),'+994 (##) ###-##-##') Where LEN(@phoneNumber) = 10
Return @FixedPhoneNumber
End

insert into Users Values('esed','ab','33',[dbo].FormatPhoneNumber('055 345 45 45'))

Select Users.PhoneNumber as PN From Users
select [dbo].FormatPhoneNumber('055 345 45 45')
