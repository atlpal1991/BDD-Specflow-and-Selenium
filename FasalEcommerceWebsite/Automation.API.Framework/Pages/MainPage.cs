using System;
using OpenQA.Selenium;



namespace FasalEcommerceBDD.Pages
{
    class MainPage
    {

		IWebDriver driver;


		public IWebElement getMenuCatelogOnMainPage(String MenuTitle, IWebDriver driver)
		{

			return driver.FindElement(By.XPath("//div[@id='block_top_menu']//li//a[contains(text(), '" + MenuTitle + "')]"));
		}


		public MainPage(IWebDriver driver)
		{

			this.driver = driver;
		}
	}
}
