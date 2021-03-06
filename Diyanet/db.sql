USE [master]
GO
/****** Object:  Database [Diyanet]    Script Date: 29.11.2016 18:51:01 ******/
CREATE DATABASE [Diyanet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Diyanet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Diyanet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Diyanet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Diyanet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Diyanet] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Diyanet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Diyanet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Diyanet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Diyanet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Diyanet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Diyanet] SET ARITHABORT OFF 
GO
ALTER DATABASE [Diyanet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Diyanet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Diyanet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Diyanet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Diyanet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Diyanet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Diyanet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Diyanet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Diyanet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Diyanet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Diyanet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Diyanet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Diyanet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Diyanet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Diyanet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Diyanet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Diyanet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Diyanet] SET RECOVERY FULL 
GO
ALTER DATABASE [Diyanet] SET  MULTI_USER 
GO
ALTER DATABASE [Diyanet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Diyanet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Diyanet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Diyanet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Diyanet] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Diyanet', N'ON'
GO
ALTER DATABASE [Diyanet] SET QUERY_STORE = OFF
GO
USE [Diyanet]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Diyanet]
GO
/****** Object:  Table [dbo].[Sehir]    Script Date: 29.11.2016 18:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sehir](
	[No] [int] NOT NULL,
	[UlkeNo] [int] NOT NULL,
	[Ad] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Sehir] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ulke]    Script Date: 29.11.2016 18:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ulke](
	[No] [int] NOT NULL,
	[Ad] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Ulke] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vakit]    Script Date: 29.11.2016 18:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vakit](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[SehirNo] [int] NOT NULL,
	[Tarih] [date] NOT NULL,
	[Hicri] [nvarchar](max) NULL,
	[Imsak] [varchar](5) NOT NULL,
	[Gunes] [varchar](5) NOT NULL,
	[Ikindi] [varchar](5) NOT NULL,
	[Aksam] [varchar](5) NOT NULL,
	[Yatsi] [varchar](5) NOT NULL,
	[Kible] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Vakit] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Vakit]  WITH CHECK ADD  CONSTRAINT [FK_Vakit_Sehir] FOREIGN KEY([SehirNo])
REFERENCES [dbo].[Sehir] ([No])
GO
ALTER TABLE [dbo].[Vakit] CHECK CONSTRAINT [FK_Vakit_Sehir]
GO
/****** Object:  StoredProcedure [dbo].[InsertCountry]    Script Date: 29.11.2016 18:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hüseyin Sekmenoğlu
-- Create date: 29.11.2016
-- Description:	ülke ekler
-- =============================================
CREATE PROCEDURE [dbo].[InsertCountry]
	@No	int,
	@Ad nvarchar(MAX)

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Ulke] ([No],[Ad])
     VALUES (@No, @Ad)

END

GO
/****** Object:  StoredProcedure [dbo].[InsertState]    Script Date: 29.11.2016 18:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hüseyin Sekmenoğlu
-- Create date: 29.11.2016
-- Description:	sehir ekler
-- =============================================
CREATE PROCEDURE [dbo].[InsertState]
	@UlkeNo int,
	@No	int,
	@Ad nvarchar(MAX)

AS
BEGIN
	SET NOCOUNT ON;

INSERT INTO [dbo].[Sehir] ([No],[UlkeNo],[Ad])
     VALUES (@No, @UlkeNo, @Ad)

END


GO
USE [master]
GO
ALTER DATABASE [Diyanet] SET  READ_WRITE 
GO
