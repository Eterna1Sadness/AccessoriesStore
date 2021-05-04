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
using System.Windows.Shapes;

namespace AccessoriesStore
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        //AccessoriesStoreDB db = new AccessoriesStoreDB();
        AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBox_Login.Text.Trim();
            string password = passwordBox_Password.Password.Trim();

            if (login.Length < 4)
            {
                textBox_Login.ToolTip = "Поле введено не корректно!";
                textBox_Login.Background = Brushes.DarkGreen;
            }
            else if (password.Length < 3)
            {
                passwordBox_Password.ToolTip = "Поле введено не корректно!";
                passwordBox_Password.Background = Brushes.DarkGreen;
            }
            else
            {
                textBox_Login.ToolTip = "";
                textBox_Login.Background = Brushes.Transparent;
                passwordBox_Password.ToolTip = "";
                passwordBox_Password.Background = Brushes.Transparent;

                MenuWindow menu = new MenuWindow();
                menu.Show();
                this.Close();
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            Registration auth = new Registration();
            auth.Show();
            Hide();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
