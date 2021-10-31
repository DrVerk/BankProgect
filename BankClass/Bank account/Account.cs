using System;

namespace BankProgect
{
    class Account : INumfer
    {
        static Random random;
        static Account()
        {
            random = new Random();
        }
        public Account(float kech,uint bet)
        {
            Kech = kech;
            NumNumf = NumNumfGenerator();
            Bet = bet;
        }
        public static  string Name { get { return "Не депозитный"; } }
        public uint NumNumf { get; }
        public float Kech { get; set; }
        public uint Bet { get; set; }
        private uint NumNumfGenerator()
        {
            uint n = Convert.ToUInt32(Math.Abs(random.Next()));
            return n;
        }
        public void addedKech(float kech)
        {
            Kech += kech;
        }
      
    }
    interface INumfer
    {
        uint NumNumf { get; }
        float Kech { get; }
        uint Bet { get; }
    }

}
