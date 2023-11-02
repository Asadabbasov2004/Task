create database bookgeneries
use bookgeneries
Create table Books(
BooksId int primary key identity,
BooksName nvarchar(20) not null,
Colour nvarchar(20) not null,
[Year] nvarchar (4) not null,
Author nvarchar(40) not null,

)
create table Genre(
GenreId int primary key identity,
GenreName nvarchar(20) not null,
BooksId int foreign key references Books(BooksId)
)

create table Languages(
LanguagesId int primary key identity,
LanguagesName nvarchar(30) not null,
BooksId int foreign key references Books (BooksId)
)

insert into Books(BooksName,Colour,[Year],Author)
Values('AliNino','black',1920,'Kamil'),
	  ('Ali','WHITE',1420,'Kamil1'),
	  ('Nino','green',1820,'Kamil2')

insert into Genre(GenreName,BooksId)
Values('dram',2),('qorxu',3),('sevinc',2)


insert into Genre(GenreName,BooksId)
Values('dram',1),('qorxu',1),('sevinc',3)


insert into Languages(LanguagesName,BooksId)
Values('az',1),('eng',1),('ru',2),('ru',3)

--4
Select Books.BooksName ,Genre.GenreName
from  Genre
join Books
On  Books.BooksId =Genre.BooksId


--5
Select Books.BooksName ,Languages.LanguagesName
from  Languages
join Books
On  Books.BooksId =Languages.BooksId

--6
Select Books.BooksName ,Genre.GenreName ,Languages.LanguagesName
from  Genre
join Books
On  Books.BooksId =Genre.BooksId
join Languages
On Books.BooksId = Languages.BooksId

--7
Select Books.BooksId,Books.BooksName ,Genre.GenreName
from  Genre
join Books
On  Books.BooksId =Genre.BooksId
ORDER BY Books.BooksId;

--8
Select Books.BooksId , Books.BooksName ,Languages.LanguagesName
from  Languages
join Books
On  Books.BooksId =Languages.BooksId
ORDER BY Books.BooksId;
