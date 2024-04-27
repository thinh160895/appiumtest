using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;

public class SwipeHandler
{
    private IWebDriver _driver;
    public SwipeHandler(IWebDriver driver)
    {
        _driver = driver;
    }
    [Obsolete]
    public void Swipe(int times)
    {
        for (int i = 0; i < times; i++)
        {
            // Get the screen size
            Size screenSize = _driver.Manage().Window.Size;

            // Calculate the start and end points of the swipe
            int startX = (int)(screenSize.Width * 0.8); 
            int endX = (int)(screenSize.Width * 0.2);   
            int y = screenSize.Height / 2;             

            // Perform the swipe
            try{
            TouchAction Swipe = new TouchAction((OpenQA.Selenium.Appium.Interfaces.IPerformsTouchActions)_driver);
            Swipe.Press(startX, y)
            .MoveTo(endX, y)
            .Release().Perform();
            // Thread.Sleep(2000);
            }
            catch(Exception ex)
            {
            Console.Write(ex.ToString());
            }
            // Task.Delay(2000).Wait();

        }
    }
}
