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
        #region Software

        private List<Software> software = new
            List<Software>()
            {
                new Software()
                {
                    Computer = new Computer()
                    {
                        ComputerId = 3,
                        Worker = new Worker()
                        {
                            Fullname = "Давидович Антон Александрович",
                            WorkerId = 1
                        }
                    },
                    ComputerId = 3,
                    LicenseStart = DateTime.Parse("01.01.2023"),
                    LicenseEnd = DateTime.Parse("01.06.2023"),
                    Program = new Program()
                    {
                        ProgramId = 1,
                        ProgramName = "Adobe Photoshop",
                        Type = new AAS_Web.Models.Type()
                        {
                            TypeId = 1,
                            TypeName = "Graphics"
                        }
                    },
                    Version = "Enterprise",
                    ProgramType = "Graphics"
                },
                new Software()
                {
                    Computer = new Computer()
                    {
                        ComputerId = 3,
                        Worker = new Worker()
                        {
                            Fullname = "Давидович Антон Александрович",
                            WorkerId = 1
                        }
                    },
                    ComputerId = 3,
                    LicenseStart = DateTime.Parse("01.01.2023"),
                    LicenseEnd = DateTime.Parse("01.06.2023"),
                    Program = new Program()
                    {
                        ProgramId = 2,
                        ProgramName = "Visual Studio 2022",
                        Type = new AAS_Web.Models.Type()
                        {
                            TypeId = 2,
                            TypeName = "IDE"
                        }
                    },
                    Version = "Community",
                    ProgramType = "IDE"
                },
                new Software()
                {
                    Computer = new Computer()
                    {
                        ComputerId = 3,
                        Worker = new Worker()
                        {
                            Fullname = "Давидович Антон Александрович",
                            WorkerId = 1
                        }
                    },
                    ComputerId = 3,
                    LicenseStart = DateTime.Parse("01.01.2023"),
                    LicenseEnd = DateTime.Parse("01.06.2099"),
                    Program = new Program()
                    {
                        ProgramId = 3,
                        ProgramName = "VS Code",
                        Type = new AAS_Web.Models.Type()
                        {
                            TypeId = 3,
                            TypeName = "Code Editor"
                        }
                    },
                    Version = "Community",
                    ProgramType = "IDE"
                },
                new Software()
                {
                    Computer = new Computer()
                    {
                        ComputerId = 3,
                        Worker = new Worker()
                        {
                            Fullname = "Давидович Антон Александрович",
                            WorkerId = 1
                        }
                    },
                    ComputerId = 3,
                    LicenseStart = DateTime.Parse("01.01.2023"),
                    LicenseEnd = DateTime.Parse("01.06.2023"),
                    Program = new Program()
                    {
                        ProgramId = 2,
                        ProgramName = "Jetbrains Rider",
                        Type = new AAS_Web.Models.Type()
                        {
                            TypeId = 2,
                            TypeName = "IDE"
                        }
                    },
                    Version = "Enterprise",
                    ProgramType = "IDE"
                }
            };

        #endregion

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
        public AdminMainWindow()
        {
            InitializeComponent();

            //var software =
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetComputersInfo", "POST", "");

            //ComputerBox.ItemsSource = JsonConvert.DeserializeObject<List<Computer>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetComputers", "POST", "").ToString());

            //ProgramBox.ItemsSource = JsonConvert.DeserializeObject<List<Program>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetPrograms", "POST", "").ToString());

            //response = JsonConvert.DeserializeObject<List<Software>>(software.ToString());
            ComputerBox.ItemsSource = computers;
            ProgramBox.ItemsSource = programs;
            GlobalInfoGrid.ItemsSource = software;
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
                GlobalInfoGrid.ItemsSource = software.Where(q =>
                        q.ComputerId == (ComputerBox.SelectedItem as Computer).ComputerId);

                ProgramBox.SelectedItem = null;
            }
        }

        private void ProgramBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProgramBox.SelectedItem != null)
            {
                GlobalInfoGrid.ItemsSource = null;
                GlobalInfoGrid.ItemsSource = software.Where(q =>
                    q.ProgramName == (ProgramBox.SelectedItem as Program).ProgramName);

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
