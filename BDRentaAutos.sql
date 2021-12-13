CREATE DATABASE [DBRentaAutos]
GO

USE [DBRentaAutos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Automoviles](
	[IdAutomovil] [INT] IDENTITY(1,1) NOT NULL,
	[Matricula] [VARCHAR](10) NOT NULL,
	[Modelo] [VARCHAR](5) NOT NULL,
	[Marca] [VARCHAR](25) NOT NULL,
	[Cuota] [DECIMAL](10, 2) NOT NULL,
	[Disponibilidad] [BIT] NOT NULL,
	[UrlFoto] [VARCHAR](MAX) NOT NULL,
	[Eliminado] [BIT] NOT NULL
 CONSTRAINT [PK_Automoviles] PRIMARY KEY CLUSTERED 
(
	[IdAutomovil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[IdCliente] [INT] IDENTITY(1,1) NOT NULL,
	[Nombre] [VARCHAR](50) NOT NULL,
	[Telefono] [NVARCHAR](20) NOT NULL,
	[Direccion] [VARCHAR](100) NOT NULL,	
	[Correo] [VARCHAR](100) NOT NULL,
	[UrlFoto] [VARCHAR](MAX) NOT NULL,
	[Eliminado] [BIT] NOT NULL
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rentas](
	[IdRenta] [INT] IDENTITY(1,1) NOT NULL,
	[FechaHora] [DATETIME] NOT NULL,
	[Completada] [BIT] NOT NULL,
	[Plazo] [INT] NOT NULL,
	[CuotaTotal] [DECIMAL](10, 2) NOT NULL,
	[IdAutomovil] [INT] NULL,
	[IdCliente] [INT] NULL,
 CONSTRAINT [PK_Rentas] PRIMARY KEY CLUSTERED 
(
	[IdRenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Rentas]  WITH CHECK ADD  CONSTRAINT [FK_Rentas_Automoviles] FOREIGN KEY([IdAutomovil])
REFERENCES [dbo].[Automoviles] ([IdAutomovil])
GO

ALTER TABLE [dbo].[Rentas] CHECK CONSTRAINT [FK_Rentas_Automoviles]
GO

ALTER TABLE [dbo].[Rentas]  WITH CHECK ADD  CONSTRAINT [FK_Rentas_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[Rentas] CHECK CONSTRAINT [FK_Rentas_Clientes]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ActualizarAutomovil]
	@IdAutomovil INT,
	@Matricula VARCHAR(10)=NULL,
	@Modelo VARCHAR(5)=NULL,
	@Marca VARCHAR(25)=NULL,
	@Cuota DECIMAL(10,2)=NULL,
	@UrlFoto VARCHAR(MAX)=NULL,
	@Disponibilidad INT=NULL
AS

BEGIN
	UPDATE Automoviles SET 
	Matricula=ISNULL(@Matricula,Matricula),
	Modelo=ISNULL(@Modelo,Modelo),
	Marca=ISNULL(@Marca,Marca),
	Cuota=ISNULL(@Cuota,Cuota),
	UrlFoto=ISNULL(@UrlFoto,UrlFoto),
	Disponibilidad=ISNULL(@Disponibilidad,Disponibilidad)
	WHERE IdAutomovil=@IdAutomovil
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ActualizarCliente]
	@IdCliente INT,
	@Nombre VARCHAR(50)=NULL,
	@Telefono VARCHAR(20)=NULL,
	@Direccion VARCHAR(100)=NULL,
	@Correo VARCHAR(100)=NULL,
	@UrlFoto VARCHAR(MAX)=NULL
AS
BEGIN
	UPDATE Clientes SET
	Nombre=ISNULL(@Nombre,Nombre),
	Telefono=ISNULL(@Telefono,Telefono),
	Direccion=ISNULL(@Direccion,Direccion),
	Correo=ISNULL(@Correo,Correo),
	UrlFoto=ISNULL(@UrlFoto,UrlFoto)
	WHERE IdCliente=@IdCliente
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
	IF(@Disponibilidad IS NULL)
	BEGIN
		SELECT * FROM Automoviles WHERE Eliminado=0
	END
	ELSE
	BEGIN
		SELECT * FROM Automoviles
		WHERE Disponibilidad=@Disponibilidad
		AND Eliminado=0
	END
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarClientePorId]
	@IdCliente INT
AS

BEGIN
	SELECT * FROM Clientes
	WHERE IdCliente=@IdCliente
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarClientes]
AS
BEGIN
    SELECT * FROM Clientes
	WHERE Eliminado=0
END	
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarRentas]
AS
BEGIN
	SELECT * FROM Rentas
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarRentasExtendidas]
AS
BEGIN
	SELECT 
	R.IdRenta, 
	R.FechaHora, 
	R.Completada, 
	R.Plazo, 
	R.CuotaTotal, 
	R.IdAutomovil, 
	R.IdCliente,
	A.Marca + ' ' + A.Modelo + ' ' + A.Matricula as NombreAutomovil, 
	A.UrlFoto as UrlFotoAutomovil,
	C.Nombre as NombreCliente, 
	C.UrlFoto as UrlFotoCliente
	FROM Rentas R
	INNER JOIN Automoviles A ON R.IdAutomovil= A.IdAutomovil
	INNER JOIN Clientes C ON R.IdCliente= C.IdCliente
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarRentaPorId]
@IdRenta INT
AS

