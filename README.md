# Chatty
Realtime browser-based chat application with a bot that queries stock quotes.

## Technologies
* ASP.NET MVC
* Bootstrap
* JQuery
* RabbitMq
* SignalR
* EntityFramework

## Setup
`git clone https://github.com/carlosv14/Chatty.git`

### Requirements
* .net Framework >= 4.5.1
* [RabbitMq Server](https://www.rabbitmq.com/download.html) running on default ports.

### Prerequisites
It is important before running anything to download and install [RabbitMq Server](https://www.rabbitmq.com/download.html).

### Run chat website
You'll need visual studio with IIS Express or changing the settings to run on local IIS if desired. Default connection string is using localdb and code first approach with entity framework was used for the database. 

Project includes two initializers to drop and create database as needed, by default the database will be dropped and re-created if there are model changes, you can change this in the initializer section of the web config.

#### Steps
1) Download and install [RabbitMq Server](https://www.rabbitmq.com/download.html)
2) Restore NuGet packages
3) Run

### Run Chat Bot
Chat bot is a separate project you can either run the console project called Chatty.ChatBot.ConsoleHost or download and install Chat Bot Windows Service.

#### Steps
1) Make sure [RabbitMq Server](https://www.rabbitmq.com/download.html) is installed and running on default ports.
2) Run console application or make sure Chat Bot Windows Service is running.

### Features
* Microsft Asp.net identity authentication.
* User encrypted password and strength validation.
* Windows Service Installer for chat bot.
* Unit Testing.
* Query stock quotes with `command: /stock=stock_code`

