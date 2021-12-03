using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace DesignPatterns.AdapterPattern.Take2.Business
{
    public class ObjectAdapter : IUserNotificationService
    {
        private readonly SendGridClient _client;

        public ObjectAdapter(SendGridClient client)
        {
            _client = client;
        }

        public Task NotifyUser(string userId, string message)
        {
            return _client.SendEmailAsync(new SendGridMessage());
        }
    }
}
