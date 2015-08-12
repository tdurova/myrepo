using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace php4dvdtests {
  [TestFixture()]
  public class Php4DvdTests {
    [Test()]
    public void LoginTest() {
        DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
        //Для подключения к saucelab
        /*capabilities.SetCapability("username", "kolersa");
        capabilities.SetCapability("accessKey", "8d5fcb61-3942-4421-b9c3-6bee8f0508ed");
        IWebDriver wd = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),capabilities);*/
        
        //Для подключения к удаленной машине
        IWebDriver wd = new RemoteWebDriver(new Uri("http://192.168.1.17:4444/wd/hub"), capabilities); 
      try {
        wd.Navigate().GoToUrl("http://192.168.1.3/php4dvd/");
        wd.FindElement(By.Id("username")).Click();
        wd.FindElement(By.Id("username")).Clear();
        wd.FindElement(By.Id("username")).SendKeys("admin");
        wd.FindElement(By.Name("password")).Click();
        wd.FindElement(By.Name("password")).Clear();
        wd.FindElement(By.Name("password")).SendKeys("admin");
        wd.FindElement(By.Name("submit")).Click();
        wd.FindElement(By.LinkText("Log out")).Click();
        wd.SwitchTo().Alert().Accept();
      } finally { wd.Quit(); }
    }
  }
}
