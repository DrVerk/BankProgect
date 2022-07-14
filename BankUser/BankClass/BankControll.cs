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
        ObservableCollection<Account> _UserAccount, _UserAccount1 = new ObservableCollection<Account>();
        ObservableCollection<User<Account>> _UserCollection =
                    new ObservableCollection<User<Account>>
                { new User<Account>("Женя"),
            new User<Account>("Миша"),
            new User<Account>("Костя") };
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

        /// <summary>
        /// Пользователи банка
        /// </summary>
        public ObservableCollection<User<Account>> UserCollection { get => _UserCollection; set => Set(ref _UserCollection, value); }

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
            try
            {
                if (name != "")
                {
                    UserCollection.Add(new User<Account>(name));
                    name = "";
                }
                else
                    throw new UserExeption("Пользовотель без имени не может быть создан!");
            }
            catch (Exception)
            {

                UserIventer.Add("Пользовотель не был создан");
            }

        }
        /// <summary>
        /// Удоляет выбраного пользователя
        /// </summary>
        public ICommand ClearUserCommand { get; }
        private void OnClearUserCommandExecuted(object p)
        {
            try
            {
                if (UserAcount != null)
                {
                    UserAcount.RemuveAccount();
                    UserCollection.Remove(UserAcount);
                    UserAcount = null;
                }
                else
                    throw new UserExeption("Пользовотель для удоления не выбран");
            }
            catch (Exception)
            {
                UserIventer.Add("Пользовотель не был удален");
            }
        }
        /// <summary>
        /// Создает новый счет в выделеном акаунте
        /// </summary>
        public ICommand CreateAccountCommand
        {
            get;
        }

        private void OnCreateAccountCommandExecuted(object p)
        {
            try
            {
                if (UserAcount != null)
                {
                    if (DepOr)
                    {
                        if (UserMoney == 0 && UserBet == 0)
                        {
                            UserAcount.Add(new Account());
                            throw new UserExeption("Создан счет с изначальными пораметрами", false);
                        }
                        else if (UserMoney < 0)
                            throw new UserExeption("Создание счета с отрицательным болансом не возможно!");
                        else
                            UserAcount.Add(new Account(UserMoney, UserBet));
                    }
                    else
                    {
                        if (UserMoney == 0 && UserBet == 0 && UserLoanRare == 0)
                        {
                            UserAcount.Add(new CreditAccount());
                            throw new UserExeption("Создан кредит с изначальными пораметрами");
                        }
                        else if (UserMoney < 0)
                            throw new UserExeption("Создание Кредита с отрицательным болансом не возможно!");
                        else
                            UserAcount.Add(new CreditAccount(UserMoney, UserBet, UserLoanRare));
                    }
                }
            }
            catch (Exception)
            {
                UserIventer.Add("Счет или кредит не был создан или создан с начальными параметрами");
            }
            UserMoney = 0; UserBet = 0; UserLoanRare = 0;
        }
        /// <summary>
        /// Вычисление для счетов
        /// </summary>
        public ICommand CalculetionAccoundCommand { get; }
        private void OnCalculetionAccoundCommandExecuted(object p)
        {
            try
            {
                if (Account.IsIterect(UserMoney))
                {
                    if (Account != null && Account1 != null)
                    {
                        UserAcount.Translation(Account, Calculetion.Minus, UserMoney);
                        UserAcount.Translation(Account1, Calculetion.Plus, UserMoney);
                        UserMoney = 0;
                    }
                }
                else throw new UserExeption("Деньги не могут быть переведены", false);
            }
            catch (Exception)
            {
                UserIventer.Add("Перевод не совершен");
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