using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Engine;
using Autofac;

namespace Lottery
{
    class Program
    {
        public static IContainer container;

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NationalLottery>().As<IEngine>();
            builder.RegisterType<ShortRandomNumberGenerator>().As<IRandomNumberGenerator<ushort>>();
            container = builder.Build();

            // Entry point for program.

            using (var scope = container.BeginLifetimeScope() )
            {
                IEngine nationalLottery = scope.Resolve<IEngine>();
                nationalLottery.Run();
            }

            Console.ReadKey();            
        }
    }
}
