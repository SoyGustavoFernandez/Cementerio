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
