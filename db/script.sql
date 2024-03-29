USE [master]
GO
/****** Object:  Database [db_lego]    Script Date: 06/29/2023 23:24:26 ******/
CREATE DATABASE [db_lego]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_lego', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_lego.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_lego_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_lego_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_lego] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_lego].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_lego] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_lego] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_lego] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_lego] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_lego] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_lego] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_lego] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_lego] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_lego] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_lego] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_lego] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_lego] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_lego] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_lego] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_lego] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_lego] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_lego] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_lego] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_lego] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_lego] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_lego] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_lego] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_lego] SET RECOVERY FULL 
GO
ALTER DATABASE [db_lego] SET  MULTI_USER 
GO
ALTER DATABASE [db_lego] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_lego] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_lego] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_lego] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_lego] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_lego] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_lego', N'ON'
GO
ALTER DATABASE [db_lego] SET QUERY_STORE = OFF
GO
USE [db_lego]
GO
/****** Object:  Table [dbo].[account]    Script Date: 06/29/2023 23:24:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[zip_code] [nvarchar](5) NULL,
	[province] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_branch_mapping]    Script Date: 06/29/2023 23:24:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_branch_mapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[branch_id] [int] NOT NULL,
 CONSTRAINT [PK_account_branch_mapping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_role_mapping]    Script Date: 06/29/2023 23:24:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_role_mapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_account_role_mapping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_role_navigation_mapping]    Script Date: 06/29/2023 23:24:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_role_navigation_mapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_role_id] [int] NOT NULL,
	[navigation_id] [int] NOT NULL,
	[privilege] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_account_role_navigation_mapping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branch]    Script Date: 06/29/2023 23:24:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branch](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK_branch] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[navigation]    Script Date: 06/29/2023 23:24:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[navigation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[controller] [nvarchar](20) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK_navigation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 06/29/2023 23:24:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[account] ON 

INSERT [dbo].[account] ([id], [fullname], [username], [password], [email], [address], [zip_code], [province], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (1, N'ristono ubah', N'tonoubah', N'ubah', N'ristonoubah@gmail.com', N'jl.ampera no 10 kel.karangreja ubah', N'1111', N'Jawa barat', CAST(N'2023-06-29T12:43:22.427' AS DateTime), N'user', CAST(N'2023-06-29T12:44:39.803' AS DateTime), N'user', 0)
INSERT [dbo].[account] ([id], [fullname], [username], [password], [email], [address], [zip_code], [province], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (2, N'ristono 2', N'tono2', N'admin2', N'ristono2@gmail.com', N'jl.ampera no 10 kel.karangreja 2', N'2231', N'Jawa tengah', CAST(N'2023-06-29T12:45:20.420' AS DateTime), N'user', CAST(N'2023-06-29T22:23:32.633' AS DateTime), N'user', 0)
INSERT [dbo].[account] ([id], [fullname], [username], [password], [email], [address], [zip_code], [province], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (6, N'ristono ubah', N'tono', N'admin', N'ristono@gmail.com', N'jl.ampera no 10 kel.karangreja ubah', N'2231', N'Jawa barat', CAST(N'2023-06-29T18:11:41.100' AS DateTime), N'user', CAST(N'2023-06-29T18:11:41.100' AS DateTime), N'user', 0)
INSERT [dbo].[account] ([id], [fullname], [username], [password], [email], [address], [zip_code], [province], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (7, N'ristono', N'tono', N'admin', N'ristonoubah@gmail.com', N'jl.ampera no 10 kel.karangreja 2', N'1111', N'Jawa barat', CAST(N'2023-06-29T18:13:22.387' AS DateTime), N'user', CAST(N'2023-06-29T22:23:07.247' AS DateTime), N'user', 0)
INSERT [dbo].[account] ([id], [fullname], [username], [password], [email], [address], [zip_code], [province], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (12, N'ristono', N'tono', N'admin', N'ristonoubah@gmail.com', N'jl.ampera no 10 kel.karangreja', N'1111', N'Jawa barat', CAST(N'2023-06-29T19:04:21.890' AS DateTime), N'user', CAST(N'2023-06-29T22:29:02.730' AS DateTime), N'user', 0)
INSERT [dbo].[account] ([id], [fullname], [username], [password], [email], [address], [zip_code], [province], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (17, N'ristono', N'tono', N'admin', N'ristonoubah@gmail.com', N'jl.ampera no 10 kel.karangreja 2', N'1111', N'Jawa barat', CAST(N'2023-06-29T19:56:55.057' AS DateTime), N'user', CAST(N'2023-06-29T22:29:15.917' AS DateTime), N'user', 0)
INSERT [dbo].[account] ([id], [fullname], [username], [password], [email], [address], [zip_code], [province], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (18, N'ristono ubah', N'tono', N'admin', N'ristonoubah@gmail.com', N'jl.ampera no 10 kel.karangreja ubah', N'2231', N'Jawa barat', CAST(N'2023-06-29T22:04:39.240' AS DateTime), N'user', CAST(N'2023-06-29T22:28:44.087' AS DateTime), N'user', 0)
INSERT [dbo].[account] ([id], [fullname], [username], [password], [email], [address], [zip_code], [province], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (19, N'ristono 2', N'tono', N'admin', N'ristonoubah@gmail.com', N'jl.ampera no 10 kel.karangreja 2', N'1111', N'Jawa tengah', CAST(N'2023-06-29T22:38:18.867' AS DateTime), N'user', CAST(N'2023-06-29T22:39:38.580' AS DateTime), N'user', 0)
SET IDENTITY_INSERT [dbo].[account] OFF
GO
SET IDENTITY_INSERT [dbo].[account_branch_mapping] ON 

INSERT [dbo].[account_branch_mapping] ([id], [account_id], [branch_id]) VALUES (31, 7, 2)
INSERT [dbo].[account_branch_mapping] ([id], [account_id], [branch_id]) VALUES (32, 2, 2)
INSERT [dbo].[account_branch_mapping] ([id], [account_id], [branch_id]) VALUES (33, 18, 7)
INSERT [dbo].[account_branch_mapping] ([id], [account_id], [branch_id]) VALUES (34, 18, 10)
INSERT [dbo].[account_branch_mapping] ([id], [account_id], [branch_id]) VALUES (35, 18, 2)
INSERT [dbo].[account_branch_mapping] ([id], [account_id], [branch_id]) VALUES (36, 12, 2)
INSERT [dbo].[account_branch_mapping] ([id], [account_id], [branch_id]) VALUES (37, 17, 2)
INSERT [dbo].[account_branch_mapping] ([id], [account_id], [branch_id]) VALUES (40, 19, 9)
SET IDENTITY_INSERT [dbo].[account_branch_mapping] OFF
GO
SET IDENTITY_INSERT [dbo].[account_role_mapping] ON 

INSERT [dbo].[account_role_mapping] ([id], [account_id], [role_id]) VALUES (24, 7, 1)
INSERT [dbo].[account_role_mapping] ([id], [account_id], [role_id]) VALUES (25, 2, 1)
INSERT [dbo].[account_role_mapping] ([id], [account_id], [role_id]) VALUES (26, 18, 1)
INSERT [dbo].[account_role_mapping] ([id], [account_id], [role_id]) VALUES (27, 12, 1)
INSERT [dbo].[account_role_mapping] ([id], [account_id], [role_id]) VALUES (28, 17, 1)
INSERT [dbo].[account_role_mapping] ([id], [account_id], [role_id]) VALUES (30, 19, 1)
SET IDENTITY_INSERT [dbo].[account_role_mapping] OFF
GO
SET IDENTITY_INSERT [dbo].[account_role_navigation_mapping] ON 

INSERT [dbo].[account_role_navigation_mapping] ([id], [account_role_id], [navigation_id], [privilege]) VALUES (17, 26, 4, N'create|read')
INSERT [dbo].[account_role_navigation_mapping] ([id], [account_role_id], [navigation_id], [privilege]) VALUES (18, 27, 4, N'read|update')
INSERT [dbo].[account_role_navigation_mapping] ([id], [account_role_id], [navigation_id], [privilege]) VALUES (19, 28, 4, N'read')
INSERT [dbo].[account_role_navigation_mapping] ([id], [account_role_id], [navigation_id], [privilege]) VALUES (21, 30, 1, N'create')
SET IDENTITY_INSERT [dbo].[account_role_navigation_mapping] OFF
GO
SET IDENTITY_INSERT [dbo].[branch] ON 

INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (2, N'Kantor cabang 1', CAST(N'2023-08-08T00:00:00.000' AS DateTime), N'Tono', NULL, NULL, 0)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (4, N'Kantor cabang 8', CAST(N'2023-06-03T00:00:00.000' AS DateTime), N'Tono', CAST(N'2023-06-28T17:18:46.597' AS DateTime), N'user', 0)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (5, N'Kantor cabang 11', CAST(N'2023-06-28T16:43:30.737' AS DateTime), N'user', CAST(N'2023-06-28T20:31:58.223' AS DateTime), N'user', 1)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (6, N'Kantor cabang 13', CAST(N'2023-06-28T16:44:42.277' AS DateTime), N'user', CAST(N'2023-06-28T16:44:42.277' AS DateTime), N'user', 1)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (7, N'Kantor cabang 14', CAST(N'2023-06-28T16:45:14.053' AS DateTime), N'user', CAST(N'2023-06-28T16:45:14.053' AS DateTime), N'user', 0)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (8, N'Kantor cabang 16', CAST(N'2023-06-28T16:45:45.337' AS DateTime), N'user', CAST(N'2023-06-28T16:45:45.337' AS DateTime), N'user', 0)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (9, N'Kantor cabang 18', CAST(N'2023-06-28T16:53:44.140' AS DateTime), N'user', CAST(N'2023-06-28T16:53:44.140' AS DateTime), N'user', 0)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (10, N'kuduk', CAST(N'2023-06-28T16:55:40.513' AS DateTime), N'user', CAST(N'2023-06-28T16:55:40.513' AS DateTime), N'user', 0)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (11, N'sdfsdfdf', CAST(N'2023-06-28T17:05:55.560' AS DateTime), N'user', CAST(N'2023-06-28T17:05:55.560' AS DateTime), N'user', 1)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (12, N'dfsdfdf', CAST(N'2023-06-28T17:06:24.720' AS DateTime), N'user', CAST(N'2023-06-28T17:06:24.720' AS DateTime), N'user', 1)
INSERT [dbo].[branch] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (13, N'Kantor cabang 20', CAST(N'2023-06-28T17:06:43.597' AS DateTime), N'user', CAST(N'2023-06-28T17:06:43.597' AS DateTime), N'user', 1)
SET IDENTITY_INSERT [dbo].[branch] OFF
GO
SET IDENTITY_INSERT [dbo].[navigation] ON 

INSERT [dbo].[navigation] ([id], [name], [controller], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (1, N'Layar 21', N'Layar 11', CAST(N'2023-06-29T10:38:37.750' AS DateTime), N'user', CAST(N'2023-06-29T11:59:31.487' AS DateTime), N'user', 0)
INSERT [dbo].[navigation] ([id], [name], [controller], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (2, N'Branching', N'Branch doang', CAST(N'2023-06-29T10:39:44.247' AS DateTime), N'user', CAST(N'2023-06-29T10:40:52.060' AS DateTime), N'user', 1)
INSERT [dbo].[navigation] ([id], [name], [controller], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (3, N'Branch', N'Branch 1', CAST(N'2023-06-29T11:59:42.100' AS DateTime), N'user', CAST(N'2023-06-29T11:59:48.193' AS DateTime), N'user', 1)
INSERT [dbo].[navigation] ([id], [name], [controller], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (4, N'Role', N'Role', CAST(N'2023-06-29T15:53:29.523' AS DateTime), N'user', CAST(N'2023-06-29T15:53:29.523' AS DateTime), N'user', 0)
SET IDENTITY_INSERT [dbo].[navigation] OFF
GO
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (1, N'admin', CAST(N'2023-06-28T23:57:42.677' AS DateTime), N'user', CAST(N'2023-06-28T23:57:42.677' AS DateTime), N'user', 0)
INSERT [dbo].[role] ([id], [name], [created_date], [created_by], [updated_date], [updated_by], [is_deleted]) VALUES (2, N'admin doang', CAST(N'2023-06-29T10:13:12.460' AS DateTime), N'user', CAST(N'2023-06-29T10:14:33.790' AS DateTime), N'user', 0)
SET IDENTITY_INSERT [dbo].[role] OFF
GO
ALTER TABLE [dbo].[account] ADD  CONSTRAINT [DF_account_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[branch] ADD  CONSTRAINT [DF_branch_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[navigation] ADD  CONSTRAINT [DF_navigation_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF_role_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[account_branch_mapping]  WITH CHECK ADD  CONSTRAINT [FK_account_branch_mapping_account] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[account_branch_mapping] CHECK CONSTRAINT [FK_account_branch_mapping_account]
GO
ALTER TABLE [dbo].[account_branch_mapping]  WITH CHECK ADD  CONSTRAINT [FK_account_branch_mapping_branch] FOREIGN KEY([branch_id])
REFERENCES [dbo].[branch] ([id])
GO
ALTER TABLE [dbo].[account_branch_mapping] CHECK CONSTRAINT [FK_account_branch_mapping_branch]
GO
ALTER TABLE [dbo].[account_role_mapping]  WITH CHECK ADD  CONSTRAINT [FK_account_role_mapping_account] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[account_role_mapping] CHECK CONSTRAINT [FK_account_role_mapping_account]
GO
ALTER TABLE [dbo].[account_role_mapping]  WITH CHECK ADD  CONSTRAINT [FK_account_role_mapping_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[account_role_mapping] CHECK CONSTRAINT [FK_account_role_mapping_role]
GO
ALTER TABLE [dbo].[account_role_navigation_mapping]  WITH CHECK ADD  CONSTRAINT [FK_account_role_navigation_mapping_account_role_mapping] FOREIGN KEY([account_role_id])
REFERENCES [dbo].[account_role_mapping] ([id])
GO
ALTER TABLE [dbo].[account_role_navigation_mapping] CHECK CONSTRAINT [FK_account_role_navigation_mapping_account_role_mapping]
GO
ALTER TABLE [dbo].[account_role_navigation_mapping]  WITH CHECK ADD  CONSTRAINT [FK_account_role_navigation_mapping_navigation] FOREIGN KEY([navigation_id])
REFERENCES [dbo].[navigation] ([id])
GO
ALTER TABLE [dbo].[account_role_navigation_mapping] CHECK CONSTRAINT [FK_account_role_navigation_mapping_navigation]
GO
USE [master]
GO
ALTER DATABASE [db_lego] SET  READ_WRITE 
GO
