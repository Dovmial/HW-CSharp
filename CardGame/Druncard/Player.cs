namespace CardGameDrunkard
{
    public class Player
    {
        public string Name { get; set; }

        public Player(string name) => Name = name;
      
        public Queue<Card> Cards { get; private set; } = new Queue<Card>();

        /// <summary>
        /// To take all cards
        /// </summary>
        /// <param name="newCards"></param>
        public void Take(List<Card> newCards)
        {
           Cards = new Queue<Card>(Cards.Concat(newCards));
        }
        /// <summary>
        /// to give the card
        /// </summary>
        /// <returns></returns>
        public Card Give()
        {
            return Cards.Dequeue();
        }
        public void ShowCards()
        {
            Console.WriteLine($"\n\n\t\tPlayer: {Name}");
            Console.Write("\t\t\t");
            foreach (var card in Cards)
            {
                //Console.WriteLine($"{card}");
               
                card.Show();
            }
        }
    }
}