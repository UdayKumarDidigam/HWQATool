create table tblTeam(Id int,Name Varchar(20),QualityBenchMark varchar(20),[Version] int,LastModifiedAt date,LastModifiedBy varchar(20));

create table tblAuditTimeSlot(Id int,AuditId int,Auditor varchar(20),StartDate date,EndDate date,TotalTime Time,[status] bit,[Version] int,LastModifiedAt date,LastModifiedBy varchar(20));   

create table tblAudit(Id int,AuditNo int,ConfirmationNo int,ServiceRequestNo int,ProcessedDate date,Processor varchar(20),ClientId int,SubTaskId int,TaskId int,Auditor varchar(20),AuditDate date,Comments varchar(20),IsDefect bit,isLearning bit,IsEscalation bit,IsClientFocus bit,IsDuplicate bit,IsSampled bit,NoOfRecords int,TotalDefects int,[Status] varchar(20),PlatformId int,[Version] int,LastModifiedAt date,LastModifiedBy varchar(20));