USE [master]
GO
/****** Object:  Database [RigoRigoTiendaBd]    Script Date: 12/12/2024 12:06:27 p. m. ******/
CREATE DATABASE [RigoRigoTiendaBd]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RigoRigoTiendaBd', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\RigoRigoTiendaBd.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RigoRigoTiendaBd_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\RigoRigoTiendaBd_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RigoRigoTiendaBd] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RigoRigoTiendaBd].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RigoRigoTiendaBd] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET ARITHABORT OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET  MULTI_USER 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RigoRigoTiendaBd] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RigoRigoTiendaBd] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RigoRigoTiendaBd] SET QUERY_STORE = OFF
GO
USE [RigoRigoTiendaBd]
GO
/****** Object:  User [UserRigoRigo]    Script Date: 12/12/2024 12:06:28 p. m. ******/
CREATE USER [UserRigoRigo] FOR LOGIN [UserRigoRigo] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [UserRigoRigo]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [UserRigoRigo]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 12/12/2024 12:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[DetallePedidoId] [int] IDENTITY(1,1) NOT NULL,
	[PedidoId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Subtotal] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DetallePedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 12/12/2024 12:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[PedidoId] [int] IDENTITY(1,1) NOT NULL,
	[CedulaCliente] [nvarchar](20) NOT NULL,
	[DireccionEntrega] [nvarchar](200) NOT NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 12/12/2024 12:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Stock] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([PedidoId])
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([ProductoId])
GO
/****** Object:  StoredProcedure [dbo].[AgregarDetallePedido]    Script Date: 12/12/2024 12:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarDetallePedido]
    @PedidoId INT,
    @ProductoId INT,
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Precio DECIMAL(10, 2);
    DECLARE @Subtotal DECIMAL(10, 2);

    -- Obtener precio del producto
    SELECT @Precio = Precio
    FROM Productos
    WHERE ProductoId = @ProductoId;

    -- Calcular subtotal
    SET @Subtotal = @Cantidad * @Precio;

    -- Insertar detalle del pedido
    INSERT INTO DetallePedido (PedidoId, ProductoId, Cantidad, Subtotal)
    VALUES (@PedidoId, @ProductoId, @Cantidad, @Subtotal);

    -- Actualizar stock
    UPDATE Productos
    SET Stock = Stock - @Cantidad
    WHERE ProductoId = @ProductoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[AgregarPedido]    Script Date: 12/12/2024 12:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarPedido]
    @CedulaCliente NVARCHAR(20),
    @DireccionEntrega NVARCHAR(200),
    @Fecha DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Fecha IS NULL
        SET @Fecha = GETDATE();

    INSERT INTO Pedidos (CedulaCliente, DireccionEntrega, Fecha)
    VALUES (@CedulaCliente, @DireccionEntrega, @Fecha);

    SELECT SCOPE_IDENTITY() AS PedidoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDetallePedido]    Script Date: 12/12/2024 12:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerDetallePedido]
    @PedidoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dp.DetallePedidoId, 
        dp.ProductoId, 
        p.Nombre AS NombreProducto,
        dp.Cantidad, 
        dp.Subtotal
    FROM DetallePedido dp
    INNER JOIN Productos p ON dp.ProductoId = p.ProductoId
    WHERE dp.PedidoId = @PedidoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerPedidos]    Script Date: 12/12/2024 12:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerPedidos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        PedidoId, 
        CedulaCliente, 
        DireccionEntrega, 
        Fecha
    FROM Pedidos
    ORDER BY Fecha DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProductos]    Script Date: 12/12/2024 12:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerProductos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ProductoId, 
        Nombre, 
        Precio, 
        Stock
    FROM Productos
    ORDER BY Nombre;
END;
GO
USE [master]
GO
ALTER DATABASE [RigoRigoTiendaBd] SET  READ_WRITE 
GO
