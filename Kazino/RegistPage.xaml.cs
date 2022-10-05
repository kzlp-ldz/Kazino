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
using System.Collections.ObjectModel;

namespace Kazino
{
    /// <summary>
    /// Логика взаимодействия для RegistPage.xaml
    /// </summary>
    public partial class RegistPage : Page
    {
        User users = new User();
        public static ObservableCollection<User> user { get; set; }
        public RegistPage()
        {
            InitializeComponent();
        }
        private void btnLogIn_click(object sender, RoutedEventArgs e)
        {
            if (login.Text != "" && password.Text != "")
            {
                user = new ObservableCollection<User>(db_connection.kazino.User.ToList());
                var z = user.Where(a => a.Login == login.Text).FirstOrDefault();
                if (z == null)
                {
                    users.Login = login.Text;
                    users.Password = password.Text;
                    users.UserName = username.Text;
                    users.Count = 0;
                    db_connection.kazino.User.Add(users);
                    db_connection.kazino.SaveChanges();
                    NavigationService.Navigate(new AuthoPage());
                }
                else
                    MessageBox.Show("Такой логин уже занят, введите другой");
            }
            else
                MessageBox.Show("Заполните все поля");
        }

        private void btnSign_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthoPage());
        }
    }
}
