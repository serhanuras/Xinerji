/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [Xinerji-dc]    Script Date: 17.05.2018 23:22:29 ******/
CREATE DATABASE [Xinerji-dc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Xinerji-dc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Xinerji-dc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Xinerji-dc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Xinerji-dc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Xinerji-dc] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Xinerji-dc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Xinerji-dc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Xinerji-dc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Xinerji-dc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Xinerji-dc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Xinerji-dc] SET ARITHABORT OFF 
GO
ALTER DATABASE [Xinerji-dc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Xinerji-dc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Xinerji-dc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Xinerji-dc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Xinerji-dc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Xinerji-dc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Xinerji-dc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Xinerji-dc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Xinerji-dc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Xinerji-dc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Xinerji-dc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Xinerji-dc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Xinerji-dc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Xinerji-dc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Xinerji-dc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Xinerji-dc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Xinerji-dc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Xinerji-dc] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Xinerji-dc] SET  MULTI_USER 
GO
ALTER DATABASE [Xinerji-dc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Xinerji-dc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Xinerji-dc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Xinerji-dc] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Xinerji-dc] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Xinerji-dc] SET QUERY_STORE = OFF
GO
USE [Xinerji-dc]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Xinerji-dc]
GO
/****** Object:  User [xinerjiuser]    Script Date: 17.05.2018 23:22:29 ******/
CREATE USER [xinerjiuser] FOR LOGIN [xinerjiuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [xinerjiuser]
GO
/****** Object:  Table [dbo].[tbl_branches]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_branches](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyId] [bigint] NULL,
	[Name] [varchar](200) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
	[Location] [varchar](100) NULL,
	[Address] [varchar](500) NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_channel_logs]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_channel_logs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ChannelCode] [int] NULL,
	[SessionId] [bigint] NULL,
	[IsOutCall] [bit] NULL,
	[Url] [varchar](500) NULL,
	[ReturnCode] [int] NULL,
	[MethodName] [varchar](500) NULL,
	[Request] [varchar](2000) NULL,
	[Response] [varchar](2000) NULL,
	[ExceptionStackTrace] [varchar](2000) NULL,
	[InsertDateTime] [datetime] NULL,
 CONSTRAINT [PK_tbl_channel_logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_channels]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_channels](
	[Id] [int] NULL,
	[Code] [varchar](10) NULL,
	[NameTr] [varchar](200) NULL,
	[NameEng] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_cities]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_tbl_cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_companies]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_companies](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[Name] [varchar](100) NULL,
	[Address] [varchar](500) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Location] [varchar](100) NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_county]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_county](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_county] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_delivery_status]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_delivery_status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[Name] [varchar](100) NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_document_types]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_document_types](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[Type] [varchar](200) NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_error_description]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_error_description](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ChannelCode] [smallint] NULL,
	[ErrorCode] [int] NULL,
	[ErrorDescriptionTR] [varchar](500) NULL,
	[ErrorDescriptionENG] [varchar](500) NULL,
	[DateLastModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_firms]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_firms](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Address] [varchar](500) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Location] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_member_types]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_member_types](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[UserLevelId] [bigint] NULL,
	[Type] [varchar](200) NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_members]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_members](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[TCIdentifier] [varchar](11) NULL,
	[Name] [varchar](100) NULL,
	[MiddleName] [varchar](100) NULL,
	[Surname] [varchar](100) NULL,
	[Birthdate] [smalldatetime] NULL,
	[Email] [varchar](250) NULL,
	[CompanyId] [bigint] NULL,
	[Password] [varchar](1000) NULL,
	[Phone] [varchar](20) NULL,
	[MemberTypeId] [bigint] NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_messaging_queue]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_messaging_queue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[TemplatedId] [bigint] NULL,
	[ReceiverAddress] [varchar](200) NULL,
	[Subject] [varchar](1000) NULL,
	[Content] [varchar](max) NOT NULL,
	[Status] [int] NULL,
	[IsEncrypted] [bit] NULL,
	[RetryCount] [int] NULL,
	[AttemptCount] [int] NULL,
	[Priority] [int] NULL,
	[InsertDateTime] [datetime] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tbl_messaging_queue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_messaging_templates]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_messaging_templates](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[SubjectTr] [varchar](1000) NULL,
	[ContentTr] [varchar](max) NULL,
	[SubjectEng] [varchar](1000) NULL,
	[ContentEng] [varchar](max) NULL,
	[InsertDateTime] [datetime] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tbl_messaging_templates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_one_time_passwords]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_one_time_passwords](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NULL,
	[SessionId] [bigint] NULL,
	[MethodName] [varchar](500) NULL,
	[OtpEncryptedString] [varchar](500) NULL,
	[OtpStatus] [tinyint] NULL,
	[OtpAttemptCount] [int] NULL,
	[OtpRemaingAttemptCount] [int] NULL,
	[InsertDateTime] [datetime] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tbl_one_time_passwords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_order_details]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_order_details](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NULL,
	[ProductId] [bigint] NULL,
	[Quantity] [int] NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_order_documents]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_order_documents](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NULL,
	[DocumentTypeId] [bigint] NULL,
	[FileName] [varchar](250) NULL,
	[FileExtension] [varchar](10) NULL,
	[FileBinary] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_order_types]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_order_types](
	[Id] [bigint] NULL,
	[FirmId] [bigint] NULL,
	[Name] [varchar](200) NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_orders]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_orders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TripId] [bigint] NULL,
	[Title] [varchar](250) NULL,
	[Description] [varchar](1000) NULL,
	[CityId] [bigint] NULL,
	[BranchId] [bigint] NULL,
	[DeliveryStatusId] [bigint] NULL,
	[OrderTypeId] [bigint] NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_products]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[Name] [varchar](200) NULL,
	[Barcode] [varchar](100) NULL,
	[Weight] [int] NULL,
	[Height] [int] NULL,
	[Width] [int] NULL,
	[Volume] [int] NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_session]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_session](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NULL,
	[ChannelCode] [smallint] NULL,
	[Status] [int] NULL,
	[CreateDateTime] [datetime] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_session_data]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_session_data](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SessionId] [bigint] NULL,
	[Key] [varchar](50) NULL,
	[Value] [varchar](8000) NULL,
	[InsertDateTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_trips]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_trips](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[Name] [varchar](200) NULL,
	[TruckId] [bigint] NULL,
	[ConsigneeId] [bigint] NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_trucks]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_trucks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[MemberId] [bigint] NULL,
	[LicenceNo] [varchar](200) NULL,
	[Capacity] [int] NULL,
	[Model] [varchar](100) NULL,
	[Year] [int] NULL,
	[Plaque] [varchar](20) NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_truckstatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_truckstatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[Name] [varchar](100) NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_user_levels]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user_levels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirmId] [bigint] NULL,
	[Name] [varchar](100) NULL,
	[Status] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Index [idx_01]    Script Date: 17.05.2018 23:22:29 ******/
CREATE NONCLUSTERED INDEX [idx_01] ON [dbo].[tbl_error_description]
(
	[ErrorCode] ASC,
	[ChannelCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_02]    Script Date: 17.05.2018 23:22:29 ******/
CREATE NONCLUSTERED INDEX [idx_02] ON [dbo].[tbl_error_description]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_01]    Script Date: 17.05.2018 23:22:29 ******/
CREATE NONCLUSTERED INDEX [idx_01] ON [dbo].[tbl_messaging_queue]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_status]    Script Date: 17.05.2018 23:22:29 ******/
CREATE NONCLUSTERED INDEX [idx_status] ON [dbo].[tbl_messaging_queue]
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_template_id]    Script Date: 17.05.2018 23:22:29 ******/
CREATE NONCLUSTERED INDEX [idx_template_id] ON [dbo].[tbl_messaging_templates]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_01]    Script Date: 17.05.2018 23:22:29 ******/
CREATE NONCLUSTERED INDEX [idx_01] ON [dbo].[tbl_one_time_passwords]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_sessionId]    Script Date: 17.05.2018 23:22:29 ******/
CREATE NONCLUSTERED INDEX [idx_sessionId] ON [dbo].[tbl_session]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_01]    Script Date: 17.05.2018 23:22:29 ******/
CREATE NONCLUSTERED INDEX [idx_01] ON [dbo].[tbl_session_data]
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_02]    Script Date: 17.05.2018 23:22:29 ******/
CREATE NONCLUSTERED INDEX [idx_02] ON [dbo].[tbl_session_data]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_changeBranchStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeBranchStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_branches SET Status=@Status WHERE Id=@Id

	SELECT * FROM tbl_branches(nolock) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_changeCompanyStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeCompanyStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_companies SET Status=@Status WHERE Id=@Id

	SELECT * FROM tbl_companies(nolock) WHERE Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_changeDeliveryStatusState]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeDeliveryStatusState]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_delivery_status SET Status=@Status WHERE Id=@Id

	SELECT * FROM tbl_delivery_status(nolock) WHERE Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_changeDocumentTypeStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeDocumentTypeStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_document_types SET Status  =@Status WHERE Id=@Id

	SELECT * FROM tbl_document_types(nolock) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_changeMember]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeMember]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_members SET Status  =@Status WHERE Id=@Id

	SELECT * FROM tbl_members(nolock) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_changeMemberStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_changeMemberStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_members SET Status  =@Status WHERE Id=@Id

	SELECT * FROM tbl_members(nolock) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_changeMemberTypeStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeMemberTypeStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_member_types SET Status  =@Status WHERE Id=@Id

	SELECT * FROM tbl_member_types(nolock) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_changeOrderDetailStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeOrderDetailStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_order_details SET Status  = @Status WHERE Id=@Id

	SELECT * FROM tbl_order_details(nolock) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_changeOrderStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeOrderStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_orders SET Status  = @Status WHERE Id=@Id

	SELECT * FROM tbl_orders(nolock) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_changeOrderTypeStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeOrderTypeStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_order_types SET Status=@Status WHERE Id=@Id

	SELECT * FROM tbl_order_types(nolock) WHERE Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_changeProductStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeProductStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_products SET Status  =@Status WHERE Id=@Id

	SELECT * FROM tbl_products(nolock) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_changeSessionStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeSessionStatus]
	@Id BIGINT,
	@Status INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE tbl_session SET Status=@Status, LastModifiedDateTime=getdate() WHERE Id=@Id

 END
GO
/****** Object:  StoredProcedure [dbo].[usp_changeTripStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeTripStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_trips SET Status  =@Status WHERE Id=@Id

	SELECT * FROM tbl_trips(nolock) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_changeTruckStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeTruckStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_truckstatus SET Status=@Status WHERE Id=@Id

	SELECT * FROM tbl_truckstatus(nolock) WHERE Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_changeUserLevelStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_changeUserLevelStatus]
@Id BIGINT,
@Status INT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tbl_user_levels SET Status=@Status WHERE Id=@Id

	SELECT * FROM tbl_user_levels(nolock) WHERE Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_createSession]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_createSession]
	@CustomerId BIGINT,
	@ChannelCode SMALLINT,
	@Status INT,
	@CreatDateTime DATETIME,
	@LastModifiedDateTime DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO tbl_session(
			CustomerId, 
			ChannelCode, 
			CreateDateTime, 
			LastModifiedDateTime, 
			Status)
	VALUES(
		@CustomerId,
		@ChannelCode,
		@CreatDateTime,
		@LastModifiedDateTime, 
		@Status)

		SET @ID = SCOPE_IDENTITY() 

		SELECT * FROM tbl_session(NOLOCK) WHERE Id = @ID

 END

GO
/****** Object:  StoredProcedure [dbo].[usp_deleteOrderDocument]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_deleteOrderDocument]
@Id BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE FROM tbl_order_documents WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_deleteOrderMissingItem]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_deleteOrderMissingItem]
@Id BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE FROM tbl_order_missing_items WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_deleteOrderRepresenter]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_deleteOrderRepresenter]
@Id BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE FROM tbl_order_representers WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_findDescriptionByErrorCode]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		MSURAS
-- Create date: 20170928
-- Description:	findDescriptionByErrorCode
-- =============================================
CREATE PROCEDURE [dbo].[usp_findDescriptionByErrorCode]
	@ErrorCode INT,
	@ChannelCode INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM tbl_error_description(NOLOCK) WHERE ErrorCode = @ErrorCode and ChannelCode=@ChannelCode
END
GO
/****** Object:  StoredProcedure [dbo].[usp_findDescriptionById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		MSURAS
-- Create date: 20170928
-- Description:	findDescriptionById
-- =============================================
CREATE PROCEDURE [dbo].[usp_findDescriptionById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM tbl_error_description(NOLOCK) WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_findMessagingByStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_findMessagingByStatus]
	@Status INT,
	@ItemCount INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP(@ItemCount) * FROM tbl_messaging_queue(NOLOCK) WHERE Status = @Status ORDER BY Priority ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_findMessagingTemplate]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_findMessagingTemplate]
@Id BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM tbl_messaging_templates(NOLOCK) WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_findSession]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[usp_findSession]
	@Id BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM tbl_session(NOLOCK) WHERE Id=@Id

	UPDATE tbl_session SET LastModifiedDateTime = getDate() WHERE Id=@Id
	

 END
GO
/****** Object:  StoredProcedure [dbo].[usp_findSmsOtp]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_findSmsOtp]
	@Id BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM tbl_one_time_passwords(NOLOCK) WHERE Id=@Id

 END

GO
/****** Object:  StoredProcedure [dbo].[usp_getAllCompanies]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getAllCompanies]
@FirmId BIGINT
AS
BEGIN
	
	SELECT * FROM tbl_companies(NOLOCK) WHERE FirmId = @FirmId and Status=1

END

GO
/****** Object:  StoredProcedure [dbo].[usp_getAllMembers]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getAllMembers]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_members(nolock) WHERE FirmId = @FirmId and Status=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getAllProducts]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getAllProducts]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_products(nolock) WHERE FirmId = @FirmId and Status=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getBranchById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_getBranchById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_branches(nolock) WHERE Id= @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getBranchList]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getBranchList]
@CompanyId BIGINT,
@PageNumber INT,
@NumberOfItemsInPage INT,
@Data VARCHAR(200)
AS
BEGIN

	DECLARE @totalRecords as FLOAT
	SELECT * FROM tbl_branches (nolock) WHERE CompanyId= @CompanyId and Status=1 
		ORDER BY NAME OFFSET @NumberOfItemsInPage*@PageNumber ROWS FETCH NEXT @NumberOfItemsInPage ROWS ONLY;

	SELECT @totalRecords = count(1) FROM tbl_branches(NOLOCK) WHERE CompanyId= @CompanyId and Status=1  

	SELECT CEILING(@totalRecords/@NumberOfItemsInPage) as PageCount
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getByLogonCrendetial]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_getByLogonCrendetial]
@Email		varchar(250),
@Password	varchar(1000)
AS
BEGIN
	SELECT * FROM tbl_members(NOLOCK) WHERE Email = @Email and Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getChannelList]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getChannelList]

AS
BEGIN
SET NOCOUNT ON;

	SELECT * FROM tbl_channels(NOLOCK)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_getCityList]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getCityList]
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM tbl_cities(NOLOCK) 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getCompanies]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getCompanies]
@FirmId BIGINT,
@PageNumber INT,
@NumberOfItemsInPage INT
AS
BEGIN
	DECLARE @totalRecords as FLOAT
	SELECT * FROM tbl_companies (nolock) WHERE FirmId = @FirmId and Status=1
		ORDER BY NAME OFFSET @NumberOfItemsInPage*@PageNumber ROWS FETCH NEXT @NumberOfItemsInPage ROWS ONLY;

	SELECT @totalRecords = count(1) FROM tbl_companies(NOLOCK) WHERE FirmId = @FirmId and Status=1

	SELECT CEILING(@totalRecords/@NumberOfItemsInPage) as PageCount
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getCompanyById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getCompanyById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_companies(nolock) WHERE Id= @Id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getCountyList]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getCountyList]
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM tbl_county(NOLOCK) 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getDeliveryStatusList]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getDeliveryStatusList]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_delivery_status(nolock) WHERE FirmId= @FirmId and Status=1
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getDocumentTypeById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getDocumentTypeById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_document_types(nolock) WHERE Id= @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getDocumentTypes]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getDocumentTypes]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_document_types(nolock) WHERE FirmId = @FirmId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getMemberById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getMemberById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_members(nolock) WHERE Id= @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getMembers]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getMembers]
@FirmId BIGINT,
@PageNumber INT,
@NumberOfItemsInPage INT
AS
BEGIN
	DECLARE @totalRecords as FLOAT
	SELECT * FROM tbl_members (nolock) WHERE FirmId = @FirmId and Status=1
		ORDER BY NAME OFFSET @NumberOfItemsInPage*@PageNumber ROWS FETCH NEXT @NumberOfItemsInPage ROWS ONLY;

	SELECT @totalRecords = count(1) FROM tbl_members(NOLOCK) WHERE FirmId = @FirmId and Status=1

	SELECT CEILING(@totalRecords/@NumberOfItemsInPage) as PageCount
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getMemberTypeById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_getMemberTypeById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_member_types(nolock) WHERE Id= @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getMemberTypes]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getMemberTypes]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_member_types(nolock) WHERE FirmId = @FirmId and Status = 1
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getMessagingByReceiver]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_getMessagingByReceiver]
@TopCount smallint,
@ReceiverEmail varchar(200),
@ReceiverCellPhone varchar(200)
AS
BEGIN
select top (@TopCount) * from [dbo].[tbl_messaging_queue] where ReceiverAddress in (@ReceiverEmail,@ReceiverCellPhone) order by 1 desc
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrderById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_orders(nolock) WHERE Id= @Id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderDetailById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrderDetailById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_details(nolock) WHERE Id= @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderDetails]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrderDetails]
@OrderId BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_details(nolock) WHERE OrderId = @OrderId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderDocumentById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrderDocumentById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_documents(nolock) WHERE Id= @Id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderDocuments]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrderDocuments]
@OrderId BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_documents(nolock) WHERE OrderId = @OrderId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderMissingItemById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrderMissingItemById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_missing_items(nolock) WHERE Id= @Id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderMissingItems]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrderMissingItems]
@OrderId BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_missing_items(nolock) WHERE OrderId = @OrderId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderRepresenter]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_getOrderRepresenter]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_representers(nolock) WHERE Id= @Id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderRepresenterById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_getOrderRepresenterById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_representers(nolock) WHERE Id= @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderRepresenters]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrderRepresenters]
@OrderId BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_representers(nolock) WHERE OrderId = @OrderId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getOrders]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrders]
@TripId BIGINT
AS
BEGIN
	SELECT * FROM tbl_orders(nolock) WHERE TripId = @TripId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getOrderTypes]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getOrderTypes]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_order_types(nolock) WHERE FirmId= @FirmId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getProductById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_getProductById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_products(nolock) WHERE Id= @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getProducts]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getProducts]
@FirmId BIGINT,
@PageNumber INT,
@NumberOfItemsInPage INT
AS
BEGIN
	DECLARE @totalRecords as FLOAT
	SELECT * FROM tbl_products (nolock) WHERE FirmId = @FirmId and Status=1
		ORDER BY NAME OFFSET @NumberOfItemsInPage*@PageNumber ROWS FETCH NEXT @NumberOfItemsInPage ROWS ONLY;

	SELECT @totalRecords = count(1) FROM tbl_products(NOLOCK) WHERE FirmId = @FirmId and Status=1

	SELECT CEILING(@totalRecords/@NumberOfItemsInPage) as PageCount
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getSessionData]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getSessionData]
@SessionId BIGINT
AS
BEGIN
	SET NOCOUNT ON;

		SELECT * FROM tbl_session_data(NOLOCK) WHERE sessionId = @SessionId
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getTripById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_getTripById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_trips(nolock) WHERE Id= @Id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getTrips]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getTrips]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_trips(nolock) WHERE FirmId = @FirmId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getTruckById]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getTruckById]
@Id BIGINT
AS
BEGIN
	SELECT * FROM tbl_trucks(nolock) WHERE Id= @Id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getTrucks]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getTrucks]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_trucks(nolock) WHERE FirmId = @FirmId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_getTruckStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getTruckStatus]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_truckstatus(nolock) WHERE FirmId= @FirmId and status=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getUserLevels]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getUserLevels]
@FirmId BIGINT
AS
BEGIN
	SELECT * FROM tbl_user_levels(nolock) WHERE FirmId= @FirmId
END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertBranch]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertBranch]
@CompanyId		bigint,
@Name			varchar(200),
@Phone			varchar(50),
@Email			varchar(200),
@Location		varchar(100),
@Address		varchar(500),
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_branches(
		CompanyId,
		Name,
		Phone,
		Email,
		Location,
		Address,
		Status)
	VALUES(
		@CompanyId,
		@Name,
		@Phone,
		@Email,
		@Location,
		@Address,
		@Status)



	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_branches(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertCompany]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertCompany]
@FirmId		bigint,
@Name		varchar(100),
@Address	varchar(500),
@Email		varchar(100),
@Phone		varchar(20),
@Location	varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_companies(
		FirmId,
		Name,
		Address,
		Email,
		Phone,
		Location,
		Status)
	VALUES(
		@FirmId,
		@Name,
		@Address,
		@Email,
		@Phone,
		@Location,
		@Status)



	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_companies(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertDeliveryStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertDeliveryStatus]
@FirmId		bigint,
@Name		varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_delivery_status(
		FirmId,
		Name,
		Status)
	VALUES(
		@FirmId,
		@Name,
		@Status)



	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_delivery_status(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertDocumentType]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertDocumentType]
@FirmId			bigint,
@Type			varchar(200),
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_document_types(
		FirmId,
		Type,
		Status)
	VALUES(
		@FirmId,
		@Type,
		@Status)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_document_types(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertMember]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertMember]
@FirmId			bigint,
@TCIdentifier	varchar(11),
@Name			varchar(100),
@MiddleName		varchar(100),
@Surname		varchar(100),
@Birthdate		datetime,
@Email			varchar(250),
@CompanyId		bigint,
@Password		varchar(1000),
@Phone			varchar(20),
@MemberTypeId	bigint,
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_members(
		FirmId,
		TCIdentifier,
		Name,
		MiddleName,
		Surname,
		Birthdate,
		Email,
		CompanyId,
		Password,
		Phone,
		MemberTypeId,
		Status)
	VALUES(
		@FirmId,
		@TCIdentifier,
		@Name,
		@MiddleName,
		@Surname,
		@Birthdate,
		@Email,
		@CompanyId,
		@Password,
		@Phone,
		@MemberTypeId,
		@Status)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_members(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertMemberType]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertMemberType]
@FirmId			bigint,
@UserLevelId	bigint,
@Type			varchar(200),
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_member_types(
		FirmId,
		UserLevelId,
		Type,
		Status)
	VALUES(
		@FirmId,
		@UserLevelId,
		@Type,
		@Status)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_member_types(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertMessaging]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertMessaging]
	@TemplatedId BIGINT,
	@Type INT,
	@ReceiverAddress VARCHAR(200),
	@Subject VARCHAR(1000),
	@Content VARCHAR(MAX),
	@Status INT,
	@IsEncrypted BIT,
	@RetryCount INT,
	@AttemptCount INT,
	@Priority INT,
	@InsertDateTime datetime,
	@LastModifiedDateTime datetime

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tbl_messaging_queue(TemplatedId,Type, ReceiverAddress,Subject,Content, Status, IsEncrypted, RetryCount, AttemptCount, Priority, InsertDateTime, LastModifiedDateTime)
		VALUES(@TemplatedId, @Type, @ReceiverAddress,@Subject,@Content, @Status, @IsEncrypted, @RetryCount, @AttemptCount, @Priority, @InsertDateTime, @LastModifiedDateTime )


 END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertOrder]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertOrder]
@TripId				bigint,
@Title				varchar(250),
@Description		varchar(1000),
@CityId				bigint,
@BranchId			bigint,
@DeliveryStatusId	bigint,
@OrderTypeId		bigint,
@Status				tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_orders(
		TripId,
		Title,
		Description,
		CityId,
		BranchId,
		DeliveryStatusId,
		OrderTypeId,
		Status)
	VALUES(
		@TripId,
		@Title,
		@Description,
		@CityId,
		@BranchId,
		@DeliveryStatusId,
		@OrderTypeId,
		@Status)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_orders(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertOrderDetail]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_insertOrderDetail]
@OrderId		bigint,
@ProductId		bigint,
@Quantity		int,
@Status			int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_order_details(
		OrderId,
		ProductId,
		Quantity,
		Status)
	VALUES(
		@OrderId,
		@ProductId,
		@Quantity,
		@Status)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_order_details(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertOrderDocument]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertOrderDocument]
@OrderId			bigint,
@DocumentTypeId		bigint,
@FileName			varchar(250),
@FileExtension		varchar(10),
@FileBinary			varchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_order_documents(
		OrderId,
		DocumentTypeId,
		FileName,
		FileExtension,
		FileBinary)
	VALUES(
		@OrderId,
		@DocumentTypeId,
		@FileName,
		@FileExtension,
		@FileBinary)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_order_documents(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertOrderMissingItem]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertOrderMissingItem]
@OrderId			bigint,
@OrderDetailId		bigint,
@Quantity			int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_order_missing_items(
		OrderId,
		OrderDetailId,
		Quantity)
	VALUES(
		@OrderId,
		@OrderDetailId,
		@Quantity)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_order_missing_items(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertOrderRepresenter]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertOrderRepresenter]
@OrderId			bigint,
@RepresenterId		bigint,
@Level				int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_order_representers(
		OrderId,
		RepresenterId,
		[Level])
	VALUES(
		@OrderId,
		@RepresenterId,
		@Level)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_order_representers(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertOrderType]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_insertOrderType]
@FirmId		bigint,
@Name		varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_order_types(
		FirmId,
		Name,
		Status)
	VALUES(
		@FirmId,
		@Name,
		@Status)



	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_order_types(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertProduct]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_insertProduct]
@FirmId		bigint,
@Name			varchar(200),
@Barcode		varchar(100),
@Weight			int,
@Height			int,
@Width			int,
@Volume			int,
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_products(
		FirmId,
		Name,
		Barcode,
		Weight,
		Height,
		Width,
		Volume,
		Status)
	VALUES(
		@FirmId,
		@Name,
		@Barcode,
		@Weight,
		@Height,
		@Width,
		@Volume,
		@Status)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_products(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertSessionData]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertSessionData]
@SessionId BIGINT,
@Key VARCHAR(50),
@Value VARCHAR(8000),
@InsertDateTime DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO tbl_session_data(SessionId, [Key], [Value], InsertDateTime)
		VALUES(@SessionId, @Key, @Value, @InsertDateTime)

	SET @ID = SCOPE_IDENTITY() 

		SELECT * FROM tbl_session_data(NOLOCK) WHERE Id = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertSmsOtp]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertSmsOtp]
	@CustomerId BIGINT,
	@SessionId BIGINT,
	@MethodName VARCHAR(500),
	@OtpEncryptedString VARCHAR(500),
	@OtpStatus TINYINT,
	@OtpAttemptCount INT,
	@OtpRemaingAttemptCount INT,
	@InsertDate DATETIME,
	@LastModifiedDate DATETIME
AS
BEGIN
	DECLARE @ID BIGINT

	INSERT INTO tbl_one_time_passwords(CustomerId, SessionId, MethodName, OtpEncryptedString, OtpStatus, OtpAttemptCount, OtpRemaingAttemptCount, InsertDateTime, LastModifiedDateTime)
	VALUES(@CustomerId, @SessionId, @MethodName, @OtpEncryptedString, @OtpStatus, @OtpAttemptCount, @OtpRemaingAttemptCount, @InsertDate, @LastModifiedDate)

	SET @ID=  SCOPE_IDENTITY() 

	SELECT * FROM tbl_one_time_passwords(NOLOCK) WHERE Id=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertTrip]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertTrip]
@FirmId			bigint,
@Name			varchar(200),
@TruckId		bigint,
@ConsigneeId	bigint,
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_trips(
		FirmId,
		Name,
		TruckId,
		ConsigneeId,
		Status)
	VALUES(
		@FirmId,
		@Name,
		@TruckId,
		@ConsigneeId,
		@Status)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_trips(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertTruck]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertTruck]
@FirmId			bigint,
@MemberId		bigint,
@LicenceNo		varchar(200),
@Capacity		int,
@Model			varchar(100),
@Year			int,
@Plaque			varchar(20),
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_trucks(
		FirmId,
		MemberId,
		LicenceNo,
		Capacity,
		Model,
		Year,
		Plaque,
		Status)
	VALUES(
		@FirmId,
		@MemberId,
		@LicenceNo,
		@Capacity,
		@Model,
		@Year,
		@Plaque,
		@Status)


	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_trucks(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertTruckStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertTruckStatus]
@FirmId		bigint,
@Name		varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_truckstatus(
		FirmId,
		Name,
		Status)
	VALUES(
		@FirmId,
		@Name,
		@Status)



	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_truckstatus(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertUserLevel]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_insertUserLevel]
@FirmId		bigint,
@Name		varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID BIGINT

	INSERT INTO 
	tbl_user_levels(
		FirmId,
		Name,
		Status)
	VALUES(
		@FirmId,
		@Name,
		@Status)



	SET @ID = SCOPE_IDENTITY() 

	SELECT * FROM tbl_user_levels(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_logChannelRequest]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_logChannelRequest]
	@ChannelCode int,
	@SessionId BIGINT,
	@IsOutCall INT,
	@Url VARCHAR(500),
	@MethodName VARCHAR(500),
	@ReturnCode INT,
	@JsonRequest VARCHAR(2000),
	@JsonResponse VARCHAR(2000),
	@ExceptionStackTrace VARCHAR(2000),
	@InsertDateTime DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tbl_channel_logs(ChannelCode, SessionId, IsOutCall, Url, MethodName, Request, Response, InsertDateTime, ReturnCode, ExceptionStackTrace)
	VALUES(@ChannelCode,@SessionId, @IsOutCall, @Url,  @MethodName, @JsonRequest, @JsonResponse,@InsertDateTime, @ReturnCode, @ExceptionStackTrace)
	
END
GO
/****** Object:  StoredProcedure [dbo].[usp_searchBranches]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_searchBranches]
@CompanyId BIGINT,
@PageNumber INT,
@NumberOfItemsInPage INT,
@Data VARCHAR(200)
AS
BEGIN

	DECLARE @totalRecords as FLOAT
	SELECT * FROM tbl_branches (nolock) WHERE CompanyId= @CompanyId and Status=1  and Name like '%' + @Data + '%'
		ORDER BY NAME OFFSET @NumberOfItemsInPage*@PageNumber ROWS FETCH NEXT @NumberOfItemsInPage ROWS ONLY;

	SELECT @totalRecords = count(1) FROM tbl_branches(NOLOCK) WHERE CompanyId= @CompanyId and Status=1  and Name like '%' + @Data + '%'

	SELECT CEILING(@totalRecords/@NumberOfItemsInPage) as PageCount
END
GO
/****** Object:  StoredProcedure [dbo].[usp_searchCompanies]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_searchCompanies]
@FirmId BIGINT,
@PageNumber INT,
@NumberOfItemsInPage INT,
@Data VARCHAR(200)

AS
BEGIN

	DECLARE @totalRecords as FLOAT
	SELECT * FROM tbl_companies (nolock) WHERE FirmId = @FirmId and Status=1  and Name like '%' + @Data + '%'
		ORDER BY NAME OFFSET @NumberOfItemsInPage*@PageNumber ROWS FETCH NEXT @NumberOfItemsInPage ROWS ONLY;

	SELECT @totalRecords = count(1) FROM tbl_companies(NOLOCK) WHERE FirmId = @FirmId and Status=1  and Name like '%' + @Data + '%'

	SELECT CEILING(@totalRecords/@NumberOfItemsInPage) as PageCount
END

GO
/****** Object:  StoredProcedure [dbo].[usp_searchDeliveryStatusList]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_searchDeliveryStatusList]
@FirmId BIGINT,
@Data VARCHAR(200)
AS
BEGIN
	SELECT * FROM tbl_delivery_status(nolock) WHERE FirmId= @FirmId and Status=1 and Name like '%' + @Data + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[usp_searchMembers]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_searchMembers]
@FirmId BIGINT,
@PageNumber INT,
@NumberOfItemsInPage INT,
@Data VARCHAR(200)
AS
BEGIN
	DECLARE @totalRecords as FLOAT
	SELECT * FROM tbl_members (nolock) WHERE FirmId = @FirmId and Status=1 and TCIdentifier like '%' + @Data + '%' or (@Data like  Name + '%' and @Data like '%' + Surname)
		ORDER BY NAME OFFSET @NumberOfItemsInPage*@PageNumber ROWS FETCH NEXT @NumberOfItemsInPage ROWS ONLY;

	SELECT @totalRecords = count(1) FROM tbl_members(NOLOCK) WHERE FirmId = @FirmId and Status=1 and TCIdentifier like '%' + @Data + '%' or (@Data like  Name + '%' and @Data like '%' + Surname)

	SELECT CEILING(@totalRecords/@NumberOfItemsInPage) as PageCount
END

GO
/****** Object:  StoredProcedure [dbo].[usp_searchMemberTypes]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_searchMemberTypes]
@FirmId BIGINT,
@Data VARCHAR(200)
AS
BEGIN
	SELECT * FROM tbl_member_types(nolock) WHERE FirmId = @FirmId and Status = 1 and Type like '%' + @Data + '%' order  by Type asc
END


GO
/****** Object:  StoredProcedure [dbo].[usp_searchProductByBarcode]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_searchProductByBarcode]
@FirmId BIGINT,
@Barcode VARCHAR(200)
AS
BEGIN
	SELECT * FROM tbl_products(nolock) WHERE FirmId = @FirmId and Status=1 and Barcode = @Barcode
END
GO
/****** Object:  StoredProcedure [dbo].[usp_searchProducts]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_searchProducts]
@FirmId BIGINT,
@PageNumber INT,
@NumberOfItemsInPage INT,
@Data VARCHAR(200)
AS
BEGIN
	DECLARE @totalRecords as FLOAT
	SELECT * FROM tbl_products (nolock) WHERE FirmId = @FirmId and Status=1 and Name like '%' + @Data + '%' or Barcode like '%' +  @Data + '%'
		ORDER BY NAME OFFSET @NumberOfItemsInPage*@PageNumber ROWS FETCH NEXT @NumberOfItemsInPage ROWS ONLY;

	SELECT @totalRecords = count(1) FROM tbl_products(NOLOCK) WHERE FirmId = @FirmId and Status=1 and Name like '%' + @Data + '%' or Barcode like '%' +  @Data + '%'

	SELECT CEILING(@totalRecords/@NumberOfItemsInPage) as PageCount
END
GO
/****** Object:  StoredProcedure [dbo].[usp_searchTruckStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_searchTruckStatus]
@FirmId BIGINT,
@Data VARCHAR(200)
AS
BEGIN
	SELECT * FROM tbl_truckstatus(nolock) WHERE FirmId= @FirmId and Status=1 and Name like '%' + @Data + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateBranch]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateBranch]
@Id			bigint,
@CompanyId		bigint,
@Name			varchar(200),
@Phone			varchar(50),
@Email			varchar(200),
@Location		varchar(100),
@Address		varchar(500),
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_branches SET
		CompanyId = @CompanyId,
		Name = @Name,
		Phone = @Phone,
		Email = @Email,
		Location = @Location,
		Address = @Address,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_branches(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateCompany]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_updateCompany]
@Id			bigint,
@Name		varchar(100),
@Address	varchar(500),
@Email		varchar(100),
@Phone		varchar(20),
@Location	varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_companies SET
		Name = @Name,
		Address = @Address,
		Email = @Email,
		Phone = @Phone,
		Location = @Location,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_companies(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateDeliveryStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_updateDeliveryStatus]
@Id			bigint,
@Name		varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_delivery_status SET
		Name = @Name,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_delivery_status(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateDocumentType]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateDocumentType]
@Id				bigint,
@Type			varchar(200),
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_member_types SET
		Type = @Type,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_document_types(NOLOCK) WHERE Id = @ID

END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateMember]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateMember]
@Id				bigint,
@TCIdentifier	varchar(11),
@Name			varchar(100),
@MiddleName		varchar(100),
@Surname		varchar(100),
@Birthdate		datetime,
@Email			varchar(250),
@CompanyId		bigint,
@Password		varchar(1000),
@Phone			varchar(20),
@MemberTypeId	bigint,
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_members SET
		TCIdentifier = @TCIdentifier,
		Name = @Name,
		MiddleName = @MiddleName,
		Surname = @Surname,
		Birthdate = @Birthdate,
		Email = @Email,
		CompanyId = @CompanyId,
		Password = @Password,
		Phone = @Phone,
		MemberTypeId = @MemberTypeId,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_members(NOLOCK) WHERE Id = @ID

END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateMemberPassword]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateMemberPassword]
@Id				bigint,
@Password		varchar(1000)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_members SET
		Password = @Password
	WHERE 
		ID = @Id


	SELECT * FROM tbl_members(NOLOCK) WHERE Id = @ID

END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateMemberType]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateMemberType]
@Id				bigint,
@UserLevelId	bigint,
@Type			varchar(200),
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_member_types SET
		UserLevelId = @UserLevelId,
		Type = @Type,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_member_types(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateMessagingAttemptCount]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateMessagingAttemptCount]
	@Id BIGINT,
	@Status INT,
	@AttemptCount INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE tbl_messaging_queue SET Status=@Status, LastModifiedDateTime=getdate(), AttemptCount=@AttemptCount WHERE Id=@Id

 END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateMessagingSatusAndResend]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[usp_updateMessagingSatusAndResend]
 	@Id BIGINT,
	@Status int
AS
BEGIN
	SET NOCOUNT ON;
	update tbl_messaging_queue set Status=@Status, LastModifiedDateTime = getdate() where Id=@Id and Status=0;

 insert into tbl_messaging_queue(Type,TemplatedId,ReceiverAddress,Subject,Content,Status,IsEncrypted,RetryCount,AttemptCount,Priority,InsertDateTime,LastModifiedDateTime)
 select Type,TemplatedId,ReceiverAddress,Subject,Content,0,IsEncrypted,5,0,Priority,getdate(),getdate() from tbl_messaging_queue where Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateOrder]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateOrder]
@Id					bigint,
@Title				varchar(250),
@Description		varchar(1000),
@CityId				bigint,
@BranchId			bigint,
@DeliveryStatusId	bigint,
@OrderTypeId		bigint,
@Status				tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_orders SET
		Title = @Title,
		Description = @Description,
		CityId = @CityId,
		BranchId = @BranchId,
		DeliveryStatusId = @DeliveryStatusId,
		OrderTypeId = @OrderTypeId,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_orders(NOLOCK) WHERE Id = @ID

END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateOrderDetail]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateOrderDetail]
@Id					bigint,
@OrderId		bigint,
@ProductId		bigint,
@Quantity		int,
@Status			int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_order_details SET
		OrderId = @OrderId,
		ProductId = @ProductId,
		Quantity = @Quantity,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_order_details(NOLOCK) WHERE Id = @ID

END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateOrderDocument]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateOrderDocument]
@Id					bigint,
@OrderId			bigint,
@DocumentTypeId		bigint,
@FileName			varchar(250),
@FileExtension		varchar(10),
@FileBinary			varchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_order_documents SET
		OrderId = @OrderId,
		DocumentTypeId = @DocumentTypeId,
		FileName = @FileName,
		FileExtension = @FileExtension,
		FileBinary =@FileBinary
	WHERE 
		ID = @Id


	SELECT * FROM tbl_order_documents(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateOrderMissingItem]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateOrderMissingItem]
@Id					bigint,
@OrderId			bigint,
@OrderDetailId		bigint,
@Quantity			int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_order_missing_items SET
		OrderId = @OrderId,
		OrderDetailId = @OrderDetailId,
		Quantity = @Quantity
	WHERE 
		ID = @Id


	SELECT * FROM tbl_order_missing_items(NOLOCK) WHERE Id = @ID

END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateOrderRepresenter]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateOrderRepresenter]
@Id					bigint,
@OrderId			bigint,
@RepresenterId		bigint,
@Level				int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_order_representers SET
		OrderId = @OrderId,
		RepresenterId = @RepresenterId,
		Level = @Level
	WHERE 
		ID = @Id


	SELECT * FROM tbl_order_representers(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateOrderType]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateOrderType]
@Id			bigint,
@Name		varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_order_types SET
		Name = @Name,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_order_types(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateOtpAttemptCount]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateOtpAttemptCount]
	@Id BIGINT

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE tbl_one_time_passwords SET OtpAttemptCount = OtpAttemptCount + 1 , OtpRemaingAttemptCount = OtpRemaingAttemptCount -1  WHERE Id=@Id

	SELECT * FROM tbl_one_time_passwords(NOLOCK) WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateProduct]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateProduct]
@Id				bigint,
@Name			varchar(200),
@Barcode		varchar(100),
@Weight			int,
@Height			int,
@Width			int,
@Volume			int,
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_products SET
		Name = @Name,
		Barcode = @Barcode,
		Weight = @Weight,
		Height = @Height,
		Width = @Width,
		Volume = @Volume,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_products(NOLOCK) WHERE Id = @ID

END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateSessionData]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateSessionData]
@Id BIGINT,
@Value VARCHAR(8000)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE tbl_session_data SET [Value] = @Value, InsertDateTime=GETDATE() WHERE Id  = @Id
		
	SELECT * FROM tbl_session_data(NOLOCK) WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateTrip]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateTrip]
@Id				bigint,
@Name			varchar(200),
@TruckId		bigint,
@ConsigneeId	bigint,
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_trips SET
		Name = @Name,
		TruckId = @TruckId,
		ConsigneeId = @ConsigneeId,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_trips(NOLOCK) WHERE Id = @ID

END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateTruck]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateTruck]
@Id				bigint,
@MemberId		bigint,
@LicenceNo		varchar(200),
@Capacity		int,
@Model			varchar(100),
@Year			int,
@Plaque			varchar(20),
@Status			tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_trucks SET
		MemberId = @MemberId,
		LicenceNo = @LicenceNo,
		Capacity = @Capacity,
		Model = @Model,
		Year = @Year,
		Plaque = @Plaque,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_trucks(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateTruckStatus]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateTruckStatus]
@Id			bigint,
@Name		varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_truckstatus SET
		Name = @Name,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_truckstatus(NOLOCK) WHERE Id = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateUserLevel]    Script Date: 17.05.2018 23:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateUserLevel]
@Id			bigint,
@Name		varchar(100),
@Status		tinyint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
	tbl_user_levels SET
		Name = @Name,
		Status = @Status
	WHERE 
		ID = @Id


	SELECT * FROM tbl_user_levels(NOLOCK) WHERE Id = @ID

END
GO
USE [master]
GO
ALTER DATABASE [Xinerji-dc] SET  READ_WRITE 
GO
