USE [db_a74b52_cementerio]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[TA_PABELLON_Insert]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_PABELLON_Insert]
GO

/******************************************************************************
NOMBRE           : TA_PABELLON_Insert
DESCRIPCIÓN      : Permite insertar un registro en la tabla TA_PABELLON
FECHA CREACIÓN   : 10/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_PABELLON_Insert
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_PABELLON_Insert]
(
	@PABN_IDCEMENTERIO INT,
	@PABS_NOMBRE VARCHAR(100),
	@PABS_TIPO INT,
	@PABS_UBICACION VARCHAR(max),
	@PABS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_PABELLON]
    (
    	[PABN_IDCEMENTERIO],
    	[PABS_NOMBRE],
    	[PABS_TIPO],
    	[PABS_UBICACION],
    	[PABS_USUREGISTRO]
    )
    VALUES
    (
    	@PABN_IDCEMENTERIO,
    	@PABS_NOMBRE,
    	@PABS_TIPO,
    	@PABS_UBICACION,
    	@PABS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO
