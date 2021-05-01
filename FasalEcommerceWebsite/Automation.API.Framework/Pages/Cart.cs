
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
namespace FasalEcommerceBDD.Pages
{
    class Cart
    {
		IWebDriver driver;
		[FindsBy(How = How.XPath, Using = "//a[@title='View my shopping cart']")]
		public IWebElement ViewCart;



		public void changecolor(IWebDriver driver)
        {
            IList<IWebElement> ColorList = driver.FindElements(By.XPath("//ul[@id='color_to_pick_list']/li")).ToList();



			for (int i=0; i< ColorList.Count; i++)
            {
				if(!ColorList[i].Selected )
                {
					ColorList[i].Click();
					break;

				}

            }

        }


		public void changesize(IWebDriver driver)
		{
			IWebElement sizeList = driver.FindElement(By.XPath("//select [@id='group_1']"));

			SelectElement selectList = new SelectElement(sizeList);
			IList<IWebElement> options = selectList.Options;


			for (int i = 0; i < options.Count; i++)
			{
				if (!options[i].Selected)
				{
					options[i].Click();
				}

			}

		}

		
		public void Addtocart( IWebDriver driver)
		{
			//categoryName: Women, Dresses, T-Shirts
			driver.FindElement(By.XPath("//button/span[contains(text(), 'Add to cart')]")).Click();
		}


		public void MouseovercartandselecProduct(IWebElement viewCart, string product, IWebDriver driver)
		{
			Actions builder = new Actions(driver);
			builder.MoveToElement(driver.FindElement(By.XPath("//a[@title='View my shopping cart']"))).Build().Perform();
			
			driver.Manage().Timeouts().ImplicitWait.Add(System.TimeSpan.FromSeconds(10));
			driver.FindElement(By.XPath("//a[@class='cart-images']/img[@alt='" + product + "']")).Click();
		}




		public Cart(IWebDriver driver)
		{

            this.driver = driver;
			
			
		}

	}
}
