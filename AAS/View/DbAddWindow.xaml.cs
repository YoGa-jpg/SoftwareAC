using System;
using System.Collections.Generic;
using System.Globalization;
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
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;

namespace AAS.View
{
    /// <summary>
    /// Interaction logic for DbAddWindow.xaml
    /// </summary>
    public partial class DbAddWindow : Window
    {
        ConfigInfo config = new ConfigInfo(true);
        public DbAddWindow()
        {
            InitializeComponent();

            var Computers =
                JsonConvert.DeserializeObject<List<Computer>>(
                    RequestHelper.SendRequest($@"{config.uri}/Home/GetComputers", "POST", "").ToString());

            var Programs =
                JsonConvert.DeserializeObject<List<Program>>(
                    RequestHelper.SendRequest($@"{config.uri}/Home/GetPrograms", "POST", "").ToString());

            ComputerBox.ItemsSource = Computers;
            ProgramBox.ItemsSource = Programs;
        }

        private void AddSoftware_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime date;
            if(!(ComputerBox.SelectedItem == null | ProgramBox.SelectedItem == null | !DateTime.TryParseExact(LicenseStartBox.Text, "dd.MM.yyyy", null, DateTimeStyles.None, out date) | !DateTime.TryParseExact(LicenseEndBox.Text, "dd.MM.yyyy", null, DateTimeStyles.None, out date) | VersionBox.Text == string.Empty))
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/AddSoftware", "POST",
                    $"compId={(ComputerBox.SelectedItem as Computer).ComputerId}&progId={(ProgramBox.SelectedItem as Program).ProgramId}&licStart={Convert.ToDateTime(LicenseStartBox.Text)}&licEnd={Convert.ToDateTime(LicenseEndBox.Text)}&version={VersionBox.Text}");

                MessageBox.Show("ПО добавлено успешно", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
