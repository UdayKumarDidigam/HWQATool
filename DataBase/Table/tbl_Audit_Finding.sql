USE [HWQATOOL]
GO
IF OBJECT_ID('DBO.TBL_AUDIT_FINDING', 'U') IS NOT NULL 
BEGIN
  DROP TABLE [DBO].[TBL_AUDIT_FINDING]
END
GO
CREATE TABLE [DBO].[TBL_AUDIT_FINDING]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[AUDIT_ID] INT NOT NULL,
	[ERROR_ID] INT NOT NULL,
	[VERSION] INT NOT NULL DEFAULT(1),
	[LAST_MODIFIED_AT] DATETIME NOT NULL DEFAULT(GETDATE()),
	[LAST_MODIFIED_BY] VARCHAR(50)  NOT NULL,
	CONSTRAINT [PK_TBL_AUDIT_FINDING] PRIMARY KEY ([ID]),
	CONSTRAINT [UQ_TBL_AUDIT_FINDING_AUDIT_ID_ERROR_ID] UNIQUE ([AUDIT_ID],[ERROR_ID]),
	CONSTRAINT [FK_TBL_AUDIT_FINDING_ID_TBL_ERROR_ID] FOREIGN KEY ([ERROR_ID]) REFERENCES [TBL_ERROR]([ID]),
	CONSTRAINT [FK_TBL_AUDIT_FINDING_ID_TBL_AUDIT_ID] FOREIGN KEY ([AUDIT_ID]) REFERENCES [TBL_ERROR]([ID]),
)
GO
