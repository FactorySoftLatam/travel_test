-- SQL Manager Lite for SQL Server 5.0.6.55900
-- ---------------------------------------
-- Host      : (local)
-- Database  : dbTravelLIB
-- Version   : Microsoft SQL Server 2019 (RTM) 15.0.2000.5


CREATE DATABASE dbTravelLIB
ON PRIMARY
  ( NAME = dbTarvelLIB,
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbTarvelLIB.mdf',
    SIZE = 8 MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 64 MB )
LOG ON
  ( NAME = dbTarvelLIB_log,
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbTarvelLIB_log.ldf',
    SIZE = 8 MB,
    MAXSIZE = 2097152 MB,
    FILEGROWTH = 64 MB )
COLLATE Modern_Spanish_CI_AS
GO

USE dbTravelLIB
GO

--
-- Definition for table __EFMigrationsHistory :
--

CREATE TABLE dbo.__EFMigrationsHistory (
  MigrationId nvarchar(150) COLLATE Modern_Spanish_CI_AS NOT NULL,
  ProductVersion nvarchar(32) COLLATE Modern_Spanish_CI_AS NOT NULL,
  CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY CLUSTERED (MigrationId)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table AspNetRoles :
--

CREATE TABLE dbo.AspNetRoles (
  Id nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Name nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
  NormalizedName nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
  ConcurrencyStamp nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  CONSTRAINT PK_AspNetRoles PRIMARY KEY CLUSTERED (Id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table AspNetRoleClaims :
--

CREATE TABLE dbo.AspNetRoleClaims (
  Id int IDENTITY(1, 1) NOT NULL,
  RoleId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
  ClaimType nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  ClaimValue nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY CLUSTERED (Id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table AspNetUsers :
--

CREATE TABLE dbo.AspNetUsers (
  Id nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
  UserName nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
  NormalizedUserName nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
  Email nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
  NormalizedEmail nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
  EmailConfirmed bit NOT NULL,
  PasswordHash nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  SecurityStamp nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  ConcurrencyStamp nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  PhoneNumber nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  PhoneNumberConfirmed bit NOT NULL,
  TwoFactorEnabled bit NOT NULL,
  LockoutEnd datetimeoffset(0) NULL,
  LockoutEnabled bit NOT NULL,
  AccessFailedCount int NOT NULL,
  CONSTRAINT PK_AspNetUsers PRIMARY KEY CLUSTERED (Id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table AspNetUserClaims :
--

CREATE TABLE dbo.AspNetUserClaims (
  Id int IDENTITY(1, 1) NOT NULL,
  UserId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
  ClaimType nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  ClaimValue nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  CONSTRAINT PK_AspNetUserClaims PRIMARY KEY CLUSTERED (Id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table AspNetUserLogins :
--

CREATE TABLE dbo.AspNetUserLogins (
  LoginProvider nvarchar(128) COLLATE Modern_Spanish_CI_AS NOT NULL,
  ProviderKey nvarchar(128) COLLATE Modern_Spanish_CI_AS NOT NULL,
  ProviderDisplayName nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  UserId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
  CONSTRAINT PK_AspNetUserLogins PRIMARY KEY CLUSTERED (LoginProvider, ProviderKey)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table AspNetUserRoles :
--

CREATE TABLE dbo.AspNetUserRoles (
  UserId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
  RoleId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
  CONSTRAINT PK_AspNetUserRoles PRIMARY KEY CLUSTERED (UserId, RoleId)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table AspNetUserTokens :
--

CREATE TABLE dbo.AspNetUserTokens (
  UserId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
  LoginProvider nvarchar(128) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Name nvarchar(128) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Value nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  CONSTRAINT PK_AspNetUserTokens PRIMARY KEY CLUSTERED (UserId, LoginProvider, Name)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table autores :
--

CREATE TABLE dbo.autores (
  id int NOT NULL,
  nombre varchar(45) COLLATE Modern_Spanish_CI_AS NOT NULL,
  apellidos varchar(45) COLLATE Modern_Spanish_CI_AS NOT NULL,
  autor AS ([nombre]+' ')+[apellidos] PERSISTED,
  PRIMARY KEY CLUSTERED (id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

EXEC sp_addextendedproperty 'MS_Description', N'Autores ', N'schema', N'dbo', N'table', N'autores'
GO

EXEC sp_addextendedproperty 'MS_Description', N'ID', N'schema', N'dbo', N'table', N'autores', N'column', N'id'
GO

EXEC sp_addextendedproperty 'MS_Description', N'Nombre(s) del autor', N'schema', N'dbo', N'table', N'autores', N'column', N'nombre'
GO

EXEC sp_addextendedproperty 'MS_Description', N'Apellido(s) del autor', N'schema', N'dbo', N'table', N'autores', N'column', N'apellidos'
GO

EXEC sp_addextendedproperty 'MS_Description', N'Nombre y Apellidos Autor (Calculado)', N'schema', N'dbo', N'table', N'autores', N'column', N'autor'
GO

--
-- Definition for table editoriales :
--

CREATE TABLE dbo.editoriales (
  id int NOT NULL,
  nombre varchar(45) COLLATE Modern_Spanish_CI_AS NOT NULL,
  sede varchar(45) COLLATE Modern_Spanish_CI_AS NOT NULL,
  PRIMARY KEY CLUSTERED (id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

EXEC sp_addextendedproperty 'MS_Description', N'Editoriales', N'schema', N'dbo', N'table', N'editoriales'
GO

EXEC sp_addextendedproperty 'MS_Description', N'ID', N'schema', N'dbo', N'table', N'editoriales', N'column', N'id'
GO

EXEC sp_addextendedproperty 'MS_Description', N'Nombre de la Editorial', N'schema', N'dbo', N'table', N'editoriales', N'column', N'nombre'
GO

EXEC sp_addextendedproperty 'MS_Description', N'Sede de la Editorial', N'schema', N'dbo', N'table', N'editoriales', N'column', N'sede'
GO

--
-- Definition for table libros :
--

CREATE TABLE dbo.libros (
  ISBN int NOT NULL,
  editoriales_id int NULL,
  titulo varchar(45) COLLATE Modern_Spanish_CI_AS NOT NULL,
  sinopsis text COLLATE Modern_Spanish_CI_AS NULL,
  n_paginas varchar(45) COLLATE Modern_Spanish_CI_AS NULL,
  PRIMARY KEY CLUSTERED (ISBN)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

EXEC sp_addextendedproperty 'MS_Description', N'Libros', N'schema', N'dbo', N'table', N'libros'
GO

EXEC sp_addextendedproperty 'MS_Description', N'ISBN Libro ', N'schema', N'dbo', N'table', N'libros', N'column', N'ISBN'
GO

EXEC sp_addextendedproperty 'MS_Description', N'ID Editorial', N'schema', N'dbo', N'table', N'libros', N'column', N'editoriales_id'
GO

EXEC sp_addextendedproperty 'MS_Description', N'Título del Libro', N'schema', N'dbo', N'table', N'libros', N'column', N'titulo'
GO

EXEC sp_addextendedproperty 'MS_Description', N'Resumen Libro', N'schema', N'dbo', N'table', N'libros', N'column', N'sinopsis'
GO

EXEC sp_addextendedproperty 'MS_Description', N'Número de páginas', N'schema', N'dbo', N'table', N'libros', N'column', N'n_paginas'
GO

--
-- Definition for table autores_has_libros :
--

CREATE TABLE dbo.autores_has_libros (
  autores_id int NOT NULL,
  libros_ISBN int NOT NULL,
  CONSTRAINT autores_has_libros_pk PRIMARY KEY CLUSTERED (autores_id, libros_ISBN)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

EXEC sp_addextendedproperty 'MS_Description', N'Libros por Autor', N'schema', N'dbo', N'table', N'autores_has_libros'
GO

EXEC sp_addextendedproperty 'MS_Description', N'ID del autor', N'schema', N'dbo', N'table', N'autores_has_libros', N'column', N'autores_id'
GO

EXEC sp_addextendedproperty 'MS_Description', N'ISBN del libro', N'schema', N'dbo', N'table', N'autores_has_libros', N'column', N'libros_ISBN'
GO

--
-- Data for table dbo.__EFMigrationsHistory  (LIMIT 0,500)
--

INSERT INTO dbo.__EFMigrationsHistory (MigrationId, ProductVersion)
VALUES
  (N'00000000000000_CreateIdentitySchema', N'5.0.4')
GO

INSERT INTO dbo.__EFMigrationsHistory (MigrationId, ProductVersion)
VALUES
  (N'20230128194154_Initialize', N'5.0.4')
GO

--
-- Data for table dbo.AspNetRoles  (LIMIT 0,500)
--

INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
VALUES
  (N'2c92ec7d-5102-4ab6-92e1-f24635afb9eb', N'Bibliotecario', N'BIBLIOTECARIO', N'c35ebea3-ce56-43b9-8f4c-dbe0892e2f9d')
GO

INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
VALUES
  (N'60690843-05ad-4e26-824d-ebfe1bf9b13f', N'Administrador', N'ADMINISTRADOR', N'cc433ee5-47a4-4e15-b3cd-5732becfeea5')
GO

--
-- Data for table dbo.AspNetUsers  (LIMIT 0,500)
--

INSERT INTO dbo.AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES
  (N'01b1b2ba-2e52-4e02-88c7-15135fdb35fd', N'pjpamell@gmail.com', N'PJPAMELL@GMAIL.COM', N'pjpamell@gmail.com', N'PJPAMELL@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHO9PtBDSrXkhETX1Nvdbs4heZDYHHN9x9nFlnYKiPPdDmH9xs+66XbCI/WwDS3qxQ==', N'V5C7YY2KPAJGWB6NMXSYKTMQMPAA7J6Z', N'd2a6bfc1-961c-4014-ae70-98b18e135383', NULL, 0, 0, NULL, 1, 0)
GO

--
-- Data for table dbo.autores  (LIMIT 0,500)
--

INSERT INTO dbo.autores (id, nombre, apellidos)
VALUES
  (1, N'Gabriel', N'García Márquez')
GO

INSERT INTO dbo.autores (id, nombre, apellidos)
VALUES
  (2, N'Julio', N'Verne')
GO

INSERT INTO dbo.autores (id, nombre, apellidos)
VALUES
  (3, N'Julio', N'Cortázar')
GO

INSERT INTO dbo.autores (id, nombre, apellidos)
VALUES
  (4, N'Fiódor', N'Dostoyevsky')
GO

INSERT INTO dbo.autores (id, nombre, apellidos)
VALUES
  (5, N'Miguel', N'De Cervantes Saavedra')
GO

INSERT INTO dbo.autores (id, nombre, apellidos)
VALUES
  (6, N'Juan Ramón', N'Jiménez')
GO

INSERT INTO dbo.autores (id, nombre, apellidos)
VALUES
  (7, N'José Lucho', N'Martí')
GO

--
-- Data for table dbo.autores_has_libros  (LIMIT 0,500)
--

INSERT INTO dbo.autores_has_libros (autores_id, libros_ISBN)
VALUES
  (1, 3)
GO

INSERT INTO dbo.autores_has_libros (autores_id, libros_ISBN)
VALUES
  (2, 4)
GO

INSERT INTO dbo.autores_has_libros (autores_id, libros_ISBN)
VALUES
  (3, 1)
GO

--
-- Data for table dbo.editoriales  (LIMIT 0,500)
--

INSERT INTO dbo.editoriales (id, nombre, sede)
VALUES
  (1, N'Apidama Ediciones', N'Colombia')
GO

INSERT INTO dbo.editoriales (id, nombre, sede)
VALUES
  (2, N'Cajón de Sastre', N'Colombia')
GO

INSERT INTO dbo.editoriales (id, nombre, sede)
VALUES
  (3, N'Caín Press', N'Colombia')
GO

INSERT INTO dbo.editoriales (id, nombre, sede)
VALUES
  (4, N'Continente Editores', N'Colombia')
GO

INSERT INTO dbo.editoriales (id, nombre, sede)
VALUES
  (5, N'Ediciones Gamma', N'Colombia')
GO

INSERT INTO dbo.editoriales (id, nombre, sede)
VALUES
  (6, N'Editorial Cien Mil', N'Colombia')
GO

--
-- Data for table dbo.libros  (LIMIT 0,500)
--

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (1, 1, N'Veinte mil leguas de viaje submarino', N'Resumen Veinte mil leguas de viaje submarino', N'250')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (2, 2, N'La otra orilla', N'La otra orilla Resumen', N'250')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (3, 2, N'Cien años de soledad', N'Resumen Cien años de soledad', N'300')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (4, 2, N'Cinco semanas en globo', N'Resumen Cinco semanas en globo', N'242')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (5, 4, N'La isla misteriosa', N'Resumen La isla misteriosa', N'500')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (6, 3, N'La vuelta al mundo en ochenta días', N'Resumen La vuelta al mundo en ochenta días', N'165')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (7, 2, N'Alrededor de la Luna', N'Alrededor de la Luna', N'165')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (8, 4, N'Viaje al centro de la Tierra', N'Viaje al centro de la Tierra', N'200')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (9, 3, N'Veinte mil lenguas de viaje submarino', N'Veinte mil lenguas de viaje submarino', N'300')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (10, 1, N'Los hijos del capitán Grant', N'Los hijos del capitán Grant', N'300')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (11, 1, N'Crónicas de una muerte anunciada', N'Crónicas de una muerte anunciada', N'200')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (12, 1, N'Rayuela', N'Rayuela', N'300')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (13, 2, N' La otra orilla', N' La otra orilla', N'120')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (14, 1, N'Manifiesto de Montecristi', N'Manifiesto de Montecristi', N'200')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (15, 5, N'Ismaelillo', N'Ismaelillo', N'200')
GO

--
-- Definition for indices :
--

CREATE UNIQUE NONCLUSTERED INDEX RoleNameIndex ON dbo.AspNetRoles
  (NormalizedName)
WHERE ([NormalizedName] IS NOT NULL)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_AspNetRoleClaims_RoleId ON dbo.AspNetRoleClaims
  (RoleId)
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX EmailIndex ON dbo.AspNetUsers
  (NormalizedEmail)
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX UserNameIndex ON dbo.AspNetUsers
  (NormalizedUserName)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_AspNetUserClaims_UserId ON dbo.AspNetUserClaims
  (UserId)
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_AspNetUserLogins_UserId ON dbo.AspNetUserLogins
  (UserId)
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_AspNetUserRoles_RoleId ON dbo.AspNetUserRoles
  (RoleId)
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

--
-- Definition for foreign keys :
--

ALTER TABLE dbo.AspNetRoleClaims
ADD CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId)
  REFERENCES dbo.AspNetRoles (Id)
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE dbo.AspNetUserClaims
ADD CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId)
  REFERENCES dbo.AspNetUsers (Id)
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE dbo.AspNetUserLogins
ADD CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId)
  REFERENCES dbo.AspNetUsers (Id)
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE dbo.AspNetUserRoles
ADD CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId)
  REFERENCES dbo.AspNetRoles (Id)
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE dbo.AspNetUserRoles
ADD CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId)
  REFERENCES dbo.AspNetUsers (Id)
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE dbo.AspNetUserTokens
ADD CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId)
  REFERENCES dbo.AspNetUsers (Id)
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE dbo.libros
ADD CONSTRAINT editoriales_libros_fk FOREIGN KEY (editoriales_id)
  REFERENCES dbo.editoriales (id)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.autores_has_libros
WITH NOCHECK ADD CONSTRAINT autores_has_libros_fk FOREIGN KEY (autores_id)
  REFERENCES dbo.autores (id)
  ON UPDATE CASCADE
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.autores_has_libros
NOCHECK CONSTRAINT autores_has_libros_fk
GO

ALTER TABLE dbo.autores_has_libros
WITH NOCHECK ADD CONSTRAINT autores_has_libros_fk2 FOREIGN KEY (libros_ISBN)
  REFERENCES dbo.libros (ISBN)
  ON UPDATE CASCADE
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.autores_has_libros
NOCHECK CONSTRAINT autores_has_libros_fk2
GO

