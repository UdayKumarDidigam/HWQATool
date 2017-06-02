USE [HWQATOOL]
GO
IF OBJECT_ID('dbo.TBL_ERROR', 'U') IS NOT NULL 
BEGIN
  DROP TABLE [DBO].[TBL_ERROR]
END
GO
CREATE TABLE [DBO].[TBL_ERROR]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[NAME] VARCHAR(50) NOT NULL,
	[DESCRIPTION] VARCHAR(100) NULL,
	[WEIGHTAGE] DECIMAL(5,2) NOT NULL,
	[TASK_ID] INT NOT NULL,
	[VERSION] INT NOT NULL DEFAULT(1),
	[LAST_MODIFIED_AT] DATETIME NOT NULL DEFAULT(GETDATE()),
	[LAST_MODIFIED_BY] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_TBL_ERROR] PRIMARY KEY ([ID]),
	CONSTRAINT [UQ_TBL_ERROR_TASK_ID_NAME] UNIQUE ([TASK_ID],[NAME]),
	CONSTRAINT [FK_TBL_ERROR_TASK_ID_TBL_TASK_ID] FOREIGN KEY ([TASK_ID]) REFERENCES TBL_TASK([ID])
)
GO
