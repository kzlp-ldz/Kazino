using System;
using System.Collections.Generic;
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

namespace Kazino
{
    /// <summary>
    /// Логика взаимодействия для AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        public AuthoPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnLogIn_click(object sender, RoutedEventArgs e)
        {
            var z = db_connection.kazino.User.Where(a => a.Login == login.Text && a.Password == password.Text).FirstOrDefault();
            if (z != null)
            {
                NavigationService.Navigate(new KazinoPage(z));
            }
            else
            {
                MessageBox.Show("пароль и логин введены неверно", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSign_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistPage());
        }
    }
}
