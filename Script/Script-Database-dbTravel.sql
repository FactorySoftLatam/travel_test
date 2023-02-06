/*CREATE DATABASE dbTravel
ON PRIMARY
  ( NAME = dbTravel,
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbTravel.mdf',
    SIZE = 8 MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 64 MB )
LOG ON
  ( NAME = dbTravel_log,
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbTravel_log.ldf',
    SIZE = 8 MB,
    MAXSIZE = 2097152 MB,
    FILEGROWTH = 64 MB )
COLLATE Modern_Spanish_CI_AS
GO*/

Use dbTravel;

DROP TABLE if exists dbo.autores_has_libros GO

DROP TABLE  if exists dbo.libros GO

DROP TABLE  if exists dbo.autores GO

DROP TABLE  if exists dbo.editoriales GO


Create Table autores (
id int primary key,
nombre varchar(45) not null,
apellidos varchar(45) not null
);


Create Table editoriales (
id int primary key,
nombre varchar(45) not null,
sede varchar(45) not null
);

Create Table libros (
ISBN int primary key,
editoriales_id int,
titulo varchar(45) not null,
sinopsis text,
n_paginas varchar(45),
CONSTRAINT editoriales_libros_fk FOREIGN KEY (editoriales_id)
REFERENCES dbo.editoriales (id)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
);

CREATE TABLE dbo.autores_has_libros (
  autores_id int NOT NULL,
  libros_ISBN int NOT NULL,
  CONSTRAINT autores_has_libros_pk PRIMARY KEY CLUSTERED (autores_id, libros_ISBN),
  CONSTRAINT autores_has_libros_fk FOREIGN KEY (autores_id)
  REFERENCES dbo.autores (id)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION,
  CONSTRAINT autores_has_libros_fk2 FOREIGN KEY (libros_ISBN)
  REFERENCES dbo.libros (ISBN)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
);

