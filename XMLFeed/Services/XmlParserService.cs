using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using XMLFeed.Models.Interfaces;

namespace XMLFeed.Services
{
    public class XmlParserService : IXmlParser<XElement>
    {
        const string xmlFeedPath = "https://www.tungsten-network.com/rss-resource-library/";

        public XmlParserService()
        {
            
        }

        public IEnumerable<XElement> ParseXml(string path = "")
        {
            if (string.IsNullOrEmpty(path))
            {
                path = xmlFeedPath;
            }
            var frictionItems = XDocument.Load(path)
                      .Descendants("item")
                      .Where(el => el.Elements("category").Any(e => e.Value == "Friction"))
                      .OrderByDescending(element => Convert.ToDateTime(element.Element("pubDate").Value))
                      .Take(10);
            return frictionItems;
        }
    }
}