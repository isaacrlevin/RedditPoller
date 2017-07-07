# POC To Show Capabilities of using Azure Functions Scheduling to Notify of Reddit Posts


### What is the Goal Here?
* To see ease of implementing 3rd party Packages in Azure Functions
* Stateless way of getting notified using 3rd Party Services 
* Proof to see how quick a function can be stood up

### What does this app do?
* Uses Azure Function Schedule Trigger (currently runs every minute using "0 */1 * * * * CRON)  
* Uses [RedditSharp](https://github.com/CrustyJew/RedditSharp) to "scrape" Reddit subreddit (in this case /r/Azure)
* Gets Posts tht have been created within the last minute, digests them, and emails with SendGrid

# Getting Started:

- **Clone this Repo and restore** :
  ````
  git clone https://github.com/isaac2004/RedditPoller  
  dotnet restore
  ````
- **Configure Azure Components**
  - Setup Free Azure Subscription (if you do not have one)
  - Add new instance of [SendGrid](https://portal.azure.com/#create/SendGrid.SendGrid) (Free Version) on your subscription
    - You get 25k emails a month here
    - Capture Api Key created during process and place in host.json "SendGridApiKey" setting
    
- **Publish App from Visual Studio 2017 Preview 3.0**
  - Right-Click RedditPoller project 
  - Create new Function App, Storage Account and Deploy
  - Add SendGrid Api Key and email to be notified in App Settings of Azure Function

- **How can this be extended?**
  - Add custom logic to notify on specific posts (matching a keyword for instance)
  - Add auth against Reddit (supported with RedditSharp) to get access to mailbox/subscribed subs/etc
  - MakeTimerTrigger customizable
  - Really options are plenty for adding hooks to Reddit

----

# License

[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](/LICENSE) 

Copyright (c) 2016-2017 [Isaac Levin](https://github.com/isaac2004)

Twitter: [@isaac2004](http://twitter.com/isaac2004) 
