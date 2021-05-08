USE [master]
GO
/****** Object:  Database [QuanLiPhongKaraoke]    Script Date: 08/05/2021 21:29:17 ******/
CREATE DATABASE [QuanLiPhongKaraoke]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLiPhongKaraoke', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLiPhongKaraoke.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLiPhongKaraoke_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLiPhongKaraoke_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLiPhongKaraoke].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLiPhongKaraoke', N'ON'
GO
USE [QuanLiPhongKaraoke]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign2]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
End
GO
/****** Object:  Table [dbo].[Account]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[Displayname] [nvarchar](100) NOT NULL DEFAULT (N'Có tên không mà sao không đặt'),
	[PassWord] [nvarchar](1000) NOT NULL DEFAULT ((0)),
	[type] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateTimeCheckIn] [datetime] NOT NULL DEFAULT (getdate()),
	[DateTimeCheckOut] [datetime] NULL,
	[idRoom] [int] NOT NULL,
	[status] [int] NOT NULL DEFAULT ((0)),
	[DisCount] [int] NULL,
	[ToTalTime] [nvarchar](100) NULL,
	[PRiceOldTime] [float] NULL DEFAULT ((0)),
	[totalPrice] [float] NULL,
	[CheckSwitch] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idService] [int] NOT NULL,
	[countService] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa đặt tên'),
	[idRoomCategory] [int] NOT NULL,
	[status] [nvarchar](100) NOT NULL DEFAULT (N' Trống'),
	[RoomInformation] [nvarchar](1000) NOT NULL DEFAULT (N'Trống'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomCategory]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNameCategory] [nvarchar](100) NOT NULL DEFAULT (N'Chưa đặt tên'),
	[Price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa đặt tên'),
	[idServiceCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServiceCategory]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa đặt tên'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Account] ([UserName], [Displayname], [PassWord], [type]) VALUES (N'hoangtrung', N'Phan Trung ', N'XWAetpNEnA8=', 1)
INSERT [dbo].[Account] ([UserName], [Displayname], [PassWord], [type]) VALUES (N'thanh', N'Thanh', N'/np3PhX7Fao=', 1)
INSERT [dbo].[Account] ([UserName], [Displayname], [PassWord], [type]) VALUES (N'thanh1', N'Thanh1', N'/np3PhX7Fao=', 0)
INSERT [dbo].[Account] ([UserName], [Displayname], [PassWord], [type]) VALUES (N'trung', N'Phan Hoàng Trung', N'/np3PhX7Fao=', 1)
INSERT [dbo].[Account] ([UserName], [Displayname], [PassWord], [type]) VALUES (N'trung1', N'Phan Trung ', N'/np3PhX7Fao=', 0)
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (1286, CAST(N'2021-04-09 21:23:09.130' AS DateTime), CAST(N'2021-04-09 21:24:37.810' AS DateTime), 2, 1, 0, N'0 tiếng 1 phút', 0, 301000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (1287, CAST(N'2021-04-09 21:28:30.027' AS DateTime), CAST(N'2021-04-09 21:28:41.837' AS DateTime), 4, 1, 0, N'0 tiếng 0 phút', 0, 315000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (1288, CAST(N'2021-04-09 21:31:16.660' AS DateTime), CAST(N'2021-04-09 21:31:31.610' AS DateTime), 3, 1, 0, N'0 tiếng 0 phút', 0, 245000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (1289, CAST(N'2021-04-09 21:35:49.347' AS DateTime), CAST(N'2021-04-09 21:35:56.607' AS DateTime), 3, 1, 0, N'0 tiếng 0 phút', 0, 420000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (1290, CAST(N'2021-04-09 21:40:10.160' AS DateTime), CAST(N'2021-04-09 21:40:44.573' AS DateTime), 7, 1, 0, N'0 tiếng 0 phút', 0, 230000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2286, CAST(N'2021-04-10 14:42:40.267' AS DateTime), CAST(N'2021-04-10 14:42:55.563' AS DateTime), 6, 1, 0, N'0 tiếng 0 phút', 0, 1375000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2287, CAST(N'2021-04-10 14:56:41.663' AS DateTime), NULL, 6, 1, 0, N'0 giờ 0 phút', 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2288, CAST(N'2021-04-10 14:57:48.670' AS DateTime), CAST(N'2021-04-10 14:58:26.110' AS DateTime), 1, 1, 0, N'0 tiếng 1 phút', 2000, 103000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2290, CAST(N'2021-04-10 15:11:12.100' AS DateTime), CAST(N'2021-04-10 15:12:18.930' AS DateTime), 1, 1, 0, N'0 tiếng 1 phút', 1000, 102000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2291, CAST(N'2021-04-10 15:12:37.650' AS DateTime), NULL, 2, 1, 0, N'0 giờ 0 phút', 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2292, CAST(N'2021-04-10 15:14:44.247' AS DateTime), CAST(N'2021-04-10 15:18:08.997' AS DateTime), 8, 1, 0, N'0 tiếng 4 phút', 2000, 110000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2293, CAST(N'2021-04-10 15:51:55.440' AS DateTime), CAST(N'2021-04-10 15:52:07.027' AS DateTime), 4, 1, 0, N'0 tiếng 1 phút', 0, 101000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2294, CAST(N'2021-04-10 15:55:26.547' AS DateTime), CAST(N'2021-04-10 15:55:28.237' AS DateTime), 3, 1, 0, N'0 tiếng 0 phút', 0, 100000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2295, CAST(N'2021-04-10 15:57:50.433' AS DateTime), CAST(N'2021-04-10 15:57:52.857' AS DateTime), 4, 1, 0, N'0 tiếng 0 phút', 0, 100000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2296, CAST(N'2021-04-10 16:11:04.200' AS DateTime), CAST(N'2021-04-10 16:12:10.950' AS DateTime), 6, 1, 0, N'0 tiếng 1 phút', 0, 902000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2297, CAST(N'2021-04-10 16:14:45.263' AS DateTime), CAST(N'2021-04-10 16:14:53.393' AS DateTime), 3, 1, 0, N'0 tiếng 0 phút', 0, 0, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2298, CAST(N'2021-04-10 16:20:40.233' AS DateTime), CAST(N'2021-04-10 16:21:06.513' AS DateTime), 3, 1, 0, N'0 tiếng 1 phút', 0, 1000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2299, CAST(N'2021-04-10 16:36:06.010' AS DateTime), CAST(N'2021-04-10 16:38:40.583' AS DateTime), 2, 1, 0, N'0 tiếng 2 phút', 0, 2000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2300, CAST(N'2021-04-10 16:39:56.770' AS DateTime), CAST(N'2021-04-10 17:16:20.763' AS DateTime), 4, 1, 0, N'0 tiếng 37 phút', 0, 137000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2301, CAST(N'2021-04-10 16:51:15.710' AS DateTime), CAST(N'2021-04-10 17:15:58.867' AS DateTime), 3, 1, 0, N'0 tiếng 24 phút', 0, 24000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2302, CAST(N'2021-04-10 17:15:09.390' AS DateTime), CAST(N'2021-04-10 17:15:14.607' AS DateTime), 2, 1, 0, N'0 tiếng 0 phút', 0, 0, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2303, CAST(N'2021-04-10 17:17:05.823' AS DateTime), CAST(N'2021-04-10 17:17:08.637' AS DateTime), 4, 1, 0, N'0 tiếng 0 phút', 0, 100000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2304, CAST(N'2021-04-10 17:17:22.580' AS DateTime), CAST(N'2021-04-10 17:18:40.250' AS DateTime), 2, 1, 0, N'0 tiếng 1 phút', 0, 1000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2305, CAST(N'2021-04-10 17:17:23.673' AS DateTime), CAST(N'2021-04-10 17:19:23.807' AS DateTime), 4, 1, 0, N'0 tiếng 2 phút', 0, 102000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2306, CAST(N'2021-04-10 17:19:20.340' AS DateTime), CAST(N'2021-04-10 17:21:33.690' AS DateTime), 2, 1, 0, N'0 tiếng 2 phút', 0, 2000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2307, CAST(N'2021-04-10 17:21:54.273' AS DateTime), CAST(N'2021-04-10 17:28:35.057' AS DateTime), 4, 1, 0, N'0 tiếng 7 phút', 0, 507000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2308, CAST(N'2021-04-10 17:21:58.437' AS DateTime), CAST(N'2021-04-10 17:28:30.213' AS DateTime), 2, 1, 0, N'0 tiếng 7 phút', 0, 507000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2310, CAST(N'2021-04-10 17:22:02.593' AS DateTime), CAST(N'2021-04-10 17:39:33.850' AS DateTime), 6, 1, 0, N'0 tiếng 17 phút', 0, 34000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2311, CAST(N'2021-04-10 17:22:03.743' AS DateTime), CAST(N'2021-04-10 17:39:56.753' AS DateTime), 8, 1, 30, N'0 tiếng 17 phút', 0, 303800, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2312, CAST(N'2021-04-10 17:28:38.973' AS DateTime), CAST(N'2021-04-10 17:31:13.157' AS DateTime), 1, 1, 0, N'0 tiếng 3 phút', 0, 203000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2313, CAST(N'2021-04-10 17:28:41.170' AS DateTime), CAST(N'2021-04-10 17:30:57.100' AS DateTime), 4, 1, 0, N'0 tiếng 2 phút', 0, 2000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2314, CAST(N'2021-04-10 17:28:50.497' AS DateTime), CAST(N'2021-04-10 17:32:30.687' AS DateTime), 5, 1, 0, N'0 tiếng 4 phút', 0, 4000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2315, CAST(N'2021-04-10 17:33:10.980' AS DateTime), CAST(N'2021-04-10 17:33:13.770' AS DateTime), 1, 1, 0, N'0 tiếng 0 phút', 0, 100000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2316, CAST(N'2021-04-10 17:33:21.660' AS DateTime), CAST(N'2021-04-10 17:33:26.100' AS DateTime), 1, 1, 0, N'0 tiếng 0 phút', 0, 100000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2317, CAST(N'2021-04-10 17:33:23.910' AS DateTime), CAST(N'2021-04-10 17:33:44.820' AS DateTime), 2, 1, 0, N'0 tiếng 0 phút', 0, 100000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2318, CAST(N'2021-04-10 17:33:32.347' AS DateTime), CAST(N'2021-04-10 17:33:35.817' AS DateTime), 5, 1, 0, N'0 tiếng 0 phút', 0, 0, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2319, CAST(N'2021-04-10 17:33:33.677' AS DateTime), CAST(N'2021-04-10 17:33:40.380' AS DateTime), 4, 1, 0, N'0 tiếng 0 phút', 0, 0, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2320, CAST(N'2021-04-10 17:36:56.693' AS DateTime), CAST(N'2021-04-10 17:38:29.660' AS DateTime), 1, 1, 0, N'0 tiếng 2 phút', 0, 102000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2321, CAST(N'2021-04-10 17:36:58.750' AS DateTime), CAST(N'2021-04-10 17:38:01.567' AS DateTime), 4, 1, 0, N'0 tiếng 1 phút', 0, 1000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2323, CAST(N'2021-04-10 17:39:21.067' AS DateTime), CAST(N'2021-04-10 17:40:38.360' AS DateTime), 5, 1, 30, N'0 tiếng 1 phút', 0, 700, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2324, CAST(N'2021-04-10 17:39:22.230' AS DateTime), CAST(N'2021-04-10 17:40:57.113' AS DateTime), 4, 1, 30, N'0 tiếng 1 phút', 0, 70700, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2325, CAST(N'2021-04-10 17:41:17.593' AS DateTime), CAST(N'2021-04-10 17:44:44.597' AS DateTime), 4, 1, 0, N'0 tiếng 3 phút', 0, 503000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2326, CAST(N'2021-04-10 17:41:22.537' AS DateTime), CAST(N'2021-04-10 17:44:24.137' AS DateTime), 2, 1, 0, N'0 tiếng 3 phút', 0, 3000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2328, CAST(N'2021-04-10 17:41:24.973' AS DateTime), CAST(N'2021-04-10 17:44:55.410' AS DateTime), 5, 1, 0, N'0 tiếng 3 phút', 0, 103000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2329, CAST(N'2021-04-10 17:41:28.220' AS DateTime), CAST(N'2021-04-12 08:33:01.347' AS DateTime), 7, 1, 0, N'38 tiếng 51 phút', 0, 4662000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2330, CAST(N'2021-04-10 17:41:29.347' AS DateTime), CAST(N'2021-05-05 13:54:40.363' AS DateTime), 9, 1, 0, N'596 tiếng 13 phút', 0, 71576000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2331, CAST(N'2021-04-10 17:55:41.167' AS DateTime), CAST(N'2021-04-10 22:58:21.243' AS DateTime), 3, 1, 0, N'5 tiếng 3 phút', 0, 403000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2332, CAST(N'2021-04-10 22:12:01.867' AS DateTime), NULL, 1, 1, 0, N'0 giờ 0 phút', 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2333, CAST(N'2021-04-10 22:39:17.837' AS DateTime), CAST(N'2021-04-10 23:00:25.303' AS DateTime), 4, 1, 0, N'0 tiếng 21 phút', 0, 21000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2334, CAST(N'2021-04-10 22:39:23.407' AS DateTime), CAST(N'2021-04-10 22:57:55.073' AS DateTime), 2, 1, 0, N'0 tiếng 18 phút', 0, 18000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2336, CAST(N'2021-04-10 23:00:31.943' AS DateTime), CAST(N'2021-04-10 23:00:35.953' AS DateTime), 4, 1, 0, N'0 tiếng 0 phút', 0, 400000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2337, CAST(N'2021-04-11 22:16:42.157' AS DateTime), CAST(N'2021-04-11 23:54:13.830' AS DateTime), 2, 1, 0, N'1 tiếng 38 phút', 0, 298000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2339, CAST(N'2021-04-12 08:16:44.053' AS DateTime), CAST(N'2021-04-12 08:16:49.883' AS DateTime), 2, 1, 0, N'0 tiếng 0 phút', 2044000, 2044000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2340, CAST(N'2021-04-12 08:40:43.577' AS DateTime), CAST(N'2021-04-19 20:25:20.543' AS DateTime), 1, 1, 0, N'179 tiếng 45 phút', 0, 10785000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2341, CAST(N'2021-04-20 10:41:28.760' AS DateTime), CAST(N'2021-04-25 21:04:04.660' AS DateTime), 1, 1, 0, N'130 tiếng 23 phút', 0, 7823000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2342, CAST(N'2021-04-25 21:05:38.363' AS DateTime), CAST(N'2021-04-25 21:05:43.283' AS DateTime), 1, 1, 0, N'0 tiếng 0 phút', 0, 0, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2343, CAST(N'2021-04-25 21:05:49.247' AS DateTime), CAST(N'2021-04-25 21:05:58.027' AS DateTime), 1, 1, 0, N'0 tiếng 0 phút', 0, 400000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2344, CAST(N'2021-04-25 21:06:30.050' AS DateTime), CAST(N'2021-04-25 21:06:41.377' AS DateTime), 1, 1, 0, N'0 tiếng 0 phút', 0, 900000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2345, CAST(N'2021-04-25 21:28:48.240' AS DateTime), CAST(N'2021-04-25 21:28:51.677' AS DateTime), 1, 1, 0, N'0 tiếng 0 phút', 0, 100000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2346, CAST(N'2021-04-25 21:29:00.273' AS DateTime), CAST(N'2021-04-28 13:59:39.473' AS DateTime), 1, 1, 0, N'64 tiếng 30 phút', 0, 4070000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2347, CAST(N'2021-04-25 21:29:01.573' AS DateTime), CAST(N'2021-04-25 23:57:40.100' AS DateTime), 3, 1, 0, N'2 tiếng 28 phút', 0, 348000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2348, CAST(N'2021-04-25 21:29:03.810' AS DateTime), CAST(N'2021-05-07 16:34:24.763' AS DateTime), 21, 1, 0, N'283 tiếng 5 phút', 0, 33970000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2350, CAST(N'2021-04-26 11:04:07.303' AS DateTime), CAST(N'2021-04-26 11:04:13.960' AS DateTime), 2, 1, 0, N'0 tiếng 0 phút', 0, 0, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2351, CAST(N'2021-04-26 11:04:27.567' AS DateTime), CAST(N'2021-04-26 23:21:48.370' AS DateTime), 5, 1, 0, N'12 tiếng 17 phút', 0, 767000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2352, CAST(N'2021-04-26 11:04:35.107' AS DateTime), CAST(N'2021-04-26 13:57:29.083' AS DateTime), 3, 1, 2, N'2 tiếng 53 phút', 0, 365540, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2353, CAST(N'2021-04-27 13:34:27.917' AS DateTime), NULL, 4, 1, 0, N'0 giờ 0 phút', 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2354, CAST(N'2021-04-27 23:34:18.203' AS DateTime), CAST(N'2021-04-27 23:34:25.493' AS DateTime), 3, 1, 0, N'0 tiếng 0 phút', 0, 0, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2355, CAST(N'2021-04-28 13:59:34.223' AS DateTime), NULL, 2, 1, 0, N'0 giờ 0 phút', 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2356, CAST(N'2021-04-28 16:37:28.910' AS DateTime), CAST(N'2021-05-03 10:25:48.907' AS DateTime), 3, 1, 0, N'113 tiếng 48 phút', 0, 7028000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2357, CAST(N'2021-04-28 16:43:29.860' AS DateTime), CAST(N'2021-04-28 16:44:26.997' AS DateTime), 1, 1, 0, N'0 tiếng 1 phút', 164000, 165000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2358, CAST(N'2021-04-28 16:52:43.187' AS DateTime), CAST(N'2021-05-01 17:00:29.630' AS DateTime), 2, 1, 0, N'72 tiếng 8 phút', 0, 4843000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2359, CAST(N'2021-04-28 16:52:55.353' AS DateTime), CAST(N'2021-05-05 13:54:35.100' AS DateTime), 5, 1, 0, N'165 tiếng 2 phút', 0, 9902000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2360, CAST(N'2021-05-01 16:31:58.200' AS DateTime), CAST(N'2021-05-07 16:34:54.467' AS DateTime), 33, 1, 0, N'144 tiếng 3 phút', 0, 9043000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2361, CAST(N'2021-05-04 10:40:14.017' AS DateTime), CAST(N'2021-05-05 13:53:45.823' AS DateTime), 2, 1, 0, N'27 tiếng 13 phút', 0, 1633000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2362, CAST(N'2021-05-04 10:40:19.103' AS DateTime), CAST(N'2021-05-05 13:53:59.277' AS DateTime), 3, 1, 0, N'27 tiếng 13 phút', 0, 1833000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2363, CAST(N'2021-05-05 13:54:15.667' AS DateTime), CAST(N'2021-05-05 13:54:18.530' AS DateTime), 3, 1, 0, N'0 tiếng 0 phút', 11540000, 11740000, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2364, CAST(N'2021-05-06 21:52:00.980' AS DateTime), NULL, 3, 0, 0, N'0 giờ 0 phút', 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2366, CAST(N'2021-05-07 10:19:25.980' AS DateTime), NULL, 4, 0, 0, N'0 giờ 0 phút', 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2367, CAST(N'2021-05-07 11:47:16.273' AS DateTime), NULL, 9, 0, 0, N'0 giờ 0 phút', 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2368, CAST(N'2021-05-07 12:36:05.260' AS DateTime), NULL, 2, 0, 0, N'0 giờ 0 phút', 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [DateTimeCheckIn], [DateTimeCheckOut], [idRoom], [status], [DisCount], [ToTalTime], [PRiceOldTime], [totalPrice], [CheckSwitch]) VALUES (2369, CAST(N'2021-05-08 13:31:29.237' AS DateTime), NULL, 34, 0, 0, N'0 giờ 0 phút', 0, NULL, 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (1269, 1286, 38, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (1271, 1287, 38, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (1272, 1287, 30, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (1274, 1288, 36, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (1275, 1288, 30, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (1277, 1289, 29, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (1278, 1289, 33, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (1279, 1290, 33, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (1280, 1290, 38, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2270, 2286, 33, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2271, 2286, 38, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2279, 2296, 38, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2281, 2299, 50, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2290, 2300, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2294, 2302, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2295, 2301, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2298, 2304, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2299, 2306, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2310, 2321, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2313, 2310, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2315, 2311, 38, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2316, 2323, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2318, 2326, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2322, 2334, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2323, 2333, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2328, 2339, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2329, 2329, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2331, 2340, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2335, 2330, 30, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2338, 2341, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2339, 2342, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2342, 2344, 38, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2346, 2350, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2347, 2351, 30, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2352, 2346, 51, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2353, 2363, 51, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2354, 2354, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2355, 2357, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2356, 2358, 29, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2357, 2358, 30, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2358, 2358, 38, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2359, 2360, 29, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2360, 2356, 29, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2361, 2362, 29, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2362, 2361, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2363, 2359, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2365, 2367, 29, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2366, 2367, 33, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2367, 2348, 50, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2368, 2368, 51, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2369, 2368, 38, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2370, 2369, 38, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2371, 2369, 29, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2372, 2369, 36, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idService], [countService]) VALUES (2373, 2366, 29, 1)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (1, N'Phòng 101', 1, N' Trống', N'phòng có 2 mic, 1 tivi, 2 thùng lớn , 3 ghế ,2 bàn,...')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (2, N'Phòng 102', 1, N'Có Người', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (3, N'Phòng 103', 1, N'Có Người', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (4, N'Phòng 104', 1, N'Có Người', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (5, N'Phòng 105', 1, N' Trống', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (6, N'Phòng 201', 2, N' Trống', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (7, N'Phòng 202', 2, N' Trống', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (8, N'Phòng 203', 2, N' Trống', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (9, N'Phòng 204', 2, N'Có Người', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (21, N'Phòng 205', 2, N' Trống', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (33, N'Phòng 106', 1, N' Trống', N'Trống')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (34, N'Phòng 107', 1, N'Có Người', N'Phòng bao gồm: quạt ,..')
INSERT [dbo].[Room] ([id], [name], [idRoomCategory], [status], [RoomInformation]) VALUES (38, N'Phòng 108', 2, N' Trống', N'Phòng bao gồm: máy lạnh và 2 loa')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[RoomCategory] ON 

INSERT [dbo].[RoomCategory] ([id], [RoomNameCategory], [Price]) VALUES (1, N'Phòng Thường', 60000)
INSERT [dbo].[RoomCategory] ([id], [RoomNameCategory], [Price]) VALUES (2, N'Phòng VIP', 120000)
SET IDENTITY_INSERT [dbo].[RoomCategory] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (29, N'Sườn nướng', 11, 200000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (30, N'7 Up', 13, 15000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (31, N'Sting', 12, 15000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (32, N'Coca Cola', 12, 15000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (33, N'Bia 333', 13, 15000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (34, N'Bia SaiGon', 13, 15000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (36, N'Canh chua', 11, 100000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (38, N'Chả chiên', 14, 100000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (50, N'Trống', 24, 0)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (51, N'Trái Cây ngũ quả', 15, 100000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (52, N'cocacola', 12, 100000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (53, N'Mực xào chua ngọt', 11, 200000)
INSERT [dbo].[Service] ([id], [name], [idServiceCategory], [price]) VALUES (54, N'bánh ngọt', 14, 20000)
SET IDENTITY_INSERT [dbo].[Service] OFF
SET IDENTITY_INSERT [dbo].[ServiceCategory] ON 

INSERT [dbo].[ServiceCategory] ([id], [name]) VALUES (11, N'Thêm Món ăn')
INSERT [dbo].[ServiceCategory] ([id], [name]) VALUES (12, N'Thêm nước uống')
INSERT [dbo].[ServiceCategory] ([id], [name]) VALUES (13, N'Thêm Bia')
INSERT [dbo].[ServiceCategory] ([id], [name]) VALUES (14, N'Thêm đồ ăn vặt')
INSERT [dbo].[ServiceCategory] ([id], [name]) VALUES (15, N'Thêm Trái Cây')
INSERT [dbo].[ServiceCategory] ([id], [name]) VALUES (24, N'Trống')
SET IDENTITY_INSERT [dbo].[ServiceCategory] OFF
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idRoom])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idService])
REFERENCES [dbo].[Service] ([id])
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([idRoomCategory])
REFERENCES [dbo].[RoomCategory] ([id])
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD FOREIGN KEY([idServiceCategory])
REFERENCES [dbo].[ServiceCategory] ([id])
GO
/****** Object:  StoredProcedure [dbo].[USP_GetBillInfoByRoom]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetBillInfoByRoom]
@idBill int
as
begin
SELECT  r.name ,b.totalPrice , b.DateTimeCheckOut ,b.DateTimeCheckIn ,b.DisCount, bi.countService, se.price, se.price*bi.countService as [Price] , se.name,CONCAT((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60),N' tiếng ' ,(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60),' phút') AS [Time],((DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)%60)*rc.Price/60) AS [TimePrice], b.PRiceOldTime,((DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)%60)*rc.Price/60)+b.PRiceOldTime [TotalTimePrice]
FROM dbo.Bill AS b,dbo.Room AS r ,dbo.Service as se, dbo.BillInfo as bi, RoomCategory as rc
WHERE  b.status = 1 AND b.CheckSwitch=0 AND bi.idBill=b.id and bi.idService =se.id and b.idRoom=r.id and b.id=@idBill and rc.id=r.idRoomCategory
end

GO
/****** Object:  StoredProcedure [dbo].[USP_GetDateCurrent]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetDateCurrent]
@checkIn datetime,@checkOut datetime 
AS
BEGIN

SELECT @checkIn,@checkOut 
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDate]
@checkIn datetime,@checkOut datetime 
AS
BEGIN

SELECT r.name AS[tên phòng],b.totalPrice AS [Tổng tiền], b.DateTimeCheckOut [Ngày/Giờ vào],b.DateTimeCheckIn AS[Ngày/Giờ ra],b.DisCount AS [Giảm giá] 
FROM dbo.Bill AS b,dbo.Room AS r 
WHERE b.DateTimeCheckIn>=@checkIn AND b.DateTimeCheckOut<=@checkOut AND b.status = 1 AND b.CheckSwitch=0 AND r.id=b.idRoom 
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateAndPage]
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
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateForReport]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateForReport]
@checkIn datetime,@checkOut datetime 
AS
BEGIN


SELECT DISTINCT
         @checkIn,@checkOut,b.id,r.name ,b.totalPrice , b.DateTimeCheckOut ,b.DateTimeCheckIn ,b.DisCount,((DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)%60)*rc.Price/60) AS [TimePrice],b.PRiceOldTime,((DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, b.DateTimeCheckOut)%60)*rc.Price/60)+b.PRiceOldTime [TotalTimePrice],
        (   SELECT concat(se.name, N' (Số lượng: ',bi.countService,') ') +', ' AS [text()]
            FROM BillInfo as bi , Service as se
            WHERE bi.idBill = b.id and bi.idService=se.id
            ORDER BY bi.idBill
            FOR XML PATH(''))[Service]
FROM Bill as b, Room as r, BillInfo as bi,RoomCategory as rc
where b.DateTimeCheckIn>=@checkIn AND b.DateTimeCheckOut<=@checkOut AND b.status = 1 AND b.CheckSwitch=0 AND b.id=bi.idBill and r.id=b.idRoom and r.idRoomCategory=rc.id
end

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListPriceOldTime]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListPriceOldTime]
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
/****** Object:  StoredProcedure [dbo].[USP_GetNumBillByDate]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[USP_GetNumBillByDate]
@checkIn datetime,@checkOut datetime 
AS
BEGIN

SELECT COUNT(*)
FROM dbo.Bill AS b,dbo.Room AS r 
WHERE b.DateTimeCheckIn>=@checkIn AND b.DateTimeCheckOut<=@checkOut AND b.status = 1 AND b.CheckSwitch=0 AND r.id=b.idRoom 
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetRoomList]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetRoomList]
AS SELECT *FROM dbo.Room

GO
/****** Object:  StoredProcedure [dbo].[USP_InserBill]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InserBill]
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
/****** Object:  StoredProcedure [dbo].[USP_InserStartBill]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InserStartBill]
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
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC	[dbo].[USP_InsertBillInfo]
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
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Login]
@userName NVARCHAR(100),@passWord nvarchar(100)
AS
BEGIN
	SELECT *FROM dbo.Account WHERE UserName=@userName AND PassWord=@passWord
END

GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTable]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[USP_SwitchTable]
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
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 08/05/2021 21:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccount]
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


END

GO
USE [master]
GO
ALTER DATABASE [QuanLiPhongKaraoke] SET  READ_WRITE 
GO
