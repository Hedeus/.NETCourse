using System.Linq;

namespace Course.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IOrderedEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
