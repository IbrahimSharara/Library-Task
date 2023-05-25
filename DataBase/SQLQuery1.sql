USE [librarySystem]
GO
/****** Object:  Table [dbo].[tbl_Book]    Script Date: 5/25/2023 8:53:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](250) NULL,
	[BookCategory] [int] NULL,
	[BookWriter] [int] NULL,
	[BookIntro] [ntext] NULL,
	[BookDetails] [ntext] NULL,
	[IsAvailable] [bit] NULL,
	[AvailableNumber] [int] NULL,
	[BookPhoto] [nvarchar](250) NULL,
 CONSTRAINT [PK_tbl_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Borrow]    Script Date: 5/25/2023 8:53:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Borrow](
	[BorrowID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[UserNationalID] [nvarchar](250) NOT NULL,
	[BorrowFrom] [datetime] NOT NULL,
	[BorroTo] [datetime] NOT NULL,
	[BorrowPrice] [float] NULL,
 CONSTRAINT [PK_tbl_Borrow] PRIMARY KEY CLUSTERED 
(
	[BorrowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 5/25/2023 8:53:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](250) NULL,
 CONSTRAINT [PK_tbl_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Writer]    Script Date: 5/25/2023 8:53:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Writer](
	[WriteID] [int] IDENTITY(1,1) NOT NULL,
	[WriterName] [nvarchar](250) NULL,
 CONSTRAINT [PK_tbl_Writer] PRIMARY KEY CLUSTERED 
(
	[WriteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Book]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Book_tbl_Category] FOREIGN KEY([BookCategory])
REFERENCES [dbo].[tbl_Category] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Book] CHECK CONSTRAINT [FK_tbl_Book_tbl_Category]
GO
ALTER TABLE [dbo].[tbl_Book]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Book_tbl_Writer] FOREIGN KEY([BookWriter])
REFERENCES [dbo].[tbl_Writer] ([WriteID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Book] CHECK CONSTRAINT [FK_tbl_Book_tbl_Writer]
GO
ALTER TABLE [dbo].[tbl_Borrow]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Borrow_tbl_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[tbl_Book] ([BookID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Borrow] CHECK CONSTRAINT [FK_tbl_Borrow_tbl_Book]
GO
