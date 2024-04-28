using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;

namespace appiumtest
{
    public class SwipeHandler
    {
        private AndroidDriver _driver;

        public SwipeHandler(AndroidDriver driver)
        {
            _driver = driver;
        }

        [Obsolete]
        public void Swipe(string direction, int times)
        {
            for (int i = 0; i < times; i++)
            {
                // Get the screen size
                Size ScreenSize = _driver.Manage().Window.Size;
                double startwidth, startheight, endwidth = 0, endheight = 0;
                startwidth = ScreenSize.Width / 2;
                startheight = ScreenSize.Height / 2;
                int border = 10;

                switch (direction.ToUpper())
                {
                    case "DOWN":
                        endwidth = ScreenSize.Width / 2;
                        endheight = ScreenSize.Height - border;
                        break;
                    case "UP":
                        endwidth = ScreenSize.Width / 2;
                        endheight = border;
                        break;
                    case "LEFT":
                        endwidth = border;
                        endheight = ScreenSize.Height / 2;
                        break;
                    case "RIGHT":
                        endwidth = ScreenSize.Width - border;
                        endheight = ScreenSize.Height / 2;
                        break;
                }
                try
                {
                    // new TouchAction((IPerformsTouchActions)_driver)
                    // .Press(startwidth, startheight)
                    // .MoveTo(endwidth, endheight)
                    // .Release().Perform();
                    // // Thread.Sleep(2000);
                    var SwipeAction = new TouchAction(_driver);
                    SwipeAction.LongPress(startwidth, startheight)
                    // .Wait(500)
                    .MoveTo(endwidth, endheight)
                    .Release()
                    .Perform();
                }
                catch(Exception ex)
                {
                Console.Write(ex.ToString());
                }
            }
        }
    }
}

// namespace appiumtest;
// public class SwipeHandler
// {
//     private IWebDriver _driver;
//     public SwipeHandler(IWebDriver driver)
//     {
//         _driver = driver;
//     }
//     [Obsolete]
//     public void Swipe(int times)
//     {
//         for (int i = 0; i < times; i++)
//         {
//             // Get the screen size
//             Size screenSize = _driver.Manage().Window.Size;

//             // Calculate the start and end points of the swipe
//             int startX = (int)(screenSize.Width * 0.8); 
//             int endX = (int)(screenSize.Width * 0.2);   
//             int y = screenSize.Height / 2;             

//             // Perform the swipe
//             try{
//             TouchAction Swipe = new TouchAction((OpenQA.Selenium.Appium.Interfaces.IPerformsTouchActions)_driver);
//             Swipe.Press(startX, y)
//             .MoveTo(endX, y)
//             .Release().Perform();
//             // Thread.Sleep(2000);
//             }
//             catch(Exception ex)
//             {
//             Console.Write(ex.ToString());
//             }
//             // Task.Delay(2000).Wait();

//         }
//     }
// }
