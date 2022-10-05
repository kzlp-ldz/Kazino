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
            this.DataContext = this;
        }

        private void btnStart_click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 2; i++)
            {
                int value = random.Next(1, 4);

                if (value == 1)
                {
                    first.Source = new BitmapImage( new Uri("C:/Users/201909/source/repos/Kazino/Kazino/Resources/1.jpg"));
                }
                else if (value == 2)
                {
                    second.Source = new BitmapImage(new Uri("C:/Users/201909/source/repos/Kazino/Kazino/Resources/2.jpg"));
                }
                else if (value == 3)
                {
                    third.Source = new BitmapImage(new Uri("C:/Users/201909/source/repos/Kazino/Kazino/Resources/3.jpg"));
                }
            }

            if (first == second && second == third)
            {
                users.Count += 1000;
                MessageBox.Show("+1000");
            }
            else if (first == second || second == third || first == third)
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
            first = null;
            second = null; 
            third = null;   
        }
    }
}
