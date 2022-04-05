using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace FFXIVScraper
{
    class Program
    {
        private DiscordSocketClient _client;
        Scraper scraper = new Scraper();
        public static void Main(string[] args)
            => new Program().AsynBot().GetAwaiter().GetResult();


        public async Task AsynBot()
        {
            _client = new DiscordSocketClient();


            _client.Log += Log;
            _client.MessageReceived += ReceivedMessage;

            await _client.LoginAsync(TokenType.Bot, "");
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task ReceivedMessage(SocketMessage arg)
        {
            string[] input = arg.Content.Split(" ");
            if (input[0] == "!ffxiv")
            {
                if (input.Length > 1)
                {
                    string item = arg.ToString().Substring(6);
                    string itemResult = scraper.GetItem(item);
                    arg.Author.SendMessageAsync(itemResult);
                }
                else
                {
                    arg.Author.SendMessageAsync("Invalid input. Expected !ffxiv <input>");
                }
            }

            return Task.CompletedTask;
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }
    }
}
