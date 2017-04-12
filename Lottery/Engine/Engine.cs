using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lottery.Engine
{
    public class Engine : IEngine
    {
        private readonly IRules rules;

        public Engine(IRules rules)
        {

            if (rules == null)
            {
                throw new ArgumentNullException(nameof(rules));
            }

            this.rules = rules;

        }

        public void Run(IEnumerable<IPlayer> players)
        {
            ushort[] numbersDrawn = rules.GenerateDraw();
            Console.WriteLine($"This weeks winning numbers are: {string.Join(", ", numbersDrawn.OrderBy(q => q))}");
            foreach (var player in players)
            {
                if (rules.CanPlay(player.Age))
                {
                    Console.WriteLine($"This player is ineligible to play. Player must be over {rules.MinimumPlayerAge}.");
                    continue;
                }

                if (rules.HasPlayerWon(numbersDrawn, player.Numbers))
                {
                    Console.WriteLine($"We have a winner!");
                }
            }
        }
    }
}
