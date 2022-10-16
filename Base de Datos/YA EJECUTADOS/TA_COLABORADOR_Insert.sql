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
