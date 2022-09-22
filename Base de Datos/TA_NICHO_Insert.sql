USE [BD_CEMENTERIO]
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
	@NICB_NUMDIF INT,
	@NICN_IDPABELLON INT,
	@NICS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_NICHO]
    (
    	[NICS_CODNICHO],
    	[NICB_NUMDIF],
    	[NICN_IDPABELLON],
		[NICS_USUREGISTRO]
    )
    VALUES
    (
    	@NICS_CODNICHO,
    	@NICB_NUMDIF,
    	@NICN_IDPABELLON,
    	@NICS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO
