using System;
using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace FFXIVScraper
{
    class Scraper
    {
        public void GetItem()
        {

            string itemName = GetName();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load($"https://ffxiv.consolegameswiki.com/wiki/{itemName}");
            var HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='mw-parser-output']/p");
            foreach (var item in HeaderNames)
            {
                if (item.InnerText != "\n")
                {
                    Console.WriteLine(item.InnerText);
                }
            }

            Console.ReadLine();
        }

        private string GetName()
        {
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();
            itemName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(itemName);
            itemName = itemName.Replace(" ", "_");
            return itemName;
        }

    }
}
