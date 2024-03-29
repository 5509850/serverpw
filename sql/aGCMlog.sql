USE [alexandr_gorbunov]
GO
/****** Object:  StoredProcedure [dbo].[aGCMlog]    Script Date: 01/06/2016 22:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[aGCMlog]
	-- Add the parameters for the stored procedure here
			@request nvarchar(50)
           ,@responce nvarchar(255)          
           ,@deviceID bigint
           ,@err nvarchar(50)
           ,@command nchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	INSERT INTO [aGcm]
           ([request]
           ,[responce]
           ,[datetimelog]
           ,[deviceID]
           ,[err]
           ,[command])
     VALUES
           (@request 
           ,@responce 
           ,GETDATE()
           ,@deviceID
           ,@err
           ,@command)
END
