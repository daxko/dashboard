USE [ProductionSupport]
GO

/****** Object:  StoredProcedure [dbo].[sqljobs_get_prev_day_jobs_usp]    Script Date: 06/29/2012 13:49:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sqljobs_get_prev_day_jobs_usp] as

truncate table ProductionSupport.dbo.Dashboard_SqlJobMetrics_Keep

insert into ProductionSupport.dbo.Dashboard_SqlJobMetrics_Keep
select j.name,
                   h.message,
                   success_status = case h.run_status
                                        when 1 then 1 /* success */
                                        else 0 /* failure */
                                    end,
                    last_run_datetime = CONVERT(DATETIME, CONVERT(CHAR(8), run_date, 112) + ' ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), run_time), 6), 5, 0, ':'), 3, 0, ':'), 121),
                    h.step_id
                from msdb.dbo.sysjobhistory h
                inner join msdb..sysjobs j on h.job_id = j.job_id                
                where CONVERT(DATETIME, CONVERT(CHAR(8), run_date, 112) + ' ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), run_time), 6), 5, 0, ':'), 3, 0, ':'), 121) 
                    > DATEADD(HOUR, -24, GETDATE())
                   order by j.name, h.step_id
                   

GO

