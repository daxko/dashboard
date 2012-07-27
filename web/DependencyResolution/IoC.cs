using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Daxko.Infrastructure.DataAccess;
using Daxko.Infrastructure.Security;
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

            var encrypted_connection_strings = ConfigurationManager.ConnectionStrings;

            r.ForSingletonOf<ICrypto>().Use<Crypto>()
                .Ctor<String>("masterCipher").EqualToAppSetting("PassPhrase");

            r.ForSingletonOf<IConnectionStringManager>()
              .Use<ConnectionStringManager>()
              .Ctor<ConnectionStringSettingsCollection>("encryptedConnections").Is(encrypted_connection_strings)
              .Ctor<bool>("ignoreLocalSqlServer").Is(true);

            r.For<IDbConnection>().Use<SqlConnection>()
                .Ctor<string>("connectionString").Is(
                    x => x.GetInstance<IConnectionStringManager>().Find("dashboard_connection_string").ConnectionString);

        }

        static void wire_up_domain(IInitializationExpression x)
        {
            x.For<IQuoteRepository>().Use<QuoteRepository>();
            //x.For<ISqlJobMetricRepository>().Use<MockupSqlJobMetricRepository>();
            x.For<ISqlJobMetricRepository>().Use<SqlJobMetricRepository>();
            //x.For<IErrorLogRepository>().Use<mockupErrorLogRepository>();
            x.For<IErrorLogRepository>().Use<ErrorLogRepository>();
        }
    }
}