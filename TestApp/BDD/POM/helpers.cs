using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.BDD.POM
{
    public class helpers
    {
        public string GeCheckIntDate()
        {
            DateTime today = DateTime.Now;
            string checkindate = today.ToString("yyyy-MM-dd");
            return checkindate;
        }

        public string GeCheckOutDate()
        {
            DateTime today = DateTime.Now;
            DateTime tomorrow = today.AddDays(5);
            string checkoutdate = tomorrow.ToString("yyyy-MM-dd");
            return checkoutdate;
        }

        public void WaitforPage(IWebDriver driver)
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) => { return false; } );

            //wait.Until(waitForElement);
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='form']/div/div[7]")));
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("pagewait")));

            }
            catch (Exception)
            {
                Console.WriteLine("waiting for page to load");
            }


        }

    }


}
