using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.DatabaseMetrics
{
    public interface IErrorLogRepository
    {
        IEnumerable<ErrorLogMetrics> get_top_5_errors();
        ErrorLogMetrics get_error_counts();
    }

    public class mockupErrorLogRepository:IErrorLogRepository
    {
        public IEnumerable<ErrorLogMetrics> get_top_5_errors()
        {
            var errors = new List<ErrorLogMetrics>();

            errors.Add(new ErrorLogMetrics { error = "this error", error_count = 123 });
            errors.Add(new ErrorLogMetrics { error = "that error", error_count = 456 });
            errors.Add(new ErrorLogMetrics { error = "this error again asfsfasfasfsafdasfasfasfasfasfasfasfsafasfasfasfasfdasfdasfasfdasfdasdfasdfasfasfdasfdasfdsafdsafdasfasfasfdasdfas  sdfasdfasdfasdf sadfasdfasdfasdf sadfasdfasdfasdf asdfasdfasdfasdfasdfasdfasdfsdf asdfasdfasdfasdfasdfasfasdfasdfasdfasfasfasfasfasfdasdf sadfasfdasfasfasfdasdf asdfasdfasdfasdfasdfasfasdf asdfasdfasdfasdfasdfasdfasdf asdfasfasdfasdfasdfas asfdasdfasdfasdf sadfasdf", error_count = 789 });
            errors.Add(new ErrorLogMetrics { error = "that error again", error_count = 101 });
            errors.Add(new ErrorLogMetrics { error = "blah", error_count = 112 });

            return errors;
        }

        public ErrorLogMetrics get_error_counts()
        {
            throw new NotImplementedException();
        }
    }
}
