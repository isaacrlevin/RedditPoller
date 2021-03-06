﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditPoller
{
    #region Object Serialized from JSON
    public class MediaEmbed
    {
    }

    public class SecureMediaEmbed
    {
    }

    public class Data2
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public string domain { get; set; }
        public object banned_by { get; set; }
        public MediaEmbed media_embed { get; set; }
        public string subreddit { get; set; }
        public object selftext_html { get; set; }
        public string selftext { get; set; }
        public object likes { get; set; }
        public object secure_media { get; set; }
        public object link_flair_text { get; set; }
        public string id { get; set; }
        public SecureMediaEmbed secure_media_embed { get; set; }
        public bool clicked { get; set; }
        public bool stickied { get; set; }
        public string author { get; set; }
        public object media { get; set; }
        public int score { get; set; }
        public object approved_by { get; set; }
        public bool over_18 { get; set; }
        public bool hidden { get; set; }
        public string thumbnail { get; set; }
        public string subreddit_id { get; set; }
        public string edited { get; set; }
        public object link_flair_css_class { get; set; }
        public string author_flair_css_class { get; set; }
        public int downs { get; set; }
        public bool saved { get; set; }
        public bool is_self { get; set; }
        public string permalink { get; set; }
        public string name { get; set; }

        public double? created { get; set; }

        public DateTime? TimeStampDate
        {
            get
            {
                return UnixEpoch.AddSeconds(this.created_utc);

            }
        }
        public string Url { get; set; }
        public object author_flair_text { get; set; }
        public string title { get; set; }
        public double created_utc { get; set; }
        public int ups { get; set; }
        public int num_comments { get; set; }
        public bool visited { get; set; }
        public object num_reports { get; set; }
        public object distinguished { get; set; }
    }

    public class Child
    {
        public string kind { get; set; }
        public Data2 Data { get; set; }
        public Image Image { get; set; }
        public string Path { get; set; }
    }

    public class Data
    {
        public string modhash { get; set; }
        public List<Child> Children { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }

    public class RedditObject
    {
        public string Kind { get; set; }
        public Data Data { get; set; }
    }
    #endregion
}
