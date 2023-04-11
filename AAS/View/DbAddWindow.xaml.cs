using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for DbAddWindow.xaml
    /// </summary>
    public partial class DbAddWindow : Window
    {
        #region Computers

        private List<Computer> computers = new
            List<Computer>()
            {
                new Computer()
                {
                    ComputerId = 1
                },
                new Computer()
                {
                    ComputerId = 2
                },
                new Computer()
                {
                    ComputerId = 3
                },
                new Computer()
                {
                    ComputerId = 4
                }
            };

        #endregion

        #region Programs

        private List<Program> programs = new
            List<Program>()
            {
                new Program()
                {
                    ProgramId = 1,
                    ProgramName = "Adobe Photoshop",
                    Type = new AAS_Web.Models.Type()
                    {
                        TypeId = 1,
                        TypeName = "Graphics"
                    }
                },
                new Program()
                {
                    ProgramId = 2,
                    ProgramName = "Visual Studio 2022",
                    Type = new AAS_Web.Models.Type()
                    {
                        TypeId = 2,
                        TypeName = "IDE"
                    }
                },
                new Program()
                {
                    ProgramId = 3,
                    ProgramName = "VS Code",
                    Type = new AAS_Web.Models.Type()
                    {
                        TypeId = 3,
                        TypeName = "Code Editor"
                    }
                },
                new Program()
                {
                    ProgramId = 2,
                    ProgramName = "Jetbrains Rider",
                    Type = new AAS_Web.Models.Type()
                    {
                        TypeId = 2,
                        TypeName = "IDE"
                    }
                },
            };

        #endregion
        ConfigInfo config = new ConfigInfo(true);
        public DbAddWindow()
        {
            InitializeComponent();

            //var Computers =
            //    JsonConvert.DeserializeObject<List<Computer>>(
            //        RequestHelper.SendRequest($@"{config.uri}/Home/GetComputers", "POST", "").ToString());

            //var Programs =
            //    JsonConvert.DeserializeObject<List<Program>>(
            //        RequestHelper.SendRequest($@"{config.uri}/Home/GetPrograms", "POST", "").ToString());

            var Computers = computers;
            var Programs = programs;

            ComputerBox.ItemsSource = Computers;
            ProgramBox.ItemsSource = Programs;
        }

        private void AddSoftware_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime date;
            if(!(ComputerBox.SelectedItem == null | ProgramBox.SelectedItem == null | !DateTime.TryParseExact(LicenseStartBox.Text, "dd.MM.yyyy", null, DateTimeStyles.None, out date) | !DateTime.TryParseExact(LicenseEndBox.Text, "dd.MM.yyyy", null, DateTimeStyles.None, out date) | VersionBox.Text == string.Empty))
            {
                //RequestHelper.SendRequest($@"{config.uri}/Home/AddSoftware", "POST",
                //    $"compId={(ComputerBox.SelectedItem as Computer).ComputerId}&progId={(ProgramBox.SelectedItem as Program).ProgramId}&licStart={Convert.ToDateTime(LicenseStartBox.Text)}&licEnd={Convert.ToDateTime(LicenseEndBox.Text)}&version={VersionBox.Text}");

                MessageBox.Show("ПО добавлено успешно", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные", "Редактирование программ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
