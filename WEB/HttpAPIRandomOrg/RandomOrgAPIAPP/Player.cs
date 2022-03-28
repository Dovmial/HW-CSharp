using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomOrgAPIAPP
{
    public enum PlayerType { AI, Human }
    public class Player
    {
        public Label Dice1 { get; private set; }
        public Label Dice2 { get; private set; }
        public Label Name { get; private set; }
        public Label Result { get; set; }
        public PlayerType Type { get; set; }

        public Player(
            ref Label dice1,
            ref Label dice2,
            ref Label name,
            ref Label result,
            PlayerType type)
        {
            Dice1 = dice1;
            Dice2 = dice2;
            Name = name;
            Result = result;
            Type = type;
        }

        public void SetRound(string dice1, string dice2, string result)
        {
            Dice1.Text = dice1;
            Dice2.Text = dice2;
            Result.Text = result;
        }
    }
}