create table tblTeam(Id int,Name Varchar(20),QualityBenchMark varchar(20),[Version] int,LastModifiedAt date,LastModifiedBy varchar(20));

create table tblAuditTimeSlot(Id int,AuditId int,Auditor varchar(20),StartDate date,EndDate date,TotalTime Time,[status] bit,[Version] int,LastModifiedAt date,LastModifiedBy varchar(20));   

CREATE TABLE TBLAUDIT
(
[ID] INT,
[AUDITNO] INT,
[CONFIRMATIONNO] INT,
[SERVICEREQUESTNO] INT,
[PROCESSEDDATE] DATE,[PROCESSOR] VARCHAR(20),
[CLIENTID] INT,
[SUBTASKID] INT,
[TASKID] INT,
[AUDITOR] VARCHAR(20),
[AUDITDATE] DATE,
[COMMENTS] VARCHAR(20),
[ISDEFECT] BIT,
[ISLEARNING] BIT,
[ISESCALATION] BIT,
[ISCLIENTFOCUS] BIT,
[ISDUPLICATE] BIT,
[ISSAMPLED] BIT,
[NOOFRECORDS] INT,
[TOTALDEFECTS] INT,
[STATUS] VARCHAR(20),
[PLATFORMID] INT,
[VERSION] INT,
[LASTMODIFIEDAT] DATE,
[LASTMODIFIEDBY] VARCHAR(20)
);