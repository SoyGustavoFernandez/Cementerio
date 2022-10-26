USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_BuscarSerQuerido]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_BuscarSerQuerido]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_BuscarSerQuerido
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_BuscarSerQuerido
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_BuscarSerQuerido](
		@DIFS_NOMBRES VARCHAR(100),
		@DIFS_APEPATERNO VARCHAR(100),
		@DIFS_APEMATERNO VARCHAR(100)
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
			D.[DIFS_DNI],
    	    D.[DIFN_IDCEMENTERIO],
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
    WHERE     (UPPER(D.[DIFS_NOMBRES]) LIKE UPPER('%'+ISNULL(@DIFS_NOMBRES,'')+'%') AND UPPER(D.[DIFS_APEPATERNO]) LIKE UPPER('%'+ISNULL(@DIFS_APEPATERNO,'')+'%') 
	AND UPPER('%'+D.[DIFS_APEMATERNO]+'%') LIKE UPPER('%'+ISNULL(@DIFS_APEMATERNO,'')+'%')) AND [NICDIFB_ESTADO] = 1

END

GO
