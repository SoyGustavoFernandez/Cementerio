USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_Delete]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_NICHO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_Delete]
(
    	@NICN_IDNICHO INT
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_NICHO]
    SET     [NICB_ESTADO] = 0
    WHERE    [NICN_IDNICHO] = @NICN_IDNICHO

END

GO
