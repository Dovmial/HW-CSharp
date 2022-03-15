
using HikeApp.BackPacks;

namespace HikeApp
{
    public class Tourist
    {
        public string Name { get; private set; }
        public string TouristType { get; private set; }
        public int Steps { get; set; }
        public int SpeedDelay { get; set; }
        public BackPackAbstract BackPack { get; set; }

        public Tourist(string name, string typeTourist, BackPackAbstract backPack, int speedDelay)
        {
            Name = name;
            TouristType = typeTourist;
            BackPack = backPack;
            Steps = 0;
            SpeedDelay = speedDelay;
         }
        public override string ToString()
        {
            return  $"{TouristType}  \t{Name}\tпрошел: {Steps}" +
                $"\tРюкзак: {BackPack.ItemsList}";
        }
    }
}
