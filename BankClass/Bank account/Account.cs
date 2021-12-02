using System;

namespace BankProgect
{
    internal class Account : INumfer
    {
        static Random random;
        uint _AcNumb;
        float _Money;
        uint _Bet;
        protected string _Name = "Счет";
        public string Name { get => _Name; }
        public uint AcNumf { get => _AcNumb; }
        public float Money { get => _Money; set { _Money = value; } }
        public uint Bet { get => _Bet; set { _Bet = value; } }
        private uint AcNumbGenerator() => Convert.ToUInt32(random.Next());
        public override string ToString() => String.Format("{0} {1} {2}", Name, AcNumf, Money);
        static Account()
        {
            random = new Random();
        }
        public Account(float kech, uint bet)
        {
            _Money = kech;
            _AcNumb = AcNumbGenerator();
            _Bet = bet;
        }
    }
    interface INumfer
    {
        uint AcNumf { get; }
        float Money { get; }
        uint Bet { get; }
    }

}
