using System;
using TechTalk.SpecFlow;
using IHSMarkit_TestProject.Pages;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IHSMarkit_TestProject.Steps
{
    [Binding]
    class ihsStepDefinitions
    {
        //Declare page object(s)
        private readonly dotNetFiddlePage theDotNetFiddlePage;

        ihsStepDefinitions()
        {
           //Instantiate page object(s)
           theDotNetFiddlePage = new dotNetFiddlePage(); 
        }
                
        [Given(@"that I click on the Run button")]
        public void GivenThatIClickOnTheRunButton()
        {
            //Page elements should not be exposed outside of the page object
            //so they are accessed via their own methods in the page object
            theDotNetFiddlePage.ClickRunButton();
        }

        [Then(@"the text ""(.*)"" is displayed")]
        public void ThenTheTextIsDisplayed(string expectedText)
        {
          Assert.AreEqual(expectedText, theDotNetFiddlePage.GetOutputText());
                      
        }

               
        [Given(@"user name is ""(.*)"" I take the action for that name")]
        public void GivenUserNameIsITakeTheActionForThatName(string name)
        {
            Char firstChar = name[0];

            switch (firstChar.ToString().ToUpper())
            {
                case "A":
                case "B":
                case "C":
                case "D":
                case "E":
                    theDotNetFiddlePage.SelectNuGetPackage();
                    break;
                case "F":
                case "G":
                case "H":
                case "K":
                    theDotNetFiddlePage.ClickShareButton();
                    break;
                case "L":
                case "M":
                case "N":
                case "P":
                    theDotNetFiddlePage.HideOptionsPanel();
                    break;
                case "Q":
                case "R":
                case "S":
                case "T":
                case "U":
                    theDotNetFiddlePage.ClickSaveButton();
                    break;
                case "V":
                case "W":
                case "X":
                case "Y":
                case "Z":
                    theDotNetFiddlePage.ClickGettingStartedButton();
                    break;
                default:
                    Debug.Print("Unknown character");
                    break;
            }

        }


        [Then(@"I get outcome for ""(.*)""")]
        public void ThenIGetOutcomeFor(string name)
        {
            Char firstChar = name[0];
            string expectedLinkText = "https://dotnetfiddle.net/";

            switch (firstChar.ToString().ToUpper())
            {
                case "A":
                case "B":
                case "C":
                case "D":
                case "E":
                    Assert.IsTrue(theDotNetFiddlePage.CheckNunitPackageVersionIsTicked()
                        ,"nUnit package version not ticked");
                    break;
                case "F":
                case "G":
                case "H":
                case "K":
                    Assert.IsTrue(theDotNetFiddlePage.CheckShareLinkValue(expectedLinkText)
                        ,"Share link value wrong");
                    break;
                case "L":
                case "M":
                case "N":
                case "P":
                    Assert.IsFalse(theDotNetFiddlePage.CheckIfOptionsPanelDisplayed()
                        ,"Options panel not hidded"  );
                    break;
                case "Q":
                case "R":
                case "S":
                case "T":
                case "U":
                    Assert.IsTrue(theDotNetFiddlePage.CheckIfLoginModalDisplayed()
                        ,"Login modal is not displayed");
                    break;
                case "V":
                case "W":
                case "X":
                case "Y":
                case "Z":
                    Assert.IsTrue(theDotNetFiddlePage.CheckIfBackToEditorDisplayed()
                        ,"Back to Editor button is not displayed");
                    break;
                default:
                    Debug.Print("Unknown character");
                    break;

            }

        }
    }
}
