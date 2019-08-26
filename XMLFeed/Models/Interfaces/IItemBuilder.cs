using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFeed.Models.Interfaces
{
    public interface IItemBuilder<T>
    {
        List<Item> BuildItems(IEnumerable<T> materials);
    }
}
