using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SivalaiDartmouth.Models
{
    public class RestaurantFullMenu
    {
        public IDictionary<string, RestaurantItem> items { get; set; }
        public IDictionary<string, RestaurantCategory> categorys { get; set; }
    }
}
