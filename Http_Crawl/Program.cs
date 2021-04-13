using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Http_crawl_data
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };
            HtmlDocument document = htmlWeb.Load("https://www.webtretho.com/f/doc-bao-gium-ban");
            var threadItems = document.DocumentNode.QuerySelectorAll("div.am-wingblank > a").ToList();
            var objs = new List<object>();
            foreach (var item in threadItems)
            {
                var linkNode = item;
                var link = linkNode.Attributes["href"].Value;
                var text = linkNode.InnerText;
                objs.Add(new { link, text });
            }
            var filename = "test.txt";
            var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fullpath = Path.Combine(directory_mydoc, filename);
            List<String> lstString = objs.Select(i => i.ToString()).ToList();
            System.IO.File.WriteAllLines(fullpath, lstString);
        }
    }
}
