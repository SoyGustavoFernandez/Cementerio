USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_Update]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_NICHO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : SourceGenerator 
SINTAXIS         :  
            TA_NICHO_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_Update]
(
    	@NICN_IDNICHO INT,
    	@NICS_CODNICHO VARCHAR(15),
    	@NICB_NUMDIF INT,
    	@NICN_IDPABELLON INT,
    	@NICS_USUMODIFICA VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_NICHO]
    SET     [NICS_CODNICHO] = @NICS_CODNICHO,
    	    [NICB_NUMDIF] = @NICB_NUMDIF,
    	    [NICN_IDPABELLON] = @NICN_IDPABELLON,
    	    [NICS_USUMODIFICA] = @NICS_USUMODIFICA
    WHERE    [NICN_IDNICHO] = @NICN_IDNICHO
END

GO
