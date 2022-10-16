USE [db_a74b52_cementerio]
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

    SELECT     N.[NICN_IDNICHO],
    	    N.[NICS_CODNICHO],
    	    N.[NICB_ESTADONICHO],
    	    N.[NICB_NUMDIFTOTAL],
			N.[NICB_NUMDIFACTUAL],
    	    N.[NICN_IDPABELLON],
    	    N.[NICS_USUREGISTRO],
    	    N.[NICD_FECREGISTRO],
    	    N.[NICS_USUMODIFICA],
    	    N.[NICD_FECMODIFICA],
    	    N.[NICB_ESTADO],
			P.[PABS_NOMBRE],
			P.[PABN_IDPABELLON]
    FROM [TA_NICHO] N
	INNER JOIN [TA_PABELLON] P ON N.[NICN_IDPABELLON] = P.[PABN_IDPABELLON] AND P.[PABB_ESTADO] = 1
    WHERE     N.[NICN_IDPABELLON] = @NICN_IDPABELLON AND N.[NICB_ESTADO] = 1


END

GO
