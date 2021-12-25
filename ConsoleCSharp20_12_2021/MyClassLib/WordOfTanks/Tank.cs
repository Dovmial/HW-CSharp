using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib.WordOfTanks
{
    public enum BattleStatus { Win = 1, Lose = -1, Draw = 0 };
    public class Tank
    {
        private string _name;
        public string GetName() { return _name; }

        private short _ammunition;
        public string GetAmmunition() { return _ammunition.ToString(); }

        private short _armor;
        public string GetArmor() { return _armor.ToString(); }

        private short _maneuverability;
        public string GetManeuverability() { return _maneuverability.ToString(); }

        public Tank(string name)
        {
            _name = name;

            Random rnd = new Random();
            _ammunition = (short)rnd.Next(0, 101);
            _armor = (short)rnd.Next(0, 101);
            _maneuverability = (short)rnd.Next(0, 101);
        }

        private static BattleStatus checkCriteryBattle(int param1 , int param2)
        {
            BattleStatus result;

            if (param1 == param2)
                result = BattleStatus.Draw;

            else if (param1 > param2)
                result = BattleStatus.Win;

            else result = BattleStatus.Lose;

            return result;
        }
        static public BattleStatus operator*(Tank t1, Tank t2)
        {
            BattleStatus[] criteryState = new BattleStatus[3];

            criteryState[0] = checkCriteryBattle(t1._armor, t2._armor);
            criteryState[1] = checkCriteryBattle(t1._ammunition, t2._ammunition);
            criteryState[2] = checkCriteryBattle(t1._maneuverability, t2._maneuverability);

            int wins = 0;
            int loses = 0;

            foreach(var item in criteryState)
            {
                if (item == BattleStatus.Win)
                    ++wins;
                else if (item == BattleStatus.Lose)
                    --loses;
            }

            if (wins >= 2)
                return BattleStatus.Win;
            else if (loses <= -2)
                return BattleStatus.Lose;
            else
                return BattleStatus.Draw;
        }

        public override string ToString()
        {
            return $"\tarmor: {_armor}\n\tammunition: {_ammunition}\n\tmaneuverability: {_maneuverability}";
        }
    }
}
