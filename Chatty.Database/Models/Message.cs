using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Database.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public TimeSpan TimeSpan { get; set; }

        [ForeignKey(nameof(ChatRoom))]
        [StringLength(50)]
        public string ChatRoomId { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
    }
}
