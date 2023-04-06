using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;

namespace AAS.View
{
    public partial class GetReportsWindow : Window
    {
        List<Report> response = new List<Report>();
        ConfigInfo config = new ConfigInfo(true);

        public GetReportsWindow()
        {
            InitializeComponent();

            var software =
                RequestHelper.SendRequest($@"{config.uri}/Home/GetReports", "POST", "");

            response = JsonConvert.DeserializeObject<List<Report>>(software.ToString());

            StatusBox.ItemsSource = JsonConvert.DeserializeObject<List<Status>>(RequestHelper.SendRequest($@"{config.uri}/Home/GetStatuses", "POST", "").ToString());

            ReportsGrid.ItemsSource = response;
        }

        private void SendAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            if(ReportsGrid.SelectedItem != null)
            {
                new SendAnswerWindow(ReportsGrid.SelectedItem as Report).Show();
            }
            else
            {
                MessageBox.Show("Выберите жалобу.", "Жалоба", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Complete_OnClick(object sender, RoutedEventArgs e)
        {
            if(ReportsGrid.SelectedItem != null)
            {
                var currentReport = ReportsGrid.SelectedItem as Report;
                RequestHelper.SendRequest($@"{config.uri}/Home/ChangeReportStatus", "POST",
                    $"reportId={currentReport.ReportId}&statusId=1");
                response = JsonConvert.DeserializeObject<List<Report>>(RequestHelper
                    .SendRequest($@"{config.uri}/Home/GetReports", "POST", "").ToString());
                ReportsGrid.ItemsSource = null;
                ReportsGrid.ItemsSource = response;
            }
            else
            {
                MessageBox.Show("Выберите жалобу.", "Жалоба", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void NotComplete_OnClick(object sender, RoutedEventArgs e)
        {
            if(ReportsGrid.SelectedItem != null)
            {
                var currentReport = ReportsGrid.SelectedItem as Report;
                RequestHelper.SendRequest($@"{config.uri}/Home/ChangeReportStatus", "POST",
                    $"reportId={currentReport.ReportId}&statusId=2");
                response = JsonConvert.DeserializeObject<List<Report>>(RequestHelper
                    .SendRequest($@"{config.uri}/Home/GetReports", "POST", "").ToString());
                ReportsGrid.ItemsSource = null;
                ReportsGrid.ItemsSource = response;
            }
            else
            {
                MessageBox.Show("Выберите жалобу.", "Жалоба", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Declined_OnClick(object sender, RoutedEventArgs e)
        {
            if(ReportsGrid.SelectedItem != null)
            {
                var currentReport = ReportsGrid.SelectedItem as Report;
                RequestHelper.SendRequest($@"{config.uri}/Home/ChangeReportStatus", "POST",
                    $"reportId={currentReport.ReportId}&statusId=3");
                response = JsonConvert.DeserializeObject<List<Report>>(RequestHelper
                    .SendRequest($@"{config.uri}/Home/GetReports", "POST", "").ToString());
                ReportsGrid.ItemsSource = null;
                ReportsGrid.ItemsSource = response;
            }
            else
            {
                MessageBox.Show("Выберите жалобу.", "Жалоба", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            StatusBox.SelectedItem = null;
            response = JsonConvert.DeserializeObject<List<Report>>(RequestHelper.SendRequest($@"{config.uri}/Home/GetReports", "POST", "").ToString());
            ReportsGrid.ItemsSource = null;
            ReportsGrid.ItemsSource = response;
        }

        private void StatusBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(StatusBox.SelectedItem != null)
            {
                ReportsGrid.ItemsSource = null;
                ReportsGrid.ItemsSource =
                    response.Where(q => q.StatusId == (StatusBox.SelectedItem as Status).StatusId);
            }
        }
    }
}
