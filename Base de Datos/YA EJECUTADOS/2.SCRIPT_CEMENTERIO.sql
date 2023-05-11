USE MASTER
GO

--DROP DATABASE db_a74b52_cementerio
--GO

--CREATE DATABASE db_a74b52_cementerio
--GO

USE db_a74b52_cementerio
GO

CREATE TABLE TA_CEMENTERIO(
CEMN_IDCEMENTERIO INT IDENTITY PRIMARY KEY,
CEMS_NOMBRES VARCHAR(200),
CEMS_USUREGISTRO VARCHAR(15),
CEMD_FECREGISTRO DATETIME DEFAULT GETDATE(),
CEMS_USUMODIFICA VARCHAR(15),
CEMD_FECMODIFICA DATETIME,
CEMB_ESTADO BIT DEFAULT 1)
GO

CREATE TABLE TA_COLABORADOR(
COLN_IDCOLABORADOR INT IDENTITY PRIMARY KEY,
COLN_IDCEMENTERIO INT,
COLS_NOMBRES VARCHAR(100),
COLS_APEPATERNO VARCHAR(50),
COLS_APEMATERNO VARCHAR(50),
COLS_CORREO VARCHAR(200),
COLS_USUREGISTRO VARCHAR(15),
COLD_FECREGISTRO DATETIME DEFAULT GETDATE(),
COLS_USUMODIFICA VARCHAR(15),
COLD_FECMODIFICA DATETIME,
COLB_ESTADO BIT DEFAULT 1)
GO

ALTER TABLE TA_COLABORADOR ADD CONSTRAINT FK_COLABORADOR_CEMENTERIO FOREIGN KEY (COLN_IDCEMENTERIO) REFERENCES TA_CEMENTERIO (CEMN_IDCEMENTERIO)
GO

CREATE TABLE TA_LOGIN(
LOGN_IDLOGIN INT IDENTITY PRIMARY KEY,
LOGN_IDCOLABORADOR INT,
LOGS_USUARIO VARCHAR(450),
LOGS_CLAVE VARCHAR(MAX),
LOGS_USUREGISTRO VARCHAR(15),
LOGD_FECREGISTRO DATETIME DEFAULT GETDATE(),
LOGS_USUMODIFICA VARCHAR(15),
LOGD_FECMODIFICA DATETIME,
LOGB_ESTADO BIT DEFAULT 1)
GO

ALTER TABLE TA_LOGIN ADD CONSTRAINT FK_LOGIN_COLABORADOR FOREIGN KEY (LOGN_IDCOLABORADOR) REFERENCES TA_COLABORADOR (COLN_IDCOLABORADOR)
GO
ALTER TABLE TA_LOGIN ADD CONSTRAINT UQ_USUARIO UNIQUE (LOGS_USUARIO)
GO

CREATE TABLE TA_PABELLON(
PABN_IDPABELLON INT IDENTITY PRIMARY KEY,
PABN_IDCEMENTERIO INT,
PABS_NOMBRE VARCHAR(100),
PABS_TIPO INT,
PABS_UBICACION VARCHAR(MAX),
PABS_USUREGISTRO VARCHAR(15),
PABD_FECREGISTRO DATETIME DEFAULT GETDATE(),
PABS_USUMODIFICA VARCHAR(15),
PABD_FECMODIFICA DATETIME,
PABB_ESTADO BIT DEFAULT 1,
PABB_ESTADOBAJA VARCHAR(MAX))
GO

ALTER TABLE TA_PABELLON ADD CONSTRAINT FK_PABELLON_CEMENTERIO FOREIGN KEY (PABN_IDCEMENTERIO) REFERENCES TA_CEMENTERIO (CEMN_IDCEMENTERIO)
GO

CREATE TABLE TA_NICHO(
NICN_IDNICHO INT IDENTITY PRIMARY KEY,
NICS_CODNICHO VARCHAR(15),
NICB_ESTADONICHO INT DEFAULT 1,
NICB_NUMDIFTOTAL INT,
NICB_NUMDIFACTUAL INT,
NICN_IDPABELLON INT,
NICS_USUREGISTRO VARCHAR(15),
NICD_FECREGISTRO DATETIME DEFAULT GETDATE(),
NICS_USUMODIFICA VARCHAR(15),
NICD_FECMODIFICA DATETIME,
NICB_ESTADO BIT DEFAULT 1)
GO

ALTER TABLE TA_NICHO ADD CONSTRAINT FK_NICHO_PABELLON FOREIGN KEY (NICN_IDPABELLON) REFERENCES TA_PABELLON (PABN_IDPABELLON)
GO

CREATE TABLE TA_DIFUNTO(
DIFN_IDDIFUNTO INT IDENTITY PRIMARY KEY,
DIFS_DNI VARCHAR(15),
DIFN_IDCEMENTERIO INT,
DIFS_NOMBRES VARCHAR(100),
DIFS_APEPATERNO VARCHAR(100),
DIFS_APEMATERNO VARCHAR(100),
DIFD_FECHADEFUNCION DATETIME,
DIFS_USUREGISTRO VARCHAR(15),
DIFD_FECREGISTRO DATETIME DEFAULT GETDATE(),
DIFS_USUMODIFICA VARCHAR(15),
DIFD_FECMODIFICA DATETIME,
DIFB_ESTADO BIT DEFAULT 1)

ALTER TABLE TA_DIFUNTO ADD CONSTRAINT FK_DIFUNTO_CEMENTERIO FOREIGN KEY (DIFN_IDCEMENTERIO) REFERENCES TA_CEMENTERIO (CEMN_IDCEMENTERIO)
GO
ALTER TABLE TA_DIFUNTO ADD CONSTRAINT UQ_DNI UNIQUE (DIFS_DNI)
GO

CREATE TABLE TA_NICHO_DIFUNTO(
NICDIFN_IDNICHODIFUNTO INT IDENTITY PRIMARY KEY,
NICDIFN_IDNICHO INT,
NICDIFN_IDDIFUNTO INT,
NICDIFS_USUREGISTRO VARCHAR(15),
NICDIFD_FECREGISTRO DATETIME DEFAULT GETDATE(),
NICDIFS_USUMODIFICA VARCHAR(15),
NICDIFD_FECMODIFICA DATETIME,
NICDIFB_ESTADO BIT DEFAULT 1)
GO

ALTER TABLE TA_NICHO_DIFUNTO ADD CONSTRAINT FK_NICHODIFUNTO_DIFUNTO FOREIGN KEY (NICDIFN_IDDIFUNTO) REFERENCES TA_DIFUNTO (DIFN_IDDIFUNTO)
GO
ALTER TABLE TA_NICHO_DIFUNTO ADD CONSTRAINT FK_NICHODIFUNTO_NICHO FOREIGN KEY (NICDIFN_IDNICHO) REFERENCES TA_NICHO (NICN_IDNICHO)
GO

INSERT INTO TA_CEMENTERIO (CEMS_NOMBRES, CEMS_USUREGISTRO, CEMS_USUMODIFICA, CEMD_FECREGISTRO, CEMD_FECMODIFICA, CEMB_ESTADO)
VALUES('San Miguel Arcangel', 'ADMIN', NULL, GETDATE(), NULL, 1)
GO

INSERT INTO TA_COLABORADOR (COLN_IDCEMENTERIO, COLS_NOMBRES, COLS_APEPATERNO, COLS_APEMATERNO, COLS_CORREO, COLS_USUREGISTRO,
COLD_FECREGISTRO, COLS_USUMODIFICA, COLD_FECMODIFICA, COLB_ESTADO)
VALUES(1, 'Usuario Administrador', '', '', 'admin@admin.admin', 'ADMIN', GETDATE(), NULL, NULL, 1)
GO

INSERT INTO TA_LOGIN(LOGN_IDCOLABORADOR, LOGS_USUARIO, LOGS_CLAVE, LOGS_USUREGISTRO, LOGD_FECREGISTRO, LOGS_USUMODIFICA,
LOGD_FECMODIFICA, LOGB_ESTADO)
VALUES(1, 'admin@admin.admin', '6wCw2mTjkyXmM4m/JMPM4w==', 'ADMIN', GETDATE(), NULL, NULL, 1)
GO

