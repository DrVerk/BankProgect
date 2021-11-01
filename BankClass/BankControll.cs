using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BankProgect.BankClass
{
    class BankControll : ViewModel
    {
        #region Система
        private ObservableCollection<User<Account>> _UserCollection;
        /// <summary>
        /// Пользователи банка
        /// </summary>
        public ObservableCollection<User<Account>> UserCollection
        {
            get => _UserCollection;
            set => Set(ref _UserCollection, value);
        }
        BankControll()
        {
            _UserCollection = new ObservableCollection<User<Account>>();
        }
        public static BankControll BankCreate()
        {
            return new BankControll();
        }
        #endregion
    }
}
