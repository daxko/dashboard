using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.DatabaseMetrics
{
    public class MockupSqlJobMetricRepository : ISqlJobMetricRepository
    {
        public IEnumerable<SqlJobMetrics> get_job_metrics_for_last_24_hours()
        {

            var metrics = new List<SqlJobMetrics>();

            metrics.Add(new SqlJobMetrics
                            {
                                job_name = "blah",
                                job_status = SqlJobMetrics.job_outcomes.success,
                                last_run = DateTime.Now,
                                message = "blah de blah"
                            });


            metrics.Add(new SqlJobMetrics
            {
                job_name = "blah",
                job_status = SqlJobMetrics.job_outcomes.failed,
                last_run = DateTime.Now,
                message = "this is an error message"
            });

            metrics.Add(new SqlJobMetrics
            {
                job_name = "this is a job with big message",
                job_status = SqlJobMetrics.job_outcomes.failed,
                last_run = DateTime.Now,
                message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ipsum sapien, tempor id suscipit nec, lacinia sed libero. Fusce justo orci, mattis sed dignissim at, sagittis et urna. Nunc ac nunc quis orci varius malesuada. Donec congue posuere volutpat. In hac habitasse platea dictumst. Curabitur felis metus, egestas sed condimentum sit amet, sagittis nec tortor. Vivamus in nulla est, eget scelerisque turpis. Curabitur ornare posuere magna. In tempus enim id tortor porta ac rhoncus felis ullamcorper. Sed commodo elementum augue, ac cursus ligula luctus sed. Sed justo magna, congue sit amet egestas eget, accumsan sed libero. Nunc sagittis fringilla tellus, in pharetra arcu porta sed. Sed dictum facilisis risus, eget cursus velit blandit eget. Mauris risus felis, cursus sed iaculis non, sollicitudin id nisl.

Nulla ullamcorper sem eget purus consectetur faucibus. Integer sodales dignissim tellus. Maecenas rutrum ullamcorper nunc ut ultricies. Aliquam erat volutpat. Pellentesque tincidunt tortor sed diam suscipit nec tempus elit fringilla. Nullam ut lacus lacinia felis egestas porttitor nec volutpat arcu. Donec vel venenatis diam. Pellentesque rutrum rutrum rutrum. Donec vel est nec eros faucibus malesuada non nec sem. Nulla euismod egestas dui a congue. Integer accumsan diam eget leo condimentum in mattis justo commodo. Pellentesque lacinia cursus sem non aliquam. Donec sed tellus id ligula consequat ornare at in nibh. Nam ac eros dui. Sed et sem lorem, et volutpat ipsum.

Nunc non magna augue. Nunc id tempus turpis. Sed purus quam, ultricies sed mattis nec, ultrices eget orci. Etiam pellentesque, eros id molestie viverra, neque tortor cursus libero, nec varius magna nisl ut ligula. Ut gravida placerat turpis, ut iaculis turpis pellentesque in. Nunc mauris augue, auctor ac posuere ut, consequat sed nisi. Aliquam bibendum ligula sed odio laoreet vulputate.

Pellentesque ac eros sapien, id feugiat massa. Donec et justo turpis. Mauris tortor neque, fringilla ut sollicitudin in, consequat quis ipsum. Sed ut elit vitae risus ullamcorper pellentesque a eu magna. Morbi bibendum lorem nec magna posuere suscipit. Donec fermentum, lectus vel elementum dignissim, urna libero interdum tortor, vel pulvinar felis massa eu lectus. Sed tempor sem nec ligula dictum commodo. Nullam pharetra, mi vitae iaculis lobortis, sem nisl adipiscing quam, luctus tempus est ligula et lectus. Integer nulla turpis, tristique in gravida convallis, consequat nec mi. Sed non odio ut justo suscipit consectetur in in massa. Ut quis turpis sit amet massa sagittis fringilla ac malesuada quam. Morbi arcu justo, convallis sit amet varius at, laoreet ac orci. Maecenas in nulla dolor. Sed lobortis, urna in mollis volutpat, orci velit laoreet nunc, vel consequat nisi ipsum sit amet orci. Integer aliquet, ligula vitae fringilla sodales, metus arcu congue risus, nec gravida tortor arcu in urna.

Nulla facilisi. Fusce mattis pellentesque magna, eget blandit nisl tempus vel. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed suscipit arcu nec dui volutpat a sollicitudin nisi vestibulum. Nulla justo diam, dignissim eget eleifend vitae, mattis ut nisl. Nunc nec libero ut lectus cursus rhoncus in nec arcu. Nulla blandit dapibus consectetur. Aliquam a sem eu metus auctor consequat. Curabitur imperdiet dictum mauris scelerisque porttitor. Aenean luctus erat ac erat consectetur vitae lacinia orci porta. Nam adipiscing felis dui. Sed consequat magna in nibh convallis lobortis. Vivamus aliquam felis ipsum. Aenean ut quam nec sapien semper vehicula feugiat vel urna. Proin felis elit, varius eget blandit eu, ornare non tortor.
"

            });

            metrics.Add(new SqlJobMetrics
            {
                job_name = "blah de blah",
                job_status = SqlJobMetrics.job_outcomes.success,
                last_run = DateTime.Now,
                message = "just another failed job"
            });


            return metrics;
        }
    }

}