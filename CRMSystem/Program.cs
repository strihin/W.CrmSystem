using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CRMSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();// new ChromeDriver();
            WebDriverWait  _waitDriver = new WebDriverWait(driver, TimeSpan.FromSeconds(11));
            driver.Navigate().GoToUrl("http://crm.altsolution.ua/clients");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("admin@altsolution.net");
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("admin");
            IWebElement submit = driver.FindElement(By.Id("primari-login-submit"));
            submit.Click();

            driver.Navigate().GoToUrl("http://crm.altsolution.ua/clients/add");

           
            for (int i = 0; i < 180; i++)
            {
                IWebElement companyName = _waitDriver.Until(m => m.FindElement(By.Name("name")));
                IWebElement companyPhone = _waitDriver.Until(m => m.FindElement(By.Id("phone")));
                IWebElement companyEmail = _waitDriver.Until(m => m.FindElement(By.Id("email")));
                IWebElement companySubmit = _waitDriver.Until(m => m.FindElement(By.Name("submit")));
               
                var name = Faker.Company.Name();
                var phone = Faker.Phone.Number()+"0000";
                var emailInput = Faker.Internet.Email();

                companyName.Click();
                companyName.SendKeys(name);
                companyPhone.SendKeys(phone);
                companyEmail.SendKeys(emailInput);
                companySubmit.Click();

                Thread.Sleep(1000);
                driver.Navigate().GoToUrl("http://crm.altsolution.ua/clients/add");
            }
            
        }
    }
}
