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

                            wire_up_domain(x);
                        });
            return ObjectFactory.Container;
        }

        static void wire_up_domain(IInitializationExpression x)
        {
            x.For<IQuoteRepository>().Use<QuoteRepository>();
        }
    }
}