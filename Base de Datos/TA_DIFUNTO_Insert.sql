USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[TA_DIFUNTO_Insert]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_DIFUNTO_Insert]
GO

/******************************************************************************
NOMBRE           : TA_DIFUNTO_Insert
DESCRIPCIÓN      : Permite insertar un registro en la tabla TA_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : SourceGenerator 
SINTAXIS         :  
            TA_DIFUNTO_Insert
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_DIFUNTO_Insert]
(
	@DIFN_IDCEMENTERIO INT,
	@DIFS_NOMBRES VARCHAR(100),
	@DIFS_APEPATERNO VARCHAR(100),
	@DIFS_APEMATERNO VARCHAR(100),
	@DIFD_FECHADEFUNCION DATETIME,
	@DIFS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_DIFUNTO]
    (
    	[DIFN_IDCEMENTERIO],
    	[DIFS_NOMBRES],
    	[DIFS_APEPATERNO],
    	[DIFS_APEMATERNO],
    	[DIFD_FECHADEFUNCION],
    	[DIFS_USUREGISTRO]
    )
    VALUES
    (
    	@DIFN_IDCEMENTERIO,
    	@DIFS_NOMBRES,
    	@DIFS_APEPATERNO,
    	@DIFS_APEMATERNO,
    	@DIFD_FECHADEFUNCION,
    	@DIFS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO
