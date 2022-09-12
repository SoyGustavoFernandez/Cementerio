USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[TA_NICHO_DIFUNTO_Update]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Update]
GO

/******************************************************************************
NOMBRE           : TA_NICHO_DIFUNTO_Update
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_NICHO_DIFUNTO
FECHA CREACIÓN   : 11/09/2022
CREADOR          : SourceGenerator 
SINTAXIS         :  
            TA_NICHO_DIFUNTO_Update
******************************************************************************/
CREATE PROCEDURE [dbo].[TA_NICHO_DIFUNTO_Update]
(
    	@NICDIFN_IDNICHODIFUNTO INT,
    	@NICDIFN_IDNICHO INT,
    	@NICDIFN_IDDIFUNTO INT,
    	@NICDIFS_USUMODIFICA VARCHAR(15),
    	@NICDIFD_FECMODIFICA DATETIME
)

AS
BEGIN

    SET NOCOUNT ON

    UPDATE [TA_NICHO_DIFUNTO]
    SET     [NICDIFN_IDNICHO] = @NICDIFN_IDNICHO,
    	    [NICDIFN_IDDIFUNTO] = @NICDIFN_IDDIFUNTO,
    	    [NICDIFS_USUMODIFICA] = @NICDIFS_USUMODIFICA,
    	    [NICDIFD_FECMODIFICA] = @NICDIFD_FECMODIFICA
    WHERE    [NICDIFN_IDNICHODIFUNTO] = @NICDIFN_IDNICHODIFUNTO
END

GO
