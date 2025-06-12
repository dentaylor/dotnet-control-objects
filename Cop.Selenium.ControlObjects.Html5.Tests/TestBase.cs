using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using System;
using System.Diagnostics;

namespace Cop.Selenium.ControlObjects.Html5.Tests;

/// <summary>
/// Base class for all Control Object test classes. 
/// </summary>
/// <typeparam name="TControlObject">
/// The type of the control object under test. This should be a class representing a specific UI control
/// (such as a textbox, button, dropdown, etc.) that provides methods and properties to interact with and
/// verify the state of that control via Selenium WebDriver. The type must have a constructor accepting an
/// <see cref="IWebElement"/> as its parameter.
/// </typeparam>
public abstract class TestBase<TControlObject>
{
    private TestRunTimer _runTimer;

    // MsTest provides this property.
    public TestContext TestContext { get; set; }

    // The locator for the control element on the page under test.
    protected abstract By Locator { get; }

    protected IWebDriver Driver { get; set; }

    protected TControlObject ControlObjectOld => (TControlObject)Activator.CreateInstance(typeof(TControlObject), Driver.FindElement(Locator));

    protected TControlObject ControlObject
    {
        get
        {
            var rootElement = Driver.FindElement(Locator);
            var adapter = new SeleniumAdapter(Driver, rootElement);
            var controlObject = Activator.CreateInstance(typeof(TControlObject), adapter);
            return (TControlObject)controlObject;
        }
    }

    /// <summary>
    /// Sets up the test environment. 
    /// </summary>
    /// <param name="page">
    /// The relative URL or page identifier to navigate to, appended to the base URL. 
    /// For Razor Pages, this typically matches the page route or name (e.g., "Index", "Contact", "progress").
    /// </param>
    /// <param name="locator">
    /// The Selenium <see cref="By"/> locator used to find the specific control element on the page under test.
    /// </param>
    public void LaunchAndNavigateToPage(string page)
    {
        _runTimer = TestRunTimer.StartNew();
        _runTimer.InitializationStart();

        var url = TestContext.Properties["autUrl"]?.ToString()
            ?? throw new InvalidOperationException("The 'autUrl' property is not set. Ensure that a runsettings file is selected.");

        Driver = new ChromeDriver();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        Driver.Manage().Window.Maximize();

        Driver.Navigate().GoToUrl(url + page);

        _runTimer.InitializationStop();
    }

    [TestCleanup]
    public void Cleanup()
    {
        _runTimer.CleanupStart();

        // This allows for inspection of the browser state when a test fails.
        if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
        {
            Driver?.Quit();
        }

        _runTimer.CleanupStop();
        _runTimer.Stop();
        _runTimer.WriteToConsole();
    }

    /// <summary>
    /// Removes the specified attribute from the control using JavaScript.      
    /// </summary>
    /// <param name="attributeName"></param>
    protected void RemoveAttribute(string elementAttribute)
    {
        var jsExecutor = (IJavaScriptExecutor)Driver;
        jsExecutor.ExecuteScript($"arguments[0].removeAttribute('{elementAttribute}');", Driver.FindElement(Locator));
    }

    /// <summary>
    /// Sets the value of the control using JavaScript.
    /// </summary>
    /// <param name="elementValue">The value to set.</param>
    protected void SetValue(object elementValue)
    {
        var jsExecutor = (IJavaScriptExecutor)Driver;
        jsExecutor.ExecuteScript("arguments[0].value = arguments[1];", Driver.FindElement(Locator), elementValue);
    }

    /// <summary>
    /// Executes the specified JavaScript code in the context of the current browser window. 
    /// </summary>
    /// <param name="script">The script.</param>
    /// <param name="args">Script arguments.</param>
    protected void ExecuteScript(string script, params object[] args)
    {
        var jsExecutor = (IJavaScriptExecutor)Driver;
        jsExecutor.ExecuteScript(script, args);
    }
}