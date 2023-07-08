USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[[TA_PABELLON_UpdateUbicacion]]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_UpdateUbicacion]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_UpdateUbicacion
DESCRIPCIÓN      : Permite actualizar una ubicación en la tabla TA_PABELLON
/ECHA CREACIÓN   : 07/07/2023
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_UpdateUbicacion
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_UpdateUbicacion]
(
    	@PABN_IDPABELLON INT,
    	@PABS_UBICACION VARCHAR(max),
    	@PABS_USUMODIFICA VARCHAR(15),
    	@PABD_FECMODIFICA DATETIME
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_PABELLON]
    SET     [PABS_UBICACION] = @PABS_UBICACION,
    	    [PABS_USUMODIFICA] = @PABS_USUMODIFICA,
    	    [PABD_FECMODIFICA] = @PABD_FECMODIFICA
    WHERE    [PABN_IDPABELLON] = @PABN_IDPABELLON
END

GO
