using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace FasalEcommerceBDD.HelperUtils
{
    public class Helper
    {

		public void navigateToPage(String url, IWebDriver driver)
		{
			driver.Navigate().GoToUrl(url);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait.Add(System.TimeSpan.FromSeconds(10));
			//ImplicitWait(10, TimeUnit.SECONDS);
			String urlCheck = driver.Url;
			driver.Manage().Timeouts().ImplicitWait.Add(System.TimeSpan.FromSeconds(10));
			//Assert.Equals(url, urlCheck);
		}

		public void slowDown(int miliseconds)
		{
			try
			{
				Thread.Sleep(miliseconds);
			}
			catch (Exception e)
			{
				//e.StackTrace()
			}

		}


		public void implicityWait(int time, IWebDriver driver)
		{
			driver.Manage().Timeouts().ImplicitWait.Add(System.TimeSpan.FromSeconds(time));

		}

		public void waitForElementToBeClickable(IWebElement element, IWebDriver driver)
		{

			WebDriverWait webDriverWait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
			webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));

		}

		public void clickOnElement(IWebDriver driver, IWebElement element)
		{
			Actions actions = new Actions(driver);
			actions.MoveToElement(element).Click().Build().Perform();
		}

		public static string RandomString(int length)
		{
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var stringChars = new char[length];
			var random = new Random();

			for (int i = 0; i < stringChars.Length; i++)
			{
				stringChars[i] = chars[random.Next(chars.Length)];
			}

			var finalString = new String(stringChars);
				return finalString;
		}
	}
}
