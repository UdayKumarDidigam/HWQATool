USE DATABASE[H and W QA Tool]
CREATE TABLE [dbo].[tbl_Audit_Finding]
(
		[Id] [int] NOT NULL,
		[AuditId] [int] NOT NULL,
		[ErrorId] [int] NOT NULL,
		[version] [int] NOT NULL,
		[LastModifiedAt] [date] NOT NULL DEFAULT(DATETIME()),
		[LastModifiedBy] [varchar]  NOT NULL,
		CONSTRAINT [PK_tbl_Audit_Finding] PRIMARY KEY ([Id]),
	    CONSTRAINT [UQ_tbl_Audit_Finding_AuditId_ErrorId] UNIQUE ([AuditId],[ErrorId]),
	    CONSTRAINT [FK_tbl_Audit_Finding_Id_TBL_ERROR_ID] FOREIGN KEY ([ErrorId]) REFERENCES tbl_Error([ID]),
)
