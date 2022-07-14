using System;
using System.Windows;
namespace BankLibrary
{
    public class UserExeption : Exception
    {
        public UserExeption(string s, bool mes = true) : base(s)
        {
            if (mes)
                MessageBox.Show(s, "Ошиба", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show(s, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
