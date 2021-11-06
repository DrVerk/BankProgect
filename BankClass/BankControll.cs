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
        string _name="";
        public string name { get => _name; set => Set(ref _name, value); }
        static User<Account> _Acount;
        public static User<Account> Acount { get => _Acount; set => _Acount=value; }
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
        public ICommand AddUserCommand { get; }
        private void OnAddUserCommandExecuted(object p)
        {
            UserCollection.Add(new User<Account>(name));
            name = "";
        }
        private bool CanAddUserCommandExecuted(object p) => true;
        #endregion
        #region ClearUserCommand
        public ICommand ClearUserCommand { get; }
        private void OnClearUserCommandExecuted(object p)
        {
            UserCollection.Remove(Acount);
            Acount = null;
        }
        private bool CanClearUserCommandExecuted(object p) => true;
        #endregion
        #region 

        #endregion
        #endregion

        #endregion
        public BankControll()
        {
            #region РеализацияКоманд
            AddUserCommand = new LambdaCommand(OnAddUserCommandExecuted,CanAddUserCommandExecuted);
            ClearUserCommand = new LambdaCommand(OnClearUserCommandExecuted, CanClearUserCommandExecuted);
            
            #endregion
        }
    }
}
