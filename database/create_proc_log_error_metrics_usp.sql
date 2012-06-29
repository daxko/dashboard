use [ProductionSupport];

go

create procedure [dbo].[log_error_metrics_usp]	
as

-- 5 Most Common Errors
insert into ProductionSupport.dbo.Dashboard_CommonOpsErrors_Keep (ErrorTimestamp, ErrorCount, ErrorDescription)
select top 5
	convert(smalldatetime,GETDATE()) as 'ErrorTimeStamp',
	COUNT(*) as 'ErrorCount',
	(case exception
		when '' then Message
		else Exception end) as 'ErrorDescription'
from LoggingDB.dbo.Log
where Level = 'error'
and date > dateadd(day,-1,getdate())
group by
	(case exception
		when '' then Message
		else Exception end)
having COUNT(*) > 1
order by ErrorCount desc


/* SQL to create our error count history and cache it in the production support DB*/

DECLARE @start_date_today DATETIME
	, @start_date_past datetime
	, @end_date_past datetime
	
select 
	@start_date_today =  CONVERT(datetime, CONVERT(varchar, MONTH(getdate())) + '.' + CONVERT(varchar, DAY(getdate())) + '.' + CONVERT(varchar, YEAR(getdate())))
	,@start_date_past = dateadd(D,-7,CONVERT(datetime, CONVERT(varchar, MONTH(getdate())) + '.' + CONVERT(varchar, DAY(getdate())) + '.' + CONVERT(varchar, YEAR(getdate()))))
	,@end_date_past = dateadd(d,-7,getdate())
	
create table #Temp1
(
	PastDate datetime
	, PastErrorCount int
	, CurrentDate datetime
	, CurrentErrorCount int
)		
	
insert into #Temp1
select DATEADD(d,-7,getdate())as PastDate,COUNT(*) as PastErrorCount,null,null
from LoggingDB.dbo.Log
where Level = 'error'
and Date between @start_date_past and @end_date_past


update #Temp1
set CurrentDate = GETDATE(), CurrentErrorCount = a.CurrentErrorCount
from (
	select getdate()as CurrentDate,COUNT(*) as CurrentErrorCount
from LoggingDB.dbo.Log
where Level = 'error'
and Date between @start_date_today and GETDATE() )a

insert into ProductionSupport.dbo.Dashboard_ErrorCounts_Keep (PastDate, PastErrorCount, CurrentDate, CurrentErrorCount)
select PastDate, PastErrorCount, CurrentDate, CurrentErrorCount
from #temp1

drop table #Temp1


GO


