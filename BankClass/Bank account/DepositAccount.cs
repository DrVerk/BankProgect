using System;
namespace BankProgect
{
    internal class DepositAccount : Account, IDeposite
    {
        uint _Deposite;
        public uint Deposite { get => _Deposite; set => _Deposite = value; }
        public DepositAccount(float kech, uint bet, uint deposite) :
            base(kech, bet)
        {
            Deposite = deposite;
            _Name = "Кредит";
        }
        public void Depositev()
        {

        }
        public override string ToString() => String.Format("{0} {1}", base.ToString(), Deposite);
    }
    interface IDeposite
    {
        uint Deposite { get; set; }
        void Depositev();
    }
}
