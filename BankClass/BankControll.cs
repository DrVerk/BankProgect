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
        #region name
        //Вспомогательная строка для названия акаунта
        string _name = "";
        public string name { get => _name; set => Set(ref _name, value); }
        #endregion
        #region Acount
        //Вспомогательная строка для переходного акаунта
        User<Account> _Acount;
        public User<Account> Acount { get => _Acount; set => Set(ref _Acount, value); }
        #endregion
        #region kech
        float _kech;
        public float kech { get => _kech; set => Set(ref _kech, value); }
        #endregion
        #region bet
        uint _bet;
        public uint bet { get => _bet; set => Set(ref _bet, value); }
        #endregion
        #region deposite
        uint _deposite;
        public uint deposite { get => _deposite; set => Set(ref _deposite, value); }
        #endregion
        #region DepOr
        bool _DepOr = true;
        public bool DepOr { get => _DepOr; set => Set(ref _DepOr, value); }
        #endregion
        #region Счет для работы
        Account _account;
        public Account account { get => _account; set => Set(ref _account, value); }
        #endregion
        #endregion
        #region Лист полильзовотелей
        private ObservableCollection<User<Account>> _UserCollection =
            new ObservableCollection<User<Account>>
        { new User<Account>("Женя"),
            new User<Account>("Миша"),
            new User<Account>("Костя") };
        /// <summary>
        /// Пользователи банка
        /// </summary>
        public ObservableCollection<User<Account>> UserCollection
        {
            get => _UserCollection;
            set => Set(ref _UserCollection, value);
        }
        #endregion
        #region Счета
        private ObservableCollection<Account> _UserAccount = new ObservableCollection<Account>();
        /// <summary>
        /// Счета пользователя
        /// </summary>
        public ObservableCollection<Account> UserAccounts
        {
            get => _UserAccount;
            set => Set(ref _UserAccount, value);
        }
        #endregion
        #region Команды
        #region AddUserCommand
        /// <summary>
        /// Добовляет нового пользователя
        /// </summary>
        public ICommand AddUserCommand { get; }
        private void OnAddUserCommandExecuted(object p)
        {
            UserCollection.Add(new User<Account>(name));
            name = "";
        }
        private bool CanAddUserCommandExecuted(object p) => true;
        #endregion
        #region ClearUserCommand
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
        private bool CanClearUserCommandExecuted(object p) => true;
        #endregion
        #region CreateAccountCommand
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
                    if (kech == 0 && bet == 0)
                        Acount.Numfers.Add(new Account(10, 100));
                    else
                        Acount.Numfers.Add(new Account(kech, bet));
                }
                else
                {
                    if (kech == 0 && bet == 0 && deposite == 0)
                        Acount.Numfers.Add(new DepositAccount(10, 100, 10));
                    else
                        Acount.Numfers.Add(new DepositAccount(kech, bet, deposite));
                }
            }
        }
        private bool CanCreateAccountCommandExecuted(object p) => true;
        #endregion
        #region BindingAccountCommand
        /// <summary>
        /// Требуется для связи ViewModel с xml
        /// </summary>
        public ICommand BindingAccountCommand { get; set; }
        private void OnBindingAccountCommandExecuted(object p)
        {
            if (Acount != null)
            {
                UserAccounts = Acount.Numfers;
            }
        }
        private bool CanBindingAccountCommandExecuted(object p) => true;
        #endregion
        #region DeleteAccountCommand
        public ICommand DeleteAccountCommand { get; set; }
        private void OnDeleteAccountCommandExecuted(object p)
        {
            if (Acount != null && account != null)
            {
                Acount.Remove(account);
            }
        }
        private bool CanDeleteAccountCommandExecuted(object p) => true;
        #endregion
        #endregion
        #endregion
        public BankControll()
        {
            #region РеализацияКоманд
            AddUserCommand = new LambdaCommand(OnAddUserCommandExecuted, CanAddUserCommandExecuted);
            ClearUserCommand = new LambdaCommand(OnClearUserCommandExecuted, CanClearUserCommandExecuted);
            BindingAccountCommand = new LambdaCommand(OnBindingAccountCommandExecuted, CanBindingAccountCommandExecuted);
            CreateAccountCommand = new LambdaCommand(OnCreateAccountCommandExecuted, CanCreateAccountCommandExecuted);
            DeleteAccountCommand = new LambdaCommand(OnDeleteAccountCommandExecuted, CanDeleteAccountCommandExecuted);
            #endregion
        }
    }
}
