USE [TheLibrary]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 18/02/2022 16:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [uniqueidentifier] NOT NULL,
	[InclusionDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[LastChangeDate] [datetime2](7) NULL,
	[Title] [varchar](100) NOT NULL,
	[Summary] [varchar](700) NOT NULL,
	[ReleaseDate] [datetime2](7) NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[AuthorId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Author_BookAuthor] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Author_BookAuthor]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[BookCategory] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BookCategory]
GO