BEGIN
	SELECT * FROM Rentas
	WHERE IdRenta=@IdRenta
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarRentaExtendidaPorId]
@IdRenta INT
AS

BEGIN
	SELECT 
	R.IdRenta, 
	R.FechaHora, 
	R.Completada, 
	R.Plazo, 
	R.CuotaTotal, 
	R.IdAutomovil, 
	R.IdCliente,
	A.Marca + ' ' + A.Modelo + ' ' + A.Matricula as NombreAutomovil, 
	A.UrlFoto as UrlFotoAutomovil,
	C.Nombre as NombreCliente, 
	C.UrlFoto as UrlFotoCliente
	FROM Rentas R
	INNER JOIN Automoviles A ON R.IdAutomovil= A.IdAutomovil
	INNER JOIN Clientes C ON R.IdCliente= C.IdCliente
	WHERE IdRenta=@IdRenta
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
	UPDATE Automoviles SET 
	Eliminado=1
	WHERE IdAutomovil=@IdAutomovil
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarCliente]
@IdCliente INT
AS
BEGIN
	UPDATE Clientes SET 
	Eliminado=1
	WHERE IdCliente=@IdCliente
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DevolverAutomovil]
@IdRenta INT
AS
BEGIN
	DECLARE @IdAutomovil INT
	SELECT @IdAutomovil=IdAutomovil 
	FROM Rentas
	WHERE IdRenta=@IdRenta

	UPDATE Rentas
	SET
	Completada=1
	WHERE IdRenta=@IdRenta
	
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
@UrlFoto VARCHAR(MAX)
AS
BEGIN
	INSERT INTO Automoviles(Matricula,Modelo,Marca,Cuota,UrlFoto,Disponibilidad, Eliminado)
	VALUES (@Matricula,@Modelo,@Marca,@Cuota,@UrlFoto,1, 0)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertarCliente]
@Nombre VARCHAR(50),
@Telefono VARCHAR(20),
@Direccion VARCHAR(100),
@Correo VARCHAR(100),
@UrlFoto VARCHAR(MAX)

AS
	BEGIN
	INSERT INTO Clientes(Nombre,Direccion,Telefono,Correo,UrlFoto, Eliminado)
	VALUES (@Nombre,@Direccion,@Telefono,@Correo,@UrlFoto, 0)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertarRenta]
	@FechaHora DATETIME,
	@Plazo INT,
	@CuotaTotal DECIMAL(10,2),
	@IdAutomovil INT,
	@IdCliente INT
AS
BEGIN
	INSERT INTO Rentas(FechaHora, Plazo, CuotaTotal, Completada, IdAutomovil, IdCliente)
	VALUES(@FechaHora,@Plazo, @CuotaTotal, 0, @IdAutomovil, @IdCliente)

	UPDATE Automoviles SET
	Disponibilidad=0
	WHERE IdAutomovil=@IdAutomovil
END
GO