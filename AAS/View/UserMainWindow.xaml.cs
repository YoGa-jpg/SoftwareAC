using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AAS.Models;
using AAS.View;
using AAS_Web.Models;
using Newtonsoft.Json;

namespace AAS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConfigInfo config = new ConfigInfo(true);

        public MainWindow()
        {
            InitializeComponent();

            //var software =
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetSoftInfo", "POST", $"computerNumber={config.computer}");

            //var fullname =
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetName", "POST", $"computer={config.computer}")
            //        .ToString();
            //Fullname_Box.Text = fullname;
            //Computer_Box.Text = config.computer.ToString();
            Fullname_Box.Text = "Давидович Антон Александрович";
            Computer_Box.Text = config.computer.ToString();

            
            var response = new List<Software>();
            SoftGrid.ItemsSource = response;
        }

        private void LogIn_OnClick(object sender, RoutedEventArgs e)
        {
            new LogInWindow().Show();
        }

        private void Reports_OnClick(object sender, RoutedEventArgs e)
        {
            new SendReportWindow().Show();
        }

        private void GetAnswers_OnClick(object sender, RoutedEventArgs e)
        {
            new AnswersWindow().Show();
        }

        private void Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            var software =
                RequestHelper.SendRequest($@"{config.uri}/Home/GetSoftInfo", "POST", $"computerNumber={config.computer}");

            var response = JsonConvert.DeserializeObject<List<Software>>(software.ToString());
            SoftGrid.ItemsSource = null;
            SoftGrid.ItemsSource = response;
        }

        private void Help_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("Help.chm");
        }
    }
}
