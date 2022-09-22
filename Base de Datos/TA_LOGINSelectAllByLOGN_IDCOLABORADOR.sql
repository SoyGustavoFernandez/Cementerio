USE [BD_CEMENTERIO]
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
