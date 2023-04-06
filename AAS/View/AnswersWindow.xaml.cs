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
        public AnswersWindow()
        {
            InitializeComponent();

            var answers = 
                RequestHelper.SendRequest($@"{config.uri}/Home/GetAnswers", "POST", $"computerNumber={config.computer}");

            Response = JsonConvert.DeserializeObject<List<Answer>>(answers.ToString());

            AnswersList.ItemsSource = Response;
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
