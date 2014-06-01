using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace Shame.ShamefulLogic
{
    public class TweetSharpShamefulService : IShamefulService
    {
        private string _consumerKey;
        private string _consumerSecret;
        private string _accessToken;
        private string _accessTokenSecret;

        public TweetSharpShamefulService(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accessToken = accessToken;
            _accessTokenSecret = accessTokenSecret;
        }

        public void NominateFine(string fine)
        {
            var service = GetAuthenticatedTwitterServices();
            service.SendTweet(new SendTweetOptions {Status = fine});
        }

        public string[] GetFines(int count, string screenName)
        {
            var service = GetAuthenticatedTwitterServices();           
            return service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions() { ScreenName = screenName, Count = count }).Select(x => x.Text).ToArray();
        }

        public List<string> GetFollowers(string screenName)
        {
            var service = GetAuthenticatedTwitterServices();
            var options = new ListFollowersOptions {ScreenName = screenName};
            IEnumerable<TwitterUser> followers = service.ListFollowers(options);
            return followers.Select(x => x.Name).ToList();
        }
   
        private TwitterService GetAuthenticatedTwitterServices()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);

            return service;
        }
    }
}
