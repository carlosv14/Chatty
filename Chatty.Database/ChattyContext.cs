using Chatty.Database.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Database
{
    public class ChattyContext : IdentityDbContext<ApplicationUser>
    {
        public ChattyContext()
            :base()
        {

        }

        public virtual DbSet<ChatRoom> ChatRooms { get; set; }

        public virtual DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.BuildChatRoom(modelBuilder.Entity<ChatRoom>());
        }
        private void BuildChatRoom(EntityTypeConfiguration<ChatRoom> entity)
        {
            entity.HasMany(e => e.Users)
                .WithMany(t => t.ChatRooms)
                .Map(map =>
                {
                    map.MapRightKey("ChatRoomId");
                    map.MapLeftKey("UserId");
                    map.ToTable("UserChatRooms");
                });
        }
    }
}
