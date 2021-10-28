﻿using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using SpecFlow.Actions.Appium.Configuration.Appium;
using SpecFlow.Actions.Appium.Configuration.WindowsAppDriver;
using System;

namespace SpecFlow.Actions.Appium
{
    internal class DriverFactory : IDriverFactory
    {
        public AndroidDriver<AndroidElement> GetAndroidDriver(IAppiumServer appiumServer, IDriverOptions driverOptions, IAppiumConfiguration appiumConfiguration)
        {
            return appiumConfiguration.LocalAppiumServerRequired

                ? new AndroidDriver<AndroidElement>(appiumServer.Current, driverOptions.Current,
                    TimeSpan.FromSeconds(appiumConfiguration.Timeout ?? 30))

                : new AndroidDriver<AndroidElement>(appiumConfiguration.ServerAddress, driverOptions.Current,
                    TimeSpan.FromSeconds(appiumConfiguration.Timeout ?? 30));
        }

        public void GetXCUITestDriver()
        {
            throw new NotImplementedException("XCUITestDriver not yet implemented");
        }

        public void GetEspressoDriver()
        {
            throw new NotImplementedException("EspressoDriver not yet implemented");
        }

        public WindowsDriver<WindowsElement> GetWindowsAppDriver(IWindowsAppDriverConfiguration windowsAppDriverConfiguration, IDriverOptions driverOptions, Uri driverUrl)
        {
            return new WindowsDriver<WindowsElement>(driverUrl, driverOptions.Current);
        }

        public void GetMacDriver()
        {
            throw new NotImplementedException("MacDriver not yet implemented");
        }
    }
}