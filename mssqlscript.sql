USE [Company]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 5/17/2020 5:25:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[time_reports]    Script Date: 5/17/2020 5:25:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[time_reports](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employee_id ] [int] NOT NULL,
	[hours] [real] NOT NULL,
	[date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_time_reports] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[time_reports]  WITH CHECK ADD  CONSTRAINT [FK_time_reports_employees_employee_id ] FOREIGN KEY([employee_id ])
REFERENCES [dbo].[employees] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[time_reports] CHECK CONSTRAINT [FK_time_reports_employees_employee_id ]
GO
