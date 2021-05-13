CREATE DATABASE QuanLiPhongKaraoke
GO 
use QuanLiPhongKaraoke
GO 

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,
	Displayname NVARCHAR(100) NOT NULL DEFAULT N'Có tên không mà sao không đặt',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	type INT NOT NULL DEFAULT 0,--1 là admin 0 là staff
)
GO
CREATE TABLE PositionType
(
	id INT IDENTITY PRIMARY KEY,
	NamePosition nvarchar(100) NOT NULL 
)
GO
CREATE TABLE RoomCategory
(
	id INT IDENTITY PRIMARY KEY,
	RoomNameCategory NVARCHAR(100)NOT NULL DEFAULT N'Chưa đặt tên',
	Price FLOAT NOT NULL,

)
GO
CREATE  TABLE Room
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100)NOT NULL DEFAULT N'Chưa đặt tên',
	idRoomCategory INT NOT NULL,	
	status NVARCHAR(100) NOT NULL DEFAULT N' Trống' --trống or có người

	FOREIGN KEY (idRoomCategory) REFERENCES dbo.RoomCategory(id)
)
GO

CREATE TABLE ServiceCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
)
GO
CREATE TABLE Service
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idServiceCategory INT NOT NULL,
	price FLOAT NOT NULL

	FOREIGN KEY (idServiceCategory) REFERENCES dbo.ServiceCategory(id)

)
GO
CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateTimeCheckIn DATETIME NOT NULL DEFAULT GETDATE(),
	DateTimeCheckOut DATETIME ,
	idRoom INT	NOT NULL,
	status INT NOT NULL DEFAULT 0--1 là đã thanh toán 0 là chưa thanh toán
	FOREIGN KEY (idRoom) REFERENCES dbo.Room(id)
)
GO
CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idService INT NOT NULL,
	countService INT NOT NULL DEFAULT 0,
	

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY(idService) REFERENCES dbo.Service(id),
)
GO


INSERT INTO dbo.Account
(
    UserName,
    Displayname,
    PassWord,
    type
)
VALUES
(   N'trung1', -- UserName - nvarchar(100)
    N'staff', -- Displayname - nvarchar(100)
    N'123', -- PassWord - nvarchar(1000)
    0    -- type - int
)
INSERT INTO dbo.Account
(
    UserName,
    Displayname,
    PassWord,
    type
)
VALUES
(   N'trung', -- UserName - nvarchar(100)
    N'Hoàng Trung', -- Displayname - nvarchar(100)
    N'123', -- PassWord - nvarchar(1000)
    1    -- type - int
)
SELECT *FROM dbo.Account WHERE UserName=N'trung' AND PassWord=N'123'	
GO

CREATE PROC USP_Login
@userName NVARCHAR(100),@passWord nvarchar(100)
AS
BEGIN
	SELECT *FROM dbo.Account WHERE UserName=@userName AND PassWord=@passWord
END
GO

INSERT dbo.RoomCategory
(
    RoomNameCategory,
    Price
)
VALUES
(   N'Phòng Thường', -- name - nvarchar(100)
    100.0 -- PeakTime - float
 
)
INSERT dbo.RoomCategory
(
    RoomNameCategory,
    Price
)
VALUES
(   N'Phòng VIP', -- name - nvarchar(100)
    200.0 -- PeakTime - float
    
)


INSERT INTO dbo.Room(	name, idRoomCategory,status)VALUES(   N'Phòng 101', 1,N' Trống')

INSERT INTO dbo.Room
(
    name,
    idRoomCategory,
    
    status
)
VALUES
(   N'Phòng 102', -- name - nvarchar(100)
    1,   -- idRoomCategory - int
    
	N' Trống'
)
INSERT INTO dbo.Room
(
    name,
    idRoomCategory,
    
    status
)
VALUES
(   N'Phòng 103', -- name - nvarchar(100)
    1,   -- idRoomCategory - int
    
    N' Trống'
)
INSERT INTO dbo.Room
(
    name,
    idRoomCategory,
    
    status
)
VALUES
(   N'Phòng 104', -- name - nvarchar(100)
    1,   -- idRoomCategory - int
    
    N' Trống'
)
INSERT INTO dbo.Room
(
    name,
    idRoomCategory,
    
    status
)
VALUES
(   N'Phòng 105', -- name - nvarchar(100)
    1,   -- idRoomCategory - int
    
    N' Trống'
)
INSERT INTO dbo.Room
(
    name,
    idRoomCategory,
    
    status
)
VALUES
(   N'Phòng 201', -- name - nvarchar(100)
    2,   -- idRoomCategory - int
    
    N' Trống'
)
INSERT INTO dbo.Room
(
    name,
    idRoomCategory,
    
    status
)
VALUES
(   N'Phòng 202', -- name - nvarchar(100)
    2,   -- idRoomCategory - int
    
    N' Trống'
)
INSERT INTO dbo.Room
(
    name,
    idRoomCategory,
    
    status
)
VALUES
(   N'Phòng 203', -- name - nvarchar(100)
    2,   -- idRoomCategory - int
    
    N' Trống'
)
INSERT INTO dbo.Room
(
    name,
    idRoomCategory,
    
    status
)
VALUES
(   N'Phòng 204', -- name - nvarchar(100)
    2,   -- idRoomCategory - int
    
   N' Trống'
)
INSERT INTO dbo.Room
(
    name,
    idRoomCategory,
    
    status
)
VALUES
(   N'Phòng 205', -- name - nvarchar(100)
    2,   -- idRoomCategory - int
    
    N' Trống'
)
go
CREATE PROC USP_GetRoomList
AS SELECT *FROM dbo.Room
go

EXEC dbo.USP_GetRoomList

INSERT INTO dbo.ServiceCategory
(
    name
)

VALUES
(N'Đồ ăn vật' -- name - nvarchar(100)
    )
INSERT INTO dbo.ServiceCategory
(
    name
)
VALUES
(N'Bánh oxi' -- name - nvarchar(100)
    )
INSERT INTO dbo.ServiceCategory
(
    name
)
VALUES
(N'Nước giải khát' -- name - nvarchar(100)
    )
INSERT INTO dbo.ServiceCategory
(
    name
)
VALUES
(N'Hải sản' -- name - nvarchar(100)
    )
INSERT INTO dbo.ServiceCategory
(
    name
)
VALUES
(N'Bia' -- name - nvarchar(100)
    )
INSERT INTO dbo.ServiceCategory
(
    name
)
VALUES
(N'Trống' -- name - nvarchar(100)
    )

INSERT INTO dbo.Service
(
    name,
    idServiceCategory,
    price
)
	VALUES
	(   N'Loại Chả chiên', -- name - nvarchar(100)
	    1,   -- idFoodCategory - int
	    100.0  -- price - float
	    )
INSERT INTO dbo.Service
	(
	    name,
	    idServiceCategory,
	    price
	)
	VALUES
	(   N'bánh trán trộn', -- name - nvarchar(100)
	    1,   -- idFoodCategory - int
	    100.0  -- price - float
	    )
INSERT INTO dbo.Service
	(
	    name,
	    idServiceCategory,
	    price
	)
	VALUES
	(   N'bánh snack', -- name - nvarchar(100)
	    2,   -- idFoodCategory - int
	    100.0  -- price - float
	    )
INSERT INTO dbo.Service
	(
	    name,
	    idServiceCategory,
	    price
	)
	VALUES
	(   N'sting', -- name - nvarchar(100)
	    3,   -- idFoodCategory - int
	    100.0  -- price - float
	    )	
INSERT INTO dbo.Service
	(
	    name,
	    idServiceCategory,
	    price
	)
	VALUES
	(   N'Nước suối', -- name - nvarchar(100)
	    3,   -- idFoodCategory - int
	    100.0  -- price - float
	    )
INSERT INTO dbo.Service
	(
	    name,
	    idServiceCategory,
	    price
	)
	VALUES
	(   N'Mực xào', -- name - nvarchar(100)
	    4,   -- idFoodCategory - int
	    100.0  -- price - float
	    )
INSERT INTO dbo.Service
	(
	    name,
	    idServiceCategory,
	    price
	)
	VALUES
	(   N'Tôm luộc', -- name - nvarchar(100)
	    4,   -- idFoodCategory - int
	    100.0  -- price - float
	    )
INSERT INTO dbo.Service
	(
	    name,
	    idServiceCategory,
	    price
	)
	VALUES
	(   N'bia 333', -- name - nvarchar(100)
	    5,   -- idFoodCategory - int
	    100.0  -- price - float
	    )
