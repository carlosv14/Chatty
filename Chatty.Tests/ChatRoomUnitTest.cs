using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatty.Core.ChatRoom;
using Chatty.Database.Models;
using Chatty.Database.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Chatty.Tests
{
    [TestClass]
    public class ChatRoomUnitTest
    {
        [TestMethod]
        public async Task RoomChatShowsLastFiftyMessagesOnly()
        {
            var chatRooms = this.GetChatRooms();
            var chatRoomRepositoryMock = new Mock<IRepository<ChatRoom>>();
            var userRepositoryMock = new Mock<IRepository<ApplicationUser>>();

            chatRoomRepositoryMock.Setup(x => x.All()).Returns(chatRooms.AsQueryable());
            chatRoomRepositoryMock.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                .Returns((object[] name) => Task.FromResult(chatRooms.FirstOrDefault(c => c.Name == name.First().ToString())));

            var chatRoomManager = new ChatRoomManager(chatRoomRepositoryMock.Object, userRepositoryMock.Object);
            var messages = await chatRoomManager.GetMessagesAsync("Default Room");

            Assert.AreEqual(messages.Count(), 50);
        }

        private List<ChatRoom> GetChatRooms()
        {
            return new List<ChatRoom>()
            {
                new ChatRoom
                {
                   Name = "Default Room",
                   Messages = new List<Message>
                   {
                        new Message { Date = DateTime.Now.AddMinutes(1), Content = "Message 2", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(2), Content = "Message 3", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(3), Content = "Message 4", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(4), Content = "Message 5", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(5), Content = "Message 6", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(6), Content = "Message 7", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(7), Content = "Message 8", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(8), Content = "Message 9", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(9), Content = "Message 10", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(10), Content = "Message 11", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(11), Content = "Message 12", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(12), Content = "Message 13", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(13), Content = "Message 14", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(14), Content = "Message 15", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(15), Content = "Message 16", UserId="4"},
                        new Message { Date = DateTime.Now.AddMinutes(16), Content = "Message 17", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(17), Content = "Message 18", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(18), Content = "Message 19", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(19), Content = "Message 20", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(20), Content = "Message 21", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(21), Content = "Message 22", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(22), Content = "Message 23", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(23), Content = "Message 24", UserId="4"},
                        new Message { Date = DateTime.Now.AddMinutes(24), Content = "Message 25", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(25), Content = "Message 26", UserId="4"},
                        new Message { Date = DateTime.Now.AddMinutes(26), Content = "Message 27", UserId="5"},
                        new Message { Date = DateTime.Now.AddMinutes(27), Content = "Message 28", UserId="5"},
                        new Message { Date = DateTime.Now.AddMinutes(28), Content = "Message 29", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(29), Content = "Message 30", UserId="5"},
                        new Message { Date = DateTime.Now.AddMinutes(30), Content = "Message 31", UserId="4"},
                        new Message { Date = DateTime.Now.AddMinutes(31), Content = "Message 32", UserId="5"},
                        new Message { Date = DateTime.Now.AddMinutes(32), Content = "Message 33", UserId="4"},
                        new Message { Date = DateTime.Now.AddMinutes(33), Content = "Message 34", UserId="6"},
                        new Message { Date = DateTime.Now.AddMinutes(34), Content = "Message 35", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(35), Content = "Message 36", UserId="4"},
                        new Message { Date = DateTime.Now.AddMinutes(36), Content = "Message 37", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(37), Content = "Message 38", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(38), Content = "Message 39", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(39), Content = "Message 40", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(40), Content = "Message 41", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(41), Content = "Message 42", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(42), Content = "Message 43", UserId="4"},
                        new Message { Date = DateTime.Now.AddMinutes(43), Content = "Message 44", UserId="5"},
                        new Message { Date = DateTime.Now.AddMinutes(44), Content = "Message 45", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(45), Content = "Message 46", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(46), Content = "Message 47", UserId="4"},
                        new Message { Date = DateTime.Now.AddMinutes(47), Content = "Message 48", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(48), Content = "Message 49", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(49), Content = "Message 50", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(50), Content = "Message 51", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(51), Content = "Message 52", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(52), Content = "Message 53", UserId="4"},
                        new Message { Date = DateTime.Now.AddMinutes(53), Content = "Message 54", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(54), Content = "Message 55", UserId="1"}
                   }
                },
                new ChatRoom
                {
                   Name = "Second Room",
                   Messages = new List<Message>
                   {
                        new Message { Date = DateTime.Now.AddMinutes(1), Content = "Message 2", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(2), Content = "Message 3", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(3), Content = "Message 4", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(4), Content = "Message 5", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(5), Content = "Message 6", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(6), Content = "Message 7", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(7), Content = "Message 8", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(8), Content = "Message 9", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(9), Content = "Message 10", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(10), Content = "Message 11", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(11), Content = "Message 12", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(12), Content = "Message 13", UserId="1"},
                        new Message { Date = DateTime.Now.AddMinutes(13), Content = "Message 14", UserId="2"},
                        new Message { Date = DateTime.Now.AddMinutes(14), Content = "Message 15", UserId="3"},
                        new Message { Date = DateTime.Now.AddMinutes(15), Content = "Message 16", UserId="4"},
                   }
                }
            };
        }
    }
}
