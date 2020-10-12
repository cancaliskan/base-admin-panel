namespace BaseAdminTemplate.Business.Contracts
{
    public interface IEmailService
    {
        void Send(string to, string subject, string text);
    }
}