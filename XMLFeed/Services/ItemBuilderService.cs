using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using XMLFeed.Models;
using XMLFeed.Models.Interfaces;

namespace XMLFeed.Services
{
    public class ItemBuilderService : IItemBuilder<XElement>
    {
        public List<Item> BuildItems(IEnumerable<XElement> xElementsItems)
        {
            var items = new List<Item>();
            foreach(var xElement in xElementsItems)
            {
                
                string heading = xElement.Descendants("title").ToList()[0].Value;
                DateTime date = Convert.ToDateTime(xElement.Descendants("pubDate").ToList()[0].Value);
                string imgUrl = xElement.Descendants("enclosure").ToList()[0].Attribute("url").Value;
                var item = new Item(heading, date, imgUrl);
                items.Add(item);
            }
            return items;
        }
    }
}