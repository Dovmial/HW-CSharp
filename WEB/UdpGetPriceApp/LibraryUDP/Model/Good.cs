

namespace LibraryUDP.Model
{
    public class Good
    {

        //public int Id { get; private set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public Good(decimal price, string name)
        {
            Price = price;
            Name = name;
        }
    }
}
