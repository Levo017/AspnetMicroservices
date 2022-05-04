using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCahce;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCahce = redisCache;
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCahce.RemoveAsync(userName);
        }

        public async Task<ShoppingCart?> GetBasket(string userName)
        {
            var basket = await _redisCahce.GetStringAsync(userName);
            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart?> UpdateBasket(ShoppingCart basket)
        {
            var basketString = JsonConvert.SerializeObject(basket);
            await _redisCahce.SetStringAsync(basket.UserName, basketString);

            return await GetBasket(basket.UserName);
        }
    }
}
