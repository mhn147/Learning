using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AdapterPattern.Take2.Business
{
    public class EmployeeFiredEvent
    {
        private readonly IUserNotificationService _userNF;

        public EmployeeFiredEvent(IUserNotificationService userNF)
        {
            _userNF = userNF;
        }

        public Task Execute()
        {
            // other work here
            return _userNF.NotifyUser("", "");
        }
    }
}
