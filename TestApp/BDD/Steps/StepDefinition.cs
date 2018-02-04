using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestApp.BDD.POM;

namespace TestApp.BDD.FeatureFile
{
    [Binding]
    public sealed class StepDefinition
    {
        IWebDriver driver = new ChromeDriver();

        [Given(@"we are able to access the url")]
        public void GivenWeAreAbleToAccessTheUrl()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://hotel-test.equalexperts.io/");
            
        }

        [When(@"I am able to save the details (.*) (.*) (.*) (.*)")]
        public void WhenIAmAbleToSaveTheDetails(string name, string lastname, int price, string deppaid)
        {
            int RowCount;

            helpers h = new helpers();
            string checkindate = h.GeCheckIntDate();
            string checkoutdate = h.GeCheckOutDate();        
            Page p = new Page();
            RowCount = p.EnterText(driver, name, lastname, price, deppaid, checkindate, checkoutdate);
            p.ReadElements(driver, name, lastname, price, RowCount);


        }

        [Then(@"Application works fine")]
        public void ThenApplicationWorksFine()
        {
            driver.Close();
        }        

        [Given(@"I am able to delete specific bookings (.*) (.*) (.*)")]
        public void GivenIAmAbleToDeleteSpecificBookings(string name, string lastname, int price)
        {
            Page p = new Page();
            p.ReadElements(driver, name, lastname, price, price);
            p.DeleteBookings(driver, name, lastname, price);              
        }

    }
}
