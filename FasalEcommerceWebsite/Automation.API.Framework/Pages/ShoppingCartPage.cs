using System;
using FasalEcommerceBDD.HelperUtils;
using OpenQA.Selenium;


namespace FasalEcommerceBDD.Pages
{
    class ShoppingCartPage
    {
		IWebDriver driver;

		Helper UniversalForSteps;


		//buttons: increase or decrease quantity, remove
		public IWebElement getButtonFromShoppingCart(String productName, String buttonClass, IWebDriver driver)
		{
			//buttonClass: minus, plus, trash 
			return driver.FindElement(
					By.XPath("//tr[.//a[contains(text(),'" + productName + "')]]//i[contains(@class,'" + buttonClass + "')]"));
		}

		public IWebElement getQuantityInput(String productName, IWebDriver driver)
		{
			return driver.FindElement(
					By.XPath("//tr[.//a[contains(text(),'" + productName + "')]]//input[contains(@class, 'cart_quantity_input')]"));
		}

		public IWebElement getAvailabilityInfoFromShoppingCart(String productName, IWebDriver driver)
		{
			return driver.FindElement(
					By.XPath("//tr[.//a[contains(text(),'" + productName + "')]]//span[contains(@class, 'label-success')]"));
		}

		public IWebElement getUnitOrTotalPriceOfProductInShoppingCart(String productName, String priceID, IWebDriver driver)
		{
			//priceID: product_price, total_product_price
			return driver.FindElement(
					By.XPath("//tr[.//a[contains(text(),'" + productName + "')]]//span[starts-with(@id, '" + priceID + "')]"));
		}

		public IWebElement getTotalPricesInShoppingCart(String productName, String totalPricesID, IWebDriver driver)
		{
			//totalCategoryID: total_product, total_shipping, total_price_without_tax, total_price
			return driver.FindElement(
					By.XPath("//td[@id='" + totalPricesID + "']"));
		}



		public ShoppingCartPage(IWebDriver driver)
		{

			this.driver = driver;
		}
	}
}
