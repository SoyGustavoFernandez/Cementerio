USE [BD_CEMENTERIO]
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
