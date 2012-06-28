using System.Data;
using System.Data.SqlClient;
using System.IO;
using domain.DatabaseMetrics;
using StructureMap;
using domain.Quotes;

namespace web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });

                            wire_up_database(x);
                            wire_up_domain(x);
                        });
            return ObjectFactory.Container;
        }

        static void wire_up_database(IInitializationExpression r)
        {

            //todo:  refactor this to use proper security encryption when retrieving a connection string
            string db_connection_path = @"C:\\Daxko\\Dashboard\\db_connection_path.txt";

            r.For<IDbConnection>().Use(x => new SqlConnection(File.OpenText(db_connection_path).ReadToEnd()));

        }

        static void wire_up_domain(IInitializationExpression x)
        {
            x.For<IQuoteRepository>().Use<QuoteRepository>();
            //x.For<ISqlJobMetricRepository>().Use<MockupSqlJobMetricRepository>();
            x.For<ISqlJobMetricRepository>().Use<SqlJobMetricRepository>();
        }
    }
}