using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BankProgect.BankClass;


namespace BankProgect
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankControll users { get; set; }
        ObservableCollection<User<Account>> user { get; set; }
        ObservableCollection<Account> accaunts { get; set; }
        public MainWindow()
        {
            users = BankControll.BankCreate();
            InitializeComponent();
            accaunts = new ObservableCollection<Account>();
            users.UserCollection.Add(new User<Account>("Витя"));
            user = users.UserCollection;
            DataContext = user;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            accaunts = (ObservableCollection<Account>)Us.SelectedItem;
        }
    }
}
