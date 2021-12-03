using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AdapterPattern.Take2.Business
{
    public interface IUserNotificationService
    {
        Task NotifyUser(string userId, string message);
    }
}
