USE [HWQATOOL]
CREATE TABLE [TBL_CLIENT]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[NAME] VARCHAR(50) NOT NULL,	
	[TEAM_ID] INT NOT NULL,
	[IS_KEY_CLIENT] BIT NOT NULL DEFAULT(0),
	[SAMPLE_PERCENTAGE] DECIMAL(5,2) NOT NULL,
	[IS_ACTIVE] BIT NOT NULL DEFAULT(1),
	[VERSION] INT NOT NULL DEFAULT(1),
	[LAST_MODIFIED_AT] DATETIME NOT NULL DEFAULT(GETDATE()),
	[LAST_MODIFIED_BY] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_TBL_CLIENT] PRIMARY KEY ([ID]),
	CONSTRAINT [UQ_TBL_CLIENT_TEAM_ID_NAME] UNIQUE ([TEAM_ID],[NAME]),
	CONSTRAINT [FK_TBL_CLIENT_TEAM_ID_TBL_TEAM_ID] FOREIGN KEY ([TEAM_ID]) REFERENCES TBL_TEAM ([ID])
)