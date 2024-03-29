﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.ChatBot.Logic.Commands
{
    public class StockQuoteCommandResolver : ICommandResolver<string>
    {
        public async Task<string> ResolveAsync(string stockCode)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(new Uri(Properties.Settings.Default.StockDataUrl.Replace("{0}",stockCode)));
            var csvParts = (await response.Content.ReadAsStringAsync()).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(',')).ToArray();
            string message = $"{csvParts[1][0]} quote is {csvParts[1][4]} per share";
            return message;
        }
    }
}
