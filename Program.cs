using System;
using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace FFXIVScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Scraper scraper = new Scraper();
            scraper.GetItem();
        }
    }
}
