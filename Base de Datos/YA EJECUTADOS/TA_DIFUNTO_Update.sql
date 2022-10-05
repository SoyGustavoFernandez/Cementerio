USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_DIFUNTO_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_Update]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_DIFUNTO_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_Update]
(
    	@DIFN_IDDIFUNTO INT,
    	@DIFN_IDCEMENTERIO INT,
    	@DIFS_NOMBRES VARCHAR(100),
    	@DIFS_APEPATERNO VARCHAR(100),
    	@DIFS_APEMATERNO VARCHAR(100),
    	@DIFD_FECHADEFUNCION DATETIME,
    	@DIFS_USUMODIFICA VARCHAR(15),
    	@DIFD_FECMODIFICA DATETIME
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_DIFUNTO]
    SET     [DIFN_IDCEMENTERIO] = @DIFN_IDCEMENTERIO,
    	    [DIFS_NOMBRES] = @DIFS_NOMBRES,
    	    [DIFS_APEPATERNO] = @DIFS_APEPATERNO,
    	    [DIFS_APEMATERNO] = @DIFS_APEMATERNO,
    	    [DIFD_FECHADEFUNCION] = @DIFD_FECHADEFUNCION,
    	    [DIFS_USUMODIFICA] = @DIFS_USUMODIFICA,
			[DIFD_FECMODIFICA] = @DIFD_FECMODIFICA
    WHERE    [DIFN_IDDIFUNTO] = @DIFN_IDDIFUNTO
END

GO
