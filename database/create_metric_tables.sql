use ProductionSupport;
go

create table ProductionSupport.dbo.Dashboard_CommonOpsErrors_Keep
(
	Id int primary key identity,
	ErrorCount int not null,
	ErrorDescription varchar(max),
	ErrorTimestamp datetime not null
)

create table ProductionSupport.dbo.Dashboard_ErrorCounts_Keep
(
	Id int primary key identity,
	PastDate datetime,
	PastErrorCount int,
	CurrentDate datetime,
	CurrentErrorCount int	
)

create table ProductionSupport.dbo.Dashboard_SqlJobMetrics_Keep
(
	name varchar(max),
	message varchar(max),
	success_status tinyint,
	last_run_datetime datetime,
	step_id smallint
)