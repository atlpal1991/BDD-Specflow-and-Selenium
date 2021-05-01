using System;
using OpenQA.Selenium;


namespace FasalEcommerceBDD.Pages
{
    class LeftMenu
    {
		IWebDriver driver;

		public IWebElement getCheckboxElementFromCatalogMenu(String checkboxName, IWebDriver driver)
		{

			return driver.FindElement(
					By.XPath("//div[contains(@class, 'layered_filter')]//label//a[contains(text(), '" + checkboxName + "')]"));
		}


            public LeftMenu(IWebDriver driver)
		{

			this.driver = driver;
		}
	}
}
