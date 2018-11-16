using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SivalaiDartmouth.Models
{
    public class RestaurantItems
    {
        public IDictionary<string, RestaurantItem> items { get; set; }
    }
}
