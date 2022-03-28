using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RandomOrgAPIAPP
{
    public static class GameHandler
    {
        private static HttpClient client = new HttpClient();
        private static string url = @"https://www.random.org/integers/?num=2&min=1&max=6&col=1&base=10&format=plain&rnd=new/";

        private static async Task<string[]> RollDiceAsync()
        {
            var response = await client.GetAsync(url);
            return (await response.Content.ReadAsStringAsync()).Split('\n');
        }

        public static async Task PlayerRollDiceAsync(Player player)
        {
            var dice = await RollDiceAsync();
            player.SetRound(dice[0], dice[1], ResultCalc(dice[0], dice[1]));
        }

        private static string ResultCalc(in string number1, in string number2)
        {
            return (int.Parse(number1) + int.Parse(number2)).ToString();
        }
    }
}
