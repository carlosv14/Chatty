using Chatty.ChatBot.Commands;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.ChatBot.Bots
{
    public class StockBotServer : IChatBotServer
    {
        private readonly IConnection connection;
        private readonly IModel channel;
        private readonly EventingBasicConsumer consumer;
        private readonly Dictionary<string, ICommandResolver<string>> commands;
        public StockBotServer()
        {
            this.commands = new Dictionary<string, ICommandResolver<string>>()
            {
                { "stock",  new StockQuoteCommandResolver() }
            };

            var factory = new ConnectionFactory() { HostName = Properties.Settings.Default.ChatBotServerUrl };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
            this.consumer = new EventingBasicConsumer(channel);

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

            consumer.Received += async (model, ea) =>
            {
                string response = null;
                var command = Encoding.UTF8.GetString(ea.Body);
                response = await this.ProcessCommandAsync(command);
                channel.BasicPublish(exchange: "",
                                routingKey: Properties.Settings.Default.ResultQueueName,
                                basicProperties: null,
                                body: Encoding.UTF8.GetBytes(response));
            };
        }

        private Task<string> ProcessCommandAsync(string command)
        {
            var commandParts = command.Split('=');
            var key = commandParts[0];
            if (!commands.ContainsKey(key))
            {
                throw new Exception("Command not found");
            }
            return this.commands[key].ResolveAsync(commandParts[1]);
        }

        public void Start()
        {
            this.channel.BasicConsume(queue: Properties.Settings.Default.CommandInQueueName,
                                    autoAck: true,
                                    consumer: consumer);
        }

        public void Stop()
        {
            this.connection.Close();
        }
    }
}
