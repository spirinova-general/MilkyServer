USE [master]
GO
/****** Object:  Database [Milky]    Script Date: 12/21/2015 22:40:48 ******/
CREATE DATABASE [Milky] ON  PRIMARY 
( NAME = N'Milky', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Milky.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Milky_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Milky_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Milky] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Milky].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Milky] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Milky] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Milky] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Milky] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Milky] SET ARITHABORT OFF
GO
ALTER DATABASE [Milky] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Milky] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Milky] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Milky] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Milky] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Milky] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Milky] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Milky] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Milky] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Milky] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Milky] SET  DISABLE_BROKER
GO
ALTER DATABASE [Milky] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Milky] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Milky] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Milky] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Milky] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Milky] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Milky] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Milky] SET  READ_WRITE
GO
ALTER DATABASE [Milky] SET RECOVERY FULL
GO
ALTER DATABASE [Milky] SET  MULTI_USER
GO
ALTER DATABASE [Milky] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Milky] SET DB_CHAINING OFF
GO
USE [Milky]
GO
/****** Object:  ForeignKey [FK__GlobalSet__Accou__33D4B598]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[GlobalSetting] DROP CONSTRAINT [FK__GlobalSet__Accou__33D4B598]
GO
/****** Object:  ForeignKey [FK_Area_City]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Area] DROP CONSTRAINT [FK_Area_City]
GO
/****** Object:  ForeignKey [FK__Account_A__Accou__276EDEB3]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Account_Area_Mapping] DROP CONSTRAINT [FK__Account_A__Accou__276EDEB3]
GO
/****** Object:  ForeignKey [FK__Account_A__AreaI__286302EC]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Account_Area_Mapping] DROP CONSTRAINT [FK__Account_A__AreaI__286302EC]
GO
/****** Object:  ForeignKey [FK__Customer__Accoun__2C3393D0]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK__Customer__Accoun__2C3393D0]
GO
/****** Object:  ForeignKey [FK__Customer__AreaId__2D27B809]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK__Customer__AreaId__2D27B809]
GO
/****** Object:  ForeignKey [FK__Delivery__Accoun__300424B4]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Delivery] DROP CONSTRAINT [FK__Delivery__Accoun__300424B4]
GO
/****** Object:  ForeignKey [FK__Delivery__Custom__1CF15040]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Delivery] DROP CONSTRAINT [FK__Delivery__Custom__1CF15040]
GO
/****** Object:  ForeignKey [FK__CustomerS__Accou__2E1BDC42]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[CustomerSetting] DROP CONSTRAINT [FK__CustomerS__Accou__2E1BDC42]
GO
/****** Object:  ForeignKey [FK__CustomerS__Custo__1ED998B2]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[CustomerSetting] DROP CONSTRAINT [FK__CustomerS__Custo__1ED998B2]
GO
/****** Object:  ForeignKey [FK__Bill__AccountId__2B3F6F97]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK__Bill__AccountId__2B3F6F97]
GO
/****** Object:  ForeignKey [FK__Bill__CustomerId__2A4B4B5E]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK__Bill__CustomerId__2A4B4B5E]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK__Bill__AccountId__2B3F6F97]
GO
ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK__Bill__CustomerId__2A4B4B5E]
GO
DROP TABLE [dbo].[Bill]
GO
/****** Object:  Table [dbo].[CustomerSetting]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[CustomerSetting] DROP CONSTRAINT [FK__CustomerS__Accou__2E1BDC42]
GO
ALTER TABLE [dbo].[CustomerSetting] DROP CONSTRAINT [FK__CustomerS__Custo__1ED998B2]
GO
DROP TABLE [dbo].[CustomerSetting]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Delivery] DROP CONSTRAINT [FK__Delivery__Accoun__300424B4]
GO
ALTER TABLE [dbo].[Delivery] DROP CONSTRAINT [FK__Delivery__Custom__1CF15040]
GO
DROP TABLE [dbo].[Delivery]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK__Customer__Accoun__2C3393D0]
GO
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK__Customer__AreaId__2D27B809]
GO
DROP TABLE [dbo].[Customer]
GO
/****** Object:  Table [dbo].[Account_Area_Mapping]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Account_Area_Mapping] DROP CONSTRAINT [FK__Account_A__Accou__276EDEB3]
GO
ALTER TABLE [dbo].[Account_Area_Mapping] DROP CONSTRAINT [FK__Account_A__AreaI__286302EC]
GO
DROP TABLE [dbo].[Account_Area_Mapping]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Area] DROP CONSTRAINT [FK_Area_City]
GO
DROP TABLE [dbo].[Area]
GO
/****** Object:  Table [dbo].[GlobalSetting]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[GlobalSetting] DROP CONSTRAINT [FK__GlobalSet__Accou__33D4B598]
GO
DROP TABLE [dbo].[GlobalSetting]
GO
/****** Object:  Table [dbo].[City]    Script Date: 12/21/2015 22:40:50 ******/
DROP TABLE [dbo].[City]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 12/21/2015 22:40:50 ******/
DROP TABLE [dbo].[Account]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 12/21/2015 22:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FarmerCode] [nvarchar](10) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[Dirty] [int] NOT NULL,
	[FirstName] [varchar](max) NULL,
	[LastName] [varchar](max) NULL,
 CONSTRAINT [PK__Account__3214EC070EA330E9] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[City]    Script Date: 12/21/2015 22:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GlobalSetting]    Script Date: 12/21/2015 22:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GlobalSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DefaultRate] [float] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Dirty] [int] NULL,
 CONSTRAINT [PK__GlobalSe__3214EC0725869641] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 12/21/2015 22:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK__Area__3214EC07145C0A3F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account_Area_Mapping]    Script Date: 12/21/2015 22:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_Area_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
	[Dirty] [int] NOT NULL,
 CONSTRAINT [PK__Account___3214EC07117F9D94] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/21/2015 22:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[Address1] [nvarchar](50) NOT NULL,
	[Address2] [nvarchar](50) NOT NULL,
	[Balance] [int] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[AccountId] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
	[Dirty] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 12/21/2015 22:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Dirty] [int] NULL,
	[DateModified] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerSetting]    Script Date: 12/21/2015 22:40:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Rate] [float] NOT NULL,
	[DefaultQuantity] [float] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Dirty] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 12/21/2015 22:40:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Balance] [float] NOT NULL,
	[Adjustment] [float] NOT NULL,
	[Tax] [float] NOT NULL,
	[IsCleared] [bit] NOT NULL,
	[PaymentMade] [float] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Dirty] [int] NOT NULL,
	[TotalAmount] [float] NOT NULL,
 CONSTRAINT [PK__Bill__3214EC07173876EA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK__GlobalSet__Accou__33D4B598]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[GlobalSetting]  WITH CHECK ADD  CONSTRAINT [FK__GlobalSet__Accou__33D4B598] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[GlobalSetting] CHECK CONSTRAINT [FK__GlobalSet__Accou__33D4B598]
