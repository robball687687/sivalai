using SivalaiDartmouth.Interfaces;
using SivalaiDartmouth.Models;
using Square.Connect.Api;
using Square.Connect.Client;
using Square.Connect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SivalaiDartmouth.Services
{
    public class InventoryRetrievalService : IInventoryRetrievalService
    {
        public InventoryRetrievalService()
        {

        }

        public RestaurantItems getInventory()
        {
            RestaurantItems retMenu = new RestaurantItems();
            

            Configuration.Default.AccessToken = "sq0atp-ck43ZyjwVgVq8ZnmW98QNw";

            var apiInstance = new CatalogApi();
            
            try
            {
                // ListCatalog
                ListCatalogResponse result = apiInstance.ListCatalog(null, null);
                IDictionary<string, RestaurantItem> items = new Dictionary<string, RestaurantItem>();
                
                foreach (var test in result.Objects)
                {
                    switch(test.Type)
                    {
                        case Square.Connect.Model.CatalogObject.TypeEnum.ITEM:
                            if(test.ItemData.CategoryId== "CC523COHULAO3I5DAZRPCNKB")
                            {
                                items.Add(test.ItemData.Name, new RestaurantItem() { ItemName = test.ItemData.Name });
                            }                            
                            break;
                        default:
                            break;
                    }
                }

                retMenu.items = items;                    
                //var test2 = items;
                //var test1 = result;
                
                //Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                //Debug.Print("Exception when calling CatalogApi.ListCatalog: " + e.Message);
            }
            
            return retMenu;
        }
    }
}
