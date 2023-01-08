/****** Object:  StoredProcedure [dbo].[P_GetUserEmailAddress]    Script Date: 1/8/2023 12:09:15 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_GetUserEmailAddress]
GO
/****** Object:  StoredProcedure [dbo].[P_GetAllUsers]    Script Date: 1/8/2023 12:09:15 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_GetAllUsers]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/8/2023 12:09:15 PM ******/
DROP TABLE IF EXISTS [dbo].[User]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/8/2023 12:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(100,1) NOT NULL,
	[FirstName] [nvarchar](300) NULL,
	[LastName] [nvarchar](300) NULL,
	[EmailAddress] [nvarchar](350) NULL,
	[Country] [nvarchar](350) NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[UserId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (109, N'Colleen', N'Kessler', N'samara_corwin@nolanschuster.name', N'Marshall Islands')
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (108, N'Graciela', N'Keeling', N'nakia_buckridge@goldner.biz', N'Cameroon')
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (107, N'Rosie', N'Mertz', N'quinn_altenwerth@effertz.us', N'United States of America')
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (106, N'Amelia', N'Weimann', N'braxton@sauerlittel.name', N'Saint Helena')
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (105, N'Rosalyn', N'Hammes', N'magdalena.jones@hirthe.biz', N'India')
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (104, N'Reagan', N'Schneider', N'earl@jones.us', N'Saint Helena')
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (103, N'Anderson', N'Balistreri', N'ismael@considine.name', N'Svalbard & Jan Mayen Islands')
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (102, N'Maegan', N'Marks', N'maurine.boehm@halvorson.ca', N'Moldova')
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (101, N'Alverta', N'Dibbert', N'bud@streich.com', N'Saint Pierre and Miquelon')
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Country]) VALUES (100, N'Khalil', N'Fay', N'boris_koch@bailey.info', N'Lithuania')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  StoredProcedure [dbo].[P_GetAllUsers]    Script Date: 1/8/2023 12:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[P_GetAllUsers]				
as 
BEGIN
	SELECT *  FROM [dbo].[User]	
END
GO
/****** Object:  StoredProcedure [dbo].[P_GetUserEmailAddress]    Script Date: 1/8/2023 12:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[P_GetUserEmailAddress]
					@UserId					    BIGINT
as 
BEGIN
	SELECT [EmailAddress]  FROM [dbo].[User]
	WHERE UserId = @UserId
END
GO
