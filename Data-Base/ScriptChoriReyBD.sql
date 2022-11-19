USE [master]
GO
/****** Object:  Database [ChoriReyBD]    Script Date: 18/11/2022 23:34:05 ******/
CREATE DATABASE [ChoriReyBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChoriReyBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ChoriReyBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChoriReyBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ChoriReyBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ChoriReyBD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChoriReyBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChoriReyBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChoriReyBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChoriReyBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChoriReyBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChoriReyBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChoriReyBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChoriReyBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChoriReyBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChoriReyBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChoriReyBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChoriReyBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChoriReyBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChoriReyBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChoriReyBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChoriReyBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChoriReyBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChoriReyBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChoriReyBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChoriReyBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChoriReyBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChoriReyBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChoriReyBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChoriReyBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChoriReyBD] SET  MULTI_USER 
GO
ALTER DATABASE [ChoriReyBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChoriReyBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChoriReyBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChoriReyBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChoriReyBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChoriReyBD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ChoriReyBD] SET QUERY_STORE = OFF
GO
USE [ChoriReyBD]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](250) NOT NULL,
	[Apellidos] [nvarchar](250) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Estado] [bit] NULL,
	[Fecha_Registro] [datetime] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encabezados]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encabezados](
	[IdEncabezado] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[IVA] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[EsFactura] [bit] NOT NULL,
	[Observacion] [nvarchar](250) NULL,
	[Fecha_Registro] [datetime] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Encabezados] PRIMARY KEY CLUSTERED 
(
	[IdEncabezado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[IdEncabezado] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [decimal](9, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[IVA] [decimal](18, 2) NOT NULL,
	[TOTAL] [decimal](18, 2) NOT NULL,
	[Fecha_Registro] [datetime] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[CodProducto] [nvarchar](50) NOT NULL,
	[NombreProducto] [nvarchar](250) NOT NULL,
	[CodigoBarras] [nvarchar](50) NULL,
	[Porcentaje_IVA] [int] NOT NULL,
	[Precio_Unitario] [decimal](18, 2) NOT NULL,
	[Fecha_Registro] [datetime] NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Clave] [nvarchar](250) NOT NULL,
	[Nombres] [nvarchar](250) NULL,
	[Apellidos] [nvarchar](250) NULL,
	[Correo] [nvarchar](250) NULL,
	[Direccion] [nvarchar](250) NULL,
	[Estado] [bit] NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Usuarios]
GO
ALTER TABLE [dbo].[Encabezados]  WITH CHECK ADD  CONSTRAINT [FK_Encabezados_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Encabezados] CHECK CONSTRAINT [FK_Encabezados_Clientes]
GO
ALTER TABLE [dbo].[Encabezados]  WITH CHECK ADD  CONSTRAINT [FK_Encabezados_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Encabezados] CHECK CONSTRAINT [FK_Encabezados_Usuarios]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Encabezados] FOREIGN KEY([IdEncabezado])
REFERENCES [dbo].[Encabezados] ([IdEncabezado])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Encabezados]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Productos]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Usuarios]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[uspClientesInsert]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClientesInsert]
	@Nombres NVARCHAR(250)
	,@Apellidos NVARCHAR(250)
	,@Direccion NVARCHAR(50)
	,@Telefono NVARCHAR(50)
	,@Correo  NVARCHAR(50)
	,@Estado BIT
	,@IdUsuario INT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		INSERT INTO  [dbo].[Clientes] (
			Nombres
			,Apellidos
			,Direccion
			,Telefono
			,Correo
			,Estado
			,Fecha_Registro
			,IdUsuario
		) VALUES (
			@Nombres
			,@Apellidos
			,@Direccion
			,@Telefono
			,@Correo
			,@Estado
			,GETDATE()
			,@IdUsuario
		)		
		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspClientesUpdate]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClientesUpdate]
	@IdCliente INT
	,@Nombres NVARCHAR(250)
	,@Apellidos NVARCHAR(250)
	,@Direccion NVARCHAR(50)
	,@Telefono NVARCHAR(50)
	,@Correo  NVARCHAR(50)
	,@Estado BIT
	,@IdUsuario INT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		UPDATE [dbo].[Clientes] SET
			Nombres = @Nombres
			,Apellidos = @Apellidos
			,Direccion = @Direccion
			,Telefono = @Telefono
			,Correo = @Correo
			,Estado = @Estado
			,IdUsuario = @IdUsuario
		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspDelClientes]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDelClientes]
	@IdCliente INT	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		DELETE FROM [dbo].[Clientes] WHERE IdCliente = @IdCliente

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspDelProductos]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDelProductos]
	@IdProducto INT	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		DELETE FROM [dbo].[Productos] WHERE IdProducto = @IdProducto

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspDelUsuarios]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDelUsuarios]
	@IdUsuario INT	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		DELETE FROM [dbo].[Usuarios] WHERE IdUsuario = @IdUsuario

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspGenerarPedidoInsert]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGenerarPedidoInsert]
	@IdCliente INT
	,@Total DECIMAL(18,2)
	,@IVA DECIMAL(18,2)
	,@SubTotal DECIMAL(18,2)
	,@Estado BIT
	,@EsFactura BIT
	,@Observacion NVARCHAR(250)
	,@IdUsuario INT
	,@JsonDetalle NVARCHAR(MAX)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		DECLARE @IdEncabezado INT

		INSERT INTO  [dbo].[Encabezados] (			
			IdCliente
			,Total
			,IVA
			,SubTotal
			,Estado
			,EsFactura
			,Observacion			
			,Fecha_Registro
			,IdUsuario
		) VALUES (
			@IdCliente
			,@Total
			,@IVA
			,@SubTotal
			,@Estado
			,@EsFactura
			,@Observacion
			,GETDATE()
			,@IdUsuario
		)

		SELECT @IdEncabezado = IDENT_CURRENT('[dbo].[Encabezados]');

		INSERT INTO [dbo].[Pedidos]
		(
			IdEncabezado
			,IdProducto
			,Cantidad
			,SubTotal
			,IVA
			,TOTAL
			,IdUsuario
		)
		SELECT 
			@IdEncabezado
			,IdProducto
			,Cantidad
			,SubTotal
			,IVA
			,TOTAL
			,IdUsuario
		FROM OPENJSON (@JsonDetalle)
		WITH 
		(
			[IdProducto] int,
			[Cantidad] DECIMAL,
			[SubTotal] DECIMAL,
			[IVA] int,
			[TOTAL] decimal(16,2),
			[IdUsuario] INT
		)
		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UspgetClientes]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetClientes]
AS
SELECT 
	IdCliente
	,Nombres
	,Apellidos
	,Direccion
	,Telefono
	,Correo
	,Estado
	,Fecha_Registro
	,IdUsuario
FROM [dbo].[Clientes]
GO
/****** Object:  StoredProcedure [dbo].[UspgetClientesByID]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetClientesByID]
	@IdCliente INT
AS
SELECT 
	IdCliente
	,Nombres
	,Apellidos
	,Direccion
	,Telefono
	,Correo
	,Estado
	,Fecha_Registro
	,IdUsuario
FROM [dbo].[Clientes] WHERE IdCliente = @IdCliente
 
GO
/****** Object:  StoredProcedure [dbo].[uspGetLogin]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetLogin]
	@Usuario nvarchar(500),
	@Clave nvarchar(max)
AS
SELECT IdUsuario
,Usuario
,Clave
,Nombres
,Apellidos
,Correo
,Direccion
,Estado
,Fecha_Creacion FROM [dbo].[Usuarios] u WHERE u.Usuario = @Usuario AND u.Clave = @Clave
GO
/****** Object:  StoredProcedure [dbo].[UspgetProductos]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetProductos]
AS
SELECT 
	IdProducto
	,CodProducto
	,NombreProducto
	,CodigoBarras
	,Porcentaje_IVA
	,Precio_Unitario
	,Fecha_Registro
	,Estado
	,IdUsuario
FROM [dbo].[Productos]
GO
/****** Object:  StoredProcedure [dbo].[UspgetProductosByID]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetProductosByID]
	@IdProducto INT
AS
SELECT 
	IdProducto
	,CodProducto
	,NombreProducto
	,CodigoBarras
	,Porcentaje_IVA
	,Precio_Unitario
	,Fecha_Registro
	,Estado
	,IdUsuario
FROM [dbo].[Productos] WHERE IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[UspgetUsuarios]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetUsuarios]
AS
SELECT 
	IdUsuario
	,Usuario
	,Clave
	,Nombres
	,Apellidos
	,Correo
	,Direccion
	,Estado
	,Fecha_Creacion
FROM [dbo].[Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[UspgetUsuariosByID]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetUsuariosByID]
	@IdUsuario INT
AS
SELECT 
	IdUsuario
	,Usuario
	,Clave
	,Nombres
	,Apellidos
	,Correo
	,Direccion
	,Estado
	,Fecha_Creacion
FROM [dbo].[Usuarios] WHERE IdUsuario = @IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[uspProductosInsert]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspProductosInsert]
	@CodProducto NVARCHAR(50)
	,@NombreProducto NVARCHAR(250)
	,@CodigoBarras NVARCHAR(50)
	,@Porcentaje_IVA INT
	,@Precio_Unitario DECIMAL(18,2)
	,@Estado BIT
	,@IdUsuario INT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		INSERT INTO  [dbo].[Productos] (
			CodProducto
			,NombreProducto
			,CodigoBarras
			,Porcentaje_IVA
			,Precio_Unitario
			,Fecha_Registro
			,Estado
			,IdUsuario
		) VALUES (
			@CodProducto
			,@NombreProducto
			,@CodigoBarras
			,@Porcentaje_IVA
			,@Precio_Unitario
			,GETDATE()
			,@Estado
			,@IdUsuario
			
		)		
		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspProductosUpdate]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspProductosUpdate]
	@IdProducto INT
	,@CodProducto NVARCHAR(50)
	,@NombreProducto NVARCHAR(250)
	,@CodigoBarras NVARCHAR(50)
	,@Porcentaje_IVA INT
	,@Precio_Unitario DECIMAL(18,2)
	,@Estado BIT
	,@IdUsuario INT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		UPDATE [dbo].[Productos] SET
			CodProducto = @CodProducto
			,NombreProducto = @NombreProducto
			,CodigoBarras = @CodigoBarras
			,Porcentaje_IVA = @Porcentaje_IVA
			,Precio_Unitario = @Precio_Unitario			
			,Estado = @Estado
			,IdUsuario = @IdUsuario
		WHERE IdProducto = @IdProducto

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspUsuariosInsert]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
#Fecha: 13-Nov-2022
#Descripción: Procedimiento encargado de crear los usuarios.
#Desarrollador por: Sixto José Romero Martínez
*/
--EXEC [dbo].[uspUsuariosInsert] 
CREATE PROCEDURE [dbo].[uspUsuariosInsert]
	@Usuario NVARCHAR(100)
	,@Clave NVARCHAR(250)
	,@Nombres NVARCHAR(250)
	,@Apellidos NVARCHAR(250)
	,@Correo NVARCHAR(250)
	,@Direccion NVARCHAR(250)
	,@Estado BIT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		INSERT INTO  [dbo].[Usuarios] (
			Usuario
			,Clave
			,Nombres
			,Apellidos
			,Correo
			,Direccion
			,Estado
			,Fecha_Creacion
		) VALUES (
			@Usuario
			,@Clave
			,@Nombres
			,@Apellidos
			,@Correo
			,@Direccion
			,@Estado
			,GETDATE()
		)		
		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspUsuariosUpdate]    Script Date: 18/11/2022 23:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
#Fecha: 13-Nov-2022
#Descripción: Procedimiento encargado de crear los usuarios.
#Desarrollador por: Sixto José Romero Martínez
*/
CREATE PROCEDURE [dbo].[uspUsuariosUpdate]
	@IdUsuario INT
	,@Usuario NVARCHAR(100)
	,@Clave NVARCHAR(250)
	,@Nombres NVARCHAR(250)
	,@Apellidos NVARCHAR(250)
	,@Correo NVARCHAR(250)
	,@Direccion NVARCHAR(250)
	,@Estado BIT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		UPDATE [dbo].[Usuarios] SET Usuario = @Usuario, Clave = @Clave, Nombres = @Nombres
			,Apellidos = @Apellidos
			,Correo = @Correo
			,Direccion = @Direccion
			,Estado = @Estado
		WHERE IdUsuario = @IdUsuario
		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
USE [master]
GO
ALTER DATABASE [ChoriReyBD] SET  READ_WRITE 
GO
