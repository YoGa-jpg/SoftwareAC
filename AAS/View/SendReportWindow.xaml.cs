using System.Collections.Generic;
using System.Windows;
using AAS.Models;
using AAS_Web.Models;
using Newtonsoft.Json;

namespace AAS
{
    public partial class SendReportWindow : Window
    {
        ConfigInfo config = new ConfigInfo(true);

        #region Data

        private List<Program> programs = new List<Program>()
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
            }
        };

        #endregion

        public SendReportWindow()
        {
            InitializeComponent();

            ProgramBox.ItemsSource = programs;

            //ProgramBox.ItemsSource = JsonConvert.DeserializeObject<List<Program>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetProgramsOnComputer", "POST", $"computer={config.computer}").ToString());
        }

        private void SendReport_OnClick(object sender, RoutedEventArgs e)
        {
            if(!(ThemeBox.Text == string.Empty | DescriptionBox.Text == string.Empty | ProgramBox.SelectedItem == null))
            {
                //RequestHelper.SendRequest($@"{config.uri}/Home/SendReport", "POST",
                //    $"computerNumber={config.computer}&theme={ThemeBox.Text}&description={DescriptionBox.Text}&program={(ProgramBox.SelectedItem as Program).ProgramId}");

                MessageBox.Show("Жалоба отправлена", "Жалоба", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Жалоба не отправлена. Проверьте введенные данные.", "Жалоба", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
