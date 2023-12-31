USE [master]
GO
/****** Object:  Database [LauncherGamesBD]    Script Date: 25.06.2023 13:14:25 ******/
CREATE DATABASE [LauncherGamesBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LauncherGamesBD', FILENAME = N'E:\sqlll\MSSQL13.SQLEXPRESS01\MSSQL\DATA\LauncherGamesBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LauncherGamesBD_log', FILENAME = N'E:\sqlll\MSSQL13.SQLEXPRESS01\MSSQL\DATA\LauncherGamesBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LauncherGamesBD] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LauncherGamesBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LauncherGamesBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LauncherGamesBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LauncherGamesBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LauncherGamesBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LauncherGamesBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LauncherGamesBD] SET  MULTI_USER 
GO
ALTER DATABASE [LauncherGamesBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LauncherGamesBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LauncherGamesBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LauncherGamesBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LauncherGamesBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LauncherGamesBD] SET QUERY_STORE = OFF
GO
USE [LauncherGamesBD]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [LauncherGamesBD]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.06.2023 13:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[achiv1] [int] NULL,
	[achiv2] [int] NULL,
	[achiv3] [int] NULL,
	[achiv4] [int] NULL,
	[achiv5] [int] NULL,
	[achiv6] [int] NULL,
	[achiv7] [int] NULL,
	[achiv8] [int] NULL,
	[achiv9] [int] NULL,
	[achiv10] [int] NULL,
	[AvatarPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (1, N'test', N'test', 1, 1, 0, 1, 1, 1, 0, NULL, NULL, NULL, N'C:\Users\daimo\Downloads\avatar.png')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (2, N'test1', N'test1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (3, N'atomic', N'atomic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (4, N'atomic1', N'atomic', 1, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'C:\Users\daimo\Pictures\GameCenter\AtomicHeart\AtomicHeart_sample.jpg')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (5, N'asd', N'asd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'C:\Users\daimo\Pictures\GameCenter\AtomicHeart\AtomicHeart_sample.jpg')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (1003, N'aaa', N'aaa', 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, N'C:\Users\daimo\Pictures\GameCenter\AtomicHeart\AtomicHeart_sample.jpg')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (1004, N'testtest', N'test', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'C:\Users\daimo\Pictures\GameCenter\AtomicHeart\AtomicHeart_sample.jpg')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (2003, N'gag', N'gag', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, N'C:\Users\daimo\Downloads\avatar.png')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (3003, N'komarrr', N'komarrr', 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N'C:\Users\daimo\Downloads\Screenshot_2.png')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (3004, N'komar', N'komar', 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, N'C:\Users\daimo\Downloads\tetrisloose.png')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (3005, N'komarkomar', N'komar', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'C:\Users\daimo\Downloads\wNE6iUbcoVQ.jpg')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (3006, N'komarkomarkomar', N'komar', 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, N'C:\Users\daimo\Downloads\Hfu4M8q71FQ.jpg')
INSERT [dbo].[Users] ([UserID], [Login], [Password], [achiv1], [achiv2], [achiv3], [achiv4], [achiv5], [achiv6], [achiv7], [achiv8], [achiv9], [achiv10], [AvatarPath]) VALUES (3007, N'dimas', N'dimas', 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, N'C:\Users\daimo\Downloads\AVATARTEST.png')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [LauncherGamesBD] SET  READ_WRITE 
GO
