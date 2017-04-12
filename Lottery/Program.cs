using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Lottery.Engine;
using Lottery.NationalLottery;

namespace Lottery
{
    class Program
    {
        public static IContainer container;

        static void Main(string[] args)
        {
            // Entry point for program.          
            RunNationalLottery();
            //RunEuroLottery();                     
            Console.ReadKey();            
        }

        private static void RunNationalLottery()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Engine.Engine>().As<IEngine>();

            // National Lottery Dependencies....
            builder.RegisterType<ShortRandomNumberGenerator>().As<IRandomNumberGenerator<ushort>>();           
            builder.RegisterType<NationalLotteryRules>().As<IRules>();
            container = builder.Build();

            var nationalLotteryPlayers = new List<NationalLotteryPlayer>();
            nationalLotteryPlayers.Add(new NationalLotteryPlayer(15, new ushort[] { 1, 2, 3, 4, 5, 6 }));
            nationalLotteryPlayers.Add(new NationalLotteryPlayer(16, new ushort[] { 1, 2, 3, 4, 5, 6 }));            

            using (var scope = container.BeginLifetimeScope())
            {
                IEngine nationalLottery = scope.Resolve<IEngine>();
                nationalLottery.Run(nationalLotteryPlayers);
            }
        }

        private static void RunEuroLottery()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Engine.Engine>().As<IEngine>();

            // Euro Lottery Dependencies...
            //builder.RegisterType<SecureRandomNumberGenerator>().As<IRandomNumberGenerator<ushort>>();          
            //builder.RegisterType<EuroLotteryRules>().As<IRules>();
            container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                //IEngine nationalLottery = scope.Resolve<IEngine>();
                //nationalLottery.Run();
            }
        }
    }
}
