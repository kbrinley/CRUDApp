USE [CRUDDB]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 10/23/2014 11:03:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[id] [int] NOT NULL PRIMARY KEY,
	[firstname] [nvarchar](40) NOT NULL,
	[middlename] [nvarchar](40) NULL,
	[lastname] [nvarchar](255) NOT NULL,
	[addressline1] [nvarchar](255) NULL,
	[addressline2] [nvarchar](255) NULL,
	[city] [nvarchar](255) NULL,
	[state] [nvarchar](40) NOT NULL,
	[zipcode] [nvarchar](10) NULL
) ON [PRIMARY]

GO


