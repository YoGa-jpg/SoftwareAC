using System;
using System.Collections.Generic;
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
    /// Interaction logic for ComputersWindow.xaml
    /// </summary>
    public partial class ComputersWindow : Window
    {
        private List<Worker> workersList;

        public List<Computer> computers;

        ConfigInfo config = new ConfigInfo(true);

        public ComputersWindow()
        {
            InitializeComponent();

            computers = JsonConvert.DeserializeObject<List<Computer>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetComputers", "POST", "").ToString());
            GlobalInfoGrid.ItemsSource = computers;

            workersList = JsonConvert.DeserializeObject<List<Worker>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetWorkers", "POST", "").ToString());

            computers = JsonConvert.DeserializeObject<List<Computer>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetComputers", "POST", "").ToString());
            

            AddComputerWorkerBox.ItemsSource = workersList;

            EditComputerWorkerBox.ItemsSource = workersList;
        }
        private void AddProgram_OnClick(object sender, RoutedEventArgs e)
        {
            var res = computers.Any(q => q.ComputerId == int.Parse(AddComputerIdBox.Text));
            if (new Regex(@"\d").IsMatch(AddComputerIdBox.Text) & AddComputerWorkerBox.SelectedItem != null & computers.All(q => q.ComputerId != int.Parse(AddComputerIdBox.Text)) & int.Parse(AddComputerIdBox.Text) > 0)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/AddComputer", "POST",
                    $"computerId={int.Parse(AddComputerIdBox.Text)}&workerId={(AddComputerWorkerBox.SelectedItem as Worker).WorkerId}");

                MessageBox.Show("Компьютер добавлен успешно", "Редактирование компьютеров", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование компьютеров", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void EditProgram_OnClick(object sender, RoutedEventArgs e) 
        {
            if(new Regex(@"\d").IsMatch(AddComputerIdBox.Text) & (EditComputerWorkerBox.SelectedItem != null) & GlobalInfoGrid.SelectedItem != null & computers.All(q => q.ComputerId != int.Parse(EditComputerIdBox.Text)) & int.Parse(EditComputerIdBox.Text) > 0)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/UpdateComputer", "POST",
                    $"computerId={int.Parse(EditComputerIdBox.Text)}&workerId={(EditComputerWorkerBox.SelectedItem as Worker).WorkerId}");

                MessageBox.Show("Компьютер изменен успешно", "Редактирование компьютеров", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование компьютеров", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void DeleteProgram_OnClick(object sender, RoutedEventArgs e)
        {
            if(GlobalInfoGrid.SelectedItem != null)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/DeleteComputer", "POST",
                    $"computerId={(GlobalInfoGrid.SelectedItem as Computer).ComputerId}");

                MessageBox.Show("Компьютер удален успешно", "Редактирование компьютеров", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование компьютеров", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        public void Resresh()
        {
            computers = JsonConvert.DeserializeObject<List<Computer>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetComputers", "POST", "").ToString());
            GlobalInfoGrid.ItemsSource = null;
            GlobalInfoGrid.ItemsSource = computers;
        }

        private void GlobalInfoGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GlobalInfoGrid.SelectedItem != null)
            {
                EditComputerIdBox.Text = (GlobalInfoGrid.SelectedItem as Computer).ComputerId.ToString();
                EditComputerWorkerBox.SelectedItem =
                    workersList.Single(q => q.WorkerId == (GlobalInfoGrid.SelectedItem as Computer).WorkerId);
            }
        }
    }
}
