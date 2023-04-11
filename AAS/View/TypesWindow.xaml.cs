using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;
using Type = AAS_Web.Models.Type;

namespace AAS.View
{
    public partial class TypesWindow : Window
    {
        #region Types

        private List<Type> types = new List<Type>()
        {
            new Type()
            {
                TypeName = "Graphics"
            },
            new Type()
            {
                TypeName = "IDE"
            },
            new Type()
            {
                TypeName = "Code Editor"
            }
        };

        #endregion

        ConfigInfo config = new ConfigInfo(true);
        public TypesWindow()
        {
            InitializeComponent();

            //types = JsonConvert.DeserializeObject<List<Type>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetTypes", "POST", "").ToString());

            GlobalInfoGrid.ItemsSource = types;
        }

        private void AddType_OnClick(object sender, RoutedEventArgs e)
        {
            if (AddTypeNameBox.Text != string.Empty)
            {
                //RequestHelper.SendRequest($@"{config.uri}/Home/AddType", "POST",
                //    $"typeName={AddTypeNameBox.Text}");

                MessageBox.Show("Тип программы добавлен успешно", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void EditType_OnClick(object sender, RoutedEventArgs e)
        {
            if (GlobalInfoGrid.SelectedItem != null & EditTypeNameBox.Text != string.Empty)
            {
                //RequestHelper.SendRequest($@"{config.uri}/Home/UpdateType", "POST",
                //    $"typeId={(GlobalInfoGrid.SelectedItem as Type).TypeId}&typeName={EditTypeNameBox.Text}");

                MessageBox.Show("Тип программы изменен успешно", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Редактирование типов", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Resresh();
        }

        private void DeleteType_OnClick(object sender, RoutedEventArgs e)
        {
            if (GlobalInfoGrid.SelectedItem != null)
            {
                //RequestHelper.SendRequest($@"{config.uri}/Home/DeleteType", "POST",
                //    $"typeId={(GlobalInfoGrid.SelectedItem as Type).TypeId}");

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
            //GlobalInfoGrid.ItemsSource = null;
            //GlobalInfoGrid.ItemsSource = JsonConvert.DeserializeObject<List<Type>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetTypes", "POST", "").ToString());
        }

        private void GlobalInfoGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GlobalInfoGrid.SelectedItem != null)
            {
                EditTypeNameBox.Text = (GlobalInfoGrid.SelectedItem as Type).TypeName;
            }
        }
    }
}
