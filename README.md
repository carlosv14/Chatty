# Chatty
Realtime browser-based chat application with a bot that queries stock quotes.

## Technologies
* ASP.NET MVC
* Bootstrap
* JQuery
* RabbitMq
* SignalR
* EntityFramework
* Moq
* Wix Toolset

## Setup
`git clone https://github.com/carlosv14/Chatty.git`

### Requirements
* .net Framework >= 4.5.1
* [RabbitMq Server](https://www.rabbitmq.com/download.html) running on default ports.

### Prerequisites
* It is important before running anything to download and install [RabbitMq Server](https://www.rabbitmq.com/download.html).
* [Wix Toolset](https://wixtoolset.org/releases/) (This is optional). 

### Configurations
* By default the address for RabbitMq server is localhost, you can change this and the queues names in the website's web config and the windows service or console application configuration files. Make sure server address and queues names match in both files if changed.
* The endpoint URL that returns the stock information is also configurable in the windows service or console application configuration file.

### Run chat website
You'll need visual studio with IIS Express or changing the settings to run on local IIS if desired. Default connection string is using localdb and code first approach with entity framework was used for the database. 

Project includes two initializers to drop and create database as needed, by default the database will be dropped and re-created if there are model changes, you can change this in the initializer section of the web config.

#### Steps
1) Download and install [RabbitMq Server](https://www.rabbitmq.com/download.html)
2) Restore NuGet packages
3) Run

### Run Chat Bot
Chat bot is a separate project, you can either run the console project called "Chatty.ChatBot.ConsoleHost" or download and install [Chat Bot Windows Service](https://drive.google.com/file/d/1HMag2ydp4c6IM4gt8sL2IrfnZk5tCLfO/view?usp=sharing).

You can also generate your own installer by compiling the project 'Chatty.ChatBot.Service.Setup.Msi' but you'll need wix toolset for this.

#### Steps
1) Make sure [RabbitMq Server](https://www.rabbitmq.com/download.html) is installed and running on default ports.
2) Run console application or Chat Bot Windows Service.

### Features
* Microsft Asp.net identity authentication.
* User encrypted password and strength validation.
* Windows Service Installer for chat bot.
* Unit Testing with mocks.
* Query stock quotes with command: `/stock=stock_code`

### Live Demo
A live demo of the chat can be found here: http://3.14.149.117/Chatty
