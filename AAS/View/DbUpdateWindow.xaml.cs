using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DbUpdateWindow.xaml
    /// </summary>
    public partial class DbUpdateWindow : Window
    {
        private Software currentSoftware;
        ConfigInfo config = new ConfigInfo(true);

        public DbUpdateWindow(Software software)
        {
            InitializeComponent();

            currentSoftware = software;

            var Computers =
                JsonConvert.DeserializeObject<List<Computer>>(
                    RequestHelper.SendRequest($@"{config.uri}/Home/GetComputers", "POST", "").ToString());

            var Programs =
                JsonConvert.DeserializeObject<List<Program>>(
                    RequestHelper.SendRequest($@"{config.uri}/Home/GetPrograms", "POST", "").ToString());

            ComputerBox.ItemsSource = Computers;
            ComputerBox.SelectedItem = Computers.Single(q => q.ComputerId == software.ComputerId);

            ProgramBox.ItemsSource = Programs;
            ProgramBox.SelectedItem = Programs.Single(q => q.ProgramId == software.ProgramId);

            if (software.LicenseStart != null) LicenseStartBox.Text = software.LicenseStart.Value.ToShortDateString();
            if (software.LicenseEnd != null) LicenseEndBox.Text = software.LicenseEnd.Value.ToShortDateString();
            VersionBox.Text = software.Version;
        }

        private void UpdateSoftware_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime date;
            if(!(ComputerBox.SelectedItem == null | ProgramBox.SelectedItem == null | !DateTime.TryParseExact(LicenseStartBox.Text, "dd.MM.yyyy", null, DateTimeStyles.None, out date) | !DateTime.TryParseExact(LicenseEndBox.Text, "dd.MM.yyyy", null, DateTimeStyles.None, out date) | VersionBox.Text == string.Empty))
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/UpdateSoftware", "POST",
                    $"softId={this.currentSoftware.SoftwareId}&compId={(ComputerBox.SelectedItem as Computer).ComputerId}&progId={(ProgramBox.SelectedItem as Program).ProgramId}&licStart={Convert.ToDateTime(LicenseStartBox.Text)}&licEnd={Convert.ToDateTime(LicenseEndBox.Text)}&version={VersionBox.Text}");

                MessageBox.Show("ПО изменено успешно успешно", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные", "Жалоба", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
