namespace HangarEstimates.Infrastructure.Interfaces.Services
{
    public interface IYesNoUserAnswerService
    {
        bool AskUser(string question, string questionTheme = "");
    }
}
