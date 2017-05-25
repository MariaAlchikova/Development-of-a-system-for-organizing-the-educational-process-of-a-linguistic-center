using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Linguistic_Center
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            LoginBox.Focus();
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            var hash = CalculateHash("3107");

            if (LoginBox.Text == "linguistic_center" && CalculateHash(PasswordBox.Password) == hash)
                NavigationService.Navigate(Pages.MainPage);
            else
                if (LoginBox.Text != "linguistic_center")
                MessageBox.Show("Некорректный логин");
            else
          if (CalculateHash(PasswordBox.Password) != hash)
                MessageBox.Show("Некорректный пароль");
            Logger.Log("Выполнен вход в систему");
        }
    }
}