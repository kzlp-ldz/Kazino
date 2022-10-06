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
    /// Логика взаимодействия для KazinoPage.xaml
    /// </summary>
    public partial class KazinoPage : Page
    {
        Random random = new Random();

        User users = new User();
        public static ObservableCollection<User> user { get; set; }

        
        public KazinoPage(User userz)
        {
            InitializeComponent();

            users = userz;

            username.Content = users.UserName;
            count.Content = users.Count;
            this.DataContext = this;
        }

        private void btnStart_click(object sender, RoutedEventArgs e)
        {
            
            var a = 0;
            var b = 0;
            var c = 0;

            for (int i = 0; i <= 2; i++)
            {
                int value = random.Next(1, 4);
                if (i == 0)
                {
                    if (value == 1)
                    {
                        first.Source = new BitmapImage(new Uri("C:/Users/chudo/source/repos/Kazino/Kazino/Resources/1.jpg"));
                        a++;
                    }
                    else if (value == 2)
                    {
                        first.Source = new BitmapImage(new Uri("C:/Users/chudo/source/repos/Kazino/Kazino/Resources/2.jpg"));
                        b++;
                    }
                    else if (value == 3)
                    {
                        first.Source = new BitmapImage(new Uri("C:/Users/chudo/source/repos/Kazino/Kazino/Resources/3.jpg"));
                        c++;
                    }
                }
                else if (i == 1)
                {
                    if (value == 1)
                    {
                        second.Source = new BitmapImage(new Uri("C:/Users/chudo/source/repos/Kazino/Kazino/Resources/1.jpg"));
                        a++;
                    }
                    else if (value == 2)
                    {
                        second.Source = new BitmapImage(new Uri("C:/Users/chudo/source/repos/Kazino/Kazino/Resources/2.jpg"));
                        b++;
                    }
                    else if (value == 3)
                    {
                        second.Source = new BitmapImage(new Uri("C:/Users/chudo/source/repos/Kazino/Kazino/Resources/3.jpg"));
                        c++;
                    }
                }
                else if (i == 2)
                {
                    if (value == 1)
                    {
                        third.Source = new BitmapImage(new Uri("C:/Users/chudo/source/repos/Kazino/Kazino/Resources/1.jpg"));
                        a++;
                    }
                    else if (value == 2)
                    {
                        third.Source = new BitmapImage(new Uri("C:/Users/chudo/source/repos/Kazino/Kazino/Resources/2.jpg"));
                        b++;
                    }
                    else if (value == 3)
                    {
                        third.Source = new BitmapImage(new Uri("C:/Users/chudo/source/repos/Kazino/Kazino/Resources/3.jpg"));
                        c++;
                    }
                }
            }

            if (a == 3 || b == 3 || c == 3)
            {
                users.Count += 1000;
                MessageBox.Show("+1000");
            }
            else if (a == 2 || b == 2 || c == 2)
            {
                users.Count += 100;
                MessageBox.Show("+100");
            }
            else
            {
                users.Count -= 10;
                MessageBox.Show("-10");
            }

            db_connection.kazino.SaveChanges();
            count.Content = users.Count;
        }
    }
}
