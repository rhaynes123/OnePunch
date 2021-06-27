using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace OnePunchUITests
{
    public class OnePunchUITests
    {
        private readonly IWebDriver driver;
        private readonly FirefoxOptions firefoxOptions = new ();
        private const string DefaultTestUrl = "https://localhost:5001/";
        public OnePunchUITests()
        {
            firefoxOptions.AcceptInsecureCertificates = true;
            driver = new FirefoxDriver(firefoxOptions);
        }

        [Fact]
        public void BasicIndexPageTest()
        {
            SetUp(DefaultTestUrl);
            Thread.Sleep(3000);
            TearDown();
        }

        [Fact]
        public void TestLoginLogOut()
        {
           
            try
            {
                SetUp($"{DefaultTestUrl}Identity/Account/Login?ReturnUrl=%2F");
                driver.Manage().Window.Size = new System.Drawing.Size(1500, 1500);
                Thread.Sleep(TimeSpan.FromSeconds(20));
                driver.FindElement(By.CssSelector(".btn")).Click();
                driver.FindElement(By.CssSelector(".btn-link")).Click();
                driver.Manage().Window.Size = new System.Drawing.Size(1500, 1500);
            }
            finally
            {
                TearDown();
            }
        }
        [Fact]
        public void TestIfUserIsAdmin()
        {

            try
            {
                SetUp($"{DefaultTestUrl}Identity/Account/Login?ReturnUrl=%2F");
                driver.Manage().Window.Size = new System.Drawing.Size(1500, 1500);
                Thread.Sleep(TimeSpan.FromSeconds(30));
                
                IWebElement username = driver.FindElement(By.Id("Input_Email"));
                
                driver.FindElement(By.CssSelector(".btn")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));
                driver.FindElement(By.LinkText($"Hello {username.Text}!")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));
                IWebElement AdminCheckBox = driver.FindElement(By.Id("Input_IsAdmin"));
                if (AdminCheckBox.Displayed && AdminCheckBox.Selected)
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.False(true);
                }
            }
            catch (Exception)
            {
                Assert.False(true);
                TearDown();
            }
            finally
            {
                TearDown();
            }
        }
        private void SetUp(string TestUrl)
        {
            try
            {
                driver.Navigate().GoToUrl(TestUrl);
            }
            catch(Exception)
            {
                driver.Quit();
            }
            
        }

        private void TearDown()
        {
            driver.Quit();
        }
    }
}
