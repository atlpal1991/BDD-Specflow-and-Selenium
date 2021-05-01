using System;
using FasalEcommerceBDD.HelperUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace FasalEcommerceBDD.Pages
{
    class CheckoutPage
    {
		IWebDriver driver;
		Helper world = new Helper();

		// Sign in
		public void SigninToOrder(String Email, String Password, IWebDriver driver)
		{
			driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(Email);
			driver.FindElement(By.XPath("//input[@id='passwd']")).SendKeys(Password);
			driver.FindElement(By.XPath("//button[@id='SubmitLogin']")).Click();
		}


		public IWebElement getInputFromcontrol(String inputID, IWebDriver driver)
		{
			return driver.FindElement(By.XPath("//input[@id='" + inputID + "']"));
		}

		public IWebElement getdropdowncontrol(String selectorID, IWebDriver driver)
		{
			// selectorID: days, months, years, id_state, id_country
			return driver.FindElement(By.XPath("//select[@id='" + selectorID + "']"));
		}

		public IWebElement GetAreaInput(String optionID, IWebDriver driver)
		{
			// optionID: newsletter, optin
			return driver.FindElement(By.XPath("//textarea[@id='" + optionID + "']"));
		}




		public void AddNewAddress(String company, String address1, String address2,
				String city, String state, String postCode, String country, String additionalInfo, String homePhone,
				String mobilePhone, String alias, IWebDriver driver)
		{
			driver.FindElement(By.XPath("//p[@class='address_add submit']//a[@title='Add']")).Click();

			IWebElement companyInput = this.getInputFromcontrol("company", driver);
			IWebElement address1Input = this.getInputFromcontrol("address1", driver);
			IWebElement address2Input = this.getInputFromcontrol("address2", driver);
			IWebElement cityInput = this.getInputFromcontrol("city", driver);
			IWebElement stateSelector = this.getdropdowncontrol("id_state", driver);
			IWebElement postCodeInput = this.getInputFromcontrol("postcode", driver);
			IWebElement countrySelector = this.getdropdowncontrol("id_country", driver);
			IWebElement additionalInfoInput = this.GetAreaInput("other", driver);
			IWebElement homePhoneInput = this.getInputFromcontrol("phone", driver);
			IWebElement mobilePhoneInput = this.getInputFromcontrol("phone_mobile", driver);
			IWebElement aliasInput = this.getInputFromcontrol("alias", driver);


			companyInput.Clear();
			companyInput.SendKeys(company);
			address1Input.Clear();
			address1Input.SendKeys(address1);
			address2Input.Clear();
			address2Input.SendKeys(address2);
			cityInput.Clear();
			cityInput.SendKeys(city);
			stateSelector.Click();
			stateSelector.SendKeys(state);
			postCodeInput.Clear();
			postCodeInput.SendKeys(postCode);
			countrySelector.Click();
			countrySelector.SendKeys(country);
			additionalInfoInput.Clear();
			additionalInfoInput.SendKeys(additionalInfo);
			homePhoneInput.Clear();
			homePhoneInput.SendKeys(homePhone);
			mobilePhoneInput.Clear();
			mobilePhoneInput.SendKeys(mobilePhone);
			aliasInput.Clear();
			aliasInput.SendKeys(alias);

			driver.FindElement(By.XPath("//button[@id='submitAddress']")).Click();
			
			driver.FindElement(By.XPath("//button[@name='processAddress']")).Click();

		}





		//Shipping

		[FindsBy(How = How.XPath, Using =  "//p[@class='checkbox']//label[contains(., 'I agree to the terms of service and will adhere to them unconditionally.')]")]
	public IWebElement termsOfServiceCheckbox;


		public void checkTermsOfServices(IWebDriver driver)
		{
			IWebElement termsOfServiceCheckbox = driver.FindElement(By.XPath("//p[@class='checkbox']//label[contains(., 'I agree to the terms of service and will adhere to them unconditionally.')]"));

			termsOfServiceCheckbox.Click();
			
		}

		//Payment

		public IWebElement getPaymentOption(String paymentOption, IWebDriver driver)
		{
			// paymentOption: Pay by bank wire, Pay by check
			return driver.FindElement(By.XPath("//p[@class='payment_module']//a[contains(text(),'" + paymentOption + "')]"));
		}

		public CheckoutPage(IWebDriver driver)
		{

			this.driver = driver;
		}
	}
}
