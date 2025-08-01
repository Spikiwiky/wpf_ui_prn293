USE [master]
GO
/****** Object:  Database [ShopNew]    Script Date: 7/19/2024 5:52:51 PM ******/
CREATE DATABASE [ShopNew]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopNew', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopNew.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopNew_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopNew_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopNew] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopNew].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopNew] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopNew] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopNew] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopNew] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopNew] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopNew] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopNew] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopNew] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopNew] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopNew] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopNew] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopNew] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopNew] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopNew] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopNew] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopNew] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopNew] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopNew] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopNew] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopNew] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopNew] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopNew] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopNew] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopNew] SET  MULTI_USER 
GO
ALTER DATABASE [ShopNew] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopNew] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopNew] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopNew] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopNew] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopNew] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopNew] SET QUERY_STORE = OFF
GO
USE [ShopNew]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[blog_id] [int] IDENTITY(1,1) NOT NULL,
	[blog_title] [nvarchar](max) NULL,
	[blog_content] [nvarchar](max) NULL,
	[blog_image] [varchar](max) NULL,
	[author_name] [nvarchar](max) NULL,
	[create_date] [datetime] NULL,
	[status] [bit] NULL,
	[isDeleted] [bit] NULL,
	[summary] [nvarchar](max) NULL,
	[category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[blog_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog_category]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog_category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](50) NULL,
	[gender] [nvarchar](50) NULL,
	[phone_number] [varchar](50) NULL,
	[email] [varchar](150) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[address] [text] NULL,
	[avatar] [text] NULL,
	[status] [bit] NULL,
	[update_date] [datetime] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[feedback_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NULL,
	[product_id] [int] NULL,
	[feedback_image] [varchar](max) NULL,
	[feedback_content] [nvarchar](max) NULL,
	[rate_star] [float] NULL,
	[status] [bit] NULL,
	[create_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[feedback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_detail]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_detail](
	[order_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[product_id] [int] NULL,
	[product_price] [float] NULL,
	[quantity] [int] NULL,
	[total_cost] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NULL,
	[staff_id] [int] NULL,
	[receiver_fullname] [nvarchar](100) NULL,
	[receiver_gender] [nvarchar](50) NULL,
	[receiver_email] [varchar](max) NULL,
	[phone_number] [nvarchar](max) NULL,
	[receiver_address] [nvarchar](max) NULL,
	[order_date] [datetime] NULL,
	[total_cost] [float] NULL,
	[note] [nvarchar](max) NULL,
	[order_status] [nvarchar](max) NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [varchar](50) NULL,
	[original_price] [float] NULL,
	[sale_price] [float] NULL,
	[quantity] [int] NULL,
	[category_id] [int] NULL,
	[thumbnail] [varchar](max) NULL,
	[product_image] [varchar](max) NULL,
	[summary] [nvarchar](max) NULL,
	[product_detail] [nvarchar](max) NULL,
	[product_status] [bit] NULL,
	[create_date] [datetime] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_category]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [varchar](50) NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 7/19/2024 5:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[staff_id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](50) NULL,
	[gender] [nvarchar](50) NULL,
	[phone_number] [varchar](50) NULL,
	[email] [varchar](150) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[address] [nvarchar](max) NULL,
	[avatar] [varchar](max) NULL,
	[role_id] [int] NULL,
	[status] [bit] NULL,
	[update_date] [datetime] NULL,
	[isDeleted] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[staff_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([customer_id], [fullname], [gender], [phone_number], [email], [password], [address], [avatar], [status], [update_date], [isDeleted]) VALUES (1, N'Phạm Sơn Tùng', N'Male', N'012345678', N'tungpshe176293@fpt.edu.vn', N'123', N'FPT', N'https://cdn-icons-png.freepik.com/512/2922/2922100.png', 0, NULL, 0)
INSERT [dbo].[Customer] ([customer_id], [fullname], [gender], [phone_number], [email], [password], [address], [avatar], [status], [update_date], [isDeleted]) VALUES (2, N'Sơn Tùng', N'Male', N'1234567890', N'phamsontung1107@gmail.com', N'123', N'FPT', NULL, 1, NULL, NULL)
INSERT [dbo].[Customer] ([customer_id], [fullname], [gender], [phone_number], [email], [password], [address], [avatar], [status], [update_date], [isDeleted]) VALUES (3, N'Việt Anh', N'Male', N'123456789', N'dovietanh20092002@gmail.com', N'123', N'FPT', NULL, 1, NULL, NULL)
INSERT [dbo].[Customer] ([customer_id], [fullname], [gender], [phone_number], [email], [password], [address], [avatar], [status], [update_date], [isDeleted]) VALUES (4, N'Nguyễn Minh Ngọc', N'Female', N'0962275431', N'11072003t@gmail.com', N'123', N'fpt', NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_detail] ON 

INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (1, 4, 2, 400000, 2, 800000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (2, 4, 3, 199000, 1, 199000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (3, 4, 4, 100000, 1, 100000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (4, 5, 2, 400000, 1, 400000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (5, 5, 3, 199000, 1, 199000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (6, 5, 4, 100000, 2, 200000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (7, 6, 1, 200000, 1, 200000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (8, 7, 1, 200000, 2, 400000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (9, 7, 2, 400000, 2, 800000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (10, 8, 9, 200000, 4, 800000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (11, 8, 10, 600000, 1, 600000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (12, 8, 13, 60000, 1, 60000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (13, 8, 11, 100000, 2, 200000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (14, 9, 13, 60000, 2, 120000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (15, 10, 13, 60000, 2, 120000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (16, 11, 2, 400000, 1, 400000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (17, 11, 10, 600000, 1, 600000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (18, 11, 1, 200000, 2, 400000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (19, 12, 2, 400000, 2, 800000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (20, 13, 2, 400000, 4, 1600000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (21, 14, 3, 199000, 1, 199000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (22, 14, 4, 100000, 1, 100000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (23, 14, 2, 400000, 5, 2000000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (24, 15, 1, 500000, 5, 2500000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (25, 15, 2, 400000, 1, 400000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (26, 16, 3, 199000, 1, 199000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (27, 16, 15, 900000, 1, 900000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (28, 17, 1, 500000, 3, 1500000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (29, 18, 3, 199000, 1, 199000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (30, 19, 2, 400000, 2, 800000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (31, 20, 2, 400000, 3, 1200000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (32, 20, 3, 199000, 1, 199000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (33, 20, 4, 100000, 1, 100000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (34, 21, 2, 400000, 2, 800000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (35, 21, 3, 199000, 4, 796000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (36, 22, 5, 500000, 4, 2000000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (37, 22, 4, 100000, 2, 200000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (38, 23, 3, 199000, 3, 597000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (39, 23, 4, 100000, 2, 200000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (40, 23, 2, 400000, 1, 400000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (41, 24, 2, 400000, 4, 1600000)
INSERT [dbo].[Order_detail] ([order_detail_id], [order_id], [product_id], [product_price], [quantity], [total_cost]) VALUES (42, 24, 3, 199000, 2, 398000)
SET IDENTITY_INSERT [dbo].[Order_detail] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (4, 1, 19, N'abc', N'Male', N'abc@gmail.com', N'1223456788', N'FPT', CAST(N'2024-06-24T19:03:18.567' AS DateTime), 1099000, N'hihi', N'Received', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (5, 1, 19, N'111', N'Male', N'111@gmail.com', N'123456789', N'Ha Noi', CAST(N'2024-06-24T19:10:29.830' AS DateTime), 799000, N'hihi', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (6, 1, 19, N'123', N'Female', N'123@gmail.com', N'123123', N'Ha Noi', CAST(N'2024-06-24T19:16:50.123' AS DateTime), 200000, N'123', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (7, 1, 19, N'test', N'Female', N'test@gmail.com', N'123456789', N'Ha Noi', CAST(N'2024-06-24T19:17:41.803' AS DateTime), 1200000, N'123', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (8, 1, 19, N'abc', N'Male', N'abc@gmail.com', N'123456789', N'Ha Noi', CAST(N'2024-06-24T19:29:57.953' AS DateTime), 1660000, N'11111', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (9, 1, 19, N'222', N'Male', N'22@gmail.com', N'123456789', N'Ha Noi', CAST(N'2024-06-24T19:36:25.030' AS DateTime), 120000, N'1233', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (10, 1, 19, N'55', N'Male', N'55@gmail.com', N'55', N'55', CAST(N'2024-06-24T19:38:17.153' AS DateTime), 120000, N'55', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (11, 1, 19, N'test2', N'Female', N'test2@gmail.com', N'123456789', N'123', CAST(N'2024-06-24T19:57:28.283' AS DateTime), 1400000, N'123', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (12, 1, 19, N'gg', N'Female', N'gg@gmail.com', N'ggg', N'gg', CAST(N'2024-06-26T14:36:50.017' AS DateTime), 800000, N'gg', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (13, 1, 19, N'fff', N'Female', N'ff@gmail.com', N'1111', N'1', CAST(N'2024-06-26T14:41:24.410' AS DateTime), 1600000, N'11', N'Received', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (14, 3, 19, N'Tùng Sơn', N'Male', N'dovietanh20092002@gmail.com', N'123123', N'FPT', CAST(N'2024-06-27T02:54:24.777' AS DateTime), 2299000, N'HIHHI', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (15, 3, 19, N'ggg', N'Male', N'gg@gmail.com', N'123', N'123', CAST(N'2024-06-27T13:03:31.913' AS DateTime), 2900000, N'123', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (16, 1, 19, N'Phạm Sơn Tùng', N'Male', N'hhhh@gmail.com', N'036789823982', N'ha noi', CAST(N'2024-07-08T16:46:59.260' AS DateTime), 1099000, N'Note ', N'Received', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (17, 1, 19, N'Minh Ngọc', N'Female', N'phamsontung1107@gmail.com', N'12345', N'FPT', CAST(N'2024-07-17T01:11:39.410' AS DateTime), 1500000, N'@@@@', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (18, 1, 19, N'Tùng Sơn', N'Male', N'phamsontung1107@gmail.com', N'123', N'123', CAST(N'2024-07-17T01:13:28.910' AS DateTime), 199000, N'123', N'Received', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (19, 1, 19, N'123', N'Male', N'123@gmail.com', N'123', N'123', CAST(N'2024-07-17T02:42:49.943' AS DateTime), 800000, N'123', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (20, 1, 19, N'123', N'Female', N'123@gmail.com', N'123', N'123', CAST(N'2024-07-17T10:51:21.710' AS DateTime), 1499000, N'123', N'Received', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (21, 1, 19, N'123', N'Female', N'123@gmail.com', N'123', N'fopt', CAST(N'2024-07-19T03:35:06.047' AS DateTime), 1596000, N'123', N'Cancelled', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (22, 1, 19, N'123', N'Female', N'1223@gmail.com', N'123', N'123', CAST(N'2024-07-19T03:37:30.403' AS DateTime), 2200000, N'123', N'Received', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (23, 1, 19, N'123', N'Male', N'123@gmail.com', N'123', N'123', CAST(N'2024-07-19T08:51:25.980' AS DateTime), 1197000, N'123', N'Received', 0)
INSERT [dbo].[Orders] ([order_id], [customer_id], [staff_id], [receiver_fullname], [receiver_gender], [receiver_email], [phone_number], [receiver_address], [order_date], [total_cost], [note], [order_status], [isDeleted]) VALUES (24, 1, 19, N'Phạm Sơn Tùng', N'Male', N'123@gmail.com', N'123', N'123', CAST(N'2024-07-19T09:19:05.823' AS DateTime), 1998000, N'123', N'Received', 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (1, N'Teeworld Flex T-shirt', 200000, 500000, 22, 1, N'https://product.hstatic.net/1000088324/product/ao_flex_mock_up-01-01_c584213f2de04ceba76243b6d10ef047_master.png', N'https://product.hstatic.net/1000088324/product/ao_flex_mock_up-01-01_c584213f2de04ceba76243b6d10ef047_master.png', N'Cotton 95,2%, 5% spandex nên vải giữ được đặc tính tự nhiên, mềm mại, thoáng mát, co dãn 2 chiều, đứng form, công nghệ in lụa sắc nét, độ bền màu cao', N'5% spandex nên vải giữ được đặc tính tự nhiên, mềm mại, thoáng mát, co dãn 2 chiều, đứng form, công nghệ in lụa sắc nét, độ bền màu cao', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (2, N'Teeworld2 Secret Of Liquid T-shirt', 400000, 400000, 47, 1, N'https://product.hstatic.net/1000088324/product/mock_up_mat_sau_4b374fe7011b4c7cbcd6cc611b89673e_master.png', N'https://product.hstatic.net/1000088324/product/mock_up_mat_sau_4b374fe7011b4c7cbcd6cc611b89673e_master.png', N'Forms áo rộng, phù hợp với nhiều phong cách và dáng người khác nhau', N'Form áo rộng', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (3, N'Teeworld Flower T-shirt', 199000, 199000, 12, 1, N'https://product.hstatic.net/1000088324/product/web__3__7f1536cafc044539a2c87787c7a5925b_master.png', N'https://product.hstatic.net/1000088324/product/web__3__7f1536cafc044539a2c87787c7a5925b_master.png', N'Công nghệ in lụa sắc nét, độ bền màu cao', N'Công nghệ in lụa sắc nét, độ bền màu cao', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (4, N'Teeworld Classic T-shirt', 100000, 100000, 20, 1, N'https://product.hstatic.net/1000088324/product/teeworld_classic_67e034fb45d843b09dc567c2fbe1407e_master.png', N'https://product.hstatic.net/1000088324/product/teeworld_classic_67e034fb45d843b09dc567c2fbe1407e_master.png', N'5% spandex nên vải giữ được đặc tính tự nhiên', N'5% spandex nên vải giữ được đặc tính tự nhiên', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (5, N'Hoodie Zip Logo Teeworld', 500000, 500000, 11, 2, N'https://product.hstatic.net/1000088324/product/hoodie_9451f63c44ef4d4f94cd6a826ca60b36_master.png', N'https://product.hstatic.net/1000088324/product/hoodie_9451f63c44ef4d4f94cd6a826ca60b36_master.png', N'Áo Hoodie Zip Logo Teeworld cao cấp form rộng Thời Trang Unisex Nam Nữ', N'Áo Hoodie Zip Logo Teeworld cao cấp form rộng Thời Trang Unisex Nam Nữ', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (6, N'POLO ENTRY BOOLAAB', 250000, 250000, 10, 3, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.16.3.18.001.123.23-11300011-bst-1_6.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.16.3.18.001.123.23-11300011-bst-1_6.jpg', N' Chất liệu: 100% Cotton thoáng mát, dễ chịu, thấm hút mồ hôi tốt. Thoải mái khi vận động trong thời tiết nóng', N' Chất liệu: 100% Cotton thoáng mát, dễ chịu, thấm hút mồ hôi tốt. Thoải mái khi vận động trong thời tiết nóng', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (7, N'POLO BOXY UN LOGO MADE IN HN ENTRY', 200000, 200000, 5, 3, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.16.3.06.012.123.23-10200011-bst-1_4.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.16.3.06.012.123.23-10200011-bst-1_4.jpg', N'Dáng rộng Oversize thoải mái, dễ dàng vận động phù hợp cho cả nam và nữ.', N'Dáng rộng Oversize thoải mái, dễ dàng vận động phù hợp cho cả nam và nữ.', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (8, N'POLO LONGSLEEVE OVERSIZED MICKEY BOOZILLA', 500000, 500000, 50, 3, N'https://cdn.boo.vn/media/catalog/product/1/_/1.0.16.3.22.002.222.23.10200011_1__3.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.0.16.3.22.002.222.23.10200011_1__3.jpg', N' Len cao cấp: Được làm từ sợi bông tự nhiên giữ ấm tốt. Chất len mềm mịn, không bị xù, độ bền cao khi sử dụng', N' Len cao cấp: Được làm từ sợi bông tự nhiên giữ ấm tốt. Chất len mềm mịn, không bị xù, độ bền cao khi sử dụng', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (9, N'Short PATCH ESSENTIAL', 200000, 200000, 15, 4, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.09.2.23.001.124.23.10200011_1__5.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.09.2.23.001.124.23.10200011_1__5.jpg', N' Là sự kết hợp hoàn hảo giữa chất vải nỉ, thun da cá, và vải len, tạo nên loại vải độ co dãn tốt và giữ ấm tốt.', N'Thành phần chủ yếu bao gồm 65% sợi Polyester và 35% sợi bông tự nhiên. Bề mặt của vải có kết cấu chồng chéo, tạo ra những đường vân giống như lớp vảy cá. ', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (10, N'SHORTS BOOZILLA', 600000, 600000, 15, 4, N'https://cdn.boo.vn/media/catalog/product/1/_/1.0.09.2.06.002.123.01-10600017-bst-1_6.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.0.09.2.06.002.123.01-10600017-bst-1_6.jpg', N'SHORTS BERMUDA NỈ LOGO THE SIMPSONS BOOZILLA', N'SHORTS BERMUDA NỈ LOGO THE SIMPSONS BOOZILLA', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (11, N'SHORT UN BOO ESSENTIAL', 100000, 100000, 3, 4, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.09.3.23.001.124.23.10700054_1__5.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.09.3.23.001.124.23.10700054_1__5.jpg', N'Chất liệu: 65% là sợi polyester và 35% là sợi bông tự nhiên. Chất nỉ dày dặn giữ nhiệt tốt, không xù và có độ đứng form nhất định.', N'Chất liệu: 65% là sợi polyester và 35% là sợi bông tự nhiên. Chất nỉ dày dặn giữ nhiệt tốt, không xù và có độ đứng form nhất định.', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (12, N'Short INTERLOCK UN IN LOGO LOONEY TUNES', 200000, 200000, 155, 4, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.09.1.23.002.124.01.60600034_1__4.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.09.1.23.002.124.01.60600034_1__4.jpg', N'Vải Jean dày dặn, có độ đứng form tôn dáng khi mặc. ', N'Vải Jean dày dặn, có độ đứng form tôn dáng khi mặc. ', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (13, N'Short PATCH ESSENTIA', 60000, 60000, 3, 4, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.09.1.23.001.124.23.10400033_1__5.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.09.1.23.001.124.23.10400033_1__5.jpg', N'Là sự kết hợp hoàn hảo giữa chất vải nỉ, thun da cá, và vải len, tạo nên loại vải độ co dãn tốt và giữ ấm tốt.', N'Thành phần chủ yếu bao gồm 65% sợi Polyester và 35% sợi bông tự nhiên. Bề mặt của vải có kết cấu chồng chéo, tạo ra những đường vân giống như lớp vảy cá. ', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (14, N'JEANS PARACHUTE CARGO STRAIGHT', 70000, 70000, 22, 5, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.21.3.18.001.124.01.60600034_3.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.21.3.18.001.124.01.60600034_3.jpg', N'Vải Jean dày dặn, có độ đứng form tôn dáng khi mặc. ', N'Form dáng: Wide leg là form quần dáng suông nhưng phần ống dài và rộng hơn bình thường. Phần đũng của form quần này được thiết kế thấp hơn tạo cảm giác đường phố, thoải mái', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (15, N'JEANS NAM STRAIGHT NAM BOOLAAB', 900000, 900000, 21, 5, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.21.2.18.006.222.23-60600034-bst-1.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.21.2.18.006.222.23-60600034-bst-1.jpg', N'Sản phẩm có độ bền cao, không phai màu khi giặt giũ"ũ', N'Dáng quần Straight suông thoải mái, che được nhiều khuyết điểm. Đây là form quần có tỷ lệ mông, đùi và ống quần không chênh lệch nhau quá nhiều tạo thành dáng suông từ trên xuống dưới', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (16, N'JOGGER OVERSIZED THE SIMPSONS BOOZILLA', 100000, 100000, 20, 6, N'https://cdn.boo.vn/media/catalog/product/1/_/1.0.24.3.22.010.222.23-10100011-bst-1_4.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.0.24.3.22.010.222.23-10100011-bst-1_4.jpg', N'JOGGER OVERSIZED THE SIMPSONS BOOZILLA', N'JOGGER OVERSIZED THE SIMPSONS BOOZILLA', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (17, N'SWEATPANT', 80000, 80000, 12, 6, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.24.3.20.002.124.23.10200011_1__3.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.24.3.20.002.124.23.10200011_1__3.jpg', N'Nỉ da cá 65% là sợi polyester và 35% là sợi bông tự nhiên. ', N' Quần Jogger được thiết kế năng động phù hợp với vận động mạnh, ống quần được bó chun gọn gàng thoải mái', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (18, N'KEYCHAIN BOO IS BACK', 20000, 20000, 20, 7, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.12.3.11.046.219.23.10200002_1_.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.12.3.11.046.219.23.10200002_1_.jpg', N'PHỤ KIỆN KEYCHAIN BOO IS BACK', N'PHỤ KIỆN KEYCHAIN BOO IS BACK', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (19, N' EMOTION', 1000, 1000, 10000, 7, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.12.3.11.026.121.23-10600017-bst-2.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.12.3.11.026.121.23-10600017-bst-2.jpg', N'PHỤ KIỆN CAO CỔ EMOTION', N'PHỤ KIỆN CAO CỔ EMOTION', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (20, N'Hat HNBXBOOLAAB', 50000, 50000, 11, 7, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.30.3.18.003.123.01-10400011-bst-1.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.30.3.18.003.123.01-10400011-bst-1.jpg', N'Vải tổng hợp có độ bền cao. Khó bị co giãn hay bị nhăn khi giặt bằng máy giặt', N'Mũ được phối màu be/tím than, vành mũ được thêu nổi hình đầu con trâu - biểu tượng của một đội bóng rổ nổi tiếng', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (21, N'COMBO BTS BOOLAAB', 2000000, 2000000, 12, 7, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.12.3.18.007.222.23-11200011-bst.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.12.3.18.007.222.23-11200011-bst.jpg', N'COMBO ĐỒ DÙNG HỌC TẬP BTS BOOLAAB', N'COMBO ĐỒ DÙNG HỌC TẬP BTS BOOLAAB', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (22, N'BANDANA MARVEL GO VIETNAM BOOZILLA', 12000, 12000, 111, 7, N'https://cdn.boo.vn/media/catalog/product/1/_/1.0.12.3.11.012.123.23.10400025_1_.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.0.12.3.11.012.123.23.10400025_1_.jpg', N' Vải tổng hợp có độ bền cao. Khó bị co giãn hay bị nhăn khi giặt bằng máy giặt', N'Sự kết hợp không chỉ đem lại góc nhìn mới lạ mà còn khẳng định tinh thần của người trẻ Việt: Ưu tiên phát triển sáng tạo dựa trên các giá trị văn hóa truyền thống.', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (23, N' GILE LEN PARTERN BOOLAAB', 200000, 200000, 22, 8, N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.42.3.18.001.223.23.10200011_2__2.jpg', N'https://cdn.boo.vn/media/catalog/product/1/_/1.2.42.3.18.001.223.23.10200011_2__2.jpg', N'Được làm từ sợi bông tự nhiên giữ ấm tốt. Chất len mềm mịn, không bị xù, độ bền cao khi sử dụng', N'Dáng rộng Oversize thoải mái, dễ dàng vận động phù hợp cho cả nam và nữ. Đây là dáng áo dễ mặc che được nhiều khuyết điểm', 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([product_id], [product_name], [original_price], [sale_price], [quantity], [category_id], [thumbnail], [product_image], [summary], [product_detail], [product_status], [create_date], [isDeleted]) VALUES (24, N'Short  Cotton Spandex ', 200000, 200000, 12, 4, N'https://routine.vn/media/amasty/webp/catalog/product/cache/5b5632a96492396f42c72e22fdd64763/q/u/quan-short-nam-06-10s24psh003_black-_1__1_jpg.webp', N'https://routine.vn/media/amasty/webp/catalog/product/cache/5b5632a96492396f42c72e22fdd64763/q/u/quan-short-nam-06-10s24psh003_black-_1__1_jpg.webp', N'Quần Short Nam Ống Đứng Cotton Spandex Trơn Form Straight -10S24PSH003
', N'Quần Short Nam Ống Đứng Cotton Spandex Trơn Form Straight -10S24PSH003
', 1, CAST(N'2024-06-27T01:55:15.323' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_category] ON 

INSERT [dbo].[Product_category] ([category_id], [category_name], [status]) VALUES (1, N'Tee-shirt', 1)
INSERT [dbo].[Product_category] ([category_id], [category_name], [status]) VALUES (2, N'Sweater ', 1)
INSERT [dbo].[Product_category] ([category_id], [category_name], [status]) VALUES (3, N'POLO', 1)
INSERT [dbo].[Product_category] ([category_id], [category_name], [status]) VALUES (4, N'SHORT', 1)
INSERT [dbo].[Product_category] ([category_id], [category_name], [status]) VALUES (5, N'JEANS', 1)
INSERT [dbo].[Product_category] ([category_id], [category_name], [status]) VALUES (6, N'JOGGER pants', 1)
INSERT [dbo].[Product_category] ([category_id], [category_name], [status]) VALUES (7, N'ACCESSORY', 1)
INSERT [dbo].[Product_category] ([category_id], [category_name], [status]) VALUES (8, N'GILE shirt', 1)
INSERT [dbo].[Product_category] ([category_id], [category_name], [status]) VALUES (9, N'All Product', 1)
SET IDENTITY_INSERT [dbo].[Product_category] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (2, N'Saler')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([staff_id], [fullname], [gender], [phone_number], [email], [password], [address], [avatar], [role_id], [status], [update_date], [isDeleted]) VALUES (14, N'Admin1', N'Male', N'012345678', N'admin1@gmail.com', N'123', N'FPT', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRgDg7kpLtCUJhgC5ns2VTqFQpt0dLVRh-8eJYYAY9o6r90SK5aOB1c_7KU_WNugjqBVA&usqp=CAU', 1, 1, CAST(N'2024-06-24T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Staff] ([staff_id], [fullname], [gender], [phone_number], [email], [password], [address], [avatar], [role_id], [status], [update_date], [isDeleted]) VALUES (18, N'Admin2', N'Female', N'0125684208', N'admin2@gmail.com', N'123', N'FPT', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6nwtSKuhamK_RmQOMjPZnlzctjERQ8OHSvzaSxMGLsasOAmQQ32asKGjdrj-Y-lpuVJw&usqp=CAU', 1, 1, NULL, NULL)
INSERT [dbo].[Staff] ([staff_id], [fullname], [gender], [phone_number], [email], [password], [address], [avatar], [role_id], [status], [update_date], [isDeleted]) VALUES (19, N'Saler1', N'Male', N'0987357218', N'Sale1@gmail.com', N'123', N'FPT', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2R1UnM0ylHT-t50Nv2mRDat_R9iAD5RsDtRIb2534-M8y8ZQY_z_ytdX5OZhKruolPxc&usqp=CAU', 2, 1, NULL, NULL)
INSERT [dbo].[Staff] ([staff_id], [fullname], [gender], [phone_number], [email], [password], [address], [avatar], [role_id], [status], [update_date], [isDeleted]) VALUES (21, N'Saler2', N'Male', N'0123456980', N'Sale2@gmail.com', N'123', N'FPT', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRMQUT50q_mkZdRdIGhICM1d7rVWRiNxOJ7TimdjOaMlKvVfcC_Lo9hLzPiPBtoBzaidk&usqp=CAU', 2, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Blog_category] ([category_id])
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Blog_category] ([category_id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[Order_detail]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Order_detail]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Order_detail]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[Order_detail]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([staff_id])
REFERENCES [dbo].[Staff] ([staff_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([staff_id])
REFERENCES [dbo].[Staff] ([staff_id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Product_category] ([category_id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Product_category] ([category_id])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
USE [master]
GO
ALTER DATABASE [ShopNew] SET  READ_WRITE 
GO
