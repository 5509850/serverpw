USE [alexandr_gorbunov]
GO

/****** Object:  Table [dbo].[aLog]    Script Date: 01/07/2016 18:01:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[aLog](
	[LogID] [bigint] IDENTITY(1,1) NOT NULL,
	[ipAdress] [nvarchar](50) NULL,
	[LastLoginTime] [smalldatetime] NULL,
	[IsSuccess] [bit] NULL,
	[userID] [bigint] NULL,
	[code] [int] NULL,
	[DeviceID] [bigint] NULL,
	[macAddress] [nvarchar](50) NULL,
	[version] [nchar](10) NULL,
 CONSTRAINT [PK_aLog] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


