USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_DIFUNTOSelectAllByNICDIFN_IDDIFUNTO]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_DIFUNTOSelectAllByNICDIFN_IDDIFUNTO]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_DIFUNTOSelectAllByNICDIFN_IDDIFUNTO
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_NICHO_DIFUNTO por su foreign key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : SourceGenerator 
SINTAXIS         :  
            TA_NICHO_DIFUNTOSelectAllByNICDIFN_IDDIFUNTO
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_DIFUNTOSelectAllByNICDIFN_IDDIFUNTO]
(
    	@NICDIFN_IDDIFUNTO INT
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     ND.[NICDIFN_IDNICHODIFUNTO],
    	    ND.[NICDIFN_IDNICHO],
    	    ND.[NICDIFN_IDDIFUNTO],
    	    ND.[NICDIFS_USUREGISTRO],
    	    ND.[NICDIFD_FECREGISTRO],
    	    ND.[NICDIFS_USUMODIFICA],
    	    ND.[NICDIFD_FECMODIFICA],
    	    ND.[NICDIFB_ESTADO],
			D.[DIFN_IDDIFUNTO],
    	    D.[DIFN_IDCEMENTERIO],
			D.[DIFS_DNI],
    	    D.[DIFS_NOMBRES],
    	    D.[DIFS_APEPATERNO],
    	    D.[DIFS_APEMATERNO],
    	    D.[DIFD_FECHADEFUNCION],
    	    D.[DIFS_USUREGISTRO],
    	    D.[DIFD_FECREGISTRO],
    	    D.[DIFS_USUMODIFICA],
    	    D.[DIFD_FECMODIFICA],
    	    D.[DIFB_ESTADO],
			N.[NICN_IDNICHO],
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
    FROM [TA_NICHO_DIFUNTO] ND
	INNER JOIN [TA_DIFUNTO] D ON ND.[NICDIFN_IDDIFUNTO] = D.[DIFN_IDDIFUNTO] AND D.[DIFB_ESTADO] = 1
	INNER JOIN [TA_NICHO] N ON ND.[NICDIFN_IDNICHO] = N.[NICN_IDNICHO] AND N.[NICB_ESTADO] = 1
	INNER JOIN [TA_PABELLON] P ON N.[NICN_IDPABELLON] = P.[PABN_IDPABELLON] AND P.[PABB_ESTADO] = 1
    WHERE     ND.[NICDIFN_IDDIFUNTO] = @NICDIFN_IDDIFUNTO
	AND [NICDIFB_ESTADO] = 1

END

GO