using System;
namespace BankLibrary
{
    public class Account : INumfer
    {
        static Random s_random;
        uint _accountNumb, _bet;
        float _money;
        protected string _Name = "Счет";
        /// <summary>
        /// тип счета
        /// </summary>
        public string Name { get => _Name; }
        /// <summary>
        /// номер счета
        /// </summary>
        public uint AccountNumf { get => _accountNumb; }
        /// <summary>
        /// деньги на акаунте
        /// </summary>
        public float Money { get => _money; set { _money = value; } }
        /// <summary>
        /// процентная ставка
        /// </summary>
        public uint Bet { get => _bet; set { _bet = value; } }
        private uint AcNumbGenerator() => Convert.ToUInt32(s_random.Next());
        public override string ToString() => String.Format("{0} {1} {2}", Name, AccountNumf, Money);
        static Account()
        {
            s_random = new Random();
        }
        public Account(float kech = 100, uint bet = 10)
        {
            _money = kech;
            _accountNumb = AcNumbGenerator();
            _bet = bet;
        }
        public static Account operator +(Account x, float y)
        {
            x.Money += y;
            return x;
        }
    }
    public static class AccountFier
    {
        public static bool IsIterect(this Account Ac, float Kec)
        {
            if (Ac.Money - Kec >= 0)
                return true;
            else
                return false;
        }
    }
    interface INumfer
    {
        uint AccountNumf { get; }
        float Money { get; }
        uint Bet { get; }
    }
}
