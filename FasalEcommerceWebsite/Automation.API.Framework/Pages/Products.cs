using System;
using FasalEcommerceBDD.HelperUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FasalEcommerceBDD.Pages
{
    public class Products
    {

		IWebDriver driver;
		Helper world = new Helper();

		// Product Successfully Added

		public IWebElement getButtonsFromProductInCategoryPage(String productName, String buttonTitle,
				IWebDriver driver)
		{
			// buttonTitle: Add to card, More
			return driver.FindElement(By.XPath("//div[@class='product-container'][.//a[contains(@title, '" + productName
					+ "')]]//div[@class='button-container']//a[contains(@title, '" + buttonTitle + "')]"));
		}


		// operations

		public string mouseoverActionOnProductPriceandreturnProduct(String price, IWebDriver driver)
		{
			Actions builder = new Actions(driver);
			IWebElement product = driver
					.FindElement(By.XPath("//div[(@itemprop='offers') and (@class='content_price')]/span[(@itemprop='price') and contains(text(), '$27')]/../../a"));
			string productName = product.GetAttribute("title");
			builder.MoveToElement(product).Build().Perform();
			world.implicityWait(10, driver);
			return productName;
		}


		public Products(IWebDriver driver)
		{
			this.driver = driver;
		}
	}
}
