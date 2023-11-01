CREATE DATABASE BB205
USE BB205
CREATE TABLE STUDENTS(
[NAME] NVARCHAR(30) NOT NULL,
[SURNAME] NVARCHAR(40) DEFAULT 'XXX',
AGE INT CHECK(AGE>16) ,
AVGPOINT INT CHECK(AVGPOINT >0 AND AVGPOINT < 100),
)

INSERT INTO STUDENTS([NAME] ,AGE,AVGPOINT)
VALUES ('ASAD',17,85)

INSERT INTO STUDENTS([NAME] ,[SURNAME],AGE,AVGPOINT)
VALUES ('ASAD2','ABBASOV',20,55);


INSERT INTO STUDENTS([NAME] ,AGE,AVGPOINT)
VALUES ('Azer',24,29)

INSERT INTO STUDENTS([NAME] ,AGE,AVGPOINT)
VALUES ('An',24,99)

INSERT INTO STUDENTS([NAME],[SURNAME] ,AGE,AVGPOINT)
VALUES ('Zamin','Asan',24,95)

SELECT * FROM STUDENTS
--1. Ortalaması 51dən yuxarı olan tələbələri göstərsin

SELECT *
FROM STUDENTS
WHERE AVGPOINT >51

--2. Ortalaması 51dən böyük, 90dan az olan tələbələri göstərsin. 

SELECT *
FROM STUDENTS
WHERE AVGPOINT >51 AND AVGPOINT<90

--3. A ilə başlayıb n ilə bitən tələbələri göstərsin.

SELECT [NAME] ,[SURNAME]
FROM STUDENTS
WHERE ([NAME] LIKE 'A%n' OR [SURNAME] LIKE 'A%n')

--4.Ortalaması 51dən kicik ve yashi 20-den boyuk olan tələbələri göstərsin
SELECT *
FROM STUDENTS
WHERE (AVGPOINT <51 AND AGE>20)



---  TASK-2
CREATE DATABASE DEPARTMENT 
USE DEPARTMENT
CREATE TABLE EMPLOYEES(
 Id INT IDENTITY(1,1) PRIMARY KEY,
 [NAME] NVARCHAR(30) CHECK (LEN([NAME]) >= 3),
 [SURNAME] NVARCHAR(30) CHECK (LEN([SURNAME]) >2),
 SALARY INT CHECK(SALARY>=200),
  Degree NVARCHAR(10) CHECK (Degree IN ('junior', 'middle', 'senior')) ,

)

SELECT * FROM EMPLOYEES

INSERT INTO EMPLOYEES ([NAME], [SURNAME], SALARY, Degree)
VALUES ('ASAD', 'ABBASOV', 2050, 'senior');

INSERT INTO EMPLOYEES ([NAME], [SURNAME], SALARY, Degree)
VALUES ('MALEYKE', 'HUMBETOVA', 1550, 'middle');

INSERT INTO EMPLOYEES ([NAME], [SURNAME], SALARY, Degree)
VALUES ('CEYHUN', 'ANAROV', 350, 'junior');

INSERT INTO EMPLOYEES ([NAME], [SURNAME], SALARY, Degree)
VALUES ('EMIL', 'BABAYEV', 1350, 'middle');

--1 - Maasi 400-den asagi olan iscileri gosteren query,

SELECT *
FROM EMPLOYEES
WHERE SALARY<400

--2 - Butun iscilerin Name ve Surname deyerlerini Fullname adi ile gosteren query,
SELECT [NAME] + ' ' + [SURNAME] AS FULLNAME
FROM EMPLOYEES;

--3 - Iscileri Id, Fullname ve Salary deyerlerine gore gosteren query
SELECT Id , [NAME] + ' ' + [SURNAME] AS FULLNAME ,SALARY 
FROM EMPLOYEES;

--4 - Derecesi junior olan iscileri gosteren query,
SELECT*
FROM EMPLOYEES
WHERE Degree = 'junior'

--5 - En yuksek maas alan iscini gosteren query,
SELECT TOP 1 *
FROM EMPLOYEES
ORDER BY SALARY DESC;

--6 - En az maas alan iscini gosteren query,
SELECT TOP 1 *
FROM EMPLOYEES
ORDER BY SALARY ASC;

--7 - Ortalama maasi (Ortamala Maas adi ile) gosteren query,
SELECT AVG(SALARY) AS AVERAGESALARY 
FROM EMPLOYEES

--8 Maasi ortalama maasdan cox olan iscileri gosteren query,
SELECT * ,(SELECT AVG(Salary) FROM EMPLOYEES) AS "AVERAGE SALARY"
FROM EMPLOYEES
WHERE Salary > (SELECT AVG(Salary) FROM EMPLOYEES); 

--9 - Soyadi "ov" ve ya "ova" ile biten iscileri gosteren query
SELECT *
FROM EMPLOYEES
WHERE ([SURNAME] LIKE '%ov') OR ([SURNAME] LIKE '%ova')