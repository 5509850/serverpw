USE [alexandr_gorbunov]
GO

/****** Object:  StoredProcedure [dbo].[aAuthentication]    Script Date: 01/05/2016 22:44:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[aAuthentication]
	@email NVARCHAR(50), 
	@pwd NVARCHAR(50),	
	@TypeDeviceID INT,
	@Token NVARCHAR(300),		
	@AndroidIDMacaddress NVARCHAR(100),	
	@ipAdress NVARCHAR(50)	
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @OK INT 	
	DECLARE @isClient INT 	
	DECLARE @deviceID BIGINT
	DECLARE @userID BIGINT
	DECLARE @DeviceName NVARCHAR(50)	 
	
	SET @OK = -1	
	SET @deviceID = 0	

   --1 ---------------------Check login and password, get return code-----------------------
   SELECT    @OK = COUNT(*) 
	FROM         aUser
	WHERE      (email = @email)	
	
	IF @OK = 0 -- not exit user
	begin 
		SET @OK = 1
		INSERT INTO [aLog] ([ipAdress] ,[LastLoginTime] ,[IsSuccess], [userID], [code]) VALUES (@ipAdress  ,GETDATE() ,0, (select userID from aUser where (email = @email)	AND (pwd = @pwd)), @OK)
		SELECT @OK AS 'returncode', 0 AS 'deviceID', '0' AS 'DeviceName', '0' AS 'PGP'
		return 0
	end
	
	SELECT    @OK = COUNT(*)
	FROM         aUser
	WHERE      (email = @email)	AND (pwd = @pwd)
	
	IF @OK = 0 -- not valid password
	begin 
		SET @OK = 2
		INSERT INTO [aLog] ([ipAdress] ,[LastLoginTime] ,[IsSuccess], [userID], [code]) VALUES (@ipAdress  ,GETDATE() ,0, (select userID from aUser where (email = @email)	AND (pwd = @pwd)), @OK)
		SELECT @OK AS 'returncode', 0 AS 'deviceID', '0' AS 'DeviceName', '0' AS 'PGP'
		return 0
	end
	
	SELECT    @OK = COUNT(*)
	FROM         aUser
	WHERE      (email = @email)	AND (pwd = @pwd) AND (isBlocked = 0)
	
	IF @OK = 0 -- user is blocked
	begin 
		SET @OK = 3
		INSERT INTO [aLog] ([ipAdress] ,[LastLoginTime] ,[IsSuccess], [userID], [code]) VALUES (@ipAdress  ,GETDATE() ,0, (select userID from aUser where (email = @email)	AND (pwd = @pwd)), @OK)
		SELECT @OK AS 'returncode', 0 AS 'deviceID', '0' AS 'DeviceName', '0' AS 'PGP'
		return 0
	end
	
	SELECT    @OK = COUNT(*)
	FROM         aUser
	WHERE      (email = @email)	AND (pwd = @pwd) AND (isActive = 1)
	
	IF @OK = 0 -- user is deleted
	begin 
		SET @OK = 4
		INSERT INTO [aLog] ([ipAdress] ,[LastLoginTime] ,[IsSuccess], [userID], [code]) VALUES (@ipAdress  ,GETDATE() ,0, (select userID from aUser where (email = @email)	AND (pwd = @pwd)), @OK)
		SELECT @OK AS 'returncode', 0 AS 'deviceID', '0' AS 'DeviceName', '0' AS 'PGP'
		return 0
	end	
	
	--SELECT 5 AS 'returncode', 0 AS 'deviceID', '0' AS 'DeviceName', '0' AS 'PGP'
	--END
	--GO
	--------------------------------------------------------------------- ALL OK
	/*
		@email NVARCHAR(50), 
	@pwd NVARCHAR(50),	
	@TypeDeviceID INT,
	@Token NVARCHAR(300),		
	@AndroidIDMacaddress NVARCHAR(100),	
	@ipAdress NVARCHAR(50)	
	*/
	
	---2)----------------------------------------------get deviceID - if not exist - create new Device for 
	select @userID = ISNULL(userID, 0) from aUser where (email = @email)	AND (pwd = @pwd)	
	
	-----------------------------for Android and Windows PC - 
	if @TypeDeviceID <> 1 -- not for webclient!!!!!!
		begin
			SELECT     TOP (1) @deviceID = deviceID, @DeviceName = Name
			FROM         aDevice
			WHERE     (TypeDeviceID = @TypeDeviceID) AND (userID = @userID) AND (AndroidIDMacaddress = @AndroidIDMacaddress) AND (isActive = 1)
		
	  --3) update token---------------------Android device exist
			if @deviceID <> 0 AND  (@TypeDeviceID = 2 OR @TypeDeviceID = 5)  
				begin
					UPDATE    TOP (1) aDevice
					SET              Token = @Token
					WHERE     (deviceID = @deviceID)
				end				
		end 
	ELSE --For WEBCLIENT------------------
		begin 
			SELECT     TOP (1) @deviceID = deviceID, @DeviceName = Name
			FROM         aDevice
			WHERE     (TypeDeviceID = @TypeDeviceID) AND (userID = @userID) AND (isActive = 1)		
		end
		
IF @deviceID = 0 --------Not Exist Device - Create new device!!!!!!!!!!!!!!!!
	begin
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
           ,(SELECT TOP (1) Name + ' 1'   FROM aTypeDevice   where TypeDeviceID = @TypeDeviceID) 
           ,GETDATE()
           ,1)
           
		SELECT @deviceID = @@IDENTITY
		SELECT TOP (1) @DeviceName = Name + ' 1'   FROM aTypeDevice   where TypeDeviceID = @TypeDeviceID
	end
	--------------------------------
	SET @OK = 5
	INSERT INTO [aLog] ([ipAdress] ,[LastLoginTime] ,[IsSuccess], [userID], [DeviceID], [code]) VALUES (@ipAdress  ,GETDATE() ,1, @userID, @deviceID, @OK)
	SELECT @OK AS 'returncode', @deviceID AS 'deviceID', @DeviceName AS 'DeviceName', '0' AS 'PGP'

	END


GO


