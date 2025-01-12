﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace HomeOffCine.Tests.TesteAutomatizado.Config;

public static class WebDriverFactory
{
    public static IWebDriver CreateWebDriver(string browser, string caminhoDriver, bool headless)
    {
        IWebDriver webDriver = null;

        switch (browser)
        {
            case "Firefox":
                var optionsFireFox = new FirefoxOptions();
                if (headless)
                    optionsFireFox.AddArgument("--headless");

                webDriver = new FirefoxDriver(caminhoDriver, optionsFireFox);

                break;
            case "Chrome":
                var options = new ChromeOptions();
                if (headless)
                    options.AddArgument("--headless");

                webDriver = new ChromeDriver(caminhoDriver, options);

                break;
        }

        return webDriver;
    }
}