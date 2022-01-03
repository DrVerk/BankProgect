using System;
using System.Windows;
namespace BankLibrary
{
    public class UserExeption : Exception
    {
        public UserExeption(string s) : base(s)
        {
            MessageBox.Show(s);
        }
    }
}
