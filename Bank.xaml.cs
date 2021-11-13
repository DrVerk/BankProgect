using System.Windows;
using BankProgect.BankClass;

namespace BankProgect
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankControll bank = new BankControll();
        public MainWindow()
        {
           
            InitializeComponent();
            DataContext = bank;
        }

        private void Taib_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
           bank.Acount = (User<Account>)Taib.SelectedItem;           
        }
    }
}
