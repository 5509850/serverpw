USE [alexandr_gorbunov]
GO

/****** Object:  StoredProcedure [dbo].[acheckABfinish]    Script Date: 01/06/2016 21:44:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[acheckABfinish]
	-- Add the parameters for the stored procedure here
	@deviceID BIGINT,
	@codeA INT,
	@codeB INT,
	@ipAdress nvarchar(50) --??????????? for log? with code!!!!?????
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
DECLARE @newDeviceID BIGINT

declare @timeoutminut int = 1 -- one minute time out after not valid code B
declare @maxerror int = 3 -- max errors of not valid time attemp before time out block

declare @diftime int
declare @errorscont int
declare @dateErrorCodeB smalldatetime
set @errorscont = 0	

-- check for added deviceId before! - return 0 if true!------------------------------
SELECT @newDeviceID = COUNT(*)
		FROM dbo.aRegistrationHost
		where deviceID = @deviceID and 	codeA = @codeA and 	codeB = @codeB and isActive = 0
		
if @newDeviceID = 1
	begin
		select 0 AS 'DeviceID' 
		return 0
	end
-- check for correct code A - if not exist records return -2	-------------------------
SELECT @newDeviceID = COUNT(*)
		FROM dbo.aRegistrationHost
		where deviceID = @deviceID and 	codeA = @codeA and isActive = 1
		
if @newDeviceID = 0
	begin
		select -2 AS 'DeviceID' 
		return 0
	end
--check for blocked after @maxerror error codeB and timeout @timeoutminut minute - return code -4	
SELECT TOP 1 @dateErrorCodeB = ISNULL(dateErrorCodeB, GETDATE()) , @errorscont = ISNULL(errorscont, 0) 
	    FROM [dbo].[aRegistrationHost] where deviceID = @deviceID and 	codeA = @codeA and isActive = 1

select @diftime = datediff(mi, @dateErrorCodeB , GETDATE())	    
if 	@errorscont >= @maxerror AND  (@diftime < @timeoutminut) 
begin
		select -4 AS 'DeviceID' 
		return 0
end  	
	
--check for correct code B and fix error and time - return -1 -------------
	SELECT @newDeviceID = COUNT(*)
		FROM dbo.aRegistrationHost
		where deviceID = @deviceID and 	codeA = @codeA and 	codeB = @codeB and isActive = 1
		
if @newDeviceID = 0
	begin
	       
	    SELECT TOP 1 @dateErrorCodeB = ISNULL(dateErrorCodeB, GETDATE()) , @errorscont = ISNULL(errorscont, 0) 
	    FROM [dbo].[aRegistrationHost] where deviceID = @deviceID and 	codeA = @codeA and isActive = 1
	    
	    UPDATE [aRegistrationHost]
		SET 
		errorscont = (select @errorscont + 1)
       ,dateErrorCodeB = GETDATE()      
		where deviceID = @deviceID and 	codeA = @codeA and isActive = 1
		
		select -1 AS 'DeviceID' 
		return 0
	end	
-----------------------------------------------------------all OK------------	
SET @newDeviceID = 0
   
INSERT INTO dbo.aDevice
		(TypeDeviceID, userID, Token, AndroidIDMacaddress, Name, dateCreate, isActive)
SELECT
typeDeviceID,
userID,
ISNULL(Token, ' '),
ISNULL(AndroidID, macaddress),
isnull(name, 'host 1'),
GETDATE() AS 'dateCreate', 
0 AS 'isActive'
		FROM dbo.aRegistrationHost
		where deviceID = @deviceID and 	codeA = @codeA and 	codeB = @codeB and isActive = 1
		
		select @newDeviceID = @@IDENTITY 
if 	@newDeviceID <> 0
	begin
		UPDATE [aRegistrationHost]
		SET 
		isActive = 0
       ,dateFinished = GETDATE()      
		where deviceID = @deviceID and codeA = @codeA and 	codeB = @codeB	
				
		select deviceID  AS 'DeviceID', Token as 'token' from dbo.aDevice where deviceID = @newDeviceID
	end 
END

GO


