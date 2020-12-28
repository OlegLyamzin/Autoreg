using Autoreg.SeleniumOperations;
using Autoreg.SeleniumOperations.OperationParameters;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Autoreg
{
    public class SeleniumManager
    {
        private OperationCreator _operations;
        private IWebDriver _driver;
        private Random _random;
        private SmsActivator _activator;

        public SeleniumManager(OperationCreator operations)
        {
            _operations = operations;
            _random = new Random();
            _activator = new SmsActivator();
        }

        public void Action(IOperationParameters parameters)
        {
            _operations[parameters].Action(parameters);
        }

        public void GMailRegistration()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.google.ru/";
            _driver.FindElement(By.XPath(".//a[@class='gb_je gb_4 gb_5c']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//div[@id='ow315']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//span[@class='z80M1 G3hhxb']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//input[@name='firstName']")).SendKeys("Сергей");
            Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//input[@name='lastName']")).SendKeys("Иванов");
            Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//input[@name='Username']")).Clear();
            Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//input[@name='Username']")).SendKeys("Ivanovsss561");

            Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElements(By.XPath(".//input[@type='password']"))[0].SendKeys("FdrGhTrE21");
            Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElements(By.XPath(".//input[@type='password']"))[1].SendKeys("FdrGhTrE21");
            Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            
            string phoneNumber = _activator.GetGMailPhoneNumber();
            _driver.FindElement(By.XPath(".//input[@id='phoneNumberId']")).SendKeys(phoneNumber);
            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            _activator.SetStatus(Constants.STATUSREADY);
            Thread.Sleep(_random.Next(2500, 5000));
            string code = null;
            while (code == null)
            {
                code = _activator.TryGetCodeActivation();
            }
            _driver.FindElement(By.XPath(".//input[@id='code']")).SendKeys(code);
            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            _driver.FindElement(By.XPath(".//input[@id='phoneNumberId']")).Clear();
            string emailRecovery = "email";
            _driver.FindElement(By.XPath(".//input[@name='recoveryEmail']")).SendKeys(emailRecovery);
            string dayBirth = "21";
            _driver.FindElement(By.XPath(".//input[@id='day']")).SendKeys(dayBirth);
            int month = 5;
            _driver.FindElement(By.XPath(".//select[@id='month']")).Click();
            _driver.FindElement(By.XPath($".//option[@value='{month}']")).Click();
            string year = "1999";
            _driver.FindElement(By.XPath(".//input[@id='year']")).SendKeys(year);
            int gender = 1;
            _driver.FindElement(By.XPath(".//select[@id='gender']")).Click();
            _driver.FindElement(By.XPath($".//option[@value='{gender}']")).Click();

            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            _driver.FindElement(By.XPath(".//div[@id='termsofserviceNext']")).Click();

        }
    }
}
