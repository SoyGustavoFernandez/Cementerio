USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_Select]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_Select]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_Select
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_NICHO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_Select
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_Select]
(
    	@NICN_IDNICHO INT
)

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
    WHERE     [NICN_IDNICHO] = @NICN_IDNICHO AND [NICB_ESTADO] = 1

END

GO
