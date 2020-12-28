using Autoreg.SeleniumOperations;
using Autoreg.SeleniumOperations.OperationParameters;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
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

        public string GMailRegistration(Person person)
        {

            //Proxy proxy = new Proxy();
            //proxy.Kind = ProxyKind.Manual;
            //proxy.IsAutoDetect = false;
            //proxy.HttpProxy = "217.29.53.64:18564";
            //proxy.SslProxy = "217.29.53.64:18564";
            ////proxy.SocksProxy = "217.29.53.64:18564";
            ////proxy.SslProxy = "217.29.53.64:18564";
            ////proxy.SocksUserName = "kQSnxx";
            ////proxy.SocksPassword = "4rFmYy";
            ChromeOptions options = new ChromeOptions();
            //options.Proxy = proxy;
            options.AddArgument("--proxy-server=socks5://193.151.189.164:1085");
            //options.AddArgument("ignore-certificate-errors");
            //options.AddArgument("--no-sandbox");
            _driver = new ChromeDriver(options);
            _driver.Url = "https://accounts.google.com/signin/v2/identifier";
            //_driver.FindElement(By.XPath(".//a[@class='gb_je gb_4 gb_5c']")).Click();
            //Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//div[@id='ow315']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//span[@class='z80M1 G3hhxb']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));
            SendKeyToElement(_driver.FindElement(By.XPath(".//input[@name='firstName']")), person.FirstName);
            SendKeyToElement(_driver.FindElement(By.XPath(".//input[@name='lastName']")), person.LastName);
            //_driver.FindElement(By.XPath(".//input[@name='firstName']")).SendKeys(person.FirstName);
            //Thread.Sleep(_random.Next(2500, 5000));
            //_driver.FindElement(By.XPath(".//input[@name='lastName']")).SendKeys(person.LastName);
            //Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//input[@name='Username']")).Clear();
            Thread.Sleep(_random.Next(2500, 5000));

            SendKeyToElement(_driver.FindElement(By.XPath(".//input[@name='Username']")), person.Login);
            //_driver.FindElement(By.XPath(".//input[@name='Username']")).SendKeys(person.Login);
            //Thread.Sleep(_random.Next(2500, 5000));

            SendKeyToElement(_driver.FindElements(By.XPath(".//input[@type='password']"))[0], person.Password);
            SendKeyToElement(_driver.FindElements(By.XPath(".//input[@type='password']"))[1], person.Password);
            //_driver.FindElements(By.XPath(".//input[@type='password']"))[0].SendKeys(person.Password);
            //Thread.Sleep(_random.Next(2500, 5000));
            //_driver.FindElements(By.XPath(".//input[@type='password']"))[1].SendKeys(person.Password);
            //Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));

            person.PhoneNumber = _activator.GetGMailPhoneNumber();
            SendKeyToElement(_driver.FindElement(By.XPath(".//input[@id='phoneNumberId']")), person.PhoneNumber);
            //_driver.FindElement(By.XPath(".//input[@id='phoneNumberId']")).SendKeys(person.PhoneNumber);
            //Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            _activator.SetStatus(Constants.STATUSREADY);
            Thread.Sleep(_random.Next(2500, 5000));

            string code = null;
            while (code == null)
            {
                code = _activator.TryGetCodeActivation();
            }
            SendKeyToElement(_driver.FindElement(By.XPath(".//input[@id='code']")), code);
            //_driver.FindElement(By.XPath(".//input[@id='code']")).SendKeys(code);
            //Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//input[@id='phoneNumberId']")).Clear();
            Thread.Sleep(_random.Next(2500, 5000));

            SendKeyToElement(_driver.FindElement(By.XPath(".//input[@name='recoveryEmail']")), person.EmailRecovery);
            //_driver.FindElement(By.XPath(".//input[@name='recoveryEmail']")).SendKeys(person.EmailRecovery);
            //Thread.Sleep(_random.Next(2500, 5000));

            SendKeyToElement(_driver.FindElement(By.XPath(".//input[@id='day']")), person.DayBirthday);
            //_driver.FindElement(By.XPath(".//input[@id='day']")).SendKeys(person.DayBirthday);
            //Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//select[@id='month']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElement(By.XPath($".//option[@value='{person.MonthBirthday}']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));

            SendKeyToElement(_driver.FindElement(By.XPath(".//input[@id='year']")), person.YearBirthday);
            //_driver.FindElement(By.XPath(".//input[@id='year']")).SendKeys(person.YearBirthday);
            //Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//select[@id='gender']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));
            _driver.FindElements(By.XPath($".//option[@value='{person.Gender}']"))[1].Click();
            Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));

            //персонализация




            try
            {
            _driver.FindElement(By.XPath(".//div[@id='termsofserviceNext']")).Click();

            }
            catch (Exception e)
            {
                Personalization();
            _driver.FindElement(By.XPath(".//div[@id='termsofserviceNext']")).Click();
            }
            Thread.Sleep(_random.Next(2500, 5000));
            //_driver.Close();
            return person.ToString();
        }

        private void Personalization()
        {
            _driver.FindElement(By.XPath(".//div[@class='SLG1Fe rBUW7e']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));

            _driver.FindElement(By.XPath(".//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-INsAgc VfPpkd-LgbsSe-OWXEXe-dgl2Hf Rj2Mlf OLiIxf PDpWxe P62QJc xYnMae TrZEUc']")).Click();
            Thread.Sleep(_random.Next(2500, 5000));
        }

        private void SendKeyToElement(IWebElement element, string key)
        {
            for(int i = 0; i < key.Length; i++)
            {
                element.SendKeys($"{key[i]}");
                Thread.Sleep(_random.Next(250, 1000));
            }
            Thread.Sleep(_random.Next(2500, 5000));
        }
    }
}
