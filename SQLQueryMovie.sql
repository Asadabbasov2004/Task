Create Database Moviesuse MoviesCREATE TABLE Directors (    Id INT PRIMARY KEY IDENTITY,    Name NVARCHAR(55) NOT NULL,    Surname NVARCHAR(55) NOT NULL,    Age INT CHECK (Age >= 18))insert into Directors(Name, Surname, Age) values('Asad','Abbasov',20),('Ceyhun','Agayev',19),('Rasim','Anarov', 60)CREATE TABLE Genres (    Id INT PRIMARY KEY IDENTITY,    Name NVARCHAR(55) NOT NULL);insert into Genres(Name) values('Science Fiction'),('Dram'),('Thriller ')CREATE TABLE Movies (    Id INT PRIMARY KEY IDENTITY,    [Name] NVARCHAR(25) NOT NULL,    Rate FLOAT CHECK (Rate >= 0 AND Rate <= 10),    DirectorId INT FOREIGN KEY  REFERENCES Directors(Id),    GenreId INT FOREIGN KEY  REFERENCES Genres(Id))insert into Movies(Name,Rate,DirectorId,GenreId) values('Movie 1' , 5 ,1 ,2),('Movie 2',7,2,1),('Movie 3',9,3,3),('Movie 4',10,2,2),('Movie 5',8,1,1)CREATE TABLE Actors (    Id INT PRIMARY KEY IDENTITY,    Name NVARCHAR(55) NOT NULL,    Surname NVARCHAR(55) NOT NULL,    Age INT CHECK (Age >= 18))insert into Actors(Name,Surname,Age) values('Abbas','Bagirov',46),('Ilkin','Abbasov',31),('Cahangir','Qasimov',21),('Behruz','eliyev',23)CREATE TABLE MovieActors (    MovieId INT FOREIGN KEY REFERENCES Movies(Id),    ActorId INT FOREIGN KEY REFERENCES Actors(Id),)insert into MovieActors values(1,1),(1,2),(1,4),(2,2),(2,3),(2,4),(3,3),(3,4)--1) - Rate deyeri 8den yuxari olan kinolari ekrana cixaran query,SELECT m.Name ,m.RateFROM Movies mwhere m.Rate>8;--2) - Kinonun adini ve Rate deyerlerini ekrana cixaran query,SELECT m.[Name], m.Rate FROM Movies m--3) - Yasi 40dan yuxari olan Aktyorlarin ve Rejissorlarin fullname, ageSELECT CONCAT(Name, ' ', Surname) AS FullName, AgeFROM ActorsWHERE Age > 40UNIONSELECT CONCAT(Name, ' ', Surname) AS FullName, AgeFROM DirectorsWHERE Age > 40;--4) - Kinonun adini, Rate deyerini ve Rejissorunun fullname deyerlerini  ekrana yazan bir View yaradin, sonra bu view-nu cagirib select edinCREATE view MovieDetails AS(
SELECT M.Name AS MovieName, M.Rate, CONCAT(D.Name, ' ', D.Surname) AS DirectorFullName
FROM Movies AS M
INNER JOIN Directors AS D ON M.DirectorId = D.Id)

SELECT * FROM MovieDetails;

--5) - Rejissorun adi, soyadi ve nece dene kinosu oldugunu ekrana cixaran query,
SELECT D.Name, D.Surname, 
COUNT(M.Id) AS NumberOfMoviesDirected FROM Directors AS D 
LEFT JOIN Movies M ON D.Id = M.DirectorId
GROUP BY D.Name, D.Surname;

--6) - Kino adi, Rate, Rejissorunun fullname ve aktyorlarin fullname deyerlerini ekrana cixaran view yaradib daha sonra select edin

CREATE View MovieDetailsWithActors AS
SELECT M.Name AS MovieName, M.Rate, CONCAT(D.Name, ' ', D.Surname) AS DirectorFullName, CONCAT(A.Name, ' ', A.Surname) AS ActorFullName
FROM Movies AS M
INNER JOIN Directors AS D ON M.DirectorId = D.Id
INNER JOIN MovieActors AS MA ON M.Id = MA.MovieId
INNER JOIN Actors AS A ON MA.ActorId = A.Id;

SELECT * FROM MovieDetailsWithActors;


--7) - Actor fullname, Rol aldigi kino,Kinonun janri, Kinonun rejissorunun fullname, Kino rate deyerlerini ekrana cixaran query
SELECT CONCAT(A.Name, ' ', A.Surname) AS ActorFullName, M.Name AS MovieName, G.Name AS Genre, CONCAT(D.Name, ' ', D.Surname) AS DirectorFullName, M.Rate
FROM Actors A
INNER JOIN MovieActors MA ON A.Id = MA.ActorId
INNER JOIN Movies M ON MA.MovieId = M.Id
INNER JOIN Genres G ON M.GenreId = G.Id
INNER JOIN Directors D ON M.DirectorId = D.Id;