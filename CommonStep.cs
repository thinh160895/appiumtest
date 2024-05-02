using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
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
                double startWidth = ScreenSize.Width / 2;
                double startHeight = ScreenSize.Height / 2;
                double endWidth = 0;
                double endHeight = 0;
                int border = 10;

                switch (direction.ToUpper())
                {
                    case "DOWN":
                        endWidth = ScreenSize.Width / 2;
                        endHeight = ScreenSize.Height - border;
                        break;
                    case "UP":
                        endWidth = ScreenSize.Width / 2;
                        endHeight = border;
                        break;
                    case "LEFT":
                        endWidth = border;
                        endHeight = ScreenSize.Height / 2;
                        break;
                    case "RIGHT":
                        endWidth = ScreenSize.Width - border;
                        endHeight = ScreenSize.Height / 2;
                        break;
                }

                try
                {
                    var touch = new PointerInputDevice(PointerKind.Touch, "finger");
                    var sequence = new ActionSequence(touch);
                    var move = touch.CreatePointerMove(null, (int)startWidth, (int)startHeight, TimeSpan.FromSeconds(1));
                    var actionPress = touch.CreatePointerDown(MouseButton.Touch);
                    var pause = touch.CreatePause(TimeSpan.FromMilliseconds(1));
                    var actionRelease = touch.CreatePointerUp(MouseButton.Touch);

                    sequence.AddAction(move);
                    sequence.AddAction(actionPress);
                    sequence.AddAction(pause);

                    // Move to end point
                    move = touch.CreatePointerMove(null, (int)endWidth, (int)endHeight, TimeSpan.FromSeconds(1));
                    sequence.AddAction(move);

                    sequence.AddAction(actionRelease);

                    var actionsSeq = new List<ActionSequence> { sequence };
                    _driver.PerformActions(actionsSeq);
                }
                catch(Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
        }
    }
}
