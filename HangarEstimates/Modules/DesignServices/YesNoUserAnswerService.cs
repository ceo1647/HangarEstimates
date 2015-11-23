using System.Windows;
using HangarEstimates.Infrastructure.Interfaces.Services;

namespace HangarEstimates.Modules.DesignServices
{
    public class YesNoUserAnswerService : IYesNoUserAnswerService
    {
        public bool AskUser(string question, string questionTheme = "")
        {
            return MessageBox.Show(question, questionTheme, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
    }
}
