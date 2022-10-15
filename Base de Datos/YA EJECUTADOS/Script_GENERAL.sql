USE db_a74b52_cementerio
GO

DROP TABLE TA_LOGIN
GO

DROP TABLE TA_COLABORADOR
GO

DROP TABLE TA_NICHO_DIFUNTO
GO

DROP TABLE TA_NICHO
GO

DROP TABLE TA_DIFUNTO
GO

DROP TABLE TA_PABELLON
GO

DROP TABLE TA_CEMENTERIO
GO

USE MASTER
GO

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
PABB_ESTADO BIT DEFAULT 1)
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

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_LOGIN_SelectByCOLS_CORREO]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_LOGIN_SelectByCOLS_CORREO]
GO

/******************************************************************************
NOMBRE           : TA_LOGIN_SelectByCOLS_CORREO
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_LOGIN por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_LOGIN_SelectByCOLS_CORREO
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_LOGIN_SelectByCOLS_CORREO]
(
    	@COLS_CORREO VARCHAR(450)
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     L.[LOGN_IDLOGIN],
    	    L.[LOGN_IDCOLABORADOR],
    	    L.[LOGS_USUARIO],
    	    L.[LOGS_CLAVE],
    	    L.[LOGS_USUREGISTRO],
    	    L.[LOGD_FECREGISTRO],
    	    L.[LOGS_USUMODIFICA],
    	    L.[LOGD_FECMODIFICA],
    	    L.[LOGB_ESTADO],
			C.[COLN_IDCOLABORADOR],
    	    C.[COLN_IDCEMENTERIO],
    	    C.[COLS_NOMBRES],
    	    C.[COLS_APEPATERNO],
    	    C.[COLS_APEMATERNO],
    	    C.[COLS_CORREO],
    	    C.[COLS_USUREGISTRO],
    	    C.[COLD_FECREGISTRO],
    	    C.[COLS_USUMODIFICA],
    	    C.[COLD_FECMODIFICA],
    	    C.[COLB_ESTADO]
    FROM [TA_LOGIN] L INNER JOIN [TA_COLABORADOR] C
	ON L.[LOGN_IDCOLABORADOR] = C.[COLN_IDCOLABORADOR]
    WHERE     UPPER(C.[COLS_CORREO]) = UPPER(@COLS_CORREO)
	AND L.[LOGB_ESTADO] = 1 AND C.[COLB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_COLABORADOR_Select]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_COLABORADOR_Select]
GO

/******************************************************************************
NOMBRE           : TA_COLABORADOR_Select
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_COLABORADOR por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_COLABORADOR_Select
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_COLABORADOR_Select]
(
    	@COLN_IDCOLABORADOR INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [COLN_IDCOLABORADOR],
    	    [COLN_IDCEMENTERIO],
    	    [COLS_NOMBRES],
    	    [COLS_APEPATERNO],
    	    [COLS_APEMATERNO],
    	    [COLS_CORREO],
    	    [COLS_USUREGISTRO],
    	    [COLD_FECREGISTRO],
    	    [COLS_USUMODIFICA],
    	    [COLD_FECMODIFICA],
    	    [COLB_ESTADO]
    FROM [TA_COLABORADOR]
    WHERE     [COLN_IDCOLABORADOR] = @COLN_IDCOLABORADOR
	AND  [COLB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[TA_COLABORADOR_Insert]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_COLABORADOR_Insert]
GO

/******************************************************************************
NOMBRE           : TA_COLABORADOR_Insert
DESCRIPCIÓN      : Permite insertar un registro en la tabla TA_COLABORADOR
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_COLABORADOR_Insert
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_COLABORADOR_Insert]
(
	@COLN_IDCEMENTERIO INT,
	@COLS_NOMBRES VARCHAR(100),
	@COLS_APEPATERNO VARCHAR(50),
	@COLS_APEMATERNO VARCHAR(50),
	@COLS_CORREO VARCHAR(200),
	@COLS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_COLABORADOR]
    (
    	[COLN_IDCEMENTERIO],
    	[COLS_NOMBRES],
    	[COLS_APEPATERNO],
    	[COLS_APEMATERNO],
    	[COLS_CORREO],
    	[COLS_USUREGISTRO]
    )
    VALUES
    (
    	@COLN_IDCEMENTERIO,
    	@COLS_NOMBRES,
    	@COLS_APEPATERNO,
    	@COLS_APEMATERNO,
    	@COLS_CORREO,
    	@COLS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_PABELLON_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_Update]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_PABELLON
FECHA CREACIÓN   : 10/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_Update]
(
    	@PABN_IDPABELLON INT,
    	@PABN_IDCEMENTERIO INT,
    	@PABS_NOMBRE VARCHAR(100),
    	@PABS_TIPO INT,
    	@PABS_UBICACION VARCHAR(max),
    	@PABS_USUMODIFICA VARCHAR(15),
    	@PABD_FECMODIFICA DATETIME
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_PABELLON]
    SET     [PABN_IDCEMENTERIO] = @PABN_IDCEMENTERIO,
    	    [PABS_NOMBRE] = @PABS_NOMBRE,
    	    [PABS_TIPO] = @PABS_TIPO,
    	    [PABS_UBICACION] = @PABS_UBICACION,
    	    [PABS_USUMODIFICA] = @PABS_USUMODIFICA,
    	    [PABD_FECMODIFICA] = @PABD_FECMODIFICA
    WHERE    [PABN_IDPABELLON] = @PABN_IDPABELLON
END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_PABELLON_SelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_SelectAll]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_SelectAll
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_PABELLON
FECHA CREACIÓN   : 10/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_SelectAll
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_SelectAll]

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [PABN_IDPABELLON],
    	    [PABN_IDCEMENTERIO],
    	    [PABS_NOMBRE],
    	    [PABS_TIPO],
    	    [PABS_UBICACION],
    	    [PABS_USUREGISTRO],
    	    [PABS_USUMODIFICA],
    	    [PABD_FECREGISTRO],
    	    [PABD_FECMODIFICA],
    	    [PABB_ESTADO]
    FROM [TA_PABELLON]
	WHERE  [PABB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_PABELLON_Select]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_Select]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_Select
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_PABELLON por su primary key
FECHA CREACIÓN   : 10/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_Select
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_Select]
(
    	@PABN_IDPABELLON INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [PABN_IDPABELLON],
    	    [PABN_IDCEMENTERIO],
    	    [PABS_NOMBRE],
    	    [PABS_TIPO],
    	    [PABS_UBICACION],
    	    [PABS_USUREGISTRO],
    	    [PABS_USUMODIFICA],
    	    [PABD_FECREGISTRO],
    	    [PABD_FECMODIFICA],
    	    [PABB_ESTADO]
    FROM [TA_PABELLON]
    WHERE     [PABN_IDPABELLON] = @PABN_IDPABELLON AND [PABB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[TA_PABELLON_Insert]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_Insert]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_Insert
DESCRIPCIÓN      : Permite insertar un registro en la tabla TA_PABELLON
FECHA CREACIÓN   : 10/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_Insert
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_Insert]
(
	@PABN_IDCEMENTERIO INT,
	@PABS_NOMBRE VARCHAR(100),
	@PABS_TIPO INT,
	@PABS_UBICACION VARCHAR(max),
	@PABS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_PABELLON]
    (
    	[PABN_IDCEMENTERIO],
    	[PABS_NOMBRE],
    	[PABS_TIPO],
    	[PABS_UBICACION],
    	[PABS_USUREGISTRO]
    )
    VALUES
    (
    	@PABN_IDCEMENTERIO,
    	@PABS_NOMBRE,
    	@PABS_TIPO,
    	@PABS_UBICACION,
    	@PABS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_PABELLON_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_Delete]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_PABELLON por su primary key
FECHA CREACIÓN   : 10/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_Delete]
(
    	@PABN_IDPABELLON INT
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_PABELLON]
    SET     [PABB_ESTADO] = 0
    WHERE    [PABN_IDPABELLON] = @PABN_IDPABELLON

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHOSelectAllByNICN_IDPABELLON]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHOSelectAllByNICN_IDPABELLON]
GO

/******************************************************************************
NOMBRE           : TA_NICHOSelectAllByNICN_IDPABELLON
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_NICHO por su foreign key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHOSelectAllByNICN_IDPABELLON
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHOSelectAllByNICN_IDPABELLON]
(
    	@NICN_IDPABELLON INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [NICN_IDNICHO],
	    [NICS_CODNICHO],
	    [NICB_ESTADONICHO],
	    [NICB_NUMDIFTOTAL],
		[NICB_NUMDIFACTUAL],
	    [NICN_IDPABELLON],
	    [NICS_USUREGISTRO],
	    [NICD_FECREGISTRO],
	    [NICS_USUMODIFICA],
	    [NICD_FECMODIFICA],
	    [NICB_ESTADO]
    FROM [TA_NICHO]
    WHERE     [NICN_IDPABELLON] = @NICN_IDPABELLON AND [NICB_ESTADO] = 1


END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_Update]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_NICHO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_Update]
(
    	@NICN_IDNICHO INT,
    	@NICS_CODNICHO VARCHAR(15),
    	@NICB_NUMDIFTOTAL INT,
    	@NICN_IDPABELLON INT,
    	@NICS_USUMODIFICA VARCHAR(15)
)

AS
BEGIN TRY

    SET NOCOUNT ON

	DECLARE @C_ACTUAL AS INT;

	SELECT @C_ACTUAL  = COUNT(NICDIFN_IDNICHO) FROM TA_NICHO_DIFUNTO WHERE NICDIFN_IDNICHO = @NICN_IDNICHO AND NICDIFB_ESTADO = 1

    SET NOCOUNT ON

	IF @C_ACTUAL <= @NICB_NUMDIFTOTAL
		BEGIN 
			 
			 UPDATE [TA_NICHO]
				SET     [NICS_CODNICHO] = @NICS_CODNICHO,
    					[NICB_NUMDIFTOTAL] = @NICB_NUMDIFTOTAL,
						[NICB_NUMDIFACTUAL] = @NICB_NUMDIFTOTAL - @C_ACTUAL,
    					[NICN_IDPABELLON] = @NICN_IDPABELLON,
    					[NICS_USUMODIFICA] = @NICS_USUMODIFICA
				WHERE    [NICN_IDNICHO] = @NICN_IDNICHO
			SELECT 1 as StatusResponse
		END
	ELSE
		BEGIN
			THROW 51000, 'ERROR', 0;  
		END
END TRY
BEGIN CATCH
  SELECT ERROR_STATE() as StatusResponse
END CATCH

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_UpdateSpace]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_UpdateSpace]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_UpdateSpace
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_NICHO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_UpdateSpace
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_UpdateSpace]
(
    	@NICN_IDNICHO INT
)

AS
BEGIN TRY

    SET NOCOUNT ON

	DECLARE @V_DISPOTOTAL AS INT;
	DECLARE @V_DISPOACTUAL AS INT;

	SELECT @V_DISPOTOTAL  = NICB_NUMDIFTOTAL FROM TA_NICHO WHERE NICN_IDNICHO = @NICN_IDNICHO;
	SELECT @V_DISPOACTUAL = NICB_NUMDIFACTUAL FROM TA_NICHO WHERE NICN_IDNICHO = @NICN_IDNICHO;

	IF @V_DISPOACTUAL > 0 AND @V_DISPOTOTAL >= @V_DISPOACTUAL
		BEGIN 
			 UPDATE [TA_NICHO]
			SET     [NICB_NUMDIFACTUAL] = NICB_NUMDIFACTUAL - 1
			WHERE    [NICN_IDNICHO] = @NICN_IDNICHO
			SELECT 1 as MensajeResponse
		END
	ELSE
		BEGIN
			THROW 51000, 'ERROR', 0;  
		END
END TRY
BEGIN CATCH
  SELECT ERROR_STATE() as StatusResponse
END CATCH

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_SelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_SelectAll]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_SelectAll
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_NICHO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_SelectAll
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_SelectAll]

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [NICN_IDNICHO],
    	    [NICS_CODNICHO],
    	    [NICB_ESTADONICHO],
    	    [NICB_NUMDIFTOTAL],
			[NICB_NUMDIFACTUAL]
    	    [NICN_IDPABELLON],
    	    [NICS_USUREGISTRO],
    	    [NICD_FECREGISTRO],
    	    [NICS_USUMODIFICA],
    	    [NICD_FECMODIFICA],
    	    [NICB_ESTADO]
    FROM [TA_NICHO] 
    WHERE [NICB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_Select]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_Select]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_Select
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_NICHO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_Select
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_Select]
(
    	@NICN_IDNICHO INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [NICN_IDNICHO],
    	    [NICS_CODNICHO],
    	    [NICB_ESTADONICHO],
    	    [NICB_NUMDIFTOTAL],
			[NICB_NUMDIFACTUAL],
    	    [NICN_IDPABELLON],
    	    [NICS_USUREGISTRO],
    	    [NICD_FECREGISTRO],
    	    [NICS_USUMODIFICA],
    	    [NICD_FECMODIFICA],
    	    [NICB_ESTADO]
    FROM [TA_NICHO]
    WHERE     [NICN_IDNICHO] = @NICN_IDNICHO AND [NICB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[TA_NICHO_Insert]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_Insert]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_Insert
DESCRIPCIÓN      : Permite insertar un registro en la tabla TA_NICHO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_Insert
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_Insert]
(
	@NICS_CODNICHO VARCHAR(15),
	@NICB_NUMDIFTOTAL INT,
	@NICB_NUMDIFACTUAL INT,
	@NICN_IDPABELLON INT,
	@NICS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_NICHO]
    (
    	[NICS_CODNICHO],
    	[NICB_NUMDIFTOTAL],
		[NICB_NUMDIFACTUAL],
    	[NICN_IDPABELLON],
		[NICS_USUREGISTRO]
    )
    VALUES
    (
    	@NICS_CODNICHO,
    	@NICB_NUMDIFTOTAL,
		@NICB_NUMDIFACTUAL,
    	@NICN_IDPABELLON,
    	@NICS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_DIFUNTO_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Update]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_DIFUNTO_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_NICHO_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_DIFUNTO_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Update]
(
    	@NICDIFN_IDNICHODIFUNTO INT,
    	@NICDIFN_IDNICHO INT,
    	@NICDIFN_IDDIFUNTO INT,
    	@NICDIFS_USUMODIFICA VARCHAR(15),
    	@NICDIFD_FECMODIFICA DATETIME
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_NICHO_DIFUNTO]
    SET     [NICDIFN_IDNICHO] = @NICDIFN_IDNICHO,
    	    [NICDIFN_IDDIFUNTO] = @NICDIFN_IDDIFUNTO,
    	    [NICDIFS_USUMODIFICA] = @NICDIFS_USUMODIFICA,
    	    [NICDIFD_FECMODIFICA] = @NICDIFD_FECMODIFICA
    WHERE    [NICDIFN_IDNICHODIFUNTO] = @NICDIFN_IDNICHODIFUNTO
END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_DIFUNTO_SelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_DIFUNTO_SelectAll]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_DIFUNTO_SelectAll
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_NICHO_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_DIFUNTO_SelectAll
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_DIFUNTO_SelectAll]

AS
BEGIN

    SET NOCOUNT ON

    SELECT     ND.[NICDIFN_IDNICHODIFUNTO],
    	    ND.[NICDIFN_IDNICHO],
    	    ND.[NICDIFN_IDDIFUNTO],
    	    ND.[NICDIFS_USUREGISTRO],
    	    ND.[NICDIFD_FECREGISTRO],
    	    ND.[NICDIFS_USUMODIFICA],
    	    ND.[NICDIFD_FECMODIFICA],
    	    ND.[NICDIFB_ESTADO],
			D.[DIFN_IDDIFUNTO],
    	    D.[DIFN_IDCEMENTERIO],
    	    D.[DIFS_NOMBRES],
    	    D.[DIFS_APEPATERNO],
    	    D.[DIFS_APEMATERNO],
    	    D.[DIFD_FECHADEFUNCION],
    	    D.[DIFS_USUREGISTRO],
    	    D.[DIFD_FECREGISTRO],
    	    D.[DIFS_USUMODIFICA],
    	    D.[DIFD_FECMODIFICA],
    	    D.[DIFB_ESTADO],
			N.[NICN_IDNICHO],
    	    N.[NICS_CODNICHO],
    	    N.[NICB_ESTADONICHO],
    	    N.[NICB_NUMDIFTOTAL],
			N.[NICB_NUMDIFACTUAL],
    	    N.[NICN_IDPABELLON],
    	    N.[NICS_USUREGISTRO],
    	    N.[NICD_FECREGISTRO],
    	    N.[NICS_USUMODIFICA],
    	    N.[NICD_FECMODIFICA],
    	    N.[NICB_ESTADO],
			P.[PABS_NOMBRE],
			P.[PABN_IDPABELLON]
    FROM [TA_NICHO_DIFUNTO] ND
	INNER JOIN [TA_DIFUNTO] D ON ND.[NICDIFN_IDDIFUNTO] = D.[DIFN_IDDIFUNTO] AND D.[DIFB_ESTADO] = 1
	INNER JOIN [TA_NICHO] N ON ND.[NICDIFN_IDNICHO] = N.[NICN_IDNICHO] AND N.[NICB_ESTADO] = 1
	INNER JOIN [TA_PABELLON] P ON N.[NICN_IDPABELLON] = P.[PABN_IDPABELLON] AND P.[PABB_ESTADO] = 1
	WHERE ND.[NICDIFB_ESTADO] = 1
END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_DIFUNTO_Select]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Select]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_DIFUNTO_Select
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_NICHO_DIFUNTO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_DIFUNTO_Select
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Select]
(
    	@NICDIFN_IDNICHODIFUNTO INT
)

AS
BEGIN

    SET NOCOUNT ON
 SELECT     ND.[NICDIFN_IDNICHODIFUNTO],
    	    ND.[NICDIFN_IDNICHO],
    	    ND.[NICDIFN_IDDIFUNTO],
    	    ND.[NICDIFS_USUREGISTRO],
    	    ND.[NICDIFD_FECREGISTRO],
    	    ND.[NICDIFS_USUMODIFICA],
    	    ND.[NICDIFD_FECMODIFICA],
    	    ND.[NICDIFB_ESTADO],
			D.[DIFN_IDDIFUNTO],
    	    D.[DIFN_IDCEMENTERIO],
    	    D.[DIFS_NOMBRES],
    	    D.[DIFS_APEPATERNO],
    	    D.[DIFS_APEMATERNO],
    	    D.[DIFD_FECHADEFUNCION],
    	    D.[DIFS_USUREGISTRO],
    	    D.[DIFD_FECREGISTRO],
    	    D.[DIFS_USUMODIFICA],
    	    D.[DIFD_FECMODIFICA],
    	    D.[DIFB_ESTADO],
			N.[NICN_IDNICHO],
    	    N.[NICS_CODNICHO],
    	    N.[NICB_ESTADONICHO],
    	    N.[NICB_NUMDIFTOTAL],
			N.[NICB_NUMDIFACTUAL],
    	    N.[NICN_IDPABELLON],
    	    N.[NICS_USUREGISTRO],
    	    N.[NICD_FECREGISTRO],
    	    N.[NICS_USUMODIFICA],
    	    N.[NICD_FECMODIFICA],
    	    N.[NICB_ESTADO],
			P.[PABS_NOMBRE],
			P.[PABN_IDPABELLON]
    FROM [TA_NICHO_DIFUNTO] ND
	INNER JOIN [TA_DIFUNTO] D ON ND.[NICDIFN_IDDIFUNTO] = D.[DIFN_IDDIFUNTO] AND D.[DIFB_ESTADO] = 1
	INNER JOIN [TA_NICHO] N ON ND.[NICDIFN_IDNICHO] = N.[NICN_IDNICHO] AND N.[NICB_ESTADO] = 1
	INNER JOIN [TA_PABELLON] P ON N.[NICN_IDPABELLON] = P.[PABN_IDPABELLON] AND P.[PABB_ESTADO] = 1
    WHERE     ND.[NICDIFN_IDNICHODIFUNTO] = @NICDIFN_IDNICHODIFUNTO AND ND.[NICDIFB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[TA_NICHO_DIFUNTO_Insert]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Insert]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_DIFUNTO_Insert
DESCRIPCIÓN      : Permite insertar un registro en la tabla TA_NICHO_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_DIFUNTO_Insert
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Insert]
(
	@NICDIFN_IDNICHO INT,
	@NICDIFN_IDDIFUNTO INT,
	@NICDIFS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_NICHO_DIFUNTO]
    (
    	[NICDIFN_IDNICHO],
    	[NICDIFN_IDDIFUNTO],
    	[NICDIFS_USUREGISTRO]
    )
    VALUES
    (
    	@NICDIFN_IDNICHO,
    	@NICDIFN_IDDIFUNTO,
    	@NICDIFS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_LOGIN_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_LOGIN_Delete]
GO

/******************************************************************************
NOMBRE           : TA_LOGIN_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_LOGIN por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_LOGIN_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_LOGIN_Delete]
(
    	@LOGN_IDLOGIN INT
)

AS
BEGIN

    SET NOCOUNT ON

     UPDATE [TA_LOGIN]
    SET     [LOGB_ESTADO] = 0
    WHERE    [LOGN_IDLOGIN] = @LOGN_IDLOGIN

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_LOGIN_SelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_LOGIN_SelectAll]
GO

/******************************************************************************
NOMBRE           : TA_LOGIN_SelectAll
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_LOGIN
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_LOGIN_SelectAll
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_LOGIN_SelectAll]

AS
BEGIN

    SET NOCOUNT ON

	SELECT L.[LOGN_IDLOGIN],
    	    L.[LOGN_IDCOLABORADOR],
    	    L.[LOGS_USUARIO],
    	    L.[LOGS_CLAVE],
    	    L.[LOGS_USUREGISTRO],
    	    L.[LOGD_FECREGISTRO],
    	    L.[LOGS_USUMODIFICA],
    	    L.[LOGD_FECMODIFICA],
    	    L.[LOGB_ESTADO],
			C.[COLN_IDCOLABORADOR],
    	    C.[COLN_IDCEMENTERIO],
    	    C.[COLS_NOMBRES],
    	    C.[COLS_APEPATERNO],
    	    C.[COLS_APEMATERNO],
    	    C.[COLS_CORREO],
    	    C.[COLS_USUREGISTRO],
    	    C.[COLD_FECREGISTRO],
    	    C.[COLS_USUMODIFICA],
    	    C.[COLD_FECMODIFICA],
    	    C.[COLB_ESTADO]
    FROM [TA_LOGIN] L INNER JOIN [TA_COLABORADOR] C
	ON L.[LOGN_IDCOLABORADOR] = C.[COLN_IDCOLABORADOR]
    WHERE     L.[LOGB_ESTADO] = 1 AND C.[COLB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_LOGINSelectAllByLOGN_IDCOLABORADOR]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_LOGINSelectAllByLOGN_IDCOLABORADOR]
GO

/******************************************************************************
NOMBRE           : TA_LOGINSelectAllByLOGN_IDCOLABORADOR
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_LOGIN por su foreign key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_LOGINSelectAllByLOGN_IDCOLABORADOR
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_LOGINSelectAllByLOGN_IDCOLABORADOR]
(
    	@LOGN_IDCOLABORADOR INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT      L.[LOGN_IDLOGIN],
    	    L.[LOGN_IDCOLABORADOR],
    	    L.[LOGS_USUARIO],
    	    L.[LOGS_CLAVE],
    	    L.[LOGS_USUREGISTRO],
    	    L.[LOGD_FECREGISTRO],
    	    L.[LOGS_USUMODIFICA],
    	    L.[LOGD_FECMODIFICA],
    	    L.[LOGB_ESTADO],
			C.[COLN_IDCOLABORADOR],
    	    C.[COLN_IDCEMENTERIO],
    	    C.[COLS_NOMBRES],
    	    C.[COLS_APEPATERNO],
    	    C.[COLS_APEMATERNO],
    	    C.[COLS_CORREO],
    	    C.[COLS_USUREGISTRO],
    	    C.[COLD_FECREGISTRO],
    	    C.[COLS_USUMODIFICA],
    	    C.[COLD_FECMODIFICA],
    	    C.[COLB_ESTADO]
    FROM [TA_LOGIN] L INNER JOIN [TA_COLABORADOR] C
	ON L.[LOGN_IDCOLABORADOR] = C.[COLN_IDCOLABORADOR]
    WHERE     [LOGN_IDCOLABORADOR] = @LOGN_IDCOLABORADOR
	AND L.[LOGB_ESTADO] = 1 AND C.[COLB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_LOGIN_Select]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_LOGIN_Select]
GO

/******************************************************************************
NOMBRE           : TA_LOGIN_Select
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_LOGIN por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_LOGIN_Select
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_LOGIN_Select]
(
    	@LOGN_IDLOGIN INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     L.[LOGN_IDLOGIN],
    	    L.[LOGN_IDCOLABORADOR],
    	    L.[LOGS_USUARIO],
    	    L.[LOGS_CLAVE],
    	    L.[LOGS_USUREGISTRO],
    	    L.[LOGD_FECREGISTRO],
    	    L.[LOGS_USUMODIFICA],
    	    L.[LOGD_FECMODIFICA],
    	    L.[LOGB_ESTADO],
			C.[COLN_IDCOLABORADOR],
    	    C.[COLN_IDCEMENTERIO],
    	    C.[COLS_NOMBRES],
    	    C.[COLS_APEPATERNO],
    	    C.[COLS_APEMATERNO],
    	    C.[COLS_CORREO],
    	    C.[COLS_USUREGISTRO],
    	    C.[COLD_FECREGISTRO],
    	    C.[COLS_USUMODIFICA],
    	    C.[COLD_FECMODIFICA],
    	    C.[COLB_ESTADO]
    FROM [TA_LOGIN] L INNER JOIN [TA_COLABORADOR] C
	ON L.[LOGN_IDCOLABORADOR] = C.[COLN_IDCOLABORADOR]
    WHERE     [LOGN_IDLOGIN] = @LOGN_IDLOGIN
	AND L.[LOGB_ESTADO] = 1 AND C.[COLB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_LOGIN_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_LOGIN_Update]
GO

/******************************************************************************
NOMBRE           : TA_LOGIN_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_LOGIN
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_LOGIN_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_LOGIN_Update]
(
    	@LOGN_IDLOGIN INT,
    	@LOGN_IDCOLABORADOR INT,
    	@LOGS_USUARIO VARCHAR(max),
    	@LOGS_CLAVE VARCHAR(max),
    	@LOGS_USUMODIFICA VARCHAR(15),
    	@LOGD_FECMODIFICA DATETIME
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_LOGIN]
    SET     [LOGN_IDCOLABORADOR] = @LOGN_IDCOLABORADOR,
    	    [LOGS_USUARIO] = @LOGS_USUARIO,
    	    [LOGS_CLAVE] = @LOGS_CLAVE,
    	    [LOGS_USUMODIFICA] = @LOGS_USUMODIFICA,
    	    [LOGD_FECMODIFICA] = @LOGD_FECMODIFICA
    WHERE    [LOGN_IDLOGIN] = @LOGN_IDLOGIN
END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[TA_LOGIN_Insert]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_LOGIN_Insert]
GO

/******************************************************************************
NOMBRE           : TA_LOGIN_Insert
DESCRIPCIÓN      : Permite insertar un registro en la tabla TA_LOGIN
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_LOGIN_Insert
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_LOGIN_Insert]
(
	@LOGN_IDCOLABORADOR INT,
	@LOGS_USUARIO VARCHAR(max),
	@LOGS_CLAVE VARCHAR(max),
	@LOGS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_LOGIN]
    (
    	[LOGN_IDCOLABORADOR],
    	[LOGS_USUARIO],
    	[LOGS_CLAVE],
    	[LOGS_USUREGISTRO]
    )
    VALUES
    (
    	@LOGN_IDCOLABORADOR,
    	@LOGS_USUARIO,
    	@LOGS_CLAVE,
    	@LOGS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[Dashboard_TotalDifuntos]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[Dashboard_TotalDifuntos]
GO

/******************************************************************************
NOMBRE           : Dashboard_TotalDifuntos
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_COLABORADOR
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            Dashboard_TotalDifuntos
******************************************************************************/
CREATE PROCEDURE [dbo].[Dashboard_TotalDifuntos]
AS
BEGIN
	SELECT 
		PABELLON = P.PABS_NOMBRE,
		CANTIDAD_DIFUNTOS = COUNT(ND.NICDIFN_IDNICHODIFUNTO)
	FROM TA_NICHO_DIFUNTO ND
	INNER JOIN TA_NICHO N ON ND.NICDIFN_IDNICHO = N.NICN_IDNICHO
	INNER JOIN TA_PABELLON P ON N.NICN_IDPABELLON = P.PABN_IDPABELLON
	WHERE NICDIFB_ESTADO = 1 AND N.NICB_ESTADO = 1 AND P.PABB_ESTADO = 1
	GROUP BY P.PABS_NOMBRE
