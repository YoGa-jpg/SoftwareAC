using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;
using Type = AAS_Web.Models.Type;

namespace AAS.View
{
    public partial class ProgramsWindow : Window
    {
        private List<Type> Types;
        private int selectedId;
        ConfigInfo config = new ConfigInfo(true);
        public ProgramsWindow()
        {
            InitializeComponent();

            Types = JsonConvert.DeserializeObject<List<Type>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetTypes", "POST", "").ToString());

            GlobalInfoGrid.ItemsSource = JsonConvert.DeserializeObject<List<Program>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetPrograms", "POST", "").ToString());

            AddProgramTypeBox.ItemsSource = Types;

            EditProgramTypeBox.ItemsSource = Types;
        }

        private void AddProgram_OnClick(object sender, RoutedEventArgs e)
        {
            if(AddProgramNameBox.Text != string.Empty & AddProgramTypeBox.SelectedItem != null)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/AddProgram", "POST",
                    $"progName={AddProgramNameBox.Text}&typeId={(AddProgramTypeBox.SelectedItem as Type).TypeId}");

                MessageBox.Show("Программа добавлена успешно", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void EditProgram_OnClick(object sender, RoutedEventArgs e)
        {
            if(GlobalInfoGrid.SelectedItem != null & EditProgramNameBox.Text != string.Empty & EditProgramTypeBox.SelectedItem != null)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/UpdateProgram", "POST",
                    $"progId={(GlobalInfoGrid.SelectedItem as Program).ProgramId}&progName={EditProgramNameBox.Text}&typeId={(EditProgramTypeBox.SelectedItem as Type).TypeId}");

                MessageBox.Show("Программа изменена успешно", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void DeleteProgram_OnClick(object sender, RoutedEventArgs e)
        {
            if(GlobalInfoGrid.SelectedItem != null)
            {
                RequestHelper.SendRequest($@"{config.uri}/Home/DeleteProgram", "POST",
                    $"progId={(GlobalInfoGrid.SelectedItem as Program).ProgramId}");

                MessageBox.Show("Программа удалена успешно", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        public void Resresh()
        {
            GlobalInfoGrid.ItemsSource = null;
            GlobalInfoGrid.ItemsSource = JsonConvert.DeserializeObject<List<Program>>(
                RequestHelper.SendRequest($@"{config.uri}/Home/GetPrograms", "POST", "").ToString());
        }

        private void GlobalInfoGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(GlobalInfoGrid.SelectedItem != null)
            {
                EditProgramNameBox.Text = (GlobalInfoGrid.SelectedItem as Program).ProgramName;
                EditProgramTypeBox.SelectedItem =
                    Types.Single(q => q.TypeId == (GlobalInfoGrid.SelectedItem as Program).Type.TypeId);
            }
        }
    }
}
