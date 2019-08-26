using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XMLFeed.Models
{
    public class Item
    {
        public Item(string heading = null, DateTime? date = null, string image = null, string category = "Friction")
        {
            Heading = heading;
            Date = date;
            Image = image;
            Category = category;
        }

        public string Heading { get; set; }
        public DateTime? Date { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
    }
}