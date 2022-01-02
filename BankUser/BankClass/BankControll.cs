using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using InfrasructureLibrary;
using System;
using BankLibrary;

namespace BankUserLibrary
{
    public class BankControll : ViewModel
    {
        DispatcherTimer _timer;
        #region Система
        #region Строки
        //Вспомогательная строка для акаунта
        string _name = "";
        User<Account> _userAcount, _userAcount1;
        float _userMoney;
        uint _userBet, _userLoanRare;
        bool _DepOr = true;
        Account _account, _account1;
        ObservableCollection<string> _UserIventer = new ObservableCollection<string>();
        public string name { get => _name; set => Set(ref _name, value); }
        //Вспомогательная строка для переходного акаунта
        public User<Account> UserAcount { get => _userAcount; set => Set(ref _userAcount, value); }
        public User<Account> UserAcount1 { get => _userAcount1; set => Set(ref _userAcount1, value); }
        public float UserMoney { get => _userMoney; set => Set(ref _userMoney, value); }
        public uint UserBet { get => _userBet; set => Set(ref _userBet, value); }
        public uint UserLoanRare { get => _userLoanRare; set => Set(ref _userLoanRare, value); }
        public bool DepOr { get => _DepOr; set => Set(ref _DepOr, value); }
        public Account Account { get => _account; set => Set(ref _account, value); }
        public Account Account1 { get => _account1; set => Set(ref _account1, value); }
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
        public ObservableCollection<Account> UserAccounts { get => _UserAccount; set => Set(ref _UserAccount, value); }
        /// <summary>
        /// Счета пользователя
        /// </summary>
        public ObservableCollection<Account> UserAccounts1 { get => _UserAccount1; set => Set(ref _UserAccount1, value); }
        public ObservableCollection<string> UserIventer { get => _UserIventer; set => Set(ref _UserIventer, value); }
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
            if (UserAcount != null)
            {
                UserAcount.RemuveAccount();
                UserCollection.Remove(UserAcount);
                UserAcount = null;
            }
        }
        /// <summary>
        /// Создает новый счет в выделеном акаунте
        /// </summary>
        public ICommand CreateAccountCommand { get; }
        private void OnCreateAccountCommandExecuted(object p)
        {
            if (UserAcount != null)
            {
                if (DepOr)
                {
                    if (UserMoney == 0 && UserBet == 0)
                        UserAcount.Add(new Account(10, 100));
                    else
                        UserAcount.Add(new Account(UserMoney, UserBet));
                }
                else
                {
                    if (UserMoney == 0 && UserBet == 0 && UserLoanRare == 0)
                        UserAcount.Add(new CreditAccount(10, 100, 10));
                    else
                        UserAcount.Add(new CreditAccount(UserMoney, UserBet, UserLoanRare));
                }
                UserMoney = 0; UserBet = 0; UserLoanRare = 0;
            }
        }
        /// <summary>
        /// Вычисление для счетов
        /// </summary>
        public ICommand CalculetionAccoundCommand { get; }
        private void OnCalculetionAccoundCommandExecuted(object p)
        {
            if (Account != null && Account1 != null)
            {
                UserAcount.Translation(Account, Calculetion.Minus, UserMoney);
                UserAcount.Translation(Account1, Calculetion.Plus, UserMoney);
                UserMoney = 0;
            }
        }
        /// <summary>
        /// Вычисление для счетов
        /// </summary>
        public ICommand CalculetionUserCommand { get; }
        private void OnCalculetionUserCommandExecuted(object p)
        {
            if (Account != null)
            {
                UserAcount.Translation(Account, Calculetion.Plus, UserMoney);
                UserMoney = 0;
            }
        }
        /// <summary>
        /// Обновление списков
        /// </summary>
        private void _BindingAccount(object p, EventArgs e)
        {
            if (UserAcount != null)
                UserAccounts = UserAcount.Numfers;
            if (UserAcount1 != null)
                UserAccounts1 = UserAcount1.Numfers;
        }
        public ICommand DeleteAccountCommand { get; set; }
        private void OnDeleteAccountCommandExecuted(object p)
        {
            if (UserAcount != null && Account != null)
                UserAcount.Remove(Account);
        }
        private bool CanCommandExecuted(object p) => true;
        #endregion
        #endregion
        public BankControll()
        {
            User<Account>.UserEvents += e => UserIventer.Add(e);
            #region Обновление списков
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _timer.Tick += _BindingAccount;
            _timer.Start();
            #endregion

            #region РеализацияКоманд
            AddUserCommand = new LambdaCommand(OnAddUserCommandExecuted, CanCommandExecuted);
            ClearUserCommand = new LambdaCommand(OnClearUserCommandExecuted, CanCommandExecuted);
            //BindingAccountCommand = new LambdaCommand(OnBindingAccountCommandExecuted, CanCommandExecuted);
            CreateAccountCommand = new LambdaCommand(OnCreateAccountCommandExecuted, CanCommandExecuted);
            DeleteAccountCommand = new LambdaCommand(OnDeleteAccountCommandExecuted, CanCommandExecuted);
            CalculetionAccoundCommand = new LambdaCommand(OnCalculetionAccoundCommandExecuted, CanCommandExecuted);
            CalculetionUserCommand = new LambdaCommand(OnCalculetionUserCommandExecuted, CanCommandExecuted);
            #endregion
        }
    }
}