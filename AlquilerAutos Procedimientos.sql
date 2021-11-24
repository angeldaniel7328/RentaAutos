USE [DBAlquierAutos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ActualizarAutomovil]
@IdAutomovil INT,
@Matricula VARCHAR(10)=NULL,
@Modelo VARCHAR(25)=NULL,
@Marca VARCHAR(25)=NULL,
@Cuota DECIMAL(10,2)=NULL,
@IdOwner INT=NULL,
@UrlFoto VARCHAR(MAX)=NULL,
@Disponibilidad INT=NULL

AS

BEGIN
	UPDATE Automoviles
	SET
	Matricula=ISNULL(@Matricula,Matricula),
	Modelo=ISNULL(@Modelo,Modelo),
	Marca=ISNULL(@Marca,Marca),
	Cuota=ISNULL(@Cuota,Cuota),
	IdOwner=ISNULL(@IdOwner,IdOwner),
	UrlFoto=ISNULL(@UrlFoto,UrlFoto),
	Disponibilidad=ISNULL(@Disponibilidad,Disponibilidad)
	WHERE IdAutomovil=@IdAutomovil
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ActualizarPersona]
@IdPersona INT,
@Nombre VARCHAR(50)=NULL,
@Direccion VARCHAR(100)=NULL,
@Telefono VARCHAR(20)=NULL,
@Correo VARCHAR(100)=NULL,
@Cargo INT=NULL,
@UrlFoto VARCHAR(MAX)=NULL,
@Disponibilidad BIT=NULL

AS
BEGIN
	UPDATE Personas
	SET
	Nombre=ISNULL(@Nombre,Nombre),
	Direccion=ISNULL(@Direccion,Direccion),
	Telefono=ISNULL(@Telefono,Telefono),
	Correo=ISNULL(@Correo,Correo),
	Cargo=ISNULL(@Cargo,Cargo),
	UrlFoto=ISNULL(@UrlFoto,UrlFoto),
	Disponibilidad=ISNULL(@Disponibilidad,Disponibilidad)
	WHERE IdPersona=@IdPersona
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarAutomovilPorId]
@IdAutomovil INT

AS

BEGIN
	SELECT * FROM Automoviles
	WHERE IdAutomovil=@IdAutomovil
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarAutomoviles]
@Disponibilidad BIT=NULL
AS

BEGIN
	IF(@Disponibilidad is NULL)
		BEGIN
			SELECT * FROM Automoviles
		END
	ELSE
		BEGIN
			SELECT * FROM Automoviles
			WHERE Disponibilidad=@Disponibilidad
		END
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarAutomovilesPorOwner]
@IdOwner INT,
@Disponibilidad BIT=NULL

AS

BEGIN
	IF(@Disponibilidad is NULL)
	BEGIN
		SELECT * FROM Automoviles
		WHERE IdOwner=@IdOwner
	END
	ELSE
	BEGIN
		SELECT * FROM Automoviles
		WHERE IdOwner=@IdOwner AND Disponibilidad=@Disponibilidad
	END
	SELECT * FROM Automoviles
	WHERE IdOwner=@IdOwner
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarPersonaPorId]
@IdPersona INT

AS

BEGIN
	SELECT * FROM PERSONAS
	WHERE IdPersona=@IdPersona
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarPersonas]
@Disponibilidad BIT=NULL
AS

BEGIN
IF(@Disponibilidad is NULL)
		BEGIN
			SELECT * FROM PERSONAS
		END
	ELSE
		BEGIN
			SELECT * FROM PERSONAS
			WHERE Disponibilidad=@Disponibilidad
		END
END
	
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarPersonasPorCargo]
@Cargo INT,
@Disponibilidad BIT=NULL

AS

BEGIN
	IF(@Disponibilidad is NULL)
		BEGIN
			SELECT * FROM PERSONAS
			WHERE Cargo=@Cargo
		END
	ELSE
		BEGIN
			SELECT * FROM PERSONAS
			WHERE Cargo=@Cargo AND Disponibilidad=@Disponibilidad
		END
	SELECT * FROM PERSONAS
	WHERE Cargo=@Cargo
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarSalidasPorEstado]
@Estado VARCHAR(25)

AS

BEGIN
	SELECT * FROM Salidas
	WHERE Estado=@Estado
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarSalidasPorEstadoExtendida]
@Estado VARCHAR(25)

AS

BEGIN
	SELECT S.IdSalida,S.FechaHoraSalida,S.Destino,S.Estado,S.IdAutomovil,S.IdPersona,
	B.Marca as MarcaAutomovil,B.UrlFoto as UrlFotoAutomovil,
	P.Marca as MarcaChofer, P.UrlFoto as UrlFotoChofer
	 FROM Salidas S

	INNER JOIN Automoviles B ON S.IdAutomovil=B.IdAutomovil
	INNER JOIN Personas P ON S.IdPersona=P.IdPersona
	WHERE Estado=@Estado
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarSalidasPorId]
@IdSalida INT

AS

BEGIN
	SELECT * FROM Salidas
	WHERE IdSalida=@IdSalida
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarSalidasPorIdExtendida]
@IdSalida INT

AS

BEGIN
	SELECT S.IdSalida,S.FechaHoraSalida,S.Destino,S.Estado,S.IdAutomovil,S.IdPersona,
	B.Marca as MarcaAutomovil,B.UrlFoto as UrlFotoAutomovil,
	P.Marca as MarcaChofer, P.UrlFoto as UrlFotoChofer
	 FROM Salidas S

	INNER JOIN Automoviles B ON S.IdAutomovil=B.IdAutomovil
	INNER JOIN Personas P ON S.IdPersona=P.IdPersona
	WHERE IdSalida=@IdSalida
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_EliminarAutomovil]
@IdAutomovil INT

AS

BEGIN
	DELETE Automoviles
	WHERE IdAutomovil=@IdAutomovil
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_EliminarPersona]
@IdPersona INT

AS

BEGIN
	DELETE Personas
	WHERE IdPersona=@IdPersona
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_FinalizarSalida]
@IdSalida INT,
@Estado VARCHAR(25)

AS

BEGIN
DECLARE @IdAutomovil INT
DECLARE @IdChofer INT
	SELECT @IdAutomovil=IdAutomovil, @IdChofer=IdPersona FROM Salidas
	WHERE IdSalida=@IdSalida

	UPDATE Salidas
	SET
	Estado=@Estado
	WHERE IdSalida=@IdSalida
	UPDATE Personas
	SET
	Disponibilidad=1
	WHERE IdPersona=@IdChofer
	
	UPDATE Automoviles
	SET
	Disponibilidad=1
	WHERE IdAutomovil=@IdAutomovil

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertarAutomovil]
@Matricula VARCHAR(10),
@Modelo VARCHAR(5),
@Marca VARCHAR(25),
@Cuota DECIMAL(10,2),
@IdOwner INT,
@UrlFoto VARCHAR(MAX)

AS

BEGIN
	INSERT INTO Automoviles(Matricula,Modelo,Marca,Cuota,IdOwner,UrlFoto,Disponibilidad)
	VALUES (@Matricula,@Modelo,@Marca,@Cuota,@IdOwner,@UrlFoto,1)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertarPersona]
@Nombre VARCHAR(50),
@Direccion VARCHAR(100),
@Telefono VARCHAR(20),
@Correo VARCHAR(100),
@Cargo INT,
@UrlFoto VARCHAR(MAX)

AS
BEGIN
INSERT INTO Personas(Nombre,Direccion,Telefono,Correo,Cargo,UrlFoto,Disponibilidad)
VALUES (@Nombre,@Direccion,@Telefono,@Correo,@Cargo,@UrlFoto,1)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertarSalida]
@FechaHoraSalida DateTime,
@Destino VARCHAR(MAX),
@Estado VARCHAR(25),
@IdAutomovil INT,
@IdChofer INT

AS

BEGIN
	INSERT INTO Salidas(FechaHoraSalida,Destino,Estado,IdAutomovil,IdPersona)
	VALUES(@FechaHoraSalida,@Destino,@Estado,@IdAutomovil,@IdChofer)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WS_ConsultarAutomovilesPorOwner]
@IdOwner INT

AS

BEGIN
	SELECT B.Matricula,B.Modelo,B.Marca,B.UrlFoto,
	P.Marca as MarcaOwner
	FROM Automoviles B INNER JOIN Personas P ON B.IdOwner=P.IdPersona
	WHERE IdOwner=@IdOwner
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[WS_ConsultarNoAutomovilesPorOwner]

AS

BEGIN
	SELECT COUNT(B.IdAutomovil) AS NoAutomoviles ,
	P.Marca
	FROM Automoviles B INNER JOIN Personas P ON B.IdOwner=P.IdPersona
	GROUP BY B.IdAutomovil,P.Marca
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WS_ConsultarSalidasMes]
@Mes Date,
@Num INT

AS

BEGIN
	SELECT TOP(@Num) count(S.IdAutomovil) as NoSalidas, B.Marca as MarcaAutomovil,
	P.Marca as MarcaOwner
	FROM Automoviles B 
	INNER JOIN Salidas S ON S.IdAutomovil=B.IdAutomovil
	INNER JOIN Personas P On B.IdOwner=P.IdPersona
	WHERE MONTH(FechaHoraSalida)=MONTH(@Mes) AND YEAR(FechaHoraSalida)=YEAR(GETDATE())
	GROUP BY S.IdAutomovil, B.Marca, P.Marca
	ORDER BY NoSalidas DESC
END
GO
