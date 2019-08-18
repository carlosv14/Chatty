using Chatty.Core.Message;
using Chatty.Database.Models;
using Chatty.Database.Repositories;
using Chatty.Web.Hubs.Clients;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;

namespace Chatty.Web.Hubs.Tickers
{
    public class ChatTicker : IChatTicker
    {
        private readonly IMessageManager messageManager;
        private readonly IHubContext<IChatClient> hubContext;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly RabbitMQ.Client.IConnection connection;
        private readonly IModel channel;
        private readonly EventingBasicConsumer consumer;

        public ChatTicker(
            IMessageManager messageManager,
            IHubContext<IChatClient> hubContext,
            IRepository<ApplicationUser> userRepository)
        {
            this.messageManager = messageManager;
            this.hubContext = hubContext;
            this.userRepository = userRepository;

            var factory = new ConnectionFactory() { HostName = Properties.Settings.Default.ChatBotServerUrl };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
            this.consumer = new EventingBasicConsumer(channel);

            this.ConfigureBotQueues();
        }

        public void ConfigureBotQueues()
        {
            this.channel.QueueDeclare(queue: Properties.Settings.Default.ResultQueueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            this.channel.QueueDeclare(queue: Properties.Settings.Default.CommandInQueueName,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

            channel.BasicConsume(queue: Properties.Settings.Default.ResultQueueName,
                                 autoAck: true,
                                 consumer: consumer);
            this.consumer.Received += async (model, ea) => await this.SendBotMessageAsync(ea.Body);
        }

        public async Task SendBotMessageAsync(byte[] content)
        {
            var message = Encoding.UTF8.GetString(content);
            this.hubContext.Clients.All.SendMessage($"[{DateTime.Now}] - stock-bot: {message}");
        }

        public void ParseCommand(string command)
        {
            command = command.Remove(0, 1);
            var body = Encoding.UTF8.GetBytes(command);
            channel.BasicPublish(exchange: "",
                             routingKey: "input",
                             basicProperties: null,
                             body: body);
        }

        public async Task SendMessage(string message)
        {
            if (message.StartsWith(@"/stock"))
            {
                this.ParseCommand(message);
                return;
            }
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();
            var currentUser = this.userRepository.Find(currentUserId);
            var date = DateTime.Now;
            var result = await this.messageManager.SaveMessageAsync(message, date, currentUserId);
            if (result.Succeeded)
            {
                this.hubContext.Clients.All.SendMessage($"[{date}] - {currentUser.UserName}: {message}");
            }
        }
    }
}