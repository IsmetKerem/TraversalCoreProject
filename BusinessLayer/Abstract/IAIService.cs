namespace BusinessLayer.Abstract
{
    public interface IAIService
    {
        Task<string> GetTravelAdviceAsync(string userMessage, string context = "");
    }
}