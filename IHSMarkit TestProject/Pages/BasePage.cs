using OpenQA.Selenium;
using IHSMarkit_TestProject.Utilities;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace IHSMarkit_TestProject.Pages
{
    public class BasePage
    {
        private IWebDriver baseDriver;
        private WebDriverWait baseWait;

        //Constructor
        public BasePage()
        {
            //Both of these can now be inherited by all the pages inheriting fron BasePage
            baseDriver = Driver.TheDriver;
            baseWait = Driver.TheWait;
        }

        /// <summary>
        /// Waits for, then returns, a clickable element
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <returns>IWebElement</returns>
        public IWebElement GetClickableElement(By elementLocator)
        {
            return baseWait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }

        /// <summary>
        /// Waits for, then retuns, a visible element 
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <returns>IWebElement</returns>
        public IWebElement GetVisibleElementByLocator(By elementLocator)
        {
            return baseWait.Until(ExpectedConditions.ElementIsVisible(elementLocator)); ;
        }

        /// <summary>
        /// Waits for element of given locator to be clickable then clicks on it.
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        public void ClickOnElement(By elementLocator)
        {
            GetClickableElement(elementLocator).Click();
        }

        /// <summary>
        /// Waits for an element to be clickable and enters the given value in it. Will also clear it, if clear set to true
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="value">Value to enter in element</param>
        /// <param name="clear">Clears element if set to true. Defaults to false</param>
        public void EnterText(By elementLocator, string value, bool? clear = false)
        {
            var element = GetClickableElement(elementLocator);
            if (clear == true)
                element.Clear();

            element.SendKeys(value);
        }

        // <summary>
        /// Switches focus to the first frame
        /// </summary>
        public void SwitchWindowFirstFrame()
        {
            baseDriver.SwitchTo().Window(baseDriver.WindowHandles.First());
        }
    }

}
