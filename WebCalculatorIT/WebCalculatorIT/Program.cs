using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalculatorIT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            IWebDriver chromedriver = new ChromeDriver();
            chromedriver.Navigate().GoToUrl("https://www.google.com/");
            IWebElement inputveld = chromedriver.FindElement(By.Name("q"));
            inputveld.SendKeys("Weer");
            IWebElement knopzoeken = chromedriver.FindElement(By.Name("btnK"));
            knopzoeken.Click();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}