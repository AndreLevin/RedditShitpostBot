using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedditApi.Reddit
{
    public partial class PostResponse
    {
        //[JsonProperty("jquery")]
        //public PostResponseJquery[][] Jquery { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public partial class JqueryClass
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("author_flair_background_color")]
        public object AuthorFlairBackgroundColor { get; set; }

        [JsonProperty("total_awards_received")]
        public long TotalAwardsReceived { get; set; }

        [JsonProperty("approved_at_utc")]
        public object ApprovedAtUtc { get; set; }

        [JsonProperty("edited")]
        public bool Edited { get; set; }

        [JsonProperty("mod_reason_by")]
        public object ModReasonBy { get; set; }

        [JsonProperty("banned_by")]
        public object BannedBy { get; set; }

        [JsonProperty("author_flair_type")]
        public string AuthorFlairType { get; set; }

        [JsonProperty("removal_reason")]
        public object RemovalReason { get; set; }

        [JsonProperty("link_id")]
        public string LinkId { get; set; }

        [JsonProperty("author_flair_template_id")]
        public object AuthorFlairTemplateId { get; set; }

        [JsonProperty("likes")]
        public bool Likes { get; set; }

        [JsonProperty("replies")]
        public string Replies { get; set; }

        [JsonProperty("user_reports")]
        public object[] UserReports { get; set; }

        [JsonProperty("saved")]
        public bool Saved { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("banned_at_utc")]
        public object BannedAtUtc { get; set; }

        [JsonProperty("mod_reason_title")]
        public object ModReasonTitle { get; set; }

        [JsonProperty("gilded")]
        public long Gilded { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("no_follow")]
        public bool NoFollow { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("rte_mode")]
        public string RteMode { get; set; }

        [JsonProperty("can_mod_post")]
        public bool CanModPost { get; set; }

        [JsonProperty("created_utc")]
        public long CreatedUtc { get; set; }

        [JsonProperty("send_replies")]
        public bool SendReplies { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("author_fullname")]
        public string AuthorFullname { get; set; }

        [JsonProperty("approved_by")]
        public object ApprovedBy { get; set; }

        [JsonProperty("mod_note")]
        public object ModNote { get; set; }

        [JsonProperty("all_awardings")]
        public object[] AllAwardings { get; set; }

        [JsonProperty("subreddit_id")]
        public string SubredditId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("awarders")]
        public object[] Awarders { get; set; }

        [JsonProperty("author_flair_css_class")]
        public object AuthorFlairCssClass { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("author_patreon_flair")]
        public bool AuthorPatreonFlair { get; set; }

        [JsonProperty("downs")]
        public long Downs { get; set; }

        [JsonProperty("author_flair_richtext")]
        public object[] AuthorFlairRichtext { get; set; }

        [JsonProperty("is_submitter")]
        public bool IsSubmitter { get; set; }

        [JsonProperty("body_html")]
        public string BodyHtml { get; set; }

        [JsonProperty("gildings")]
        public Gildings Gildings { get; set; }

        [JsonProperty("collapsed_reason")]
        public object CollapsedReason { get; set; }

        [JsonProperty("distinguished")]
        public object Distinguished { get; set; }

        [JsonProperty("associated_award")]
        public object AssociatedAward { get; set; }

        [JsonProperty("stickied")]
        public bool Stickied { get; set; }

        [JsonProperty("author_premium")]
        public bool AuthorPremium { get; set; }

        [JsonProperty("can_gild")]
        public bool CanGild { get; set; }

        [JsonProperty("removed")]
        public bool Removed { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("author_flair_text_color")]
        public object AuthorFlairTextColor { get; set; }

        [JsonProperty("score_hidden")]
        public bool ScoreHidden { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("num_reports")]
        public long NumReports { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("report_reasons")]
        public object[] ReportReasons { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("author_flair_text")]
        public object AuthorFlairText { get; set; }

        [JsonProperty("spam")]
        public bool Spam { get; set; }

        [JsonProperty("collapsed")]
        public bool Collapsed { get; set; }

        [JsonProperty("subreddit_name_prefixed")]
        public string SubredditNamePrefixed { get; set; }

        [JsonProperty("controversiality")]
        public long Controversiality { get; set; }

        [JsonProperty("ignore_reports")]
        public bool IgnoreReports { get; set; }

        [JsonProperty("collapsed_because_crowd_control")]
        public object CollapsedBecauseCrowdControl { get; set; }

        [JsonProperty("mod_reports")]
        public object[] ModReports { get; set; }

        [JsonProperty("subreddit_type")]
        public string SubredditType { get; set; }

        [JsonProperty("ups")]
        public long Ups { get; set; }
    }
    public partial struct PostResponseJquery
    {
        public JqueryJqueryUnion[] AnythingArray;
        public long? Integer;
        public string String;

        public static implicit operator PostResponseJquery(JqueryJqueryUnion[] AnythingArray) => new PostResponseJquery { AnythingArray = AnythingArray };
        public static implicit operator PostResponseJquery(long Integer) => new PostResponseJquery { Integer = Integer };
        public static implicit operator PostResponseJquery(string String) => new PostResponseJquery { String = String };
    }
    public partial struct JqueryJqueryUnion
    {
        public bool? Bool;
        public long? Integer;
        public JqueryClass[] JqueryClassArray;
        public string String;

        public static implicit operator JqueryJqueryUnion(bool Bool) => new JqueryJqueryUnion { Bool = Bool };
        public static implicit operator JqueryJqueryUnion(long Integer) => new JqueryJqueryUnion { Integer = Integer };
        public static implicit operator JqueryJqueryUnion(JqueryClass[] JqueryClassArray) => new JqueryJqueryUnion { JqueryClassArray = JqueryClassArray };
        public static implicit operator JqueryJqueryUnion(string String) => new JqueryJqueryUnion { String = String };
    }
    public partial class Gildings
    {
    }

}