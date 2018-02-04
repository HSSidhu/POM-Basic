using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestApp.BDD.POM
{
    class Page
    {
        public int EnterText(IWebDriver driver, string name, string lastname, int price , string deppaid, string checkindate, string checkoutdate)
        {
            int _totalrows;

            helpers h = new helpers();
            h.WaitforPage(driver);

            IWebElement table = driver.FindElement(By.Id("bookings"));
            IList<IWebElement> rows = table.FindElements(By.ClassName("row"));
            _totalrows = rows.Count;            

            driver.FindElement(By.Id("firstname")).SendKeys(name);
            driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            driver.FindElement(By.Id("totalprice")).SendKeys("120");
            driver.FindElement(By.XPath(".//*[@id='checkin']")).SendKeys(checkindate);
            driver.FindElement(By.XPath(".//*[@id='checkout']")).SendKeys(checkoutdate);
            if (deppaid == "yes")
           
                driver.FindElement(By.XPath(".//*[@id='depositpaid']/option[1]")).Click();
            else 
                driver.FindElement(By.XPath(".//*[@id='depositpaid']/option[2]")).Click();

            driver.FindElement(By.XPath(".//*[@id='form']/div/div[7]")).Click();

            return _totalrows;
        }

        public int RowsCount(IWebDriver driver)
        {
            int _totalrows;

            IWebElement table = driver.FindElement(By.Id("bookings"));
            IList<IWebElement> rows = table.FindElements(By.ClassName("row"));

            _totalrows = rows.Count;
            return _totalrows;

        }
        public void ReadElements(IWebDriver driver, string name, string lastname, int price, int RowCount)
        {
            int _totalrows;
            Boolean result = false;

            helpers h = new helpers();
            h.WaitforPage(driver);

            IWebElement table = driver.FindElement(By.Id("bookings"));
            IList<IWebElement> rows = table.FindElements(By.ClassName("row"));
            _totalrows = rows.Count;

            while (_totalrows <= RowCount)
            {
                IWebElement table1 = driver.FindElement(By.Id("bookings"));
                IList<IWebElement> rows1 = table.FindElements(By.ClassName("row"));
                _totalrows = rows1.Count;
            }

            foreach (IWebElement row in rows)
            {
                string[] elems = row.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if (elems[2] != "Price")
                {
                    string fname = elems[0];
                    string sname = elems[1];
                    int p = Convert.ToInt32(elems[2]);

                    if (name == fname & lastname == sname & price == p)
                    {
                        result = true;
                    }
                }
            }


            if (result is true)
                Console.Out.WriteLine("Booking exists");
            else
                Console.Out.WriteLine("Booking does not Exist. Please check before proceeding");
           
        }
        public void DeleteBookings(IWebDriver driver, string name, string lastname, int price)
        {

            helpers h = new helpers();
            h.WaitforPage(driver);


            IWebElement table = driver.FindElement(By.Id("bookings"));
            IList<IWebElement> rows = table.FindElements(By.ClassName("row"));

            foreach(IWebElement row in rows)
            {
                string[] elems = row.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if (elems[2] != "Price")
                {
                    string fname = elems[0];
                    string sname = elems[1];
                    int p = Convert.ToInt32(elems[2]);

                    if (name == fname & lastname == sname & price == p)
                    {
                        row.FindElement(By.TagName("input")).Click();
                        Console.WriteLine("Row deleted successfully");
                    }

                }   

            }

        }
    }
}
