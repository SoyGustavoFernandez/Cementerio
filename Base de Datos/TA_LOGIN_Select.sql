USE [BD_CEMENTERIO]
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