INSERT INTO dbo.Service
	(
	    name,
	    idServiceCategory,
	    price
	)
	VALUES
	(   N'saigon xanh', -- name - nvarchar(100)
	    5,   -- idFoodCategory - int
	    100.0  -- price - float
	    )
INSERT INTO dbo.Service
	(
	    name,
	    idServiceCategory,
	    price
	)
	VALUES
	(   N'Trống', -- name - nvarchar(100)
	    6,   -- idFoodCategory - int
	    0.0  -- price - float
	    )

INSERT INTO dbo.Bill
(
    DateTimeCheckIn,
    DateTimeCheckOut,
    idRoom,
    status
)
VALUES
(   GETDATE(), -- DateTimeCheckIn - date
    null, -- DateTimeCheckOut - date
    9,         -- idRoom - int
    0          -- status - int
    )	
INSERT INTO dbo.Bill
(
    DateTimeCheckIn,
    DateTimeCheckOut,
    idRoom,
    status
)
VALUES
(   GETDATE(), -- DateTimeCheckIn - date
    null, -- DateTimeCheckOut - date
    7,         -- idRoom - int
    0          -- status - int
    )
INSERT INTO dbo.Bill
(
    DateTimeCheckIn,
    DateTimeCheckOut,
    idRoom,
    status
)
VALUES
(   GETDATE(), -- DateTimeCheckIn - date
    GETDATE(), -- DateTimeCheckOut - date
    7,         -- idRoom - int
    1          -- status - int
    )	
INSERT INTO dbo.Bill
(
    DateTimeCheckIn,
    DateTimeCheckOut,
    idRoom,
    status
)
VALUES
(   GETDATE(), -- DateTimeCheckIn - date
    null, -- DateTimeCheckOut - date
    2,         -- idRoom - int
    0          -- status - int
    )		
	
INSERT INTO dbo.BillInfo
(
    idBill,
    idService,
    countService
)
VALUES
(   2, -- idBill - int
    11, -- idFood - int
    2  -- countFood - int
    )	
INSERT INTO dbo.BillInfo
(
    idBill,
    idService,
    countService
)
VALUES
(   2, -- idBill - int
    12, -- idFood - int
    2  -- countFood - int
    )
INSERT INTO dbo.BillInfo
(
    idBill,
    idService,
    countService
)
VALUES
(   1, -- idBill - int
    13, -- idFood - int
    3  -- countFood - int
    )
INSERT INTO dbo.BillInfo
(
    idBill,
    idService,
    countService
)
VALUES
(   1, -- idBill - int
    16, -- idFood - int
    20  -- countFood - int
    )


	
SELECT DateTimeCheckIn FROM dbo.Bill WHERE idRoom=9 

SELECT (DATEDIFF(minute, '2021-03-08 08:31:19.400', GETDATE()))

SELECT CONCAT((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60),N' tiếng ' ,(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60),' phút') AS [Time],((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60)*rc.Price/60) AS [TimePrice] FROM dbo.Bill AS b,dbo.Room AS r,dbo.RoomCategory AS rc WHERE b.idRoom=r.id AND r.idRoomCategory=rc.id AND  b.idRoom=9
SELECT CONCAT((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60),N' tiếng ' ,(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60),' phút') AS [Time],((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60)*rc.Price/60) AS [TimePrice] FROM dbo.BillInfoByFood AS fbi,dbo.BillInfoByDevice AS dbi,dbo.Bill AS b,dbo.Food AS f,dbo.Device AS d,dbo.Room AS r,dbo.RoomCategory AS rc WHERE fbi.idBill=b.id  AND dbi.idBill=b.id AND b.idRoom=r.id AND r.idRoomCategory=rc.id AND b.idRoom=7
SELECT CONCAT((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60),N' tiếng ' ,(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60),' phút') AS [Time],((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60)*rc.Price/60) AS [TimePrice] FROM dbo.BillInfo AS bi, dbo.Bill AS b,dbo.Service AS s,dbo.Room AS r,dbo.RoomCategory AS rc WHERE bi.idBill=b.id   AND b.idRoom=r.id AND r.idRoomCategory=rc.id AND b.status=1 AND b.idRoom=9 AND s.id=bi.idService
SELECT  d.name AS [DeviceName],d.Price AS [DevicePrice],bi.countDevice,d.Price*bi.countDevice AS [TotalPrice] FROM dbo.BillInfo AS bi, dbo.Bill AS b,dbo.Device AS d WHERE bi.idBill=b.id AND bi.idDevice=d.id AND b.idRoom=9


SELECT  f.name AS [FoodName],f.price AS [FoodPrice],bi.countFood,f.price*bi.countFood AS [TotalPrice] FROM dbo.BillInfo AS bi, dbo.Bill AS b,dbo.Food AS f WHERE bi.idBill=b.id AND bi.idFood=f.id AND b.status=0 AND b.idRoom=9
GO

CREATE PROC USP_InserStartBill
@idRoom Int
AS
BEGIN
	INSERT INTO dbo.Bill
	(
	    DateTimeCheckIn,
	    DateTimeCheckOut,
	    idRoom,
	    status,
		DisCount,
		ToTalTime
	)
	VALUES
	(   GETDATE(), -- DateTimeCheckIn - datetime
	    null, -- DateTimeCheckOut - datetime
	    @idRoom,         -- idRoom - int
	    0,
		0,
		N'0 giờ 0 phút'          -- status - int
	    )
		UPDATE dbo.Room SET status=N'Có Người' WHERE id=@idRoom
		
END
GO
ALTER PROC USP_InserBill
@idRoom Int
AS
BEGIN
	INSERT INTO dbo.Bill
	(
	    DateTimeCheckIn,
	    DateTimeCheckOut,
	    idRoom,
	    status,
		DisCount,
		ToTalTime
	)
	VALUES
	(   GETDATE(), -- DateTimeCheckIn - datetime
	    null, -- DateTimeCheckOut - datetime
	    @idRoom,         -- idRoom - int
	    0,
		0,
		N'0 giờ 0 phút'          -- status - int
	    )

		
END
GO

ALTER PROC	USP_InsertBillInfo
@idBill INT, @idService INT,@count INT,@idRoom INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @ServiceCount INT=1
	SELECT @isExitsBillInfo=id ,@ServiceCount=countService FROM dbo.BillInfo WHERE idBill=@idBill AND idService=@idService 

	IF(@isExitsBillInfo>0)
	BEGIN
		DECLARE @newCountService INT=@ServiceCount+@count
		IF(@newCountService>0)
			UPDATE dbo.BillInfo SET countService=@ServiceCount+@count WHERE idService=@idService
		ELSE
			DELETE dbo.BillInfo WHERE idBill=@idBill AND idService=@idService

		
    END
	ELSE
	BEGIN
	INSERT INTO dbo.BillInfo
	(
	    idBill,
	    idService,
	    countService
	)
	VALUES
	(   @idBill, -- idBill - int
	    @idService, -- idFood - int
	    @count
		
	    )
    END
	UPDATE dbo.Bill SET CheckSwitch=0 WHERE idRoom=@idRoom
END
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT,UPDATE
AS
BEGIN
    DECLARE @idBill INT

	SELECT @idBill=idBill FROM Inserted

	DECLARE @idRoom INT

	SELECT @idRoom=idRoom FROM dbo.Bill WHERE id=@idBill AND status=0

	DECLARE @countBillInfo INT
	 
	DECLARE @count INT
	SELECT @count=COUNT(*) FROM dbo.BillInfo WHERE @idBill=idBill

	IF(@count>0)
		UPDATE dbo.Room SET status=N'Có Người' WHERE id=@idRoom
	ELSE
		UPDATE dbo.Room SET status=N' Trống' WHERE id=@idRoom
END
GO

 

DELETE dbo.BillInfo
DELETE dbo.Bill
go
CREATE TRIGGER UTP_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill=id FROM Inserted

	DECLARE @idRoom INT

	SELECT @idRoom=idRoom FROM dbo.Bill WHERE id=@idBill 

	DECLARE @count INT=0

	SELECT @count=count (*) FROM dbo.Bill  WHERE @idRoom=idRoom AND status=0

	IF(@count=0)
		UPDATE dbo.Room SET status=N' Trống' WHERE id=@idRoom


END
GO

ALTER TABLE dbo.Bill
ADD DisCount INT

UPDATE dbo.Bill SET DisCount=0

SELECT  f.name AS [FoodName],f.price AS [FoodPrice],bi.countFood,f.price*bi.countFood AS [TotalPrice] FROM dbo.BillInfoByFood AS bi, dbo.Bill AS b,dbo.Food AS f,dbo.Room AS r WHERE r.id=b.idRoom and bi.idBill=b.id AND bi.idFood=f.id AND b.status=0 AND b.idRoom=7
SELECT MAX(id)FROM dbo.Bill
SELECT *FROM dbo.Service where idServiceCategory=1
SELECT *FROM dbo.Account

DECLARE @idBillNew INT =1018
SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill=@idBillNew

DECLARE @idBillOld INT =1019
UPDATE dbo.BillInfo SET idBill=@idBillOld WHERE id IN (SELECT * FROM dbo.IDBillInfoTable)
GO



alter PROC USP_SwitchTable
@idTable1 int, @idTable2 int
AS
BEGIN
	DECLARE @idFirstBill INT
	DECLARE @idSeconrdBill INT 

	DECLARE @isFirstRoomEmty INT =1
	DECLARE @isSecondRoomEmty INT =1

	SELECT @idSeconrdBill=id FROM dbo.Bill WHERE idRoom=@idTable2 AND status=0

	SELECT @idFirstBill=id FROM dbo.Bill WHERE idRoom=@idTable1 AND status=0

	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-------------'

	IF(@idFirstBill is NULL)
	BEGIN
		INSERT INTO dbo.Bill
		(
		    DateTimeCheckIn,
		    DateTimeCheckOut,
		    idRoom,
		    status
			
		)
		VALUES
		(   GETDATE(), -- DateTimeCheckIn - datetime
		    NULL, -- DateTimeCheckOut - datetime
		    @idTable1,         -- idRoom - int
		    0
			         -- status - int
		    )
			SELECT @idFirstBill= MAX(id) FROM dbo.Bill WHERE idRoom=@idTable1 AND status=0

	END
	SELECT @isFirstRoomEmty=COUNT(*) FROM dbo.BillInfo WHERE idBill=@idFirstBill

	IF(@idSeconrdBill is NULL)
	BEGIN
		INSERT INTO dbo.Bill
		(
		    DateTimeCheckIn,
		    DateTimeCheckOut,
		    idRoom,
		    status
			
			
		)
		VALUES
		(   GETDATE(), -- DateTimeCheckIn - datetime
		    NULL, -- DateTimeCheckOut - datetime
		    @idTable2,         -- idRoom - int
		    0
			        -- status - int
		    )
			SELECT @idSeconrdBill= MAX(id) FROM dbo.Bill WHERE idRoom=@idTable2 AND status=0
			
			
	END

	SELECT @isSecondRoomEmty=COUNT(*) FROM dbo.BillInfo WHERE idBill=@idSeconrdBill

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill=@idSeconrdBill

	UPDATE dbo.BillInfo SET idBill= @idSeconrdBill WHERE idBill = @idFirstBill

	UPDATE dbo.BillInfo SET idBill=@idFirstBill WHERE id IN (SELECT *FROM dbo.idBillInfoTable)
    
	
	DROP TABLE idBillInfoTable
	IF(@isFirstRoomEmty=0)
		UPDATE dbo.Room SET status=N' Trống' WHERE id=@idTable2
	IF(@isSecondRoomEmty=0)
		UPDATE dbo.Room SET status=N' Trống' WHERE id=@idTable1
	UPDATE dbo.Room SET status=N'Có người' WHERE id=@idTable2
END
GO
EXEC dbo.USP_SwitchTable @idTable1 = 1, -- int
	                         @idTable2 = 5  -- int





CREATE PROC USP_GetListPriceOldTime
@IDRoom1 INT, @IDRoom2 int
AS
BEGIN
	DECLARE @idFirstBill INT
	DECLARE @idSeconrdBill INT 

	SELECT @idSeconrdBill=id FROM dbo.Bill WHERE idRoom=@IDRoom2 AND status=0
	SELECT @idFirstBill=id FROM dbo.Bill WHERE idRoom=@IDRoom1 AND status=0
