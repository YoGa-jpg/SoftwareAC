using System.Collections.Generic;
using System.Windows;
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;

namespace AAS.View
{
    public partial class SendAnswerWindow : Window
    {
        private Report currentReport;
        ConfigInfo config = new ConfigInfo(true);
        public SendAnswerWindow(Report report)
        {
            InitializeComponent();

            currentReport = report;
        }

        private void SendAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            if(!(ThemeBox.Text == string.Empty | DescriptionBox.Text == string.Empty))
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/SendAnswer", "POST",
                    $"reportNumber={currentReport.ReportId}&theme={ThemeBox.Text}&description={DescriptionBox.Text}");

                MessageBox.Show("Ответ успешно отправлен", "Ответ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные", "Ответ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
