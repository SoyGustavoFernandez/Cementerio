USE [BD_CEMENTERIO]
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
