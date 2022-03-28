using System;
using System.Windows.Forms;

namespace RandomOrgAPIAPP
{
    public partial class Form1 : Form
    {
        Player player1, player2;
        public Form1()
        {
            InitializeComponent();
            InitPlayers();
        }
        private void InitPlayers()
        {

            player1 = new Player(
                ref lblDice1Player1,
                ref lblDice2Player1,
                ref lblPlayer1,
                ref lblResultPlayer1,
                PlayerType.Human);

            player2 = new Player(
                ref lblDice1Player2,
                ref lblDice2Player2,
                ref lblPlayer2,
                ref lblResultPlayer2,
                PlayerType.Human);
        }

        private async void btnDice1Random_Click(object sender, EventArgs e)
        {
            await GameHandler.PlayerRollDiceAsync(player1);
            if(player2.Type == PlayerType.AI)
                await GameHandler.PlayerRollDiceAsync(player2);

        }

        private async void btnDice2Random_Click(object sender, EventArgs e)
        {
            await GameHandler.PlayerRollDiceAsync(player2);
        }

        private void rbAI_CheckedChanged(object sender, EventArgs e)
        {
            btnDice2Random.Visible ^= true;
            if (rbAI.Checked)
            {
                player2.Name.Text = "Компьютер";
                player2.Type = PlayerType.AI;
            }
            else
            {
                player2.Name.Text = "Игрок 2";
                player2.Type = PlayerType.Human;
            }
        }
    }
}
