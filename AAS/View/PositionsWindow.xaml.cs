using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;
using Type = AAS_Web.Models.Type;

namespace AAS.View
{
    /// <summary>
    /// Interaction logic for PositionsWindow.xaml
    /// </summary>
    public partial class PositionsWindow : Window
    {
        private List<Position> positions;
        ConfigInfo config = new ConfigInfo(true);

        public PositionsWindow()
        {
            InitializeComponent();

            positions = JsonConvert.DeserializeObject<List<Position>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetPositions", "POST", "").ToString());

            GlobalInfoGrid.ItemsSource = positions;
        }

        private void AddPosition_OnClick(object sender, RoutedEventArgs e)
        {
            if (AddPositionNameBox.Text != string.Empty)
            {
                string permission = AddPositionPermissionBox.Text;
                if (AddPositionPermissionBox.Text == string.Empty)
                    permission = null;

                RequestHelper.SendRequest($@"{config.uri}/Home/AddPosition", "POST",
                    $"positionName={AddPositionNameBox.Text}&permission={permission}");

                MessageBox.Show("Тип программы добавлен успешно", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void EditPosition_OnClick(object sender, RoutedEventArgs e)
        {
            string permission = EditPositionPermissionBox.Text;
            if (EditPositionPermissionBox.Text == string.Empty)
                permission = null;

            if (GlobalInfoGrid.SelectedItem != null & EditPositionNameBox.Text != string.Empty)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/UpdatePosition", "POST",
                    $"positionId={(GlobalInfoGrid.SelectedItem as Position).PositionId}&positionName={EditPositionNameBox.Text}&permission={permission}");

                MessageBox.Show("Тип программы изменен успешно", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void DeletePosition_OnClick(object sender, RoutedEventArgs e)
        {
            if (GlobalInfoGrid.SelectedItem != null)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/DeletePosition", "POST",
                    $"positionId={(GlobalInfoGrid.SelectedItem as Position).PositionId}");

                MessageBox.Show("Тип программы удален успешно", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        public void Resresh()
        {
            GlobalInfoGrid.ItemsSource = null;
            GlobalInfoGrid.ItemsSource = JsonConvert.DeserializeObject<List<Position>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetPositions", "POST", "").ToString());
        }

        private void GlobalInfoGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GlobalInfoGrid.SelectedItem != null)
            {
                EditPositionNameBox.Text = (GlobalInfoGrid.SelectedItem as Position).PositionName;
                EditPositionPermissionBox.Text = (GlobalInfoGrid.SelectedItem as Position).Permission;
            }
        }
    }
}
