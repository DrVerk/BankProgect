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

        private void AccountChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            bank.account = (Account)AccountsView.SelectedItem;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (bank.DepOr)
            {
                bank.DepOr = false;
                pER.Visibility = 0;
                dEP.Visibility = 0;
            }
            else
            {
                bank.DepOr = true;
                pER.Visibility = Visibility.Hidden;
                dEP.Visibility = Visibility.Hidden;
            }
        }

        private void ComboBox_UserChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UsCombo.SelectedItem != null)
                bank.Acount = (User<Account>)UsCombo.SelectedItem;
        }

        private void AcCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (AcCombo.SelectedItem != null)
                bank.account = (Account)AcCombo.SelectedItem;
        }
    }
}
