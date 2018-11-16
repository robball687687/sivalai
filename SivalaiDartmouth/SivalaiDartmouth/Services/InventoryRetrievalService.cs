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
                IDictionary<string, RestaurantCategory> categorys = new Dictionary<string, RestaurantCategory>();

                foreach (var restObj in result.Objects)
                {
                    switch(restObj.Type)
                    {
                        case Square.Connect.Model.CatalogObject.TypeEnum.ITEM:
                            if(restObj.ItemData.CategoryId== "CC523COHULAO3I5DAZRPCNKB")
                            {
                                items.Add(restObj.ItemData.Name, new RestaurantItem() {
                                    ItemName = restObj.ItemData.Name,
                                    ItemDescription = restObj.ItemData.Description,
                                    ItemPrice = "$12"
                                });
                            }                            
                            break;
                        case Square.Connect.Model.CatalogObject.TypeEnum.CATEGORY:
                            categorys.Add(restObj.CategoryData.Name, new RestaurantCategory()
                            {
                                CategoryName = restObj.CategoryData.Name
                            });
                            break;
                        default:
                            break;
                    }
                }

                retMenu.items = items;                    
                var test2 = categorys;
                var test1 = test2;
                
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
