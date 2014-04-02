using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;

namespace Tests
{
    [TestClass]
    public class TwitterControllerTests
    {
        [TestMethod]
        public void ShouldTweetMessage()
        {
            var message = "Message " + Guid.NewGuid().ToString();
            var controller = new TwitterController();

            var result = controller.TweetMessage(message);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldGetPosts()
        {
            var controller = new TwitterController();

            var posts = controller.GetPosts();

            Assert.IsTrue(posts.Any());
        }  
    }
}