GO
/****** Object:  ForeignKey [FK_Area_City]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Area]  WITH CHECK ADD  CONSTRAINT [FK_Area_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_Area_City]
GO
/****** Object:  ForeignKey [FK__Account_A__Accou__276EDEB3]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Account_Area_Mapping]  WITH CHECK ADD  CONSTRAINT [FK__Account_A__Accou__276EDEB3] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Account_Area_Mapping] CHECK CONSTRAINT [FK__Account_A__Accou__276EDEB3]
GO
/****** Object:  ForeignKey [FK__Account_A__AreaI__286302EC]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Account_Area_Mapping]  WITH CHECK ADD  CONSTRAINT [FK__Account_A__AreaI__286302EC] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Account_Area_Mapping] CHECK CONSTRAINT [FK__Account_A__AreaI__286302EC]
GO
/****** Object:  ForeignKey [FK__Customer__Accoun__2C3393D0]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK__Customer__Accoun__2C3393D0] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK__Customer__Accoun__2C3393D0]
GO
/****** Object:  ForeignKey [FK__Customer__AreaId__2D27B809]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK__Customer__AreaId__2D27B809] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK__Customer__AreaId__2D27B809]
GO
/****** Object:  ForeignKey [FK__Delivery__Accoun__300424B4]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK__Delivery__Accoun__300424B4] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK__Delivery__Accoun__300424B4]
GO
/****** Object:  ForeignKey [FK__Delivery__Custom__1CF15040]    Script Date: 12/21/2015 22:40:50 ******/
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
/****** Object:  ForeignKey [FK__CustomerS__Accou__2E1BDC42]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[CustomerSetting]  WITH CHECK ADD  CONSTRAINT [FK__CustomerS__Accou__2E1BDC42] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[CustomerSetting] CHECK CONSTRAINT [FK__CustomerS__Accou__2E1BDC42]
GO
/****** Object:  ForeignKey [FK__CustomerS__Custo__1ED998B2]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[CustomerSetting]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
/****** Object:  ForeignKey [FK__Bill__AccountId__2B3F6F97]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK__Bill__AccountId__2B3F6F97] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK__Bill__AccountId__2B3F6F97]
GO
/****** Object:  ForeignKey [FK__Bill__CustomerId__2A4B4B5E]    Script Date: 12/21/2015 22:40:51 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK__Bill__CustomerId__2A4B4B5E] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK__Bill__CustomerId__2A4B4B5E]
GO
