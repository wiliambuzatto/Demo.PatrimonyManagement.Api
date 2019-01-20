USE [DB_PatrimonyManagement]
GO

/****** Object:  Table [dbo].[LogEntry]    Script Date: 20/01/2019 20:36:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LogEntry](
	[Id] [uniqueidentifier] NOT NULL,
	[CreationDate] [datetime2](7) NULL,
	[UserId] [uniqueidentifier] NULL,
	[EntityName] [nvarchar](max) NULL,
	[EntityId] [uniqueidentifier] NOT NULL,
	[Operation] [nvarchar](max) NULL,
	[LogDateTime] [datetime2](7) NOT NULL,
	[ValuesChanges] [nvarchar](max) NULL,
 CONSTRAINT [PK_LogEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


