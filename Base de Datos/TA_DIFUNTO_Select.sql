USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_Select]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_Select]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_Select
DESCRIPCIÓN      : Permite seleccionar un registro de la tabla TA_DIFUNTO por su primary key
FECHA CREACIÓN   : 11/09/2022
CREADOR          : SourceGenerator 
SINTAXIS         :  
            TA_DIFUNTO_Select
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_Select]
(
    	@DIFN_IDDIFUNTO INT
)

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
    WHERE     [DIFN_IDDIFUNTO] = @DIFN_IDDIFUNTO AND [DIFB_ESTADO] = 1

END

GO
