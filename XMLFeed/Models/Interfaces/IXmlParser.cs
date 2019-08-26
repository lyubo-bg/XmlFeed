using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFeed.Models.Interfaces
{
    public interface IXmlParser<T>
    {
        IEnumerable<T> ParseXml(string path = "");
    }
}
