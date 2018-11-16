using SivalaiDartmouth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SivalaiDartmouth.Interfaces
{
    public interface IInventoryRetrievalService
    {
        RestaurantFullMenu getInventory();
    }
}
