
namespace HikeApp.BackPacks
{
    public abstract class BackPackAbstract
    {
        public string ItemsList { get; set; }
        public BackPackAbstract(string itemsList)
        {
            ItemsList = itemsList;
        }
    }
}