Create Database Movies
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