USE [DB_PatrimonyManagement]
GO

/****** Object:  Table [dbo].[Patrimony]    Script Date: 20/01/2019 20:36:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Patrimony](
	[Id] [uniqueidentifier] NOT NULL,
	[CreationDate] [datetime2](7) NULL,
	[Name] [varchar](200) NOT NULL,
	[BrandId] [uniqueidentifier] NOT NULL,
	[Description] [varchar](500) NULL,
	[TippingNumber] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Patrimony] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Patrimony]  WITH CHECK ADD  CONSTRAINT [FK_Patrimony_Brand_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Patrimony] CHECK CONSTRAINT [FK_Patrimony_Brand_BrandId]
GO


