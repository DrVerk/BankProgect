namespace BankProgect
{
    class DepositAccount : Account, IDeposite
    {
        public uint Deposite { get; set; }
        public new static string Name { get { return "Депозитный"; } }
        public DepositAccount(float kech, uint bet, uint deposite) :
            base(kech,bet)
        {
            Deposite = deposite;
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
