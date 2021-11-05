SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE DATABASE [Insight.Database.Demo]
GO

USE [Insight.Database.Demo]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeatherForecast]') AND type in (N'U'))
DROP TABLE [dbo].[WeatherForecast]
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
SET IDENTITY_INSERT [dbo].[WeatherForecast] ON 
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

