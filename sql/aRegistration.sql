USE [alexandr_gorbunov]
GO

/****** Object:  StoredProcedure [dbo].[aRegistration]    Script Date: 01/05/2016 22:43:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [dbo].[aRegistration]
	@email NVARCHAR(50), 
	@pwd NVARCHAR(50),	
	@TypeDeviceID INT,
	@Token NVARCHAR(300),		
	@AndroidIDMacaddress NVARCHAR(100),	
	@Name NVARCHAR(50)	
	
AS
BEGIN

SET NOCOUNT ON;
DECLARE @EXISTUSER INT 
DECLARE @userID BIGINT 
DECLARE @deviceID BIGINT 
SET @userID = 0	
SET @EXISTUSER = 0	
SET @deviceID = 0	

	BEGIN TRY
		SELECT     @EXISTUSER = COUNT(*) 
		FROM       aUser  
		WHERE     email = @email
	
	
IF  @EXISTUSER <> 0
		begin 
		SELECT 0 AS 'userID'
		end
ELSE
	begin

    INSERT INTO [aUser]
           ([email]
           ,[pwd]
           ,[dateRegistration]
           ,[balance]
           ,[isBlocked]
           ,[isActive])
     VALUES
           (@email
           ,@pwd
           ,GETDATE()
           ,0
           ,0
           ,1)

select @userID = @@IDENTITY

INSERT INTO [aDevice]
           ([TypeDeviceID]
           ,[userID]
           ,[Token]
           ,[AndroidIDMacaddress]
           ,[Name]
           ,[dateCreate]
           ,[isActive])
     VALUES
           (@TypeDeviceID
           ,@userID
           ,@Token
           ,@AndroidIDMacaddress
           ,@Name
           ,GETDATE()
           ,1)
SELECT @deviceID = @@IDENTITY
SELECT  @userID AS 'userID', @deviceID AS 'deviceID'
----------- , ISNULL(TypeDeviceID, 0) AS 'TypeDeviceID', ISNULL(Token, '') AS 'Token', ISNULL(AndroidIDMacaddress, '') AS 'AndroidIDMacaddress', ISNULL(Name, 'name') AS 'Name', ISNULL(dateCreate, GETDATE()) AS 'dateCreate' from dbo.aDevice WHERE (deviceID = @deviceID) AND (userID = @userID) AND (isActive = 1)
	end    
  
END TRY
	
	BEGIN CATCH
	SELECT -1 AS 'userID'
	END CATCH;



END

GO


