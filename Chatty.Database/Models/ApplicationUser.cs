using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Database.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ChatRooms = new HashSet<ChatRoom>();
            this.Messages = new HashSet<Message>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public virtual ICollection<ChatRoom> ChatRooms { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
