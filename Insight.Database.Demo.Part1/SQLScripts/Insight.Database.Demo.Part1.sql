SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE DATABASE [Insight.Database.Demo]
GO

USE [Insight.Database.Demo]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_GetAllWeatherForecast]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_GetAllWeatherForecast]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_GetAddWeatherForecastsAndSummary]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_GetAddWeatherForecastsAndSummary]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_AddWeatherForecasts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_AddWeatherForecasts]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllWeatherForecast]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllWeatherForecast]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeatherForecast]') AND type in (N'U'))
DROP TABLE [dbo].[WeatherForecast]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SummaryDim]') AND type in (N'U'))
DROP TABLE [dbo].[SummaryDim]
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'T_AddWeatherForecast' AND ss.name = N'dbo')
DROP TYPE [dbo].[T_AddWeatherForecast]
GO

CREATE TYPE [dbo].[T_AddWeatherForecast] AS TABLE(
	[WeatherForecastId] [int] NULL,
	[Date] [datetime] NULL,
	[TemperatureC] [int] NULL,
	[Summary] [nvarchar](max) NULL
)
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SummaryDim](
	[SummaryId] [int] IDENTITY(1000,1) NOT NULL,
	[Summary] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SummaryId] PRIMARY KEY CLUSTERED 
(
	[SummaryId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeatherForecast](
	[WeatherForecastId] [int] IDENTITY(100,1) NOT NULL,
	[Date] [datetime] NULL,
	[TemperatureC] [int] NULL,
	[Summary] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.WeatherForecastId] PRIMARY KEY CLUSTERED 
(
	[WeatherForecastId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SummaryDim] ON 
GO
INSERT [dbo].[SummaryDim] ([SummaryId], [Summary]) VALUES (1007, N'Hot')
GO
INSERT [dbo].[SummaryDim] ([SummaryId], [Summary]) VALUES (1006, N'Balmy')
GO
INSERT [dbo].[SummaryDim] ([SummaryId], [Summary]) VALUES (1005, N'Warm')
GO
INSERT [dbo].[SummaryDim] ([SummaryId], [Summary]) VALUES (1004, N'Mild')
GO
INSERT [dbo].[SummaryDim] ([SummaryId], [Summary]) VALUES (1003, N'Cool')
GO
INSERT [dbo].[SummaryDim] ([SummaryId], [Summary]) VALUES (1002, N'Chilly')
GO
INSERT [dbo].[SummaryDim] ([SummaryId], [Summary]) VALUES (1001, N'Bracing')
GO
INSERT [dbo].[SummaryDim] ([SummaryId], [Summary]) VALUES (1000, N'Freezing')
GO
SET IDENTITY_INSERT [dbo].[SummaryDim] OFF
GO
SET IDENTITY_INSERT [dbo].[WeatherForecast] ON 
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (112, CAST(N'2021-11-06T10:08:23.660' AS DateTime), 101, N'string_101')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (111, CAST(N'2021-11-05T10:08:23.660' AS DateTime), 100, N'string_100')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (110, CAST(N'2021-11-06T10:08:23.660' AS DateTime), 101, N'string_101')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (109, CAST(N'2021-11-05T10:08:23.660' AS DateTime), 100, N'string_100')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (108, CAST(N'2021-11-06T10:08:23.660' AS DateTime), 101, N'string_101')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (107, CAST(N'2021-11-05T10:08:23.660' AS DateTime), 100, N'string_100')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (106, CAST(N'2021-09-09T00:00:00.000' AS DateTime), 45, N'Scorching')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (105, CAST(N'2021-09-10T00:00:00.000' AS DateTime), 35, N'Sweltering')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (104, CAST(N'2021-09-11T00:00:00.000' AS DateTime), 25, N'Hot')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (103, CAST(N'2021-09-12T00:00:00.000' AS DateTime), 0, N'Chilly')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (102, CAST(N'2021-09-13T00:00:00.000' AS DateTime), 10, N'Warm')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (101, CAST(N'2021-09-14T00:00:00.000' AS DateTime), 5, N'Mild')
GO
INSERT [dbo].[WeatherForecast] ([WeatherForecastId], [Date], [TemperatureC], [Summary]) VALUES (100, CAST(N'2021-09-15T00:00:00.000' AS DateTime), -5, N'Freezing')
GO
SET IDENTITY_INSERT [dbo].[WeatherForecast] OFF
GO
/****** Object:  StoredProcedure [dbo].[GetAllWeatherForecast]    Script Date: 05-11-2021 17:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetAllWeatherForecast]
 AS
                SELECT * FROM [dbo].[WeatherForecast]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[P_AddWeatherForecasts] 
(@WeatherForecasts  [T_AddWeatherForecast] READONLY)
 AS

	INSERT INTO [dbo].[WeatherForecast]
			   ([Date]
			   ,[TemperatureC]
			   ,[Summary])
	SELECT [Date]
		  ,[TemperatureC]
		  ,[Summary]
	  FROM @WeatherForecasts

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[P_GetAddWeatherForecastsAndSummary]
(@WeatherForecasts_New  [T_AddWeatherForecast] READONLY)
 AS

	INSERT INTO [dbo].[WeatherForecast]
			   ([Date]
			   ,[TemperatureC]
			   ,[Summary])
	SELECT [Date]
		  ,[TemperatureC]
		  ,[Summary]
	  FROM @WeatherForecasts_New

	 SELECT  * FROM [dbo].[WeatherForecast]
	 SELECT  * FROM [dbo].[SummaryDim]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[P_GetAllWeatherForecast]
 AS
                SELECT * FROM [dbo].[WeatherForecast]
GO
