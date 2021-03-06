USE [master]
GO
/****** Object:  Database [AgenziaDiAssicurazione]    Script Date: 03.09.2021 15:20:19 ******/
CREATE DATABASE [AgenziaDiAssicurazione]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AgenziaDiAssicurazione', FILENAME = N'C:\Users\terez\AgenziaDiAssicurazione.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AgenziaDiAssicurazione_log', FILENAME = N'C:\Users\terez\AgenziaDiAssicurazione_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AgenziaDiAssicurazione].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET ARITHABORT OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET  MULTI_USER 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET QUERY_STORE = OFF
GO
USE [AgenziaDiAssicurazione]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [AgenziaDiAssicurazione]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 03.09.2021 15:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 03.09.2021 15:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodiceFiscale] [varchar](16) NOT NULL,
	[Nome] [varchar](30) NULL,
	[Cognome] [varchar](20) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Polizze]    Script Date: 03.09.2021 15:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Polizze](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroPolizza] [int] NOT NULL,
	[DataScadenza] [datetime2](7) NOT NULL,
	[RataMensile] [decimal](18, 2) NOT NULL,
	[Tipo] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Polizze] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210903085029_firstMigration', N'5.0.9')
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [CodiceFiscale], [Nome], [Cognome]) VALUES (1, N'IT65V962LE5697L3', N'Tereza', N'Simkova')
INSERT [dbo].[Customers] ([Id], [CodiceFiscale], [Nome], [Cognome]) VALUES (2, N'IT9658PLdE562Vb6', N'Alice', N'Rossi')
INSERT [dbo].[Customers] ([Id], [CodiceFiscale], [Nome], [Cognome]) VALUES (3, N'ITOP65kj98pdFG23', N'Andrea', N'Neri')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Polizze] ON 

INSERT [dbo].[Polizze] ([Id], [NumeroPolizza], [DataScadenza], [RataMensile], [Tipo], [CustomerId]) VALUES (1, 1, CAST(N'2022-09-12T00:00:00.0000000' AS DateTime2), CAST(320.50 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Polizze] ([Id], [NumeroPolizza], [DataScadenza], [RataMensile], [Tipo], [CustomerId]) VALUES (2, 2, CAST(N'2021-10-01T00:00:00.0000000' AS DateTime2), CAST(210.00 AS Decimal(18, 2)), 2, 1)
SET IDENTITY_INSERT [dbo].[Polizze] OFF
GO
/****** Object:  Index [IX_Polizze_CustomerId]    Script Date: 03.09.2021 15:20:20 ******/
CREATE NONCLUSTERED INDEX [IX_Polizze_CustomerId] ON [dbo].[Polizze]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Polizze]  WITH CHECK ADD  CONSTRAINT [FK_Polizze_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Polizze] CHECK CONSTRAINT [FK_Polizze_Customers_CustomerId]
GO
USE [master]
GO
ALTER DATABASE [AgenziaDiAssicurazione] SET  READ_WRITE 
GO
