using System.Collections.Generic;
using System.Windows;
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;

namespace AAS
{
    public partial class SendReportWindow : Window
    {
        ConfigInfo config = new ConfigInfo(true);
        public SendReportWindow()
        {
            InitializeComponent();

            ProgramBox.ItemsSource = JsonConvert.DeserializeObject<List<Program>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetProgramsOnComputer", "POST", $"computer={config.computer}").ToString());
        }

        private void SendReport_OnClick(object sender, RoutedEventArgs e)
        {
            if(!(ThemeBox.Text == string.Empty | DescriptionBox.Text == string.Empty | ProgramBox.SelectedItem == null))
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/SendReport", "POST",
                    $"computerNumber={config.computer}&theme={ThemeBox.Text}&description={DescriptionBox.Text}&program={(ProgramBox.SelectedItem as Program).ProgramId}");

                MessageBox.Show("Жалоба отправлена", "Жалоба", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Жалоба не отправлена. Проверьте введенные данные.", "Жалоба", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
