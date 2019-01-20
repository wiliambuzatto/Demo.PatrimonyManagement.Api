USE [DB_PatrimonyManagement]
GO

/****** Object:  Table [dbo].[Brand]    Script Date: 20/01/2019 20:38:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Brand](
	[Id] [uniqueidentifier] NOT NULL,
	[CreationDate] [datetime2](7) NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


