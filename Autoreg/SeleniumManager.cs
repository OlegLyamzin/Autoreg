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
        private Random random;
        private SmsActivator activator;

        public SeleniumManager(OperationCreator operations)
        {
            _operations = operations;
            random = new Random();
        }

        public void Action(IOperationParameters parameters)
        {
            _operations[parameters].Action(parameters);
        }

        public void Registration()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.google.ru/";
            _driver.FindElement(By.XPath(".//a[@class='gb_je gb_4 gb_5c']")).Click();
            Thread.Sleep(random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//div[@id='ow315']")).Click();
            Thread.Sleep(random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//span[@class='z80M1 G3hhxb']")).Click();
            Thread.Sleep(random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//input[@name='firstName']")).SendKeys("Иван");
            Thread.Sleep(random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//input[@name='lastName']")).SendKeys("Иванов");
            Thread.Sleep(random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//input[@name='Username']")).Clear();
            Thread.Sleep(random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//input[@name='Username']")).SendKeys("Ivanov564839");

            Thread.Sleep(random.Next(2500, 5000));
            _driver.FindElements(By.XPath(".//input[@type='password']"))[0].SendKeys("Cthdth2102");
            Thread.Sleep(random.Next(2500, 5000));

            _driver.FindElements(By.XPath(".//input[@type='password']"))[1].SendKeys("Cthdth2102");
            Thread.Sleep(random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            String phoneNumber = activator.GetAmountGMailPhoneNumber();
        }
    }
}
