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
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;

namespace AAS.View
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        List<Software> response = new List<Software>();
        ConfigInfo config = new ConfigInfo(true);
        public AdminMainWindow()
        {
            InitializeComponent();

            var software =
                RequestHelper.SendRequest($@"{config.uri}/Home/GetComputersInfo", "POST", "");

            ComputerBox.ItemsSource = JsonConvert.DeserializeObject<List<Computer>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetComputers", "POST", "").ToString());

            ProgramBox.ItemsSource = JsonConvert.DeserializeObject<List<Program>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetPrograms", "POST", "").ToString());

            response = JsonConvert.DeserializeObject<List<Software>>(software.ToString());
            GlobalInfoGrid.ItemsSource = response;
        }

        private void Reports_OnClick(object sender, RoutedEventArgs e)
        {
            new GetReportsWindow().Show();
        }

        private void Records_OnClick(object sender, RoutedEventArgs e)
        {
            new GetRecordsWindow().Show();
        }

        private void GlobalInfoGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }

        private void AddRow_OnClick(object sender, RoutedEventArgs e)
        {
            new DbAddWindow().Show();
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            if(GlobalInfoGrid.SelectedItem != null)
            {
                new DbUpdateWindow(GlobalInfoGrid.SelectedItem as Software).Show();
            }
            else
            {
                MessageBox.Show("Выберите ПО", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            if(GlobalInfoGrid.SelectedItem != null)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/DeleteSoftware", "POST",
                    $"id={(GlobalInfoGrid.SelectedItem as Software).SoftwareId}");

                MessageBox.Show("ПО удалено успешно", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Выберите ПО", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ProgramsEdit_OnClick(object sender, RoutedEventArgs e)
        {
            new ProgramsWindow().Show();
        }

        private void WorkersEdit_OnClick(object sender, RoutedEventArgs e)
        {
            new WorkersWindow().Show();
        }

        private void ComputersEdit_OnClick(object sender, RoutedEventArgs e)
        {
            new ComputersWindow().Show();
        }

        private void ComputerBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComputerBox.SelectedItem != null)
            {
                GlobalInfoGrid.ItemsSource = null;
                GlobalInfoGrid.ItemsSource = response.Where(q =>
                        q.ComputerId == (ComputerBox.SelectedItem as Computer).ComputerId);

                ProgramBox.SelectedItem = null;
            }
        }

        private void ProgramBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProgramBox.SelectedItem != null)
            {
                GlobalInfoGrid.ItemsSource = null;
                GlobalInfoGrid.ItemsSource = response.Where(q =>
                    q.ProgramId == (ProgramBox.SelectedItem as Program).ProgramId);

                ComputerBox.SelectedItem = null;
            }
        }

        private void Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            GlobalInfoGrid.ItemsSource = null;
            GlobalInfoGrid.ItemsSource = JsonConvert.DeserializeObject<List<Software>>(RequestHelper.SendRequest($@"{config.uri}/Home/GetComputersInfo", "POST", "").ToString());
            ComputerBox.SelectedItem = null;
            ProgramBox.SelectedItem = null;
        }

        private void TypesEdit_OnClick(object sender, RoutedEventArgs e)
        {
            new TypesWindow().Show();
        }

        private void PositionsEdit_OnClick(object sender, RoutedEventArgs e)
        {
            new PositionsWindow().Show();
        }
    }
}
