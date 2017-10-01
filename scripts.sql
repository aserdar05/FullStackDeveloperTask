/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [CountryDb]
GO
/****** Object:  User [SERDARAY]    Script Date: 1.10.2017 13:53:18 ******/
CREATE USER [SERDARAY] FOR LOGIN [SERDARAY] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [SERDARAY]
GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 1.10.2017 13:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](10) NOT NULL,
	[FULLNAME] [nvarchar](100) NOT NULL,
	[CODE] [nvarchar](10) NOT NULL,
	[CURRENCY] [nvarchar](50) NOT NULL,
	[FLAG] [nvarchar](50) NOT NULL,
	[LANGUAGE] [nvarchar](50) NOT NULL,
	[CAPITALCITY] [nvarchar](50) NOT NULL,
	[POPULATION] [bigint] NOT NULL,
	[REGION] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[COUNTRY] ON 

INSERT [dbo].[COUNTRY] ([ID], [NAME], [FULLNAME], [CODE], [CURRENCY], [FLAG], [LANGUAGE], [CAPITALCITY], [POPULATION], [REGION]) VALUES (1, N'Almanya', N'Almanya', N'009', N'EURO', N'sad', N'ALMANCA', N'Münich', 84235120, N'EUROPE')
SET IDENTITY_INSERT [dbo].[COUNTRY] OFF
