using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.ApplicationCore.Entities
{
    public class User: IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? PhotoUrl { get; set; }   
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
