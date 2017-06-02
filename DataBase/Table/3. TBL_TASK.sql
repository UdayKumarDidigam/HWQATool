USE [HWQATOOL]
GO
IF OBJECT_ID('dbo.TBL_TASK', 'U') IS NOT NULL 
BEGIN
  DROP TABLE dbo.[TBL_TASK]
END
GO
CREATE TABLE [TBL_TASK]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[NAME] VARCHAR(50) NOT NULL,
	[SAMPLE_PERCENTAGE] DECIMAL(5,2) NOT NULL,
	[TEAM_ID] INT NOT NULL,
	[VERSION] INT NOT NULL DEFAULT(1),
	[LAST_MODIFIED_AT] DATETIME NOT NULL DEFAULT(GETDATE()),
	[LAST_MODIFIED_BY] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_TBL_TASK] PRIMARY KEY ([ID]),
	CONSTRAINT [UQ_TBL_TASK_TEAM_ID_NAME] UNIQUE ([TEAM_ID],[NAME]),
	CONSTRAINT [FK_TBL_TASK_TEAM_ID_TBL_TEAM_ID] FOREIGN KEY ([TEAM_ID]) REFERENCES TBL_TEAM ([ID])
)
GO
