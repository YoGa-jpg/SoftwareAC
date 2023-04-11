using System.Windows;
using AAS.Models;

namespace AAS.View
{
    public partial class LogInWindow : Window
    {
        ConfigInfo config = new ConfigInfo(true);
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void LogIn_OnClick(object sender, RoutedEventArgs e)
        {
            //if (RequestHelper.SendRequest($@"{config.uri}/Home/LogIn", "POST",
            //    $"pass={PasswordBox.Password}").ToString() == "true")
            if(true)
            {
                new AdminMainWindow().Show();
                Close();;
            }
            else
            {
                MessageBox.Show("Введен неверный пароль.", "Вход", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
