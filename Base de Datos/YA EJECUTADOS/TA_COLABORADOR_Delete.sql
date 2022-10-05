USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_COLABORADOR_Delete]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_COLABORADOR_Delete]
GO

/******************************************************************************
NOMBRE           : TA_COLABORADOR_Delete
DESCRIPCIÓN      : Permite eliminar de forma permanente un registro en la tabla TA_COLABORADOR por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_COLABORADOR_Delete
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_COLABORADOR_Delete]
(
    	@COLN_IDCOLABORADOR INT
)

AS
BEGIN

    SET NOCOUNT ON

     UPDATE [TA_COLABORADOR]
    SET     [COLB_ESTADO] = 0
    WHERE    [COLN_IDCOLABORADOR] = @COLN_IDCOLABORADOR

END

GO
