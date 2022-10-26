USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_SelectByDNI]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_SelectByDNI]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_SelectByDNI
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_DIFUNTO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_SelectByDNI
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_SelectByDNI]
(
    	@DIFS_DNI VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [DIFN_IDDIFUNTO],
    	    [DIFN_IDCEMENTERIO],
			[DIFS_DNI],
    	    [DIFS_NOMBRES],
    	    [DIFS_APEPATERNO],
    	    [DIFS_APEMATERNO],
    	    [DIFD_FECHADEFUNCION],
    	    [DIFS_USUREGISTRO],
    	    [DIFD_FECREGISTRO],
    	    [DIFS_USUMODIFICA],
    	    [DIFD_FECMODIFICA],
    	    [DIFB_ESTADO]
    FROM [TA_DIFUNTO]
    WHERE     [DIFS_DNI] = @DIFS_DNI AND [DIFB_ESTADO] = 1

END

GO
