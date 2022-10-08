USE [BD_CEMENTERIO]
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