USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_PABELLON_Select]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_Select]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_Select
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_PABELLON por su primary key
FECHA CREACIÓN   : 10/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_Select
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_Select]
(
    	@PABN_IDPABELLON INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [PABN_IDPABELLON],
    	    [PABN_IDCEMENTERIO],
    	    [PABS_NOMBRE],
    	    [PABS_TIPO],
    	    [PABS_UBICACION],
    	    [PABS_USUREGISTRO],
    	    [PABS_USUMODIFICA],
    	    [PABD_FECREGISTRO],
    	    [PABD_FECMODIFICA],
    	    [PABB_ESTADO]
    FROM [TA_PABELLON]
    WHERE     [PABN_IDPABELLON] = @PABN_IDPABELLON AND [PABB_ESTADO] = 1

END

GO
