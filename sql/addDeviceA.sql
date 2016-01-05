USE [alexandr_gorbunov]
GO

/****** Object:  StoredProcedure [dbo].[addDeviceA]    Script Date: 01/05/2016 22:41:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[addDeviceA] 
	-- Add the parameters for the stored procedure here
	@deviceID BIGINT, 
	@codeA INT,
	@codeB INT,
	@name nvarchar(50)
AS
BEGIN

--clear all records by user id
UPDATE [dbo].[aRegistrationHost]
   SET [isActive] = 0  WHERE userID = (SELECT TOP 1 [userID]  FROM [aDevice] where [deviceID] = @deviceID AND [isActive] = 1)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO [aRegistrationHost]
           ([deviceID]
           ,[userID]
           ,[codeA]
           ,[codeB]
           ,[isActive]           
           ,[dateGetCodeA]
           ,[name])
     VALUES
           (@deviceID
           ,(SELECT TOP 1 [userID]  FROM [aDevice] where [deviceID] = @deviceID AND [isActive] = 1)
           ,@codeA
           ,@codeB
           ,1
           ,GETDATE()
           ,@name)

    -- Insert statements for procedure here
	SELECT @@IDENTITY AS 'ID'
END

GO


