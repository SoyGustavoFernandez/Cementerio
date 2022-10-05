USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHOSelectAllByNICN_IDPABELLON]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHOSelectAllByNICN_IDPABELLON]
GO

/******************************************************************************
NOMBRE           : TA_NICHOSelectAllByNICN_IDPABELLON
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_NICHO por su foreign key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHOSelectAllByNICN_IDPABELLON
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHOSelectAllByNICN_IDPABELLON]
(
    	@NICN_IDPABELLON INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [NICN_IDNICHO],
	    [NICS_CODNICHO],
	    [NICB_ESTADONICHO],
	    [NICB_NUMDIF],
	    [NICN_IDPABELLON],
	    [NICS_USUREGISTRO],
	    [NICD_FECREGISTRO],
	    [NICS_USUMODIFICA],
	    [NICD_FECMODIFICA],
	    [NICB_ESTADO]
    FROM [TA_NICHO]
    WHERE     [NICN_IDPABELLON] = @NICN_IDPABELLON AND [NICB_ESTADO] = 1


END

GO
