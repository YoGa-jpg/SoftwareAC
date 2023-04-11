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
        #region Reports

        private List<Report> reports = new List<Report>()
        {
            new Report()
            {
                ReportId = 1,
                ComputerId = 3,
                ProgramId = 3,
                ReportDate = DateTime.Parse("09.04.2023"),
                ReportTheme = "Не работает VS",
                Status = new Status()
                {
                    Name = "Выполнено",
                    StatusId = 1
                }
            },
            new Report()
            {
                ReportId = 2,
                ComputerId = 3,
                ProgramId = 3,
                ReportDate = DateTime.Parse("09.04.2023"),
                ReportTheme = "Не работает VS",
                Status = new Status()
                {
                    Name = "Не рассмотрено",
                    StatusId = 3
                }
            },
            new Report()
            {
                ReportId = 3,
                ComputerId = 3,
                ProgramId = 3,
                ReportDate = DateTime.Parse("09.04.2023"),
                ReportTheme = "Не работает VS",
                Status = new Status()
                {
                    Name = "Не рассмотрено",
                    StatusId = 3
                }
            }
        };

        #endregion

        #region Statuses

        private List<Status> statuses = new List<Status>()
        {
            new Status()
            {
                Name = "Выполнено",
                StatusId = 1
            },
            new Status()
            {
                Name = "В процессе",
                StatusId = 2
            },
            new Status()
            {
                Name = "Не рассмотрено",
                StatusId = 3
            }
        };

            #endregion
        List<Report> response = new List<Report>();
        ConfigInfo config = new ConfigInfo(true);

        public GetReportsWindow()
        {
            InitializeComponent();

            //var software =
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetReports", "POST", "");

            //response = JsonConvert.DeserializeObject<List<Report>>(software.ToString());

            //StatusBox.ItemsSource = JsonConvert.DeserializeObject<List<Status>>(RequestHelper.SendRequest($@"{config.uri}/Home/GetStatuses", "POST", "").ToString());

            //ReportsGrid.ItemsSource = response;
            StatusBox.ItemsSource = statuses;
            ReportsGrid.ItemsSource = reports;
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
                    reports.Where(q => q.Status.Name == (StatusBox.SelectedItem as Status).Name);
            }
        }
    }
}
