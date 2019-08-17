using Chatty.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Core.Message
{
    public class MessageManager : IMessageManager
    {
        private readonly IRepository<Database.Models.Message> messageRepository;

        public MessageManager(IRepository<Chatty.Database.Models.Message> messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public async Task<OperationResult> SaveMessageAsync(string messageText, DateTime date, string userId, string chatRoom = "Default Room")
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(messageText) || date == null)
            {
                throw new ArgumentNullException("All arguments must be provided");
            }

            var message = new Database.Models.Message
            {
                ChatRoomId = chatRoom,
                Content = messageText,
                Date = date,
                UserId = userId
            };

            this.messageRepository.Create(message);
            await this.messageRepository.SaveChangesAsync();
            return new OperationResult(true);
        }
    }
}
