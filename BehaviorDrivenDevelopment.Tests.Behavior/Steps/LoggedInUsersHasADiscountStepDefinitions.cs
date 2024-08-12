using BehaviorDrivenDevelopment.Service;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BehaviorDrivenDevelopment.Tests.Behavior.Steps
{
    [Binding]
    public class LoggedInUsersHasADiscountStepDefinitions
    {
        private User _user;
        private Basket _basket;
        private List<Product> _products;
        private readonly IPricingService _pricingServcice = new PricingService();

        [Given(@"a user that is not logged in")]
        public void GivenAUserThatIsNotLoggedIn()
        {
            _user = new User
            {
                isLoggedIn = false
            };
        }

        [Given(@"an empty basket")]
        public void GivenAnEmptyBasket()
        {
            _basket = new Basket
            {
                user = _user
            }; 
        }

        [Then(@"the basket value is (.*) EUR")]
        public void ThenTheBasketValueIsEUR(decimal expectedBasketValue)
        {
            var basketValue = _pricingServcice.GetBasketTotalAmount(_basket);
            basketValue.Should().Be(expectedBasketValue);
        }

        [Given(@"a user that is logged in")]
        public void GivenAUserThatIsLoggedIn()
        {
            _user = new User
            {
                isLoggedIn = true
            };
        }

        [When(@"a (.*) that costs (.*) EUR is added to the basket")]
        public void WhenAT_ShirtThatCostsEURIsAddedToTheBasket(string itenName, int p0)
        {
            _basket.products.Add(new Product
            {
                name = itenName,
                price = p0,
            });
        }
    }
}
