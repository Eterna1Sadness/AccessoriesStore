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
    public partial class Registration : Window
    {
        //AccessoriesStoreDB db = new AccessoriesStoreDB();
        AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string FullName = textBox_FullName.Text;
            string SpecialistLogin = textBox_Login.Text.Trim();
            string SpecialistPassword = passwordBox_Password.Password.Trim();
            string Email = textBox_Email.Text.ToLower().Trim();
            string rePassword = passwordBox_RePassword.Password.Trim();

            if (FullName.Length < 4 || !FullName.Contains(" "))
            {
                textBox_FullName.ToolTip = "Поле введено не корректно!";
                textBox_FullName.Background = Brushes.DarkGreen;
            }
            else if (SpecialistLogin.Length < 4)
            {
                Clear();
                textBox_Login.ToolTip = "Поле введено не корректно!";
                textBox_Login.Background = Brushes.DarkGreen;
            }
            else if (SpecialistPassword.Length < 5)
            {
                Clear();
                passwordBox_Password.ToolTip = "Поле введено не корректно!";
                passwordBox_Password.Background = Brushes.DarkGreen;
            }
            else if (rePassword != SpecialistPassword)
            {
                Clear();
                passwordBox_RePassword.ToolTip = "Поле введено не корректно!";
                passwordBox_RePassword.Background = Brushes.DarkGreen;
            }
            else if (Email.Length < 5 || !Email.Contains("@") || !Email.Contains("."))
            {
                Clear();
                textBox_Email.ToolTip = "Поле введено не корректно!";
                textBox_Email.Background = Brushes.DarkGreen;
            }
            else
            {
                textBox_Email.ToolTip = null;
                textBox_Email.Background = Brushes.Transparent;

                Specialist spec = new Specialist()
                {
                    FullName = textBox_FullName.Text,
                    SpecialistLogin = textBox_Login.Text.Trim(),
                    SpecialistPassword = passwordBox_Password.Password.Trim(),
                    Email = textBox_Email.Text.ToLower().Trim(),
                };

                db.Specialists.Add(spec);
                db.SaveChanges();
                this.Close();
                Authorization auth = new Authorization();
                auth.Show();
            }
        }

        private void Clear()
        {
            string FullName = textBox_FullName.Text;
            string SpecialistLogin = textBox_Login.Text.Trim();
            string SpecialistPassword = passwordBox_Password.Password.Trim();
            string rePassword = passwordBox_RePassword.Password.Trim();
            string Email = textBox_Email.Text.ToLower().Trim();

            textBox_FullName.ToolTip = null;
            textBox_FullName.Background = Brushes.Transparent;
            textBox_Login.ToolTip = null;
            textBox_Login.Background = Brushes.Transparent;
            passwordBox_Password.ToolTip = null;
            passwordBox_Password.Background = Brushes.Transparent;
            passwordBox_RePassword.ToolTip = null;
            passwordBox_RePassword.Background = Brushes.Transparent;
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization();
            auth.Show();
            Hide();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
