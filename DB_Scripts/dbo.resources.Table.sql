USE [Cypago]
GO
/****** Object:  Table [dbo].[resources]    Script Date: 25/09/2024 06:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resources](
	[urn] [nvarchar](100) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[data] [nvarchar](max) NULL,
	[resourceType] [nvarchar](15) NOT NULL,
	[dataHash] [varbinary](100) NOT NULL,
	[scanid] [int] NOT NULL,
 CONSTRAINT [PK_urn_hash_scan] PRIMARY KEY CLUSTERED 
(
	[urn] ASC,
	[dataHash] ASC,
	[scanid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [resource_index1]    Script Date: 25/09/2024 06:21:11 ******/
CREATE NONCLUSTERED INDEX [resource_index1] ON [dbo].[resources]
(
	[urn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[resources]  WITH CHECK ADD  CONSTRAINT [FK_scanid_key] FOREIGN KEY([scanid])
REFERENCES [dbo].[scan] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[resources] CHECK CONSTRAINT [FK_scanid_key]
GO
