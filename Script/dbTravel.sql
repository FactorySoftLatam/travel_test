-- SQL Manager Lite for SQL Server 5.0.6.55900
-- ---------------------------------------
-- Host      : (local)
-- Database  : dbTravel
-- Version   : Microsoft SQL Server 2019 (RTM) 15.0.2000.5


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
  PRIMARY KEY CLUSTERED (id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
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

--
-- Definition for table Categoria :
--

CREATE TABLE dbo.Categoria (
  idCategoria int IDENTITY(1, 1) NOT NULL,
  descripcion varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  esActivo bit NULL,
  fechaRegistro datetime DEFAULT getdate() NULL,
  PRIMARY KEY CLUSTERED (idCategoria)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table Venta :
--

CREATE TABLE dbo.Venta (
  idVenta int IDENTITY(1, 1) NOT NULL,
  numeroDocumento varchar(40) COLLATE Modern_Spanish_CI_AS NULL,
  tipoPago varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  fechaRegistro datetime DEFAULT getdate() NULL,
  total decimal(10, 2) NULL,
  PRIMARY KEY CLUSTERED (idVenta)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table Producto :
--

CREATE TABLE dbo.Producto (
  idProducto int IDENTITY(1, 1) NOT NULL,
  nombre varchar(100) COLLATE Modern_Spanish_CI_AS NULL,
  idCategoria int NULL,
  stock int NULL,
  precio decimal(10, 2) NULL,
  esActivo bit NULL,
  fechaRegistro datetime DEFAULT getdate() NULL,
  PRIMARY KEY CLUSTERED (idProducto)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table DetalleVenta :
--

CREATE TABLE dbo.DetalleVenta (
  idDetalleVenta int IDENTITY(1, 1) NOT NULL,
  idVenta int NULL,
  idProducto int NULL,
  cantidad int NULL,
  precio decimal(10, 2) NULL,
  total decimal(10, 2) NULL,
  PRIMARY KEY CLUSTERED (idDetalleVenta)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table NumeroDocumento :
--

CREATE TABLE dbo.NumeroDocumento (
  idNumeroDocumento int IDENTITY(1, 1) NOT NULL,
  ultimo_Numero int NOT NULL,
  fechaRegistro datetime DEFAULT getdate() NULL,
  PRIMARY KEY CLUSTERED (idNumeroDocumento)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table Rol :
--

CREATE TABLE dbo.Rol (
  idRol int IDENTITY(1, 1) NOT NULL,
  descripcion varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  esActivo bit NULL,
  fechaRegistro datetime DEFAULT getdate() NULL,
  PRIMARY KEY CLUSTERED (idRol)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table Usuario :
--

CREATE TABLE dbo.Usuario (
  idUsuario int IDENTITY(1, 1) NOT NULL,
  nombreApellidos varchar(100) COLLATE Modern_Spanish_CI_AS NULL,
  correo varchar(40) COLLATE Modern_Spanish_CI_AS NULL,
  idRol int NULL,
  clave varchar(40) COLLATE Modern_Spanish_CI_AS NULL,
  esActivo bit NULL,
  PRIMARY KEY CLUSTERED (idUsuario)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
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
  (5, N'Miguel', N'De Cervantes')
GO

--
-- Data for table dbo.Categoria  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Categoria ON
GO

INSERT INTO dbo.Categoria (idCategoria, descripcion, esActivo, fechaRegistro)
VALUES
  (1, N'Laptops', 1, '20230128 14:36:31.953')
GO

INSERT INTO dbo.Categoria (idCategoria, descripcion, esActivo, fechaRegistro)
VALUES
  (2, N'Monitores', 1, '20230128 14:36:31.953')
GO

INSERT INTO dbo.Categoria (idCategoria, descripcion, esActivo, fechaRegistro)
VALUES
  (3, N'Teclados', 1, '20230128 14:36:31.953')
GO

INSERT INTO dbo.Categoria (idCategoria, descripcion, esActivo, fechaRegistro)
VALUES
  (4, N'Auriculares', 1, '20230128 14:36:31.953')
GO

INSERT INTO dbo.Categoria (idCategoria, descripcion, esActivo, fechaRegistro)
VALUES
  (5, N'Memorias', 1, '20230128 14:36:31.953')
GO

INSERT INTO dbo.Categoria (idCategoria, descripcion, esActivo, fechaRegistro)
VALUES
  (6, N'Accesorios', 1, '20230128 14:36:31.957')
GO

SET IDENTITY_INSERT dbo.Categoria OFF
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

--
-- Data for table dbo.libros  (LIMIT 0,500)
--

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (1, 1, N'Veinte mil leguas de viaje submarino', N'a-x', N'250')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (2, 2, N'La última', N'q', N'250')
GO

INSERT INTO dbo.libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas)
VALUES
  (3, 2, N'Cien años de soledad', N'1', N'300')
GO

--
-- Data for table dbo.NumeroDocumento  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.NumeroDocumento ON
GO

INSERT INTO dbo.NumeroDocumento (idNumeroDocumento, ultimo_Numero, fechaRegistro)
VALUES
  (1, 0, '20230128 14:36:32.637')
GO

SET IDENTITY_INSERT dbo.NumeroDocumento OFF
GO

--
-- Data for table dbo.Producto  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Producto ON
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (1, N'laptop samsung book pro', 1, 20, 2500, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (2, N'laptop lenovo idea pad', 1, 30, 2200, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (3, N'laptop asus zenbook duo', 1, 30, 2100, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (4, N'monitor teros gaming te-2', 2, 25, 1050, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (5, N'monitor samsung curvo', 2, 15, 1400, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (6, N'monitor huawei gamer', 2, 10, 1350, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (7, N'teclado seisen gamer', 3, 10, 800, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (8, N'teclado antryx gamer', 3, 10, 1000, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (9, N'teclado logitech', 3, 10, 1000, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (10, N'auricular logitech gamer', 4, 15, 800, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (11, N'auricular hyperx gamer', 4, 20, 680, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (12, N'auricular redragon rgb', 4, 25, 950, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (13, N'memoria kingston rgb', 5, 10, 200, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (14, N'ventilador cooler master', 6, 20, 200, 1, '20230128 14:36:32.310')
GO

INSERT INTO dbo.Producto (idProducto, nombre, idCategoria, stock, precio, esActivo, fechaRegistro)
VALUES
  (15, N'mini ventilador lenono', 6, 15, 200, 1, '20230128 14:36:32.310')
GO

SET IDENTITY_INSERT dbo.Producto OFF
GO

--
-- Data for table dbo.Rol  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Rol ON
GO

INSERT INTO dbo.Rol (idRol, descripcion, esActivo, fechaRegistro)
VALUES
  (1, N'Administrador', 1, '20230128 14:36:31.287')
GO

INSERT INTO dbo.Rol (idRol, descripcion, esActivo, fechaRegistro)
VALUES
  (2, N'Empleado', 1, '20230128 14:36:31.287')
GO

SET IDENTITY_INSERT dbo.Rol OFF
GO

--
-- Data for table dbo.Usuario  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Usuario ON
GO

INSERT INTO dbo.Usuario (idUsuario, nombreApellidos, correo, idRol, clave, esActivo)
VALUES
  (1, N'jose smith', N'admin@example.com', 1, N'12345', 1)
GO

INSERT INTO dbo.Usuario (idUsuario, nombreApellidos, correo, idRol, clave, esActivo)
VALUES
  (2, N'luis smith', N'employe@example.com', 2, N'12345', 1)
GO

SET IDENTITY_INSERT dbo.Usuario OFF
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
ADD CONSTRAINT autores_has_libros_fk FOREIGN KEY (autores_id)
  REFERENCES dbo.autores (id)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.autores_has_libros
ADD CONSTRAINT autores_has_libros_fk2 FOREIGN KEY (libros_ISBN)
  REFERENCES dbo.libros (ISBN)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.Producto
ADD FOREIGN KEY (idCategoria)
  REFERENCES dbo.Categoria (idCategoria)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.DetalleVenta
ADD FOREIGN KEY (idProducto)
  REFERENCES dbo.Producto (idProducto)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.DetalleVenta
ADD FOREIGN KEY (idVenta)
  REFERENCES dbo.Venta (idVenta)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.Usuario
ADD FOREIGN KEY (idRol)
  REFERENCES dbo.Rol (idRol)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

