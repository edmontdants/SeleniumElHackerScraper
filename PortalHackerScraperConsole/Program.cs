using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Threading;
using WordpressAPI;

namespace PortalHackerScraperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://blog.elhacker.net";
            driver.Navigate();

            var posts = driver.FindElements(By.ClassName("art-PostHeader"));
            System.Console.WriteLine($"Posts detectados: {posts.Count}");

            List<string> links = new List<string>();
            foreach (var item in posts)
            {
                var href = item.FindElement(By.TagName("a")).GetAttribute("href");
                System.Console.WriteLine(href);
                links.Add(href);
            }

            var fetchedPosts = Fetch(links, driver);
            Post(fetchedPosts);

            driver.Quit();
        }

        /// <summary>
        /// Fetch all posts.
        /// </summary>
        private static List<Post> Fetch(List<string> links, IWebDriver webDriver)
        {
            try
            {
                List<Post> fetchedPosts = new List<Post>();

                foreach (var item in links)
                {
                    Thread.Sleep(300);
                    webDriver.Navigate().GoToUrl(item);

                    Post aux = new Post();

                    //ar - PostHeader a
                    aux.Title = webDriver.FindElement(By.CssSelector(".art-PostHeader > a:nth-child(2)")).Text;
                    var artPostContent = webDriver.FindElement(By.ClassName("art-PostContent"));

                    var artContent = artPostContent.FindElements(By.TagName("div"))[2];

                    string innerHtml = "";
                    IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;
                    if (js != null)
                    {
                        innerHtml = (string)js.ExecuteScript("return arguments[0].innerHTML;", artContent);
                    }

                    aux.Content = innerHtml;
                    fetchedPosts.Add(aux);
                }

                return fetchedPosts;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Problem fetching content");
                return null;
            }
        }

        /// <summary>
        /// Re-post content.
        /// </summary>
        private static void Post(List<Post> posts)
        {
            try
            {
                // ENTER TO WORDPRESS AND POST.
                foreach (var item in posts)
                {

                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Problem posting content");
            }
        }
    }
}
