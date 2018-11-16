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

        public RestaurantFullMenu getInventory()
        {
            RestaurantFullMenu retMenu = new RestaurantFullMenu();
            
            Configuration.Default.AccessToken = "sq0atp-ck43ZyjwVgVq8ZnmW98QNw";
            int categorynumber = 0;

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
                            categorynumber = categorynumber + 1;
                            categorys.Add(restObj.CategoryData.Name, new RestaurantCategory()
                            {
                                CategoryName = restObj.CategoryData.Name,
                                CategoryNumber = categorynumber.ToString()
                            });
                            break;
                        default:
                            break;
                    }
                }

                retMenu.items = items;
                retMenu.categorys = categorys;
            }
            catch (Exception e)
            {
                //Debug.Print("Exception when calling CatalogApi.ListCatalog: " + e.Message);
            }
            
            return retMenu;
        }
    }
}
