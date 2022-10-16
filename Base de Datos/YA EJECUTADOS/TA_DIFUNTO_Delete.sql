USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_Delete]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_DIFUNTO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_Delete]
(
    	@DIFN_IDDIFUNTO INT
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_DIFUNTO]
    SET     [DIFB_ESTADO] = 0
    WHERE    [DIFN_IDDIFUNTO] = @DIFN_IDDIFUNTO

END

GO
