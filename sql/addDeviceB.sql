USE [alexandr_gorbunov]
GO

/****** Object:  StoredProcedure [dbo].[addDeviceB]    Script Date: 01/05/2016 22:42:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[addDeviceB]
	@TypeDeviceID INT, 
	@Token nvarchar(50),
	@AndroidID nvarchar(50),
	@macaddress nvarchar(50),
	@codeA INT,	
	@ipAdress nvarchar(50) --??????????? for log??????
	
AS
BEGIN
	
	UPDATE [aRegistrationHost]
   SET 
      [typeDeviceID] = @TypeDeviceID
      ,[Token] = @Token
      ,[AndroidID] = @AndroidID
      ,[macaddress] = @macaddress
      ,[dateGetCodeB] = GETDATE()
      
 WHERE [isActive] = 1 and [codeA] = @codeA 
 AND (AndroidID IS NULL OR [AndroidID] = @AndroidID) --for denied get code B from another device
 
 SELECT codeB AS 'codeB' from dbo.aRegistrationHost where  [isActive] = 1 and [codeA] = @codeA
 
END

GO


