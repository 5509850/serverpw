USE [alexandr_gorbunov]
GO

/****** Object:  Table [dbo].[aRegistrationHost]    Script Date: 01/05/2016 22:45:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[aRegistrationHost](
	[registrationHostID] [bigint] IDENTITY(1,1) NOT NULL,
	[deviceID] [bigint] NULL,
	[userID] [bigint] NULL,
	[codeA] [int] NULL,
	[codeB] [int] NULL,
	[isActive] [bit] NULL,
	[typeDeviceID] [int] NULL,
	[Token] [nvarchar](50) NULL,
	[AndroidID] [nvarchar](50) NULL,
	[macaddress] [nvarchar](50) NULL,
	[dateGetCodeA] [smalldatetime] NULL,
	[dateGetCodeB] [smalldatetime] NULL,
	[dateFinished] [smalldatetime] NULL,
	[name] [nvarchar](50) NULL,
	[dateErrorCodeB] [smalldatetime] NULL,
	[errorscont] [int] NULL,
 CONSTRAINT [PK_aRegistrationHost] PRIMARY KEY CLUSTERED 
(
	[registrationHostID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


