USE [alexandr_gorbunov]
GO

/****** Object:  Table [dbo].[aGcm]    Script Date: 01/06/2016 22:23:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[aGcm](
	[gcmID] [bigint] IDENTITY(1,1) NOT NULL,
	[request] [nvarchar](50) NULL,
	[responce] [nvarchar](255) NULL,
	[datetimelog] [smalldatetime] NULL,
	[deviceID] [bigint] NULL,
	[err] [nvarchar](50) NULL,
	[command] [nchar](20) NULL,
 CONSTRAINT [PK_aGcm] PRIMARY KEY CLUSTERED 
(
	[gcmID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


