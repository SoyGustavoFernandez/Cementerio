USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_Update]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_NICHO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_Update]
(
    	@NICN_IDNICHO INT,
    	@NICS_CODNICHO VARCHAR(15),
    	@NICB_NUMDIFTOTAL INT,
    	@NICN_IDPABELLON INT,
    	@NICS_USUMODIFICA VARCHAR(15)
)

AS
BEGIN TRY

    SET NOCOUNT ON

	DECLARE @C_ACTUAL AS INT;

	SELECT @C_ACTUAL  = COUNT(NICDIFN_IDNICHO) FROM TA_NICHO_DIFUNTO WHERE NICDIFN_IDNICHO = @NICN_IDNICHO AND NICDIFB_ESTADO = 1

    SET NOCOUNT ON

	IF @C_ACTUAL <= @NICB_NUMDIFTOTAL
		BEGIN 
			 
			 UPDATE [TA_NICHO]
				SET     [NICS_CODNICHO] = @NICS_CODNICHO,
    					[NICB_NUMDIFTOTAL] = @NICB_NUMDIFTOTAL,
						[NICB_NUMDIFACTUAL] = @NICB_NUMDIFTOTAL - @C_ACTUAL,
    					[NICN_IDPABELLON] = @NICN_IDPABELLON,
    					[NICS_USUMODIFICA] = @NICS_USUMODIFICA
				WHERE    [NICN_IDNICHO] = @NICN_IDNICHO
			SELECT 1 as StatusResponse
		END
	ELSE
		BEGIN
			THROW 51000, 'ERROR', 0;  
		END
END TRY
BEGIN CATCH
  SELECT ERROR_STATE() as StatusResponse
END CATCH

GO