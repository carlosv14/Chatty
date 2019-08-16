using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Database.Models
{
    public class ChatRoom
    {
        public ChatRoom()
        {
            this.Messages = new HashSet<Message>();
            this.Users = new HashSet<ApplicationUser>();
        }

        [Key]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
