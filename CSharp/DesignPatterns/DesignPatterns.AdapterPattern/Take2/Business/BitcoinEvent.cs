using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AdapterPattern.Take2.Business
{
    public class BitcoinEvent
    {
        private readonly IUserNotificationService _userNF;

        public BitcoinEvent(IUserNotificationService userNF)
        {
            _userNF = userNF;
        }

        public Task Execute()
        {
            return _userNF.NotifyUser("", "");
        }
    }
}
