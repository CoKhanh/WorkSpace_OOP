USE [master]
GO
/****** Object:  Database [QLNV]    Script Date: 5/19/2019 11:25:37 PM ******/
CREATE DATABASE [QLNV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLNV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLNV.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLNV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLNV_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLNV] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLNV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLNV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLNV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLNV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLNV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLNV] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLNV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLNV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLNV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLNV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLNV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLNV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLNV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLNV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLNV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLNV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLNV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLNV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLNV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLNV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLNV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLNV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLNV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLNV] SET RECOVERY FULL 
GO
ALTER DATABASE [QLNV] SET  MULTI_USER 
GO
ALTER DATABASE [QLNV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLNV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLNV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLNV] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLNV] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLNV', N'ON'
GO
USE [QLNV]
GO
/****** Object:  Table [dbo].[CHAMCONG]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHAMCONG](
	[MaNV] [nchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[NgayThang] [date] NOT NULL,
	[CheckIn] [time](7) NULL,
	[CheckOut] [time](7) NULL,
	[TG] [nchar](10) NULL,
	[Thang] [nchar](10) NULL,
 CONSTRAINT [PK_CHAMCONG] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[HoTen] ASC,
	[NgayThang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[id] [nchar](10) NOT NULL,
	[password] [nchar](10) NULL,
 CONSTRAINT [PK_DangNhap] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DUAN]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DUAN](
	[MaDA] [nchar](10) NOT NULL,
	[TenDA] [nvarchar](50) NULL,
	[Phong] [nchar](10) NULL,
	[KinhPhi] [nchar](10) NULL,
	[DangTienHanh] [nvarchar](50) NULL,
 CONSTRAINT [PK_DUAN] PRIMARY KEY CLUSTERED 
(
	[MaDA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHANCONG]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANCONG](
	[MaDA] [nchar](10) NOT NULL,
	[MaNV] [nchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
 CONSTRAINT [PK_PHANCONG] PRIMARY KEY CLUSTERED 
(
	[MaDA] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHONGBAN]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONGBAN](
	[MaPB] [nchar](10) NOT NULL,
	[TenPB] [nvarchar](50) NULL,
	[TruongPhong] [nchar](10) NOT NULL,
	[TenTrPhong] [nvarchar](50) NULL,
 CONSTRAINT [PK_PHONGBAN_1] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STAFFS]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STAFFS](
	[MaNV] [nchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[Phai] [nchar](10) NULL,
	[SDT] [nchar](10) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Luong] [nchar](10) NULL,
	[PhongBan] [nchar](10) NULL,
	[NowWorking] [nvarchar](50) NULL,
 CONSTRAINT [PK_STAFFS] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaNV] [nchar](10) NOT NULL,
	[Pass] [nvarchar](50) NOT NULL,
	[ChucVu] [nchar](10) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TinhLuong]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhLuong](
	[ThangNam] [nchar](10) NOT NULL,
	[MaNV] [nchar](10) NOT NULL,
	[SoNgayDiLam] [nchar](10) NULL,
	[SoNgayNghi] [nchar](10) NULL,
	[SoNgayTre] [nchar](10) NULL,
	[TienPhat] [nvarchar](50) NULL,
	[DuAnThamGia] [nchar](10) NULL,
	[TienDuAn] [nvarchar](50) NULL,
	[LuongCoBan] [nvarchar](50) NULL,
	[Luong] [nvarchar](50) NULL,
 CONSTRAINT [PK_TinhLuong] PRIMARY KEY CLUSTERED 
(
	[ThangNam] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'001       ', N'Dương Cơ Khánh', CAST(N'2019-05-10' AS Date), CAST(N'06:31:08' AS Time), CAST(N'21:25:38' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'001       ', N'Dương Cơ Khánh', CAST(N'2019-05-11' AS Date), CAST(N'07:04:49' AS Time), CAST(N'16:54:49' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'001       ', N'Dương Cơ Khánh', CAST(N'2019-05-15' AS Date), CAST(N'19:23:55' AS Time), CAST(N'19:24:02' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'001       ', N'Dương Cơ Khánh', CAST(N'2019-05-16' AS Date), CAST(N'08:10:27' AS Time), CAST(N'08:10:38' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'001       ', N'Dương Cơ Khánh', CAST(N'2019-05-19' AS Date), CAST(N'18:13:30' AS Time), CAST(N'18:13:36' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'001       ', N'Dương Cơ Khánh', CAST(N'2019-12-04' AS Date), CAST(N'14:03:59' AS Time), CAST(N'17:02:09' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-03-01' AS Date), CAST(N'06:02:02' AS Time), CAST(N'11:06:07' AS Time), NULL, N'3         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-03-02' AS Date), CAST(N'06:43:29' AS Time), CAST(N'17:15:00' AS Time), NULL, N'3         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-12' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-13' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-14' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-15' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-16' AS Date), CAST(N'08:22:50' AS Time), CAST(N'15:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-17' AS Date), CAST(N'09:22:50' AS Time), CAST(N'20:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-18' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-19' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-20' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-21' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-22' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-23' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-24' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-25' AS Date), CAST(N'07:03:28' AS Time), CAST(N'16:59:03' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-26' AS Date), CAST(N'06:34:09' AS Time), CAST(N'17:03:00' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-27' AS Date), CAST(N'06:53:00' AS Time), CAST(N'16:49:04' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-28' AS Date), CAST(N'06:47:32' AS Time), CAST(N'16:45:09' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-29' AS Date), CAST(N'06:54:00' AS Time), CAST(N'17:02:00' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-04-30' AS Date), CAST(N'06:40:30' AS Time), CAST(N'14:40:00' AS Time), NULL, N'4         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-01' AS Date), CAST(N'06:30:00' AS Time), CAST(N'16:50:00' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-02' AS Date), CAST(N'07:30:00' AS Time), CAST(N'17:09:00' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-04' AS Date), CAST(N'06:50:30' AS Time), CAST(N'16:57:42' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-07' AS Date), CAST(N'07:45:00' AS Time), CAST(N'16:43:00' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-08' AS Date), CAST(N'07:18:31' AS Time), CAST(N'16:52:32' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-09' AS Date), CAST(N'06:48:28' AS Time), CAST(N'16:42:06' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-10' AS Date), CAST(N'07:05:00' AS Time), CAST(N'17:05:02' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-11' AS Date), CAST(N'07:25:00' AS Time), CAST(N'16:29:27' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-12' AS Date), CAST(N'13:37:36' AS Time), CAST(N'13:37:36' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-13' AS Date), CAST(N'06:45:25' AS Time), CAST(N'17:02:09' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-15' AS Date), CAST(N'11:24:03' AS Time), CAST(N'11:24:06' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-16' AS Date), CAST(N'09:28:24' AS Time), CAST(N'09:28:27' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-17' AS Date), CAST(N'00:22:50' AS Time), CAST(N'00:22:53' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-18' AS Date), CAST(N'01:13:29' AS Time), CAST(N'01:13:49' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'2019-05-19' AS Date), CAST(N'18:12:51' AS Time), CAST(N'18:13:01' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'003       ', N'Võ Đăng Khoa', CAST(N'2019-05-17' AS Date), CAST(N'21:03:47' AS Time), CAST(N'21:03:55' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'004       ', N'Đỗ Tường Khải', CAST(N'2019-05-08' AS Date), CAST(N'06:39:00' AS Time), CAST(N'16:52:07' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'004       ', N'Đỗ Tường Khải', CAST(N'2019-05-09' AS Date), CAST(N'06:29:18' AS Time), CAST(N'16:29:44' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'004       ', N'Đỗ Tường Khải', CAST(N'2019-05-10' AS Date), CAST(N'07:06:03' AS Time), CAST(N'17:06:15' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'004       ', N'Đỗ Tường Khải', CAST(N'2019-05-12' AS Date), CAST(N'14:06:01' AS Time), CAST(N'14:06:01' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'004       ', N'Đỗ Tường Khải', CAST(N'2019-05-14' AS Date), CAST(N'22:57:06' AS Time), CAST(N'13:55:41' AS Time), NULL, NULL)
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'004       ', N'Đỗ Tường Khải', CAST(N'2019-05-17' AS Date), CAST(N'13:58:23' AS Time), CAST(N'13:58:27' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'005       ', N'Võ Bùi Đăng Khoa', CAST(N'2019-05-14' AS Date), CAST(N'23:02:37' AS Time), CAST(N'23:02:38' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'006       ', N'Hoàng Thị Thu Mai', CAST(N'2019-05-08' AS Date), CAST(N'06:53:03' AS Time), CAST(N'16:53:03' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'006       ', N'Hoàng Thị Thu Mai', CAST(N'2019-05-09' AS Date), CAST(N'06:40:57' AS Time), CAST(N'16:40:58' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'006       ', N'Hoàng Thị Thu Mai', CAST(N'2019-05-10' AS Date), CAST(N'06:32:09' AS Time), CAST(N'17:02:09' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'006       ', N'Hoàng Thị Thu Mai', CAST(N'2019-05-12' AS Date), CAST(N'14:03:59' AS Time), CAST(N'14:03:59' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'006       ', N'Hoàng Thị Thu Mai', CAST(N'2019-05-15' AS Date), CAST(N'11:24:50' AS Time), CAST(N'11:24:52' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'006       ', N'Hoàng Thị Thu Mai', CAST(N'2019-05-16' AS Date), CAST(N'10:38:54' AS Time), CAST(N'10:38:56' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'006       ', N'Hoàng Thị Thu Mai', CAST(N'2019-05-17' AS Date), CAST(N'21:53:22' AS Time), CAST(N'21:53:26' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'007       ', N'Vương Thị Thu Trang', CAST(N'2019-05-17' AS Date), CAST(N'21:04:10' AS Time), CAST(N'21:04:13' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'008       ', N'Hà Kiều Oanh', CAST(N'2019-05-17' AS Date), CAST(N'21:53:34' AS Time), CAST(N'21:53:36' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'009       ', N'Nguyễn Thị Thanh Thủy', CAST(N'2019-05-16' AS Date), CAST(N'23:19:04' AS Time), CAST(N'23:19:06' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'011       ', N'Đàm Tổ Triều', CAST(N'2019-05-17' AS Date), CAST(N'21:59:10' AS Time), CAST(N'21:59:13' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'014       ', N'Nguyễn Nhật Quang', CAST(N'2019-05-17' AS Date), CAST(N'09:53:03' AS Time), CAST(N'09:53:09' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'018       ', N'Từ Ngọc Yến', CAST(N'2019-05-17' AS Date), CAST(N'00:34:44' AS Time), CAST(N'00:35:08' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'020       ', N'Trần Thị Kim Nguyên', CAST(N'2019-05-17' AS Date), CAST(N'00:37:38' AS Time), CAST(N'00:37:40' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'021       ', N'Nguyễn Hoàng Hữu Đức', CAST(N'2019-05-17' AS Date), CAST(N'07:14:36' AS Time), CAST(N'07:14:40' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'038       ', N'Nguyễn Mạnh Đình', CAST(N'2019-05-17' AS Date), CAST(N'22:10:07' AS Time), CAST(N'22:10:11' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [HoTen], [NgayThang], [CheckIn], [CheckOut], [TG], [Thang]) VALUES (N'042       ', N'Trần Thanh Tùng', CAST(N'2019-05-18' AS Date), CAST(N'00:16:59' AS Time), CAST(N'00:17:06' AS Time), NULL, N'5         ')
GO
INSERT [dbo].[DangNhap] ([id], [password]) VALUES (N'001       ', N'123       ')
GO
INSERT [dbo].[DangNhap] ([id], [password]) VALUES (N'002       ', N'123       ')
GO
INSERT [dbo].[DangNhap] ([id], [password]) VALUES (N'003       ', N'123       ')
GO
INSERT [dbo].[DangNhap] ([id], [password]) VALUES (N'004       ', N'123       ')
GO
INSERT [dbo].[DangNhap] ([id], [password]) VALUES (N'005       ', N'123       ')
GO
INSERT [dbo].[DangNhap] ([id], [password]) VALUES (N'006       ', N'123       ')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'ABC       ', N'Tìm Kiếm Tài Trợ', N'FN001     ', N'150000    ', N'yes')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'ACGDH     ', N'Promote', N'AD001     ', N'3000000000', N'yes')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'DA001     ', N'Lập trình Windows', N'IT001     ', N'20000     ', N'yes')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'DA002     ', N'Tuyển nhân sự', N'HR001     ', N'22000     ', N'yes')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'DA003     ', N'Quản lý tài chính', N'FN001     ', N'20000     ', N'done')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'DA004     ', N'Tư vấn khách hàng', N'AD001     ', N'20000     ', N'yes')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'DA005     ', N'TKKH', N'CR001     ', N'25000     ', N'yes')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'DA006     ', N'Quảng Cáo Sản Phẩm', N'DS001     ', N'20000     ', N'yes')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'DA007     ', N'Quay TVC', N'DS001     ', N'25000     ', N'yes')
GO
INSERT [dbo].[DUAN] ([MaDA], [TenDA], [Phong], [KinhPhi], [DangTienHanh]) VALUES (N'DA008     ', N'Tìm Kiếm Tài Trợ', N'MK001     ', N'15000     ', N'yes')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'ABC       ', N'009       ', N'Nguyễn Thị Thanh Thủy')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'ABC       ', N'014       ', N'Nguyễn Nhật Quang')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'ABC       ', N'015       ', N'Đặng Phương Nam')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'ABC       ', N'019       ', N'Trần My')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'ABC       ', N'022       ', N'Mai Kim Trí')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'ABC       ', N'023       ', N'Trần Hữu Thiện Tâm')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'001       ', N'Dương Cơ Khánh')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'002       ', N'Từ Đăng Huy')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'003       ', N'Võ Đăng Khoa')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'004       ', N'Đỗ Tường Khải')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'005       ', NULL)
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'011       ', N'Đàm Tổ Triều')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'019       ', N'Trần My')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'039       ', NULL)
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'040       ', NULL)
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'043       ', N'Tạ Ngọc Tuấn')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA001     ', N'045       ', N'Võ Bùi Tuấn Huy')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA002     ', N'002       ', N'Từ Đăng Huy')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA002     ', N'005       ', N'Võ Bùi Đăng Khoa')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA002     ', N'006       ', N'Hoàng Thị Thu Mai')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA002     ', N'007       ', N'Vương Thị Thu Trang')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA002     ', N'008       ', N'Hà Kiều Oanh')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA002     ', N'022       ', N'Mai Kim Trí')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA002     ', N'030       ', NULL)
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA002     ', N'044       ', N'Phan Thanh Bình')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA002     ', N'046       ', N'Huỳnh Gia Huy')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA003     ', N'001       ', NULL)
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA003     ', N'039       ', NULL)
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA003     ', N'040       ', NULL)
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA004     ', N'002       ', N'Từ Đăng Huy')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA004     ', N'009       ', N'Nguyễn Thị Thanh Thủy')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA004     ', N'010       ', N'Trịnh Nguyễn Chí Sĩ')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA004     ', N'011       ', N'Đàm Tổ Triều')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA004     ', N'014       ', N'Nguyễn Nhật Quang')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA004     ', N'017       ', N'Đỗ Lê Quí')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA004     ', N'018       ', N'Từ Ngọc Yến')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA004     ', N'022       ', N'Mai Kim Trí')
GO
INSERT [dbo].[PHANCONG] ([MaDA], [MaNV], [TenNV]) VALUES (N'DA004     ', N'024       ', N'Hoàng Lê Vương')
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [TruongPhong], [TenTrPhong]) VALUES (N'AD001     ', N'Advertisement', N'018       ', N'Từ Ngọc Yến')
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [TruongPhong], [TenTrPhong]) VALUES (N'CR001     ', N'Customer Relationships', N'011       ', N'Đàm Tổ Triều')
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [TruongPhong], [TenTrPhong]) VALUES (N'DS001     ', N'Media', N'010       ', N'Trịnh Nguyễn Chí Sĩ')
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [TruongPhong], [TenTrPhong]) VALUES (N'FN001     ', N'Finance', N'006       ', N'Hoàng Thị Thu Mai')
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [TruongPhong], [TenTrPhong]) VALUES (N'HR001     ', N'Human Resources', N'019       ', N'Trần My')
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [TruongPhong], [TenTrPhong]) VALUES (N'IT001     ', N'IT', N'002       ', N'Từ Đăng Huy')
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [TruongPhong], [TenTrPhong]) VALUES (N'MA001     ', N'Manage', N'005       ', N'Võ Bùi Đăng Khoa')
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [TenPB], [TruongPhong], [TenTrPhong]) VALUES (N'MK001     ', N'Marketing', N'021       ', N'Mai Kim Trí')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'001       ', N'Dương Cơ Khánh', CAST(N'1999-02-03' AS Date), N'Nam       ', N'0922270762', N'Tp.Hồ Chí Minh', N'13000000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'002       ', N'Từ Đăng Huy', CAST(N'1999-04-03' AS Date), N'Nam       ', N'0976960375', N'Tp.Hồ Chí Minh', N'13500000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'003       ', N'Võ Đăng Khoa', CAST(N'1999-03-04' AS Date), N'Nam       ', N'9876543210', N'Long An', N'10000000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'004       ', N'Đỗ Tường Khải', CAST(N'1999-09-01' AS Date), N'Nam       ', N'0000000000', N'Long An', N'12700000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'005       ', N'Võ Bùi Đăng Khoa', CAST(N'1999-06-03' AS Date), N'Nam       ', N'5566444792', N'Tp.Hồ Chí Minh', N'12700000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'006       ', N'Hoàng Thị Thu Mai', CAST(N'1996-05-04' AS Date), N'Nữ        ', N'0907580512', N'Long An', N'10000000  ', N'FN001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'007       ', N'Vương Thị Thu Trang', CAST(N'1999-02-05' AS Date), N'Nữ        ', N'0100148530', N'Tp.Hồ Chí Minh', N'13500000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'008       ', N'Hà Kiều Oanh', CAST(N'1995-06-05' AS Date), N'Nữ        ', N'0909314520', N'Lâm Đồng', N'10000000  ', N'FN001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'009       ', N'Nguyễn Thị Thanh Thủy', CAST(N'1999-08-09' AS Date), N'Nữ        ', N'4413254879', N'Tp.Hồ Chí Minh', N'10000000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'010       ', N'Trịnh Nguyễn Chí Sĩ', CAST(N'1999-02-01' AS Date), N'Nam       ', N'0938396861', N'Hà Nội', N'12700000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'011       ', N'Đàm Tổ Triều', CAST(N'1999-02-09' AS Date), N'Nam       ', N'0321549845', N'Tp.Hồ Chí Minh', N'12700000  ', N'MK001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'012       ', N'Bùi Tiến Dũng', CAST(N'2019-05-17' AS Date), N'Nam       ', N'0123456789', N'Đà Nẵng', N'10000000  ', N'CR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'013       ', N'Lương Ngọc Tuấn', CAST(N'2019-05-17' AS Date), N'Nam       ', N'0123456789', N'Tp.Hồ Chí Minh', N'10000000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'014       ', N'Nguyễn Nhật Quang', CAST(N'2019-04-19' AS Date), N'Nam       ', N'0978456321', N'Tp.Hồ Chí Minh', N'15000000  ', N'CR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'015       ', N'Đặng Phương Nam', CAST(N'2019-04-27' AS Date), N'Nam       ', N'5647382910', N'Đà Nẵng', N'13500000  ', N'CR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'016       ', N'Nguyễn Cao Sơn Tùng', CAST(N'1997-10-12' AS Date), N'Nam       ', N'0987123456', N'Tp.Hồ Chí Minh', N'12700000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'017       ', N'Đỗ Lê Quí', CAST(N'1999-10-24' AS Date), N'Nam       ', N'0162345879', N'TP HCM', N'13500000  ', N'IT001     ', N'No')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'018       ', N'Từ Ngọc Yến', CAST(N'1996-01-06' AS Date), N'Nữ        ', N'0927136782', N'Trà Vinh', N'15000000  ', N'MK001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'019       ', N'Trần My', CAST(N'1995-06-20' AS Date), N'Nữ        ', N'0912837465', N'Tp.Hồ Chí Minh', N'10000000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'020       ', N'Trần Thị Kim Nguyên', CAST(N'1999-09-03' AS Date), N'Nữ        ', N'0192837456', N'Tp.Hồ Chí Minh', N'15000000  ', N'CR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'021       ', N'Nguyễn Hoàng Hữu Đức', CAST(N'1999-09-14' AS Date), N'Nam       ', N'9124356780', N'Tp.Hồ Chí Minh', N'10000000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'022       ', N'Mai Kim Trí', CAST(N'1994-08-25' AS Date), N'Khác      ', N'0998822771', N'TP.HCM', N'10000000  ', N'FN001     ', N'No')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'023       ', N'Trần Hữu Thiện Tâm', CAST(N'1999-05-26' AS Date), N'Nam       ', N'0912834576', N'Tp.Hồ Chí Minh', N'15000000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'024       ', N'Hoàng Lê Vương', CAST(N'1999-12-22' AS Date), N'Nam       ', N'0918234566', N'Tp.Hồ Chí Minh', N'13500000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'025       ', N'Lâm Thanh Thảo', CAST(N'1993-08-18' AS Date), N'Nữ        ', N'0129384576', N'Trà Vinh', N'13500000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'026       ', N'Hồ Ngọc Sơn Hà', CAST(N'1998-08-12' AS Date), N'Nam       ', N'0981275436', N'Quảng Trị', N'12700000  ', N'CR001     ', N'no')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'027       ', N'Bùi Tuấn Sơn', CAST(N'2019-05-17' AS Date), N'Nam       ', N'0123654987', N'Hà Nội', N'15000000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'028       ', N'Đoàn Nhật Khoa', CAST(N'1998-09-17' AS Date), N'Nam       ', N'0912738489', N'Tp.Hồ Chí Minh', N'13500000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'029       ', N'Lạc Bội San', CAST(N'2019-05-17' AS Date), N'Nam       ', N'3214569870', N'Tp.Hồ Chí Minh', N'12000000  ', N'HR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'030       ', N'Võ Đăng Quang', CAST(N'2019-05-14' AS Date), N'Nam       ', N'132135646 ', N'Tp.Hồ Chí Minh', N'20000     ', N'IT001     ', N'No')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'031       ', N'Lê Văn Qúy', CAST(N'2019-05-14' AS Date), N'Nam       ', N'1234567890', N'Tp.Hồ Chí Minh', N'10000000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'032       ', N'Dương Gia Nghi', CAST(N'2019-05-14' AS Date), N'Nam       ', N'0011224477', N'Tp.Hồ Chí Minh', N'11000000  ', N'FN001     ', N'No')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'033       ', N'Nguyễn Xuân Tuyền', CAST(N'2019-05-17' AS Date), N'Nữ        ', N'0123456789', N'Tp.Hồ Chí Minh', N'12000000  ', N'FN001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'034       ', N'Trần Tú Uyên', CAST(N'2019-05-17' AS Date), N'Nam       ', N'6547892310', N'Tp.Hồ Chí Minh', N'10000000  ', N'MK001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'035       ', N'Trần Thanh Thanh', CAST(N'2019-05-17' AS Date), N'Nam       ', N'2563149087', N'Tp.Hồ Chí Minh', N'12000000  ', N'CR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'036       ', N'Lý Gia Quân', CAST(N'2019-05-15' AS Date), N'Nữ        ', N'1234567890', N'Đà Lạt', N'20000000  ', N'HR001     ', N'No')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'037       ', N'Đoàn Nhật Hào', CAST(N'2019-05-17' AS Date), N'Nam       ', N'1032465798', N'Tp.Hồ Chí Minh', N'12000000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'038       ', N'Nguyễn Mạnh Đình', CAST(N'2019-05-17' AS Date), N'Nam       ', N'1234567890', N'Tp.Hồ Chí Minh', N'10000000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'039       ', N'Phạm Quốc Thuyên', CAST(N'2019-05-17' AS Date), N'Nam       ', N'1032465897', N'Tp.Hồ Chí Minh', N'11500000  ', N'MK001     ', N'No')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'040       ', N'Dương Bách Khoa', CAST(N'2019-05-17' AS Date), N'Nam       ', N'121123311 ', N'Tp.Hồ Chí Minh', N'10000000  ', N'IT001     ', N'No')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'041       ', N'Nguyễn Quang Hải', CAST(N'2019-05-18' AS Date), N'Nam       ', N'0312658974', N'Hà Nội', N'12500000  ', N'MK001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'042       ', N'Trần Thanh Tùng', CAST(N'2001-02-19' AS Date), N'Nam       ', N'0321547890', N'Tp.Hồ Chí Minh', N'10000000  ', N'CR001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'043       ', N'Tạ Ngọc Tuấn', CAST(N'2019-05-18' AS Date), N'Nam       ', N'0123654789', N'Tp.Hồ Chí Minh', N'10000000  ', N'MK001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'044       ', N'Phan Thanh Bình', CAST(N'2019-05-18' AS Date), N'Nam       ', N'654123098 ', N'Tp.Hồ Chí Minh', N'10000000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'045       ', N'Võ Bùi Tuấn Huy', CAST(N'2019-05-19' AS Date), N'Nam       ', N'0223469844', N'Tp.Hồ Chí Minh', N'10000000  ', N'IT001     ', N'Now')
GO
INSERT [dbo].[STAFFS] ([MaNV], [HoTen], [NgaySinh], [Phai], [SDT], [DiaChi], [Luong], [PhongBan], [NowWorking]) VALUES (N'046       ', N'Huỳnh Gia Huy', CAST(N'2019-05-19' AS Date), N'Nam       ', N'0906575156', N'Tp.Hồ Chí Minh', N'10000000  ', N'FN001     ', N'Now')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'001       ', N'2', N'M         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'002       ', N'2', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'003       ', N'1', N'M         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'004       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'005       ', N'1', N'M         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'006       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'007       ', N'1', N'M         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'008       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'009       ', N'1', N'M         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'010       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'011       ', N'1', N'M         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'014       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'015       ', N'1', N'M         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'016       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'017       ', N'1', N'M         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'018       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'019       ', N'1', N'M         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'020       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'021       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'038       ', N'1', N'E         ')
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'042       ', N'1', NULL)
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'043       ', N'1', NULL)
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'044       ', N'1', NULL)
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'045       ', N'1', NULL)
GO
INSERT [dbo].[TaiKhoan] ([MaNV], [Pass], [ChucVu]) VALUES (N'046       ', N'1', NULL)
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'4         ', N'001       ', N'1         ', N'29        ', N'1         ', N'3250000', N'1         ', N'500000', N'10000000  ', N'7250000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'4         ', N'002       ', N'19        ', N'11        ', N'2         ', N'1250000', N'3         ', N'1500000', N'13500000  ', N'13750000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'001       ', N'5         ', N'26        ', N'3         ', N'3800000', N'2         ', N'1000000', N'13000000  ', N'10200000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'002       ', N'15        ', N'16        ', N'4         ', N'2750000', N'3         ', N'1500000', N'13500000  ', N'12250000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'003       ', N'1         ', N'30        ', N'1         ', N'3700000', N'1         ', N'500000', N'10000000  ', N'6800000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'004       ', N'5         ', N'26        ', N'2         ', N'3250000', N'1         ', N'500000', N'12700000  ', N'9950000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'006       ', N'7         ', N'24        ', N'4         ', N'3800000', N'1         ', N'500000', N'10000000  ', N'6700000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'007       ', N'1         ', N'30        ', N'1         ', N'3700000', N'1         ', N'500000', N'13500000  ', N'10300000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'008       ', N'1         ', N'30        ', N'1         ', N'3700000', N'1         ', N'500000', N'10000000  ', N'6800000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'011       ', N'1         ', N'30        ', N'1         ', N'3700000', N'2         ', N'1000000', N'12700000  ', N'10000000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'018       ', N'1         ', N'30        ', N'0         ', N'3000000', N'1         ', N'500000', N'15000000  ', N'12500000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'038       ', N'1         ', N'30        ', N'1         ', N'3750000', N'0         ', N'0', N'10000000  ', N'6250000')
GO
INSERT [dbo].[TinhLuong] ([ThangNam], [MaNV], [SoNgayDiLam], [SoNgayNghi], [SoNgayTre], [TienPhat], [DuAnThamGia], [TienDuAn], [LuongCoBan], [Luong]) VALUES (N'5         ', N'042       ', N'1         ', N'30        ', N'0         ', N'3000000', N'0         ', N'0', N'10000000  ', N'7000000')
GO
ALTER TABLE [dbo].[PHANCONG]  WITH CHECK ADD  CONSTRAINT [FK_PHANCONG_DUAN] FOREIGN KEY([MaDA])
REFERENCES [dbo].[DUAN] ([MaDA])
GO
ALTER TABLE [dbo].[PHANCONG] CHECK CONSTRAINT [FK_PHANCONG_DUAN]
GO
ALTER TABLE [dbo].[PHANCONG]  WITH CHECK ADD  CONSTRAINT [FK_PHANCONG_STAFFS] FOREIGN KEY([MaNV])
REFERENCES [dbo].[STAFFS] ([MaNV])
GO
ALTER TABLE [dbo].[PHANCONG] CHECK CONSTRAINT [FK_PHANCONG_STAFFS]
GO
ALTER TABLE [dbo].[PHONGBAN]  WITH CHECK ADD  CONSTRAINT [FK_PHONGBAN_STAFFS] FOREIGN KEY([TruongPhong])
REFERENCES [dbo].[STAFFS] ([MaNV])
GO
ALTER TABLE [dbo].[PHONGBAN] CHECK CONSTRAINT [FK_PHONGBAN_STAFFS]
GO
/****** Object:  StoredProcedure [dbo].[AssignEmp]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AssignEmp]
@MaDA nchar(10),
@MaNV nchar(10),
@TenNV nvarchar(50)
as
begin 
set nocount on;
insert into PHANCONG(MaDA,MaNV,TenNV)
values (@MaDA,@MaNV,@TenNV)
end 

GO
/****** Object:  StoredProcedure [dbo].[CC_Check]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CC_Check]
@MaNV nchar(10),
@NgayThang Date,
@return nchar OUTPUT
as
begin
set nocount on;
select @return = 'y' from CHAMCONG where MaNV=@MaNV and NgayThang = @NgayThang and CheckOut is null
end

GO
/****** Object:  StoredProcedure [dbo].[CC_edit_info]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CC_edit_info]
@MaNV nchar(10),
@HoTen nvarchar(50),
@NgaySinh Date,
@DiaChi nvarchar(50),
@SDT nchar(10)
as
begin
set nocount on;
update STAFFS set
HoTen = @HoTen,NgaySinh = @NgaySinh, DiaChi=@DiaChi,SDT = @SDT
where MaNV=@MaNV
end

GO
/****** Object:  StoredProcedure [dbo].[CC_InsertCC]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CC_InsertCC]
@MaNV nchar(10),
@HoTen nvarchar(50),
@NgayThang Date,
@CheckIn Time(7),
@Thang nchar(10)
as
begin
set nocount on;
Insert into CHAMCONG(MaNV,HoTen,NgayThang,CheckIn,Thang)
values(@MaNV,@HoTen,@NgayThang,@CheckIn,@Thang)
end

GO
/****** Object:  StoredProcedure [dbo].[CC_InsertRaVe]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CC_InsertRaVe]
@MaNV nchar(10),
@NgayThang Date,
@CheckOut nchar(10)
as
begin 
set nocount on;
update CHAMCONG set
MaNV=@MaNV,NgayThang = @NgayThang,CheckOut = @CheckOut 
where MaNV = @MaNV and NgayThang = @NgayThang and CheckOut is null
end

GO
/****** Object:  StoredProcedure [dbo].[CC_load_bangCC]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CC_load_bangCC]
@MaNV nchar(10),
@Thang nchar(10)
as
begin
set nocount on;
select NgayThang,CheckIn,CheckOut from CHAMCONG where MaNV = @MaNV and Thang = @Thang
end

GO
/****** Object:  StoredProcedure [dbo].[CC_Load_Emp]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[CC_Load_Emp]
@MaNV nchar(10)
as
begin 
set nocount on;
select HoTen,NgaySinh,DiaChi,SDT from STAFFS where MaNV = @MaNV
end

GO
/****** Object:  StoredProcedure [dbo].[CC_load_ID]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CC_load_ID]
@MaNV nchar(10)
as
begin
set nocount on;
Select MaNV,Pass from TaiKhoan where MaNV = @MaNV
end

GO
/****** Object:  StoredProcedure [dbo].[CC_Salary]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[CC_Salary]
@MaNV nchar (10),
@NgayThang nchar(10)
as 
begin
set nocount on;
select   SNDL.SoNgayDiLam,
SNDT.SoNgayDiTre,
SDA.SoDuAnThamGia,Sal.Luong
from 
(Select MaNV,Count(MaNV) as SoNgayDiLam from CHAMCONG where CheckIn is not Null and CheckOut is not null and MaNV = @MaNV and Thang = @NgayThang Group by MaNV,Thang) as SNDL
	,(Select distinct MaNV,isnull((select count(MaNV)from CHAMCONG where CheckIn is not Null and CheckOut is not null and  MaNV = @MaNV and Thang = @NgayThang  and CheckIn > '07:00:00' Group by MaNV,Thang),0) as SoNgayDiTre 
		from CHAMCONG 
			--where CheckIn is not Null and CheckOut is not null and CheckIn > '07:00:00' and  MaNV = @MaNV and Thang = @NgayThang
			Group by MaNV,Thang
			) as SNDT
	,(Select MaNV,Count(PHANCONG.MaDA) as SoDuAnThamGia from PHANCONG,DUAN Where PHANCONG.MaDA=DUAN.MaDA and DUAN.DangTienHanh = 'yes' and PHANCONG.MaNV = @MaNV group by MaNV) as SDA
	,(select MaNV,Luong from STAFFS where MaNV = @MaNV) as Sal
where SNDL.MaNV = SNDT.MaNV and SNDT.MaNV
=SDA.MaNV and SDA.MaNV = Sal.MANV
end

GO
/****** Object:  StoredProcedure [dbo].[CC_Sua_MK]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CC_Sua_MK]
@MaNV nchar(10),
@Pass nvarchar(50)
as
begin 
set nocount on;
update TaiKhoan set
Pass = @Pass
where MaNV=@MaNV
end

GO
/****** Object:  StoredProcedure [dbo].[CheckID]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CheckID]
@MaNV nchar(10),
@return nchar(10) OUTPUT
as
begin
set nocount on;
select @return ='T' where @MaNV not in (select MaNV from TaiKhoan)and @MaNV in (Select MaNV from STAFFS)
end

GO
/****** Object:  StoredProcedure [dbo].[CheckMaNV]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CheckMaNV]
@MaNV nchar(10)
as
Begin
SET NOCOUNT ON
if(@MaNV in (Select MaNV from STAFFS)) 
return 
end

GO
/****** Object:  StoredProcedure [dbo].[Delete_Staff]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Delete_Staff]
@MaNV nchar(10)
as
begin
Set nocount on;
Delete from STAFFS Where MaNV = @MaNV
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteEmpInPro]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteEmpInPro]
@MaDA nchar(10),
@MaNV nchar(10)
as
begin
set nocount on;
Delete from PHANCONG where MaDA = @MaDA and MaNV = @MaNV
end

GO
/****** Object:  StoredProcedure [dbo].[Edit_Project]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Edit_Project]
@MaDA nchar(10),
@TenDA nvarchar(50),
@Phong nchar(10),
@KinhPhi nchar(10),
@DangTienHanh nvarchar(50)
as
begin
set nocount on;
update DUAN 
Set
MaDA = @MaDA,
TenDA = @TenDA,
Phong = @Phong,
KinhPhi=@KinhPhi,
DangTienHanh = @DangTienHanh 
where MaDA = @MaDA
end

GO
/****** Object:  StoredProcedure [dbo].[EditDept]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EditDept]
@MaPB nchar(10),
@TenPB nvarchar(50),
@TruongPhong nchar(10),
@TenTrPhong nvarchar(50)
as
begin
Set nocount on;
Update PHONGBAN set
MaPB = @MaPB,TenPB=@TenPB,TruongPhong=@TruongPhong,TenTrPhong = @TenTrPhong
where MaPB = @MaPB
end

GO
/****** Object:  StoredProcedure [dbo].[editStaff]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editStaff]
@MaNV nchar(10),
@HoTen nvarchar(50),
@NgaySinh date,
@Phai nchar(10),
@SDT nchar(10),
@DiaChi nvarchar(50),
@Luong nchar(10),
@PhongBan nchar(10),
@NowWorking nvarchar(50)
as
begin
Set nocount on;
Update STAFFS 
set
MaNV=@MaNV,HoTen=@HoTen,NgaySinh=@NgaySinh,Phai=@Phai,SDT=@SDT,DiaChi=@DiaChi,Luong=@Luong, PhongBan = @PhongBan,
NowWorking = @NowWorking
where MaNV = @MaNV
end

GO
/****** Object:  StoredProcedure [dbo].[FindDept]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[FindDept]
@MaPB nchar(10)
as
begin
set nocount on;
select TenPB from PHONGBAN where MaPB=@MaPB
end

GO
/****** Object:  StoredProcedure [dbo].[FindProject]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FindProject]
@TenDA nvarchar(50)
as
begin
set nocount on;
select* from DUAN where TenDA like '%' + RTRIM(@TenDA) + '%'  
end

GO
/****** Object:  StoredProcedure [dbo].[FindStaff]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[FindStaff]
@MaNV nchar(10)
as
begin
select HoTen from STAFFS where MaNV  like RTRIM(@MaNV) + '%' and NowWorking ='yes' and @MaNV not in (select TruongPhong from PHONGBAN)
end

GO
/****** Object:  StoredProcedure [dbo].[Hide_staff]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Hide_staff]
@NowWorking nvarchar(50) = 'no',
@MaNV nchar(10)
as
begin
Set nocount on;
Update STAFFS set
NowWorking = @NowWorking
where MaNV = @MaNV
end

GO
/****** Object:  StoredProcedure [dbo].[Insert_Proj]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Insert_Proj]
@MaDA nchar(10),
@TenDA nvarchar(50),
@Phong nchar(10),
@KinhPhi nchar(10),
@DangTienHanh nvarchar(50)
as
begin
set nocount on;
insert into DUAN(MaDA,TenDA,Phong,KinhPhi,DangTienHanh)
values(@MaDA,@TenDA,@Phong,@KinhPhi,@DangTienHanh)
end

GO
/****** Object:  StoredProcedure [dbo].[InsertDept]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertDept]
@MaPB nchar(10),
@TenPB nvarchar(50),
@TruongPhong nchar(10),
@TenTrPhong nvarchar(50)
as
begin
set nocount on;
insert into PHONGBAN(MaPB,TenPB,TruongPhong,TenTrPhong)
values(@MaPB,@TenPB,@TruongPhong,@TenTrPhong)
end

GO
/****** Object:  StoredProcedure [dbo].[insertStaff]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertStaff]
@MaNV nchar(10),
@HoTen nvarchar(50),
@NgaySinh date,
@Phai nchar(10),
@SDT nchar(10),
@DiaChi nvarchar(50),
@Luong nchar(10),
@PhongBan nchar(10),
@NowWorking nvarchar(50)
as
begin
Set nocount on;
insert into STAFFS(MaNV,HoTen,NgaySinh,Phai,SDT,DiaChi,Luong,PhongBan,NowWorking)
values (@MaNV,@HoTen,@NgaySinh,@Phai,@SDT,@DiaChi,@Luong,@PhongBan,@NowWorking)
end

GO
/****** Object:  StoredProcedure [dbo].[Load_Dept]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Load_Dept]
as
begin 
Select* from PHONGBAN 
end

GO
/****** Object:  StoredProcedure [dbo].[Load_Emp_Grby_Dept]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Load_Emp_Grby_Dept]
@MaPB nchar(10)
as
begin
Select MaNV,HoTen,NgaySinh,Phai,SDT,DiaChi,Luong,PHONGBAN From STAFFS where PhongBan = @MaPB
end

GO
/****** Object:  StoredProcedure [dbo].[Load_Employee]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Load_Employee]
as
begin
Select* From STAFFS Where NowWorking ='yes'
end

GO
/****** Object:  StoredProcedure [dbo].[Load_Project]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Load_Project]
as
begin
set nocount on;
Select* From DUAN where DangTienHanh = 'yes'
end

GO
/****** Object:  StoredProcedure [dbo].[LoadEmpProject]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LoadEmpProject]
@MaDA nchar(10)
as
begin
set nocount on;
Select STAFFS.MaNV,STAFFS.HoTen,STAFFS.NgaySinh,STAFFS.Phai,STAFFS.SDT,STAFFS.DiaChi,STAFFS.Luong,STAFFS.PhongBan,STAFFS.NowWorking
From (Select MaNV from PHANCONG where MaDA = @MaDA) as DS,STAFFS
where  DS.MaNV = STAFFS.MaNV and STAFFS.NowWorking='yes'
end

GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Login]
@MaNV nchar(10),
@Password nvarchar(50),
@ChucVu nchar(10) OUTPUT
as
begin 
set nocount on;
Select @ChucVu = ChucVu from TaiKhoan where (MaNV = @MaNV and  @Password = (select Pass from TaiKhoan where MaNV = @MaNV))
end

GO
/****** Object:  StoredProcedure [dbo].[ProFindEmpName]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ProFindEmpName]
@MaNV nchar(10),
@MaDA nchar(10)
as
begin 
set nocount on;
select HoTen from STAFFS where MaNV like RTRIM(@MaNV) + '%' and NowWorking ='yes'
and @MaNV not in (select MaNV from PHANCONG where MaDA = @MaDA)
end

GO
/****** Object:  StoredProcedure [dbo].[Salary_Insert]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Salary_Insert]
@ThangNam nchar(10),
@MaNV nchar(10),
@SoNgayDiLam nchar(10),
@SoNgayNghi nchar(10),
@SoNgayDiTre nchar(10),
@TienPhat nvarchar(50),
@DuAnThamGia nvarchar(10),
@TienThuong nvarchar(10),
@LuongCoBan nvarchar(10),
@TongLuong nchar(10)
as
begin
set nocount on;
insert TinhLuong(ThangNam,MaNV,SoNgayDiLam,SoNgayNghi,SoNgayTre,TienPhat,DuAnThamGia,TienDuAn,LuongCoBan,Luong)
values(@ThangNam,@MaNV,@SoNgayDiLam,@SoNgayNghi,@SoNgayDiTre,@TienPhat,@DuAnThamGia,@TienThuong,@LuongCoBan,@TongLuong)
end

GO
/****** Object:  StoredProcedure [dbo].[Search_employee]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Search_employee]
@Hoten nvarchar(50)
as
begin
select* from STAFFS where HoTen like  '%' + RTRIM(@HoTen) + '%' and NowWorking ='yes'
end

GO
/****** Object:  StoredProcedure [dbo].[SignUp]    Script Date: 5/19/2019 11:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SignUp]
@MaNV nchar(10),
@Pass nvarchar(50),
@ChucVu nchar(10)
as
begin
set nocount on;
insert into TaiKhoan(MaNV,Pass,ChucVu)
values(@MaNV,@Pass,@ChucVu) 
end

GO
USE [master]
GO
ALTER DATABASE [QLNV] SET  READ_WRITE 
GO
