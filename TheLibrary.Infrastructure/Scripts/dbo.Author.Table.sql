USE [TheLibrary]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 18/02/2022 16:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Id] [uniqueidentifier] NOT NULL,
	[InclusionDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[LastChangeDate] [datetime2](7) NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
