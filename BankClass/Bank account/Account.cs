using System;

namespace BankProgect
{
    class Account : INumfer
    {
        static Random random;
        uint _NumNumf;
        float _Kech;
        uint _Bet;
        protected string _Name = "Не депозитный";
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
        public string Name { get => _Name; }
        public uint NumNumf { get => _NumNumf; }
        public float Kech { get => _Kech; set { _Kech = value; } }
        public uint Bet { get => _Bet; set { _Bet = value; } }
        private uint NumNumfGenerator()=> Convert.ToUInt32(Math.Abs(random.Next()));        
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
