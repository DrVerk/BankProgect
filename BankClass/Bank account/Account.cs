using System;

namespace BankProgect
{
    internal class Account : INumfer
    {
        static Random random;
        uint _NumNumf;
        float _Kech;
        uint _Bet;
        protected string _Name = "Счет";
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
        private uint NumNumfGenerator()=> Convert.ToUInt32(random.Next());        
        public void addedKech(float kech)
        {
            Kech += kech;
        }
        public override string ToString() => String.Format("{0} {1} {2}",Name,NumNumf,Kech);
       
    }
    interface INumfer
    {
        uint NumNumf { get; }
        float Kech { get; }
        uint Bet { get; }
    }

}
