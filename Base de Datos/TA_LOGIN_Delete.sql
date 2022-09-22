USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_LOGIN_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_LOGIN_Delete]
GO

/******************************************************************************
NOMBRE           : TA_LOGIN_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_LOGIN por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_LOGIN_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_LOGIN_Delete]
(
    	@LOGN_IDLOGIN INT
)

AS
BEGIN

    SET NOCOUNT ON

     UPDATE [TA_LOGIN]
    SET     [LOGB_ESTADO] = 0
    WHERE    [LOGN_IDLOGIN] = @LOGN_IDLOGIN

END

GO
