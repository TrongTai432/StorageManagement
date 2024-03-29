USE [master]
GO
/****** Object:  Database [QLKho]    Script Date: 7/30/2023 5:14:09 PM ******/
CREATE DATABASE [QLKho]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLKho', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLKho.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLKho_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLKho_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLKho] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKho].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKho] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKho] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKho] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKho] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKho] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKho] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLKho] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKho] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKho] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKho] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKho] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKho] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKho] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKho] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKho] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLKho] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKho] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKho] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKho] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKho] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKho] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKho] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKho] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLKho] SET  MULTI_USER 
GO
ALTER DATABASE [QLKho] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKho] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKho] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKho] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLKho] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLKho]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 7/30/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaPN] [nvarchar](50) NOT NULL,
	[MaHH] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuXuat]    Script Date: 7/30/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuXuat](
	[MaPX] [nvarchar](50) NOT NULL,
	[MaHH] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK__ChiTietP__7557BDA48085343E] PRIMARY KEY CLUSTERED 
(
	[MaPX] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 7/30/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHH] [nvarchar](50) NOT NULL,
	[TenHH] [nvarchar](100) NULL,
	[DVT] [nvarchar](100) NULL,
	[Gia] [float] NULL,
 CONSTRAINT [PK__HangHoa__2725A6E4452F3BBA] PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kho]    Script Date: 7/30/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[MaKho] [nvarchar](50) NOT NULL,
	[TenKho] [nvarchar](255) NULL,
	[DiaChi] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 7/30/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [nvarchar](50) NOT NULL,
	[TenNCC] [nvarchar](255) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SDT] [nvarchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 7/30/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPN] [nvarchar](50) NOT NULL,
	[NgayNhap] [date] NULL,
	[MaNCC] [nvarchar](50) NULL,
	[MaKho] [nvarchar](50) NULL,
	[TenNguoiGiao] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuXuat]    Script Date: 7/30/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuat](
	[MaPX] [nvarchar](50) NOT NULL,
	[NgayXuat] [date] NULL,
	[TenNguoiNhan] [nvarchar](255) NULL,
	[DiaChiNhan] [nvarchar](255) NULL,
	[MaKho] [nvarchar](50) NULL,
 CONSTRAINT [PK__PhieuXua__2725E7CAC3D1A38A] PRIMARY KEY CLUSTERED 
(
	[MaPX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaHH], [SoLuong]) VALUES (N'PN1', N'HH1', 2)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaHH], [SoLuong]) VALUES (N'PN1', N'HH2', 3)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaHH], [SoLuong]) VALUES (N'PN2', N'HH3', 4)
INSERT [dbo].[ChiTietPhieuXuat] ([MaPX], [MaHH], [SoLuong]) VALUES (N'PK3', N'HH1', 13)
INSERT [dbo].[ChiTietPhieuXuat] ([MaPX], [MaHH], [SoLuong]) VALUES (N'PK3', N'HH2', 5)
INSERT [dbo].[ChiTietPhieuXuat] ([MaPX], [MaHH], [SoLuong]) VALUES (N'PK3', N'HH3', 4)
INSERT [dbo].[ChiTietPhieuXuat] ([MaPX], [MaHH], [SoLuong]) VALUES (N'PX1', N'HH2', 5)
INSERT [dbo].[ChiTietPhieuXuat] ([MaPX], [MaHH], [SoLuong]) VALUES (N'PX1', N'HH3', 2)
INSERT [dbo].[ChiTietPhieuXuat] ([MaPX], [MaHH], [SoLuong]) VALUES (N'PX2', N'HH2', 2)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DVT], [Gia]) VALUES (N'HH1', N'Hàng hóa 1', N'Tạ', 120000)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DVT], [Gia]) VALUES (N'HH2', N'Hàng hóa 2', N'Tạ', 100000)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DVT], [Gia]) VALUES (N'HH3', N'Hoàng Hóa 3', N'kg', 50000)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DVT], [Gia]) VALUES (N'HH4', N'Hàng hóa 4', N'Tạ', 50000)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DVT], [Gia]) VALUES (N'HH5', N'Hàng hóa 5', N'Bao', 150000)
INSERT [dbo].[Kho] ([MaKho], [TenKho], [DiaChi]) VALUES (N'K1', N'Kho 1', N'Huế')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NCC1', N'Nhà cung cấp 1', N'Huế', N'0123214134')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NCC2', N'Nhà cung cấp 2', N'Đà Nẵng', N'0646574574')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NCC3', N'Nhà cung cấp 3', N'Huế', N'0564656512')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [MaNCC], [MaKho], [TenNguoiGiao]) VALUES (N'PN1', CAST(N'2023-07-24' AS Date), N'NCC1', N'K1', N'Công ty A')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [MaNCC], [MaKho], [TenNguoiGiao]) VALUES (N'PN2', CAST(N'2023-07-23' AS Date), N'NCC2', N'K1', N'Công ty B')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [MaNCC], [MaKho], [TenNguoiGiao]) VALUES (N'PN3', CAST(N'2023-07-25' AS Date), N'NCC2', N'K1', N'Công ty C')
INSERT [dbo].[PhieuXuat] ([MaPX], [NgayXuat], [TenNguoiNhan], [DiaChiNhan], [MaKho]) VALUES (N'PK3', CAST(N'2023-07-24' AS Date), N'Hảo', N'Huế', N'K1')
INSERT [dbo].[PhieuXuat] ([MaPX], [NgayXuat], [TenNguoiNhan], [DiaChiNhan], [MaKho]) VALUES (N'PX1', CAST(N'2023-07-24' AS Date), N'Hà', N'Huế', N'K1')
INSERT [dbo].[PhieuXuat] ([MaPX], [NgayXuat], [TenNguoiNhan], [DiaChiNhan], [MaKho]) VALUES (N'PX2', CAST(N'2023-07-24' AS Date), N'Hiền', N'Đà Nẵng', N'K1')
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaPN])
REFERENCES [dbo].[PhieuNhap] ([MaPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuXuat_HangHoa] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK_ChiTietPhieuXuat_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuXuat_PhieuXuat] FOREIGN KEY([MaPX])
REFERENCES [dbo].[PhieuXuat] ([MaPX])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK_ChiTietPhieuXuat_PhieuXuat]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_Kho] FOREIGN KEY([MaKho])
REFERENCES [dbo].[Kho] ([MaKho])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_Kho]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_Kho] FOREIGN KEY([MaKho])
REFERENCES [dbo].[Kho] ([MaKho])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK_PhieuXuat_Kho]
GO
/****** Object:  StoredProcedure [dbo].[SelectAllHangHoa]    Script Date: 7/30/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllHangHoa]
AS
BEGIN
    SELECT * FROM HangHoa;
END
GO
USE [master]
GO
ALTER DATABASE [QLKho] SET  READ_WRITE 
GO
