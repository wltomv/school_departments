USE [master]

CREATE DATABASE [School_departments]
GO

USE [School_departments]
GO

CREATE SCHEMA dept AUTHORIZATION dbo;
GO


CREATE TABLE dept.department(
	id INT PRIMARY KEY IDENTITY (1,1),
	nombre VARCHAR (150) NOT NULL,
	descripction VARCHAR(300) NOT NULL
)


CREATE TABLE dept.professor(
	id INT PRIMARY KEY IDENTITY(1,1),
	name VARCHAR(150) NOT NULL,
	address VARCHAR(200) NOT NULL,
	telephone VARCHAR(15) NOT NULL,
	dept_id INT  NOT NULL
	FOREIGN KEY (dept_id) REFERENCES dept.department (id)
)

CREATE TABLE dept.course(
	id INT PRIMARY KEY IDENTITY(1,1),
	name VARCHAR(30) NOT NULL,
	level INT NOT NULL,
	description VARCHAR(300) NOT NULL,
	prof_id INT NOT NULL,
	FOREIGN KEY (prof_id) REFERENCES dept.professor (id)
)
