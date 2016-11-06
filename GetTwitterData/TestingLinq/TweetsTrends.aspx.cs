using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinqToTwitter;
using System.Threading.Tasks;

namespace TestingLinq
{

    public partial class Tweets : System.Web.UI.Page
    {
        private SingleUserAuthorizer authorizer =
   new SingleUserAuthorizer
   {
       CredentialStore =
      new SingleUserInMemoryCredentialStore
      {
          ConsumerKey =
          "qG3i9jwAh1jday01dJxp1adgm",
          ConsumerSecret =
         "Xw4iyZYxL9ksQpV8X7cZKhUMYl3HVS5A90iazywEE663gUnq09",
          AccessToken =
         "795204951970430976-YJ2HbpsUdTX1Y81r0mZd1AJ4SI0AULG",
          AccessTokenSecret =
         "XZxmtdsKrOgye6KqdRb7K8B0lpJ9uGdUmIDEJ9WZXQ8qm"
      }
   };
        private List<Status> currentTweets;
        private async Task GetMostRecent200HomeTimeLine()
        {
            var twitterContext = new TwitterContext(authorizer);

            var tweets = from tweet in twitterContext.Status
                         where tweet.Type == StatusType.Home &&
                         tweet.Count == 200
                         select tweet;

            currentTweets = await tweets.ToListAsync();
        }


        public async Task func()
        {
            await GetMostRecent200HomeTimeLine();
            ListBox2.Items.Clear();
            currentTweets.ForEach(tweet =>
               ListBox2.Items.Add(tweet.User.ScreenNameResponse+"1"));

            var twitterContext = new TwitterContext(authorizer);

            var trends =
               await
               (from trend in twitterContext.Trends
                where trend.Type == TrendType.Place &&
                      trend.WoeID == 23424922
                select trend)
               .ToListAsync();

            if (trends != null &&
                trends.Any() &&
                trends.First().Locations != null)
            {
               

                trends.ForEach(trnd =>
                   ListBox1.Items.Add(
                        "Name: " +trnd.Name+",\tCountry: "+trnd.Locations.ToList().First().Name+ ", Query: "+trnd.Query+"\nSearch "+trnd.SearchUrl));
            }

          
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(func));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}