USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_PABELLON_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_Update]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_PABELLON
FECHA CREACIÓN   : 10/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_Update]
(
    	@PABN_IDPABELLON INT,
    	@PABN_IDCEMENTERIO INT,
    	@PABS_NOMBRE VARCHAR(100),
    	@PABS_TIPO INT,
    	@PABS_UBICACION VARCHAR(max),
    	@PABS_USUMODIFICA VARCHAR(15),
    	@PABD_FECMODIFICA DATETIME
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_PABELLON]
    SET     [PABN_IDCEMENTERIO] = @PABN_IDCEMENTERIO,
    	    [PABS_NOMBRE] = @PABS_NOMBRE,
    	    [PABS_TIPO] = @PABS_TIPO,
    	    [PABS_UBICACION] = @PABS_UBICACION,
    	    [PABS_USUMODIFICA] = @PABS_USUMODIFICA,
    	    [PABD_FECMODIFICA] = @PABD_FECMODIFICA
    WHERE    [PABN_IDPABELLON] = @PABN_IDPABELLON
END

GO
