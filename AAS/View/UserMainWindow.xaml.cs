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

        #region Data

        private List<Software> softwareList = new
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
                    ProgramType = "Code Editor"
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

            
            //var response = new List<Software>();
            var response = softwareList;
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
