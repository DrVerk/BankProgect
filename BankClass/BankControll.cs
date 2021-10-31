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
    class BankControll
    {
        #region Система
        public ObservableCollection<User<Account>> UserCollection;
        BankControll()
        {
            UserCollection = new ObservableCollection<User<Account>>();
        }
        public static BankControll BankCreate()
        {
            return new BankControll();
        }
        #endregion
    }
}
