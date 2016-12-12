using DemoBuy.Models;
using DemoBuy.Seller;
using DemoBuy.Services;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Http;

namespace DemoBuy.Controllers
{
    //[Authorize]
    public class NowController : ApiController
    {
        // GET api/values
        public IEnumerable<NowApiModel> Get()
        {
            foreach (Shop key in Enum.GetValues(typeof(Shop)))
            {
                var products = GetCache(key, SellerService.GetProduct);

                if(products != null)
                {
                    yield return new NowApiModel()
                    {
                        Shop = key,
                        Products = products
                    };
                }
            }
        }
        
        private ProductApiModel[] GetCache(Shop key, Func<Shop, ProductApiModel[]> action)
        {
            return WebCache.Get(key.ToString()) as ProductApiModel[] ?? SetCache(key, action);
        }

        private ProductApiModel[] SetCache(Shop key, Func<Shop, ProductApiModel[]> action)
        {
            int minutesToCache;
            var value = action.Invoke(key);

            switch (key)
            {
                case Shop.Pchome:
                    minutesToCache = 20;
                    break;
                case Shop.Tkec:
                    minutesToCache = 20;
                    break;
                case Shop.Yahoo:
                default:
                    minutesToCache = 20;
                    break;
            }

            WebCache.Set(key.ToString(), value, minutesToCache);
            
            return value;
        }        
    }
}