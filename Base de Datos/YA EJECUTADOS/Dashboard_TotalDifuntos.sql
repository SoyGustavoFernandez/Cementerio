USE [BD_CEMENTERIO]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[Dashboard_TotalDifuntos]') and ObjectProperty(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[Dashboard_TotalDifuntos]
GO

/******************************************************************************
NOMBRE           : Dashboard_TotalDifuntos
DESCRIPCIÓN      : Permite actualizar un registro en la tabla TA_COLABORADOR
FECHA CREACIÓN   : 11/09/2022
CREADOR          : Gustavo Fernández 
SINTAXIS         :  
            Dashboard_TotalDifuntos
******************************************************************************/
CREATE PROCEDURE [dbo].[Dashboard_TotalDifuntos]
AS
BEGIN
	SELECT 
		PABELLON = P.PABS_NOMBRE,
		CANTIDAD_DIFUNTOS = COUNT(ND.NICDIFN_IDNICHODIFUNTO)
	FROM TA_NICHO_DIFUNTO ND
	INNER JOIN TA_NICHO N ON ND.NICDIFN_IDNICHO = N.NICN_IDNICHO
	INNER JOIN TA_PABELLON P ON N.NICN_IDPABELLON = P.PABN_IDPABELLON
	WHERE NICDIFB_ESTADO = 1 AND N.NICB_ESTADO = 1 AND P.PABB_ESTADO = 1
	GROUP BY P.PABS_NOMBRE
END