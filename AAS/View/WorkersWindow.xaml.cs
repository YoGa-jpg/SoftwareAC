using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;
using Type = System.Type;

namespace AAS.View
{
    public partial class WorkersWindow : Window
    {
        private List<Position> positions;
        ConfigInfo config = new ConfigInfo(true);
        public WorkersWindow()
        {
            InitializeComponent();

            GlobalInfoGrid.ItemsSource = JsonConvert.DeserializeObject<List<Worker>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetWorkers", "POST", "").ToString());

            positions = JsonConvert.DeserializeObject<List<Position>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetPositions", "POST", "").ToString());

            AddWorkerPositionBox.ItemsSource = positions;

            EditWorkerPositionBox.ItemsSource = positions;
        }

        private void AddProgram_OnClick(object sender, RoutedEventArgs e)
        {
            if(AddWorkerNameBox.Text != string.Empty & AddWorkerPositionBox.SelectedItem != null)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/AddWorker", "POST",
                    $"workerName={AddWorkerNameBox.Text}&positionId={(AddWorkerPositionBox.SelectedItem as Position).PositionId}");

                MessageBox.Show("Работник добавлен успешно", "Редактирование работников", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование работников", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void EditProgram_OnClick(object sender, RoutedEventArgs e)
        {
            if(GlobalInfoGrid.SelectedItem != null & EditWorkerNameBox.Text != string.Empty & EditWorkerPositionBox.SelectedItem != null)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/UpdateWorker", "POST",
                    $"workerId={(GlobalInfoGrid.SelectedItem as Worker).WorkerId}&workerName={EditWorkerNameBox.Text}&positionId={(EditWorkerPositionBox.SelectedItem as Position).PositionId}");

                MessageBox.Show("Работник изменен успешно", "Редактирование работников", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование работников", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void DeleteProgram_OnClick(object sender, RoutedEventArgs e)
        {
            if(GlobalInfoGrid.SelectedItem != null)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/DeleteWorker", "POST",
                    $"workerId={(GlobalInfoGrid.SelectedItem as Worker).WorkerId}");

                MessageBox.Show("Работник удален успешно", "Редактирование работников", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование работников", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        public void Resresh()
        {
            GlobalInfoGrid.ItemsSource = null;
            GlobalInfoGrid.ItemsSource = JsonConvert.DeserializeObject<List<Worker>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetWorkers", "POST", "").ToString());
        }

        private void GlobalInfoGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GlobalInfoGrid.SelectedItem != null)
            {
                EditWorkerNameBox.Text = (GlobalInfoGrid.SelectedItem as Worker).Fullname;
                EditWorkerPositionBox.SelectedItem =
                    positions.Single(q => q.PositionId == (GlobalInfoGrid.SelectedItem as Worker).PositionId);
            }
        }
    }
}
