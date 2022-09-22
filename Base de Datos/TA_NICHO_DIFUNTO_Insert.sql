USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[TA_NICHO_DIFUNTO_Insert]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Insert]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_DIFUNTO_Insert
DESCRIPCIÓN      : Permite insertar un registro en la tabla TA_NICHO_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            TA_NICHO_DIFUNTO_Insert
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Insert]
(
	@NICDIFN_IDNICHO INT,
	@NICDIFN_IDDIFUNTO INT,
	@NICDIFS_USUREGISTRO VARCHAR(15)
)

AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO [TA_NICHO_DIFUNTO]
    (
    	[NICDIFN_IDNICHO],
    	[NICDIFN_IDDIFUNTO],
    	[NICDIFS_USUREGISTRO]
    )
    VALUES
    (
    	@NICDIFN_IDNICHO,
    	@NICDIFN_IDDIFUNTO,
    	@NICDIFS_USUREGISTRO
    )

    SELECT SCOPE_IDENTITY()

END

GO
