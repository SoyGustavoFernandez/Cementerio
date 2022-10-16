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
