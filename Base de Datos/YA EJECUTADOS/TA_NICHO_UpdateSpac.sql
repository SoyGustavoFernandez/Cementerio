USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_UpdateSpace]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_UpdateSpace]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_UpdateSpace
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_NICHO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_UpdateSpace
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_UpdateSpace]
(
    	@NICN_IDNICHO INT,
		@CANTIDAD INT
)

AS
BEGIN

    SET NOCOUNT ON

	DECLARE @V_DISPOTOTAL AS INT;
	DECLARE @V_DISPOACTUAL AS INT;

	SELECT @V_DISPOTOTAL  = NICB_NUMDIFTOTAL FROM TA_NICHO WHERE NICN_IDNICHO = @NICN_IDNICHO;
	SELECT @V_DISPOACTUAL = NICB_NUMDIFACTUAL FROM TA_NICHO WHERE NICN_IDNICHO = @NICN_IDNICHO;

	 UPDATE [TA_NICHO]
		SET     [NICB_NUMDIFACTUAL] = NICB_NUMDIFACTUAL + @CANTIDAD,
				[NICB_ESTADONICHO] = CASE WHEN	@V_DISPOTOTAL = @V_DISPOACTUAL THEN 1 
										  WHEN	@V_DISPOTOTAL > @V_DISPOACTUAL THEN 2
										  WHEN	@V_DISPOTOTAL < @V_DISPOACTUAL THEN 3 END
		WHERE    [NICN_IDNICHO] = @NICN_IDNICHO
END

GO