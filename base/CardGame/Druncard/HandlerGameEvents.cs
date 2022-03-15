using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDrunkard
{
    public  class HandlerGameEvents
    {
        private static event Action? EndRound;
        public static void Subscribing(Player player)
        {
                EndRound += player.ShowCards;
        }
        public static void Unsubscribing(Player player)
        {
                EndRound -= player.ShowCards;
        }

        public static void EndRoundEvent()
        {
            EndRound?.Invoke();
        }
    }
}
