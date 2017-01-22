namespace Project
{
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();
        public double? RememberedResult { get; set; }

        static Singleton(){}

        public static Singleton GetInstance
        {
            get
            {
                return _instance;
            }
        }

        private Singleton()
        {
            RememberedResult = null;
        }
    }
}
