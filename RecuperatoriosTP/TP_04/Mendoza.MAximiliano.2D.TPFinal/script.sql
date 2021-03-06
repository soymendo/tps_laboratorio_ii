USE [master]
GO
/****** Object:  Database [PlacaVideo]    Script Date: 24/11/2021 08:16:41 ******/
CREATE DATABASE [PlacaVideo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PlacaVideo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PlacaVideo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PlacaVideo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PlacaVideo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PlacaVideo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PlacaVideo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PlacaVideo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PlacaVideo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PlacaVideo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PlacaVideo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PlacaVideo] SET ARITHABORT OFF 
GO
ALTER DATABASE [PlacaVideo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PlacaVideo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PlacaVideo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PlacaVideo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PlacaVideo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PlacaVideo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PlacaVideo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PlacaVideo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PlacaVideo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PlacaVideo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PlacaVideo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PlacaVideo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PlacaVideo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PlacaVideo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PlacaVideo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PlacaVideo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PlacaVideo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PlacaVideo] SET RECOVERY FULL 
GO
ALTER DATABASE [PlacaVideo] SET  MULTI_USER 
GO
ALTER DATABASE [PlacaVideo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PlacaVideo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PlacaVideo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PlacaVideo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PlacaVideo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PlacaVideo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PlacaVideo', N'ON'
GO
ALTER DATABASE [PlacaVideo] SET QUERY_STORE = OFF
GO
USE [PlacaVideo]
GO
/****** Object:  Table [dbo].[PlacasVideo]    Script Date: 24/11/2021 08:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlacasVideo](
	[Nombre] [nvarchar](50) NULL,
	[Marca] [nvarchar](50) NULL,
	[TipoDeMemoria] [nvarchar](50) NULL,
	[CapacidadDeRam] [int] NULL,
	[FrecuenciaDeMemoria] [int] NULL,
	[Consumo] [int] NULL,
	[Longitud] [int] NULL,
	[InterfazPci] [float] NULL,
	[MineriaBitrcoin] [float] NULL,
	[MineriaEthereum] [float] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[PlacasVideo] ([Nombre], [Marca], [TipoDeMemoria], [CapacidadDeRam], [FrecuenciaDeMemoria], [Consumo], [Longitud], [InterfazPci], [MineriaBitrcoin], [MineriaEthereum]) VALUES (N'Radeon 100', N'Asus', N'GDDR3', 5, 5, 52, 15, 3.2000000476837158, 0.0010000000474974513, 0.0020000000949949026)
INSERT [dbo].[PlacasVideo] ([Nombre], [Marca], [TipoDeMemoria], [CapacidadDeRam], [FrecuenciaDeMemoria], [Consumo], [Longitud], [InterfazPci], [MineriaBitrcoin], [MineriaEthereum]) VALUES (N'Radeon 200', N'Amd', N'GDDR5', 6, 6, 65, 16, 3.2000000476837158, 0.0010000000474974513, 0.0020000000949949026)
INSERT [dbo].[PlacasVideo] ([Nombre], [Marca], [TipoDeMemoria], [CapacidadDeRam], [FrecuenciaDeMemoria], [Consumo], [Longitud], [InterfazPci], [MineriaBitrcoin], [MineriaEthereum]) VALUES (N'Radeon 400', N'Gigabyte', N'SinAsignar', 8, 8, 82, 18, 3, 0.004999999888241291, 0.004999999888241291)
GO
USE [master]
GO
ALTER DATABASE [PlacaVideo] SET  READ_WRITE 
GO