DECLARE @PriceOld FLOAT
SELECT @PriceOld=((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60)*rc.Price/60) FROM dbo.Bill AS b,dbo.Room AS r,dbo.RoomCategory AS rc WHERE b.idRoom=r.id AND r.idRoomCategory=rc.id and b.status=0 AND CheckSwitch=0  and  b.idRoom=@IDRoom1
PRINT @PriceOld
PRINT @IDRoom2
PRINT '--------'
UPDATE dbo.Bill SET CheckSwitch=1,status=1 WHERE idRoom=@IDRoom1 AND id=@idFirstBill
DECLARE @totalPrice FLOAT
SELECT @totalPrice=@PriceOld+PRiceOldTime FROM dbo.Bill WHERE idRoom =@IDRoom1
UPDATE dbo.Bill SET PRiceOldTime=@totalPrice WHERE idRoom=@IDRoom2  AND id=@idSeconrdBill

PRINT @PriceOld
PRINT '--------'
END
GO
EXEC dbo.USP_GetListPriceOldTime @IDRoom1 = 6, -- int
                                 @IDRoom2 = 7  -- int
UPDATE dbo.Bill SET PRiceOldTime=30 WHERE idRoom=7



SELECT PRiceOldTime,(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60)*rc.Price/60)) AS [ totalTime] FROM dbo.Bill AS b,dbo.Room AS r,dbo.RoomCategory AS rc WHERE  status=0  AND  idRoom=4

 

ALTER TABLE dbo.Room
ADD RoomInformation nvarchar(1000) NOT NULL DEFAULT N'Trống' 

UPDATE dbo.Bill SET PriceOldTime=0

DELETE FROM dbo.BillInfo
DELETE FROM dbo.Bill

UPDATE dbo.Room SET status=N' Trống'
go
UPDATE dbo.Bill SET status=0 WHERE id=1

SELECT *FROM dbo.Room WHERE id=
SELECT * FROM dbo.Account where UserName= 'staff'
go
CREATE PROC USP_UpdateAccount
@userName Nvarchar(100),@DisPlayName Nvarchar(100),@passWord nvarchar(100), @NewpassWord nvarchar(100)
AS 
BEGIN
	DECLARE @isRightPass INT=0

	SELECT @isRightPass=COUNT(*) FROM dbo.Account WHERE UserName=@userName AND PassWord=@passWord
    
	IF(@isRightPass=1)
	BEGIN

		IF(@NewpassWord=NULL OR @NewpassWord='')
		BEGIN
				UPDATE dbo.Account SET Displayname=@DisPlayName WHERE UserName=@userName
		END
		ELSE
				UPDATE dbo.Account SET Displayname=@DisPlayName,PassWord=@NewpassWord WHERE UserName=@userName
	END


END.
GO
DELETE FROM dbo.RoomCategory WHERE id=
SELECT *FROM dbo.Account
SELECT*FROM dbo.Bill
SELECT *FROM dbo.Room
SELECT *FROM dbo.RoomCategory
SELECT *FROM dbo.ServiceCategory
SELECT *FROM dbo.Service
SELECT *FROM dbo.BillInfo
SELECT UserName,Displayname,type FROM dbo.Account
SELECT * FROM dbo.Bill WHERE idRoom= 12 
SELECT *FROM dbo.BillInfo WHERE idBill=1149
UPDATE dbo.RoomCategory SET RoomNameCategory=N'{0}',Price={1} WHERE id={2}
go
CREATE FUNCTION [dbo].[fuConvertToUnsign2]
(
 @strInput NVARCHAR(4000)
) 
RETURNS NVARCHAR(4000)
AS
Begin
 Set @strInput=rtrim(ltrim(lower(@strInput)))
 IF @strInput IS NULL RETURN @strInput
 IF @strInput = '' RETURN @strInput
 Declare @text nvarchar(50), @i int
 Set @text='-''`~!@#$%^&*()?><:|}{,./\"''='';–'
 Select @i= PATINDEX('%['+@text+']%',@strInput ) 
 while @i > 0
 begin
 set @strInput = replace(@strInput, substring(@strInput, @i, 1), '')
 set @i = patindex('%['+@text+']%', @strInput)
 End
 Set @strInput =replace(@strInput,' ',' ')
 
 DECLARE @RT NVARCHAR(4000)
 DECLARE @SIGN_CHARS NCHAR(136)
 DECLARE @UNSIGN_CHARS NCHAR (136)
 SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế
 ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý'
 +NCHAR(272)+ NCHAR(208)
 SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee
 iiiiiooooooooooooooouuuuuuuuuuyyyyy'
 DECLARE @COUNTER int
 DECLARE @COUNTER1 int
 SET @COUNTER = 1
 WHILE (@COUNTER <=LEN(@strInput))
 BEGIN 
 SET @COUNTER1 = 1
 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
 BEGIN
 IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) 
 = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
 BEGIN 
 IF @COUNTER=1
 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) 
 + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
 ELSE
 SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) 
 +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) 
 + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)
 BREAK
 END
 SET @COUNTER1 = @COUNTER1 +1
 END
 SET @COUNTER = @COUNTER +1
 End
 SET @strInput = replace(@strInput,' ','-')
 RETURN lower(@strInput)
END


SELECT *FROM dbo.Service WHERE dbo.fuConvertToUnsign2(name) LIKE N'%' +dbo.fuConvertToUnsign2(N'ban')+'%'
go
create PROC USP_GetListBillByDateAndPage
@checkIn datetime,@checkOut DATETIME, @page INT
AS
BEGIN
	DECLARE @pageRows INT =10
	DECLARE @selectRows INT =@pageRows
	DECLARE @exceptRows INT =(@page-1)*@pageRows


	;WITH billShow AS( SELECT b.id, r.name AS[tên phòng],b.totalPrice AS [Tổng tiền], b.DateTimeCheckOut [Ngày/Giờ vào],b.DateTimeCheckIn AS[Ngày/Giờ ra],b.DisCount AS [Giảm giá] 
	FROM dbo.Bill AS b,dbo.Room AS r 
	WHERE b.DateTimeCheckIn>=@checkIn AND b.DateTimeCheckOut<=@checkOut AND b.status = 1 AND b.CheckSwitch=0 AND r.id=b.idRoom )

	SELECT TOP (@selectRows) *FROM billShow WHERE id NOT IN(SELECT TOP(@exceptRows)  id FROM billShow)
	
END
GO

EXEC USP_GetListBillByDateAndPage @checkIn='2021-23-03',@checkOut='2021-24-03',@page=2
EXEC dbo.USP_GetListBillByDateAndPage @checkIn = '2021-03-23 ', 
                               @checkOut = '2021-03-24 ',
							   @page=4 
go
 CREATE PROC USP_GetNumBillByDate
@checkIn datetime,@checkOut datetime 
AS
BEGIN

SELECT COUNT(*)
FROM dbo.Bill AS b,dbo.Room AS r 
WHERE b.DateTimeCheckIn>=@checkIn AND b.DateTimeCheckOut<=@checkOut AND b.status = 1 AND b.CheckSwitch=0 AND r.id=b.idRoom 
END

GO
SELECT*FROM dbo.Account
go
create PROC USP_GetListBillByDate
@checkIn datetime,@checkOut datetime 
AS
BEGIN

SELECT r.name AS[tên phòng],b.totalPrice AS [Tổng tiền], b.DateTimeCheckIn [Ngày/Giờ vào],b.DateTimeCheckOut AS[Ngày/Giờ ra],b.DisCount AS [Giảm giá] 
FROM dbo.Bill AS b,dbo.Room AS r 
WHERE b.DateTimeCheckIn>=@checkIn AND b.DateTimeCheckOut<=@checkOut AND b.status = 1 AND b.CheckSwitch=0 AND r.id=b.idRoom 
END
GO
select *from bill
alter proc USP_GetBillInfoByRoom
@idBill int
as
begin
SELECT  r.name ,b.totalPrice , b.DateTimeCheckOut ,b.DateTimeCheckIn ,b.DisCount, bi.countService, se.price, se.price*bi.countService as [Price] , se.name,CONCAT((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60),N' tiếng ' ,(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60),' phút') AS [Time],((DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)%60)*rc.Price/60) AS [TimePrice], b.PRiceOldTime,((DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)%60)*rc.Price/60)+b.PRiceOldTime [TotalTimePrice]
FROM dbo.Bill AS b,dbo.Room AS r ,dbo.Service as se, dbo.BillInfo as bi, RoomCategory as rc
WHERE  b.status = 1 AND b.CheckSwitch=0 AND bi.idBill=b.id and bi.idService =se.id and b.idRoom=r.id and b.id=@idBill and rc.id=r.idRoomCategory
end
go

exec USP_GetBillInfoByRoom @idRoom = 1
select *from Bill
select *from BillInfo
go





create PROC USP_GetListBillByDateForReport
@checkIn datetime,@checkOut datetime,@Service nvarchar (1000)  
AS
BEGIN


SELECT DISTINCT
         @service as[servicename],@checkIn,@checkOut,b.id,r.name ,b.totalPrice , b.DateTimeCheckOut ,b.DateTimeCheckIn ,b.DisCount,((DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)%60)*rc.Price/60) AS [TimePrice],b.PRiceOldTime,((DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)%60)*rc.Price/60)+b.PRiceOldTime [TotalTimePrice],
        (   SELECT concat(se.name, N' (Số lượng: ',bi.countService,') ') +', ' AS [text()]
            FROM BillInfo as bi , Service as se
            WHERE bi.idBill = b.id and bi.idService=se.id 
            ORDER BY bi.idBill
            FOR XML PATH(''))[Service]
FROM Bill as b, Room as r, BillInfo as bi,RoomCategory as rc,Service as se
where b.DateTimeCheckIn>=@checkIn AND b.DateTimeCheckOut<=@checkOut AND b.status = 1 AND b.CheckSwitch=0 AND b.id=bi.idBill and r.id=b.idRoom and r.idRoomCategory=rc.id  and se.id=bi.idService and dbo.fuConvertToUnsign2(se.name) LIKE N'%' +dbo.fuConvertToUnsign2(@Service)+'%'
end
go
exec USP_GetListBillByDateForReport @checkIn='20210401', @checkOut='20210401',@Service=N'7 up'

SELECT *FROM dbo.Service WHERE dbo.fuConvertToUnsign2(name) LIKE N'%' +dbo.fuConvertToUnsign2(N'ban'
go
alter PROC USP_GetRoomByDateAndID
@checkIn datetime,@checkOut datetime,@RoomName nvarchar(100)
AS
BEGIN

SELECT @checkIn,@checkOut,r.id,r.name,rc.RoomNameCategory,r.RoomInformation,Concat(Sum((DATEDIFF(MINUTE, b.DateTimeCheckIn,b.DateTimeCheckOut)))/60,N' Giờ ',Sum((DATEDIFF(MINUTE, b.DateTimeCheckIn,b.DateTimeCheckOut)))%60,N' Phút') as totalTime , concat(Sum(b.totalPrice),N'VNĐ') as totalPrice
FROM dbo.Bill AS b,dbo.Room AS r ,dbo.RoomCategory as rc
WHERE b.DateTimeCheckIn>=@checkIn AND b.DateTimeCheckOut<=@checkOut AND b.status = 1 
AND b.CheckSwitch=0 AND r.id=b.idRoom and r.idRoomCategory=rc.id and r.name=@RoomName group by r.id,r.name,rc.RoomNameCategory,r.RoomInformation
END
GO
select *from room
select *from ServiceCategory
 SELECT s.id,s.name,sc.name ,s.price FROM dbo.Service as s,ServiceCategory as sc where s.idServiceCategory=sc.id
 SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s,ServiceCategory as sc where s.idServiceCategory=sc.id and dbo.fuConvertToUnsign2(s.name) LIKE N'%' +dbo.fuConvertToUnsign2(N'up')+'%'

 SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s,ServiceCategory as sc where s.idServiceCategory=sc.id and dbo.fuConvertToUnsign2(sc.name) LIKE N'%' +dbo.fuConvertToUnsign2(N'Thêm Món ăn')+'%'

 SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s, ServiceCategory as sc where s.idServiceCategory=sc.id and sc.name not like N'%món ăn%' and s.name like N's%'
SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s, ServiceCategory as sc where s.idServiceCategory=sc.id AND s.price  ='15000'   OR (dbo.fuConvertToUnsign2(s.name)  LIKE N'%' +dbo.fuConvertToUnsign2(N'canh')+'%' and s.idServiceCategory=sc.id  )

SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s, ServiceCategory as sc where s.idServiceCategory=sc.id and dbo.fuConvertToUnsign2(s.name) LIKE N'%' +dbo.fuConvertToUnsign2(N'{0}')+'%' AND dbo.fuConvertToUnsign2(sc.name) LIKE N'%' +dbo.fuConvertToUnsign2(N'{0}')+'%'

select a.UserName,a.Displayname,a.type,p.NamePosition from Account a, PositionType p where a.type=p.id
select *from account