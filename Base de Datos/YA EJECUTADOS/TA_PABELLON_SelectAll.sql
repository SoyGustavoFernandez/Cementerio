USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_PABELLON_SelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_SelectAll]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_SelectAll
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_PABELLON
FECHA CREACIÓN   : 10/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_SelectAll
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_SelectAll]

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
    	    [PABB_ESTADO],
			[PABB_ESTADOBAJA]
    FROM [TA_PABELLON]
	--WHERE  [PABB_ESTADO] = 1

END

GO
