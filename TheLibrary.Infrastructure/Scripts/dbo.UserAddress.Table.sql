USE [TheLibrary]
GO
/****** Object:  Table [dbo].[UserAddress]    Script Date: 18/02/2022 16:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddress](
	[Id] [uniqueidentifier] NOT NULL,
	[InclusionDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[LastChangeDate] [datetime2](7) NULL,
	[IdentificationCode] [varchar](30) NOT NULL,
	[Number] [int] NOT NULL,
	[Address] [varchar](80) NOT NULL,
	[Complement] [varchar](80) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserAddress]  WITH CHECK ADD  CONSTRAINT [FK_User_UserAddress] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserAddress] CHECK CONSTRAINT [FK_User_UserAddress]
GO
