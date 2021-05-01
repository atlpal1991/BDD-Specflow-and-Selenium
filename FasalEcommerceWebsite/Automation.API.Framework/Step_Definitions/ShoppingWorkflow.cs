using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using FasalEcommerceBDD.HelperUtils;
using FasalEcommerceBDD.Pages;
using TechTalk.SpecFlow.Assist;
using FasalEcommerceBDD.HelperUtils.Models;

namespace FasalEcommerceBDD.Step_Definitions
{
    [Binding]
    class ShoppingWorkflow
    {
        Helper world = new Helper();
        private IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        public ShoppingWorkflow(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)ScenarioContext.Current["driver"];

        }


        [Given(@"I am at home page")]
        public void GivenIAmAtHomePage()
        {
            
            world.navigateToPage(Properties.url, _driver);
            world.slowDown(1000);

        }

        [Given(@"selected (.*) categeory for shopping")]
        public void GivenSelectedCategeoryForShopping(string p0)
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.getMenuCatelogOnMainPage(p0, _driver).Click();
            world.implicityWait(10, _driver);
        }

        [Given(@"apply three filters (.*), (.*), (.*) and search for results")]
        public void GivenApplyThreeFiltersAndSearchForResults(string p0, string p1, string p2)
        {

            LeftMenu leftMenu = new LeftMenu(_driver);
            leftMenu.getCheckboxElementFromCatalogMenu(p0, _driver).Click();
            leftMenu.getCheckboxElementFromCatalogMenu(p1, _driver).Click();
            leftMenu.getCheckboxElementFromCatalogMenu(p2, _driver).Click();

        }

        [When(@"Add an item of worth (.*) and add to cart")]
        public void WhenAddAnItemOfWorthAndAddToCart(string p0)
        {
            Products P = new Products(_driver);
            string productName=P.mouseoverActionOnProductPriceandreturnProduct(p0, _driver);
            IWebElement addToBasketButton = P.getButtonsFromProductInCategoryPage(productName, "Add to cart", _driver);
            world.waitForElementToBeClickable(addToBasketButton, _driver);
            if (addToBasketButton.Displayed && addToBasketButton.Enabled)
            {
                world.clickOnElement(_driver, addToBasketButton);
            }
            world.implicityWait(10, _driver);


        }

        [Then(@"Item should be available in the cart")]
        public void ThenItemShouldBeAvailableInTheCart()
        {
            Cart c = new Cart(_driver);
            IWebElement ContinueShopping = _driver.FindElement(By.XPath("//div[@class='button-container']//span[.//span[contains(.,'Continue')]]//i"));

            world.waitForElementToBeClickable(ContinueShopping, _driver);
            ContinueShopping.Click();
            c.MouseovercartandselecProduct(c.ViewCart, "Blouse", _driver);

            //Change color
            c.changecolor(_driver);

            //Change size
            c.changesize(_driver);

            //Add one more item
            c.Addtocart(_driver);

            IWebElement Checkout = _driver.FindElement(By.XPath("//div[@class='button-container']//a[.//span[contains(.,'checkout')]]//i"));

            world.waitForElementToBeClickable(Checkout, _driver);
            Checkout.Click();

        }

        [When(@"Go to Cart Page and proceed to checkout")]
        public void WhenGoToCartPageAndProceedToCheckout()
        {
            _driver.FindElement(By.XPath("//*[@id='center_column']/p[2]/a[1]")).Click();
            
        }

        [When(@"Enter username password, Address , Shipping_Details  and  Enter Address Shipping details")]
        public void WhenEnterUsernamePasswordAddressShipping_DetailsAndEnterAddressShippingDetails(Table table)
        {
            var a= table.CreateInstance<Login>();
            CheckoutPage checkout = new CheckoutPage(_driver);
            checkout.SigninToOrder(a.email, a.password,  _driver);


            String company = "Fasal";
            String address1 = "Dummy1";
            String address2 = "Dummy2";
            String city = "testCity";
            String state = "Florida";
            String postCode = "00005";
            String country = "United States";
            String additionalInfo = "";
            String homePhone = "1234567890";
            String mobilePhone = "";
            String alias = Helper.RandomString(10).ToString();
            

        checkout.AddNewAddress(company, address1, address2,
                 city, state, postCode, country, additionalInfo, homePhone,
                 mobilePhone, alias, _driver);

            //Select Address


            //


        }


        [When(@"Go to payment page and select payment type and proceed")]
        public void WhenGoToPaymentPageAndSelectPaymentTypeAndProceed()
        {
            CheckoutPage checkout = new CheckoutPage(_driver);
            //Add Shipping details
            checkout.checkTermsOfServices(_driver);

            //proceed to checkout
            _driver.FindElement(By.XPath("//button[@name='processCarrier']")).Click();

            checkout.getPaymentOption("Pay by bank wire", _driver);


//            _driver.FindElement(By.XPath("//button[@class='button btn btn-default button-medium']")).Click();
        }

        [Then(@"read the message in the final order confirmation summary page")]
        public void ThenReadTheMessageInTheFinalOrderConfirmationSummaryPage()
        {
            Console.WriteLine("This does not ask for payment details.");
        }






    }
}
