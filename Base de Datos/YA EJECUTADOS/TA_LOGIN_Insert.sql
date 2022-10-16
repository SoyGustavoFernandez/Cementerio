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
