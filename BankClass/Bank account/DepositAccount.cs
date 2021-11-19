namespace BankProgect
{
    class DepositAccount : Account, IDeposite
    {
        uint _Deposite;
        public uint Deposite { get => _Deposite; set => _Deposite = value; }
        public DepositAccount(float kech, uint bet, uint deposite) :
            base(kech, bet)
            
        {
            Deposite = deposite;
            base._Name = "Депозитный";
        }
        public void Depositev()
        {

        }

    }
    interface IDeposite
    {
        uint Deposite { get; set; }
        void Depositev();
    }
}
