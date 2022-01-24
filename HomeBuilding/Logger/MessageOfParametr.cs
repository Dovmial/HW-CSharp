namespace LoggerProject
{
    internal class MessageOfParametr
    {
        
        public bool Instance { get; set; } = false;
        public string MessagePost { get; set; } = "";
        public Parametrs Parametr { get; set; }
        public MessageOfParametr(bool instance, Parametrs parametr)
        {
            Instance = instance;
            Parametr = parametr;
        }
    }
}
