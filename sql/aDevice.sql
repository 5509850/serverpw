USE [alexandr_gorbunov]
GO

/****** Object:  Table [dbo].[aDevice]    Script Date: 01/07/2016 18:18:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[aDevice](
	[deviceID] [bigint] IDENTITY(1,1) NOT NULL,
	[TypeDeviceID] [int] NULL,
	[userID] [bigint] NULL,
	[Token] [nvarchar](512) NULL,
	[AndroidIDMacaddress] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[dateCreate] [smalldatetime] NULL,
	[isActive] [bit] NULL,
	[version] [nchar](10) NULL,
 CONSTRAINT [PK_aDevice] PRIMARY KEY CLUSTERED 
(
	[deviceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