END
GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_COLABORADOR_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_COLABORADOR_Delete]
GO

/******************************************************************************
NOMBRE           : TA_COLABORADOR_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_COLABORADOR por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_COLABORADOR_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_COLABORADOR_Delete]
(
    	@COLN_IDCOLABORADOR INT
)

AS
BEGIN

    SET NOCOUNT ON

     UPDATE [TA_COLABORADOR]
    SET     [COLB_ESTADO] = 0
    WHERE    [COLN_IDCOLABORADOR] = @COLN_IDCOLABORADOR

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_AutenticarLogin]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_AutenticarLogin]
GO
/******************************************************************************
NOMBRE           : TA_AutenticarLogin
DESCRIPCIÓN      : Permite autenticar el inicio de sesión para un usuario
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_AutenticarLogin
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_AutenticarLogin]
	@USU_USUARIO VARCHAR(MAX),
	@USU_CLAVE VARCHAR(MAX)
AS
BEGIN
	IF EXISTS
		(SELECT * FROM [TA_LOGIN] WHERE UPPER([LOGS_USUARIO]) = UPPER(@USU_USUARIO) AND [LOGS_CLAVE] = @USU_CLAVE AND [LOGB_ESTADO] = 1)
	BEGIN
		SELECT     L.[LOGN_IDLOGIN],
    	    L.[LOGN_IDCOLABORADOR],
    	    L.[LOGS_USUARIO],
    	    L.[LOGS_CLAVE],
    	    L.[LOGS_USUREGISTRO],
    	    L.[LOGD_FECREGISTRO],
    	    L.[LOGS_USUMODIFICA],
    	    L.[LOGD_FECMODIFICA],
    	    L.[LOGB_ESTADO],
			C.[COLN_IDCOLABORADOR],
    	    C.[COLN_IDCEMENTERIO],
    	    C.[COLS_NOMBRES],
    	    C.[COLS_APEPATERNO],
    	    C.[COLS_APEMATERNO],
    	    C.[COLS_CORREO],
    	    C.[COLS_USUREGISTRO],
    	    C.[COLD_FECREGISTRO],
    	    C.[COLS_USUMODIFICA],
    	    C.[COLD_FECMODIFICA],
    	    C.[COLB_ESTADO]
    FROM [TA_LOGIN] L INNER JOIN [TA_COLABORADOR] C
	ON L.[LOGN_IDCOLABORADOR] = C.[COLN_IDCOLABORADOR]
    WHERE  L.[LOGS_USUARIO] = UPPER(@USU_USUARIO) AND [LOGS_CLAVE] = @USU_CLAVE AND [LOGB_ESTADO] = 1
	AND C.[COLB_ESTADO] = 1
	END
	ELSE IF EXISTS (SELECT * FROM [TA_LOGIN] WHERE UPPER([LOGS_USUARIO]) = UPPER(@USU_USUARIO) AND [LOGB_ESTADO] != '0')
		BEGIN
			SELECT '404' NO_EXISTE
		END
END
GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_DIFUNTO_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Delete]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_DIFUNTO_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_NICHO_DIFUNTO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_DIFUNTO_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Delete]
(
    	@NICDIFN_IDNICHODIFUNTO INT
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_NICHO_DIFUNTO]
    SET     [NICDIFB_ESTADO] = 0
	WHERE    [NICDIFN_IDNICHODIFUNTO] = @NICDIFN_IDNICHODIFUNTO

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_Delete]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_NICHO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_Delete]
(
    	@NICN_IDNICHO INT
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_NICHO]
    SET     [NICB_ESTADO] = 0
    WHERE    [NICN_IDNICHO] = @NICN_IDNICHO

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_Update]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_Update]
(
    	@DIFN_IDDIFUNTO INT,
    	@DIFN_IDCEMENTERIO INT,
    	@DIFS_NOMBRES VARCHAR(100),
    	@DIFS_APEPATERNO VARCHAR(100),
    	@DIFS_APEMATERNO VARCHAR(100),
    	@DIFD_FECHADEFUNCION DATETIME,
    	@DIFS_USUMODIFICA VARCHAR(15),
    	@DIFD_FECMODIFICA DATETIME
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_DIFUNTO]
    SET     [DIFN_IDCEMENTERIO] = @DIFN_IDCEMENTERIO,
    	    [DIFS_NOMBRES] = @DIFS_NOMBRES,
    	    [DIFS_APEPATERNO] = @DIFS_APEPATERNO,
    	    [DIFS_APEMATERNO] = @DIFS_APEMATERNO,
    	    [DIFD_FECHADEFUNCION] = @DIFD_FECHADEFUNCION,
    	    [DIFS_USUMODIFICA] = @DIFS_USUMODIFICA,
			[DIFD_FECMODIFICA] = @DIFD_FECMODIFICA
    WHERE    [DIFN_IDDIFUNTO] = @DIFN_IDDIFUNTO
END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_SelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_SelectAll]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_SelectAll
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_SelectAll
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_SelectAll]

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [DIFN_IDDIFUNTO],
    	    [DIFN_IDCEMENTERIO],
    	    [DIFS_NOMBRES],
    	    [DIFS_APEPATERNO],
    	    [DIFS_APEMATERNO],
    	    [DIFD_FECHADEFUNCION],
    	    [DIFS_USUREGISTRO],
    	    [DIFD_FECREGISTRO],
    	    [DIFS_USUMODIFICA],
    	    [DIFD_FECMODIFICA],
    	    [DIFB_ESTADO]
    FROM [TA_DIFUNTO]
    WHERE  [DIFB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_Select]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_Select]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_Select
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_DIFUNTO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_Select
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_Select]
(
    	@DIFN_IDDIFUNTO INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [DIFN_IDDIFUNTO],
    	    [DIFN_IDCEMENTERIO],
    	    [DIFS_NOMBRES],
    	    [DIFS_APEPATERNO],
    	    [DIFS_APEMATERNO],
    	    [DIFD_FECHADEFUNCION],
    	    [DIFS_USUREGISTRO],
    	    [DIFD_FECREGISTRO],
    	    [DIFS_USUMODIFICA],
    	    [DIFD_FECMODIFICA],
    	    [DIFB_ESTADO]
    FROM [TA_DIFUNTO]
    WHERE     [DIFN_IDDIFUNTO] = @DIFN_IDDIFUNTO AND [DIFB_ESTADO] = 1

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[TA_DIFUNTO_Insert]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_Insert]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_Insert
DESCRIPCIÓN      : Permite insertar un registro en la tabla TA_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_Insert
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_Insert]
(
	@DIFN_IDCEMENTERIO INT,
	@DIFS_NOMBRES VARCHAR(100),
	@DIFS_APEPATERNO VARCHAR(100),
	@DIFS_APEMATERNO VARCHAR(100),
	@DIFD_FECHADEFUNCION DATETIME,
	@DIFS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_DIFUNTO]
    (
    	[DIFN_IDCEMENTERIO],
    	[DIFS_NOMBRES],
    	[DIFS_APEPATERNO],
    	[DIFS_APEMATERNO],
    	[DIFD_FECHADEFUNCION],
    	[DIFS_USUREGISTRO]
    )
    VALUES
    (
    	@DIFN_IDCEMENTERIO,
    	@DIFS_NOMBRES,
    	@DIFS_APEPATERNO,
    	@DIFS_APEMATERNO,
    	@DIFD_FECHADEFUNCION,
    	@DIFS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_Delete]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_DIFUNTO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_Delete]
(
    	@DIFN_IDDIFUNTO INT
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_DIFUNTO]
    SET     [DIFB_ESTADO] = 0
    WHERE    [DIFN_IDDIFUNTO] = @DIFN_IDDIFUNTO

END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_COLABORADOR_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_COLABORADOR_Update]
GO

/******************************************************************************
NOMBRE           : TA_COLABORADOR_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_COLABORADOR
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_COLABORADOR_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_COLABORADOR_Update]
(
    	@COLN_IDCOLABORADOR INT,
    	@COLN_IDCEMENTERIO INT,
    	@COLS_NOMBRES VARCHAR(100),
    	@COLS_APEPATERNO VARCHAR(50),
    	@COLS_APEMATERNO VARCHAR(50),
    	@COLS_CORREO VARCHAR(200),
    	@COLS_USUMODIFICA VARCHAR(15),
    	@COLD_FECMODIFICA DATETIME
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_COLABORADOR]
    SET     [COLN_IDCEMENTERIO] = @COLN_IDCEMENTERIO,
    	    [COLS_NOMBRES] = @COLS_NOMBRES,
    	    [COLS_APEPATERNO] = @COLS_APEPATERNO,
    	    [COLS_APEMATERNO] = @COLS_APEMATERNO,
    	    [COLS_CORREO] = @COLS_CORREO,
    	    [COLS_USUMODIFICA] = @COLS_USUMODIFICA,
    	    [COLD_FECMODIFICA] = @COLD_FECMODIFICA
    WHERE    [COLN_IDCOLABORADOR] = @COLN_IDCOLABORADOR
    AND	    [COLB_ESTADO] = 1
END

GO

USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_COLABORADOR_SelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_COLABORADOR_SelectAll]
GO

/******************************************************************************
NOMBRE           : TA_COLABORADOR_SelectAll
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_COLABORADOR
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_COLABORADOR_SelectAll
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_COLABORADOR_SelectAll]

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [COLN_IDCOLABORADOR],
    	    [COLN_IDCEMENTERIO],
    	    [COLS_NOMBRES],
    	    [COLS_APEPATERNO],
    	    [COLS_APEMATERNO],
    	    [COLS_CORREO],
    	    [COLS_USUREGISTRO],
    	    [COLD_FECREGISTRO],
    	    [COLS_USUMODIFICA],
    	    [COLD_FECMODIFICA],
    	    [COLB_ESTADO]
    FROM [TA_COLABORADOR] 
	WHERE [COLB_ESTADO] = 1

END

GO
