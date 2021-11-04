using System;

namespace BankProgect
{
    class Account : INumfer
    {
        static Random random;
        uint _NumNumf;
        float _Kech;
        uint _Bet;
        static Account()
        {
            random = new Random();
        }
        public Account(float kech, uint bet)
        {
            _Kech = kech;
            _NumNumf = NumNumfGenerator();
            _Bet = bet;
        }
        public static string Name { get => "Не депозитный"; }
        public uint NumNumf { get => _NumNumf; }
        public float Kech { get => _Kech; set { _Kech = value; } }
        public uint Bet { get => _Bet; set { _Bet = value; } }
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
