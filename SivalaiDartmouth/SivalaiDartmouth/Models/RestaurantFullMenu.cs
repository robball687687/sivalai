using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SivalaiDartmouth.Models
{
    public class RestaurantFullMenu
    {
        IDictionary<string, RestaurantItem> items = new Dictionary<string, RestaurantItem>();
        IDictionary<string, RestaurantCategory> categorys = new Dictionary<string, RestaurantCategory>();
    }
}
