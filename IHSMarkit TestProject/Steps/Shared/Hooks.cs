using IHSMarkit_TestProject.Utilities;
using TechTalk.SpecFlow;

namespace IHSMarkit_TestProject.Steps.Shared
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario()]
        public static void Setup()
        {
            //Using appsettings.QA.json for settings
            Driver.BaseUrl = Driver.GetBaseUrl();
            Driver.DefaultTimeout = Driver.GetTimeouSeconds();
            Driver.OpenBrowser(Driver.GetBrowser());
            Driver.NavigateTo(Driver.BaseUrl);
            Driver.CheckPageTitle(Driver.GetBasePageTitle());
        }    

        [AfterScenario()]
        public static void ShutDown()
        {
            Driver.ShutDown();
        }
    }
}
