using CardGameDrunkard.View;

namespace CardGameDrunkard
{
    public enum Suit 
    { 
        Hearts, Diamonds, Spades, Clubs
    };
    public enum FaceValue
    {
        Six = 6, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    };
    public class Card: IComparable <Card>
    {
        public Suit Suit { get; set; }

        public FaceValue FaceValue { get; set; }
        public Card(FaceValue facevalue, Suit suit)
        {
            FaceValue = facevalue;
            Suit = suit;
        }
        public void Show()
        {
            CardView.View(this);
        }
        public override string ToString()
        {
            return $"{FaceValue} of {Suit}";
        }

        public int CompareTo(Card? other)
        {
            return FaceValue.CompareTo(other?.FaceValue);
        }
    }
}