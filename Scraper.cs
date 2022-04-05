using System;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Web;

namespace FFXIVScraper
{
    class Scraper
    {
        public string GetItem(string item)
        {
            try
            {
                string itemFormatted = FormatName(item);
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load($"https://ffxiv.consolegameswiki.com/wiki/{itemFormatted}");
                HtmlNodeCollection HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='mw-parser-output']/p");
                foreach (var node in HeaderNames)
                {
                    if (node.InnerText != "\n")
                    {
                        string decodedText = HttpUtility.HtmlDecode(node.InnerText);
                        return decodedText;
                    }
                }
            }
            catch (Exception error)
            {
                return "Not found";
            }
            return "Not Found";
        }

        private string FormatName(string item)
        {

            item = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item);
            item = item.Replace(" ", "_");
            return item;
        }

    }
}


//!ffxivfinder item blades
//Hey I found bla : 