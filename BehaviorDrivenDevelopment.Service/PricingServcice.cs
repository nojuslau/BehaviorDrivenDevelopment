using System.Reflection.Metadata;

namespace BehaviorDrivenDevelopment.Service
{
    public interface IPricingService
    {
        decimal GetBasketTotalAmount(Basket basket);
    }

    public class PricingService : IPricingService
    {
        public decimal GetBasketTotalAmount(Basket basket)
        {
            if(!basket.products.Any())
            {
                return 0;
            }

            var basketValue = basket.products.Sum(x => x.price);

            if (basket.user.isLoggedIn)
            {
                return basketValue - (basketValue * 0.05m);
            }

            return basketValue;
        }
    }

    public class Basket
    {
        public User user { get; init; }
        public List<Product> products { get; } = new();
    }

    public class Product 
    {
        public string name { get; init; }
        public decimal price { get; init; }
    }

    public class  User
    {
        public string userName { get; init; }
        public string password { get; init; }
        public bool isLoggedIn { get; init; }
    }
}
