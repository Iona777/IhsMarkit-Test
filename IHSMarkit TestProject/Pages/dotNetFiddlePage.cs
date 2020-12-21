using OpenQA.Selenium;
using IHSMarkit_TestProject.Utilities;

namespace IHSMarkit_TestProject.Pages
{
    public class dotNetFiddlePage: BasePage
    {
        string dotNetFiddlePageURL = null;

        //Element locators
        private readonly By runButtonLocator = By.Id("run-button");
        private readonly By outputWindowLocator = By.ClassName("cm-string");
        private readonly By shareButtonLocator = By.Id("Share");
        private readonly By shareLinkLocator = By.Id("ShareLink");      
        private readonly By packageNameInputLocator = By.XPath("//*[@placeholder='Package name...']");
        private readonly By nUnitPackageLocator = By.XPath("//*[@package-id='NUnit'][@role='menuitem']");
        private readonly By nUnitVersionLocator = By.XPath("//*[@package-id='NUnit'][@version-name='3.12.0.0']");
        private readonly By nUnitVersionTickLocator = By.XPath("//*[@package-id='NUnit'][@version-name='3.12.0.0']/i");
        private readonly By deletePackageLocator = By.ClassName("delete-package");
        private readonly By optionsPanel = By.XPath("//*[@class='sidebar unselectable']");
        private readonly By sideBarToggle = By.XPath("//*[@class='btn btn-default btn-xs btn-sidebar-toggle']");
        private readonly By saveButtonLocator = By.Id("save-button");
        private readonly By loginModalLocator = By.Id("login-modal-label");
        private readonly By gettingStartedButtonLocator = By.CssSelector("[href='/GettingStarted/']");
        private readonly By backToEditorLocator = By.CssSelector("[class='btn btn-default'][href='/']");
                

        public void ClickRunButton()
        {
            ClickOnElement(runButtonLocator);
        }

                
        public string GetOutputText()
        {
            return GetVisibleElementByLocator(outputWindowLocator).Text;
        }


        public void SelectNuGetPackage()
        {
            ClickOnElement(packageNameInputLocator);
            EnterText(packageNameInputLocator, "nunit");
            ClickOnElement(nUnitPackageLocator);
            ClickOnElement(nUnitVersionLocator);

        }

        public bool CheckNunitPackageVersionIsTicked()
        {
            ClickOnElement(deletePackageLocator);
            ClickOnElement(packageNameInputLocator);
            EnterText(packageNameInputLocator, "nunit");
            ClickOnElement(nUnitPackageLocator);
                       
            return GetVisibleElementByLocator(nUnitVersionTickLocator).Displayed; 
        }


        //Although we wait for the element to be visible, the code to set the value may
        //take a moment to run, so we have to wait for it.
        public bool CheckShareLinkValue(string expectedValue)
        {
            var value = GetVisibleElementByLocator(shareLinkLocator).GetAttribute("value");

            for (int i = 0; i < 200; i++)
            {
                if (value.StartsWith(expectedValue))
                {
                    return true;
                }
                
                Driver.Pause(10); 
                value = GetVisibleElementByLocator(shareLinkLocator).GetAttribute("value");   
            }
            return false;
        }

        
        public void ClickShareButton()
        {
            ClickOnElement(shareButtonLocator);
        }

        public void HideOptionsPanel()
        {
            ClickOnElement(sideBarToggle);
        }

        public bool CheckIfOptionsPanelDisplayed()
        {
            //Element does not have normal 'displayed' attribute to check for visibility in normal way
            var styleValue = GetVisibleElementByLocator(optionsPanel).GetAttribute("style");

            for (int i = 0; i < 200; i++)
            {
                if (styleValue.Equals("left: -180px;"))
                {
                    return false;  //Element is hidden 
                }

                Driver.Pause(10);
                styleValue = GetVisibleElementByLocator(optionsPanel).GetAttribute("style");
            }
            return true; //Element is displayed
        }

        public void ClickSaveButton()
        {
            ClickOnElement(saveButtonLocator);
        }


        public bool CheckIfLoginModalDisplayed()
        {
            SwitchWindowFirstFrame();
            return GetVisibleElementByLocator(loginModalLocator).Displayed;
        }


        public void ClickGettingStartedButton()
        {
            ClickOnElement(gettingStartedButtonLocator);
        }

        public bool CheckIfBackToEditorDisplayed()
        {
            return GetVisibleElementByLocator(backToEditorLocator).Displayed;
        }
    }
}
