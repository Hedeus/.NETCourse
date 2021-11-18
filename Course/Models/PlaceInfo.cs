using System.Linq;
using System.Text;
using System.Windows;

namespace Course.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }

        public Point location { get; set; }

        public IOrderedEnumerable<ConfirmedCount> Counts { get; set; }

    }
}
