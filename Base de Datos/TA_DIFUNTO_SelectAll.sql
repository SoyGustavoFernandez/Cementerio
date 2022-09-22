USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_SelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_SelectAll]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_SelectAll
DESCRIPCIÓN      : Permite seleccionar todos los registros de la tabla TA_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_SelectAll
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_SelectAll]

AS
BEGIN

    SET NOCOUNT ON

    SELECT     [DIFN_IDDIFUNTO],
    	    [DIFN_IDCEMENTERIO],
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
    WHERE  [DIFB_ESTADO] = 1

END

GO
