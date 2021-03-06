USE [HWQATOOL]
GO
IF OBJECT_ID('DBO.TBL_AUDIT', 'U') IS NOT NULL 
BEGIN
  DROP TABLE [DBO].[TBL_AUDIT]
END
GO
CREATE TABLE [DBO].[TBL_AUDIT]
(
	[ID] BIGINT NOT NULL,
	[AUDIT_NO] VARCHAR(50) NULL,
	[BATCH_NO] VARCHAR(50) NULL,
	[FILE_NO] VARCHAR(50) NULL,
	[SERVICE_REQUEST_NO] VARCHAR(50) NULL,
	[PROCESSED_DATE] DATETIME NULL,
	[PROCESSOR] INT NULL,	
	[PLATFORM_ID] INT NULL,
	[TASK_ID] INT NULL,
	[SUB_TASK_ID] INT NULL,
	[CLIENT_ID] INT NULL,
	[AUDITOR] INT NULL,
	[AUDIT_DATE] DATETIME NULL,
	[AUDITOR_COMMENTS] VARCHAR(50) NULL,
	[IS_DEFECT] BIT NOT NULL DEFAULT(0),
	[IS_LEARNING] BIT NOT NULL DEFAULT(0),
	[IS_ESCALATION] BIT NOT NULL DEFAULT(0),
	[IS_CLIENTFOCUS] BIT NOT NULL DEFAULT(0),
	[IS_DUPLICATE] BIT NOT NULL DEFAULT(0),
	[IS_SAMPLED] BIT NOT NULL DEFAULT(0),
	[NO_OF_RECORDS] INT NOT NULL DEFAULT(1),
	[STATUS] INT NOT NULL,
	[IS_ACTIVE] BIT NOT NULL DEFAULT(1),
	[VERSION] INT NOT NULL DEFAULT(1),
	[LAST_MODIFIED_AT] DATETIME NOT NULL DEFAULT (GETDATE()),
	[LAST_MODIFIED_BY] VARCHAR(50)NOT NULL,
	CONSTRAINT [PK_TBL_AUDIT] PRIMARY KEY([ID]),
	CONSTRAINT[FK_TBL_AUDIT_PROCESSOR_TBL_USER_ID] FOREIGN KEY([PROCESSOR]) REFERENCES [TBL_USER]([ID]),
	CONSTRAINT[FK_TBL_AUDIT_AUDITOR_TBL_USER_ID] FOREIGN KEY([AUDITOR]) REFERENCES [TBL_USER]([ID]),
	CONSTRAINT[FK_TBL_AUDIT_TASK_ID_TBL_SUB_TASK_ID] FOREIGN KEY([TASK_ID]) REFERENCES [TBL_TASK]([ID]),
	CONSTRAINT[FK_TBL_AUDIT_SUB_TASK_ID_TBL_SUB_TASK_ID] FOREIGN KEY([SUB_TASK_ID]) REFERENCES [TBL_SUB_TASK]([ID]),
	CONSTRAINT[FK_TBL_AUDIT_CLIENT_ID_TBL_CLIENT_ID] FOREIGN KEY([CLIENT_ID]) REFERENCES [TBL_CLIENT]([ID]),
	CONSTRAINT[FK_TBL_AUDIT_PLATFORM_TBL_PLATFORM_ID] FOREIGN KEY([PLATFORM_ID]) REFERENCES [TBL_PLATFORM]([ID]),
)
GO
