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

namespace AAS
{
    /// <summary>
    /// Interaction logic for AnswersWindow.xaml
    /// </summary>
    public partial class AnswersWindow : Window
    {
        public ConfigInfo config = new ConfigInfo(true); 
        public List<Answer> Response;

        #region Data

        private List<Answer> answers = new List<Answer>()
        {
            new Answer()
            {
                AnswerId = 1,
                AnswerDescription = "Лицензия была продлена. Приносим извинения за неудобства.",
                AnswerTheme = "Не работает VS",
                Report = new Report()
                {
                    ReportId = 1,
                    Computer = new
                        Computer()
                        {
                            ComputerId = 3
                        },
                    ComputerId = 3,
                    Program = new Program()
                    {
                        ProgramName = "Visual Studio 2022"
                    },
                    ProgramId = 2,
                    ReportTheme = "Не работает VS",
                    ReportDescription = "des"
                },
                ReportId = 1
            }
        };

        #endregion
        public AnswersWindow()
        {
            InitializeComponent();

            //var answers = 
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetAnswers", "POST", $"computerNumber={config.computer}");

            //Response = JsonConvert.DeserializeObject<List<Answer>>(answers.ToString());

            AnswersList.ItemsSource = answers;
        }

        private void ShowAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            if(AnswersList.SelectedItem != null)
            {
                new ShowAnswerWindow(AnswersList.SelectedItem as Answer).Show();
            }
            else
            {
                MessageBox.Show("Выберите сообщение, которе хотите открыть!", "Ответ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
