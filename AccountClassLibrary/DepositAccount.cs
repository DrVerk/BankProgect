using System;
namespace BankLibrary
{
    public class CreditAccount : Account, IDeposite
    {
        uint _loanRare;
        /// <summary>
        /// кредитная ставка
        /// </summary>
        public uint LoanRate { get => _loanRare; set => _loanRare = value; }
        public override string ToString() => String.Format("{0} {1}", base.ToString(), LoanRate);
        public CreditAccount(float kech = 100, uint bet = 10, uint deposite = 10) : base(kech, bet)
        {
            LoanRate = deposite;
            _Name = "Кредит";
        }
    }
    interface IDeposite
    {
        uint LoanRate { get; set; }
    }
}
