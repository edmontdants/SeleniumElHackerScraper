using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Windows;

namespace PortalHackerScraper
{
    public class MainProcess
    {
        private static MainProcess instance;
        public static MainProcess Intance { get { return (instance == null) ? new MainProcess() : instance; } }

        public MainProcess()
        {

        }

        public void Start()
        {
            IWebDriver driver = new FirefoxDriver();
            MessageBox.Show("TEST");
        }
    }
}
