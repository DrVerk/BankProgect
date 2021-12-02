using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BankProgect.Infrastructure.Commands;


namespace BankProgect.BankClass
{
    internal class BankControll : ViewModel
    {
        #region Система
        #region Строки
        //Вспомогательная строка для акаунта
        string _name = "";
        User<Account> _UsAcount, _Acount1;
        float _UserMoney;
        uint _UserBet, _LoanRare;
        bool _DepOr = true;
        Account _account, _account1;
        public string name { get => _name; set => Set(ref _name, value); }
        //Вспомогательная строка для переходного акаунта
        public User<Account> Acount { get => _UsAcount; set => Set(ref _UsAcount, value); }
        public User<Account> Acount1 { get => _Acount1; set => Set(ref _Acount1, value); }
        public float UserMoney { get => _UserMoney; set => Set(ref _UserMoney, value); }
        public uint UserBet { get => _UserBet; set => Set(ref _UserBet, value); }
        public uint UsLoanRare { get => _LoanRare; set => Set(ref _LoanRare, value); }
        public bool DepOr { get => _DepOr; set => Set(ref _DepOr, value); }
        public Account account { get => _account; set => Set(ref _account, value); }
        public Account account1 { get => _account1; set => Set(ref _account1, value); }
        ObservableCollection<User<Account>> _UserCollection =
                    new ObservableCollection<User<Account>>
                { new User<Account>("Женя"),
            new User<Account>("Миша"),
            new User<Account>("Костя") };
        /// <summary>
        /// Пользователи банка
        /// </summary>
        public ObservableCollection<User<Account>> UserCollection { get => _UserCollection; set => Set(ref _UserCollection, value); }
        ObservableCollection<Account> _UserAccount, _UserAccount1 = new ObservableCollection<Account>();
        /// <summary>
        /// Счета пользователя
        /// </summary>
        public ObservableCollection<Account> UserAccounts { get { return _UserAccount; } set => Set(ref _UserAccount, value); }
        /// <summary>
        /// Счета пользователя
        /// </summary>
        public ObservableCollection<Account> UserAccounts1 { get { return _UserAccount1; } set => Set(ref _UserAccount1, value); }
        #endregion
        #region Команды
        /// <summary>
        /// Добовляет нового пользователя
        /// </summary>
        public ICommand AddUserCommand { get; }
        private void OnAddUserCommandExecuted(object p)
        {
            UserCollection.Add(new User<Account>(name));
            name = "";
        }
        /// <summary>
        /// Удоляет выбраного пользователя
        /// </summary>
        public ICommand ClearUserCommand { get; }
        private void OnClearUserCommandExecuted(object p)
        {
            if (Acount != null)
            {
                UserCollection.Remove(Acount);
                Acount = null;
            }
        }
        /// <summary>
        /// Создает новый счет в выделеном акаунте
        /// </summary>
        public ICommand CreateAccountCommand { get; }
        private void OnCreateAccountCommandExecuted(object p)
        {
            if (Acount != null)
            {
                if (DepOr)
                {
                    if (UserMoney == 0 && UserBet == 0)
                        Acount.Numfers.Add(new Account(10, 100));
                    else
                        Acount.Numfers.Add(new Account(UserMoney, UserBet));
                }
                else
                {
                    if (UserMoney == 0 && UserBet == 0 && UsLoanRare == 0)
                        Acount.Numfers.Add(new CreditAccount(10, 100, 10));
                    else
                        Acount.Numfers.Add(new CreditAccount(UserMoney, UserBet, UsLoanRare));
                }
                UserMoney = 0; UserBet = 0; UsLoanRare = 0;
            }
        }
        /// <summary>
        /// Вычисление для счетов
        /// </summary>
        public ICommand CalculetionAccoundCommand { get; }
        private void OnCalculetionAccoundCommandExecuted(object p)
        {
            if (account != null && account1 != null)
            {
                Acount.Translation(account, Calculetion.Minus, UserMoney);
                Acount.Translation(account1, Calculetion.Plus, UserMoney);
                UserMoney = 0;
            }
        }
        /// <summary>
        /// Вычисление для счетов
        /// </summary>
        public ICommand CalculetionUserCommand { get; }
        private void OnCalculetionUserCommandExecuted(object p)
        {
            if (account != null)
            {
                Acount.Translation(account, Calculetion.Plus, UserMoney);
                UserMoney = 0;
            }
        }
        /// <summary>
        /// Требуется для связи ViewModel с xml
        /// </summary>
        public ICommand BindingAccountCommand { get; set; }
        private void OnBindingAccountCommandExecuted(object p)
        {
            if (Acount != null)
                UserAccounts = Acount.Numfers;
            if (Acount1 != null)
                UserAccounts1 = Acount1.Numfers;
        }
        public ICommand DeleteAccountCommand { get; set; }
        private void OnDeleteAccountCommandExecuted(object p)
        {
            if (Acount != null && account != null)
                Acount.Remove(account);
        }
        private bool CanCommandExecuted(object p) => true;
        #endregion
        #endregion
        public BankControll()
        {
            #region РеализацияКоманд
            AddUserCommand = new LambdaCommand(OnAddUserCommandExecuted, CanCommandExecuted);
            ClearUserCommand = new LambdaCommand(OnClearUserCommandExecuted, CanCommandExecuted);
            BindingAccountCommand = new LambdaCommand(OnBindingAccountCommandExecuted, CanCommandExecuted);
            CreateAccountCommand = new LambdaCommand(OnCreateAccountCommandExecuted, CanCommandExecuted);
            DeleteAccountCommand = new LambdaCommand(OnDeleteAccountCommandExecuted, CanCommandExecuted);
            CalculetionAccoundCommand = new LambdaCommand(OnCalculetionAccoundCommandExecuted, CanCommandExecuted);
            CalculetionUserCommand = new LambdaCommand(OnCalculetionUserCommandExecuted, CanCommandExecuted);
            #endregion
        }
    }
}