USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_SelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_SelectAll]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_SelectAll
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_NICHO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_SelectAll
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_SelectAll]

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [NICN_IDNICHO],
    	    [NICS_CODNICHO],
    	    [NICB_ESTADONICHO],
    	    [NICB_NUMDIFTOTAL],
    	    [NICB_NUMDIFACTUAL],
    	    [NICN_IDPABELLON],
    	    [NICS_USUREGISTRO],
    	    [NICD_FECREGISTRO],
    	    [NICS_USUMODIFICA],
    	    [NICD_FECMODIFICA],
    	    [NICB_ESTADO]
    FROM [TA_NICHO] 
    WHERE [NICB_ESTADO] = 1

END

GO
