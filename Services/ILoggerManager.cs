namespace IPS_survey.Services
{
    public interface ILoggerManager
    {
        public void LogDebug(string message);
        public void LogError(string message);
        public void LogInfo(string message);
        public void LogWarn(string message);
    }
}
