USE [alexandr_gorbunov]
GO

/****** Object:  Table [dbo].[aUser]    Script Date: 01/05/2016 22:45:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[aUser](
	[userID] [bigint] IDENTITY(1,1) NOT NULL,
	[aUser] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[pwd] [nvarchar](50) NULL,
	[dateRegistration] [smalldatetime] NULL,
	[balance] [int] NULL,
	[isBlocked] [bit] NOT NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_aUser] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


