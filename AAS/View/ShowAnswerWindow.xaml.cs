using System.Windows;
using AAS_Web.Models;

namespace AAS
{
    public partial class ShowAnswerWindow : Window
    {
        public ShowAnswerWindow(Answer answer)
        {
            InitializeComponent();

            ThemeBox.Text = answer.AnswerTheme;
            DescriptionBox.Text = answer.AnswerDescription;
            ProgramBox.Text = answer.Report.Program.ProgramName;
        }
    }
}
