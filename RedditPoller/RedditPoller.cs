using System.Text;
using RedditSharp.Things;
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Configuration;

namespace RedditPoller
{
    public static class RedditPoller
    {
        [FunctionName("TimerTriggerCSharp")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            string url = "https://www.reddit.com/r/azure/new/.json";
            List<string> items = new List<string>();
            var reddit = new RedditSharp.Reddit();

            List<Child> children = new List<Child>();
            WebClient client = new WebClient();
            string text1 = client.DownloadString(url);
            RedditObject redditObject = JsonConvert.DeserializeObject<RedditObject>(text1);

            foreach (var post in redditObject.Data.Children)
            {
                if (DateTime.UtcNow.AddMinutes(-1) < post.Data.TimeStampDate)
                {
                    children.Add(post);
                    log.Info($"Reddit Post {post.Data.title} found");
                }
            }

            if (children.Count > 0)
            {
                var apiKey = (ConfigurationManager.AppSettings["SendGridApiKey"]);
                var sgClient = new SendGridClient(apiKey);
                var from = new EmailAddress(ConfigurationManager.AppSettings["EmailAddress"]);
                var subject = "New Reddit Post";
                var to = new EmailAddress(ConfigurationManager.AppSettings["EmailAddress"]);
                var plainTextContent = new StringBuilder();
                foreach (var post in children)
                {
                    plainTextContent.AppendLine($"<a href='{post.Data.Url}'>{post.Data.title}</a><br />");
                }
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent.ToString(), plainTextContent.ToString());
                sgClient.SendEmailAsync(msg).Wait();
            }
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}