﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedditApi.Reddit;

namespace RedditApi.Reddit
{
    public partial class Thing
    {
        public enum ThingKind
        {
            Comment,
            Account,
            Link,
            Message,
            Subreddit,
            Award,
            Undefined
        }
        public ThingKind Kind { get; private set; }

        private string _KindString;
        [JsonProperty("kind")]
        private string KindString
        {
            get
            {
                return _KindString;
            }
            set
            {
                _KindString = value;
                switch (value)
                {
                    case "t1":

                        Kind = ThingKind.Comment;
                        break;
                    case "t2":
                        Kind = ThingKind.Account;
                        break;
                    case "t3":
                        Kind = ThingKind.Link;
                        break;
                    case "t4":
                        Kind = ThingKind.Message;
                        break;
                    case "t5":
                        Kind = ThingKind.Subreddit;
                        break;
                    case "t6":
                        Kind = ThingKind.Award;
                        break;
                    default:
                        Kind = ThingKind.Undefined;
                        break;

                }
            }
        }

        [JsonProperty("data")]
        public ThingData Data { get; set; }
    }

    public partial class ThingData
    {
        [JsonProperty("author_flair_background_color")]
        public object AuthorFlairBackgroundColor { get; set; }

        [JsonProperty("approved_at_utc")]
        public long? ApprovedAtUtc { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("selftext")]
        public string Selftext { get; set; }

        [JsonProperty("author_fullname")]
        public string AuthorFullname { get; set; }

        [JsonProperty("saved")]
        public bool Saved { get; set; }

        [JsonProperty("mod_reason_title")]
        public object ModReasonTitle { get; set; }

        [JsonProperty("gilded")]
        public long Gilded { get; set; }

        [JsonProperty("clicked")]
        public bool Clicked { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link_flair_richtext")]
        public object[] LinkFlairRichtext { get; set; }

        [JsonProperty("subreddit_name_prefixed")]
        public string SubredditNamePrefixed { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("pwls")]
        public object Pwls { get; set; }

        [JsonProperty("link_flair_css_class")]
        public object LinkFlairCssClass { get; set; }

        [JsonProperty("downs")]
        public long Downs { get; set; }

        [JsonProperty("thumbnail_height")]
        public long? ThumbnailHeight { get; set; }

        [JsonProperty("hide_score")]
        public bool HideScore { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quarantine")]
        public bool Quarantine { get; set; }

        [JsonProperty("link_flair_text_color")]
        public string LinkFlairTextColor { get; set; }

        [JsonProperty("ignore_reports")]
        public bool IgnoreReports { get; set; }

        [JsonProperty("subreddit_type")]
        public string SubredditType { get; set; }

        [JsonProperty("ups")]
        public long Ups { get; set; }

        [JsonProperty("total_awards_received")]
        public long TotalAwardsReceived { get; set; }

        [JsonProperty("media_embed")]
        public Gildings MediaEmbed { get; set; }

        [JsonProperty("thumbnail_width")]
        public long? ThumbnailWidth { get; set; }

        [JsonProperty("author_flair_template_id")]
        public object AuthorFlairTemplateId { get; set; }

        [JsonProperty("is_original_content")]
        public bool IsOriginalContent { get; set; }

        [JsonProperty("user_reports")]
        public object[] UserReports { get; set; }

        [JsonProperty("secure_media")]
        public object SecureMedia { get; set; }

        [JsonProperty("is_reddit_media_domain")]
        public bool IsRedditMediaDomain { get; set; }

        [JsonProperty("is_meta")]
        public bool IsMeta { get; set; }

        [JsonProperty("category")]
        public object Category { get; set; }

        [JsonProperty("secure_media_embed")]
        public Gildings SecureMediaEmbed { get; set; }

        [JsonProperty("link_flair_text")]
        public object LinkFlairText { get; set; }

        [JsonProperty("can_mod_post")]
        public bool CanModPost { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("approved_by")]
        public string ApprovedBy { get; set; }

        [JsonProperty("author_premium")]
        public bool AuthorPremium { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("edited")]
        public bool Edited { get; set; }

        [JsonProperty("author_flair_css_class")]
        public object AuthorFlairCssClass { get; set; }

        [JsonProperty("author_flair_richtext")]
        public object[] AuthorFlairRichtext { get; set; }

        [JsonProperty("gildings")]
        public Gildings Gildings { get; set; }

        [JsonProperty("post_hint", NullValueHandling = NullValueHandling.Ignore)]
        public string PostHint { get; set; }

        [JsonProperty("content_categories")]
        public object ContentCategories { get; set; }

        [JsonProperty("is_self")]
        public bool IsSelf { get; set; }

        [JsonProperty("mod_note")]
        public object ModNote { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("link_flair_type")]
        public string LinkFlairType { get; set; }

        [JsonProperty("wls")]
        public object Wls { get; set; }

        [JsonProperty("removed_by_category")]
        public object RemovedByCategory { get; set; }

        [JsonProperty("banned_by")]
        public object BannedBy { get; set; }

        [JsonProperty("author_flair_type")]
        public string AuthorFlairType { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("allow_live_comments")]
        public bool AllowLiveComments { get; set; }

        [JsonProperty("selftext_html")]
        public string SelftextHtml { get; set; }

        [JsonProperty("likes")]
        public bool? Likes { get; set; }

        [JsonProperty("suggested_sort")]
        public object SuggestedSort { get; set; }

        [JsonProperty("banned_at_utc")]
        public object BannedAtUtc { get; set; }

        [JsonProperty("view_count")]
        public object ViewCount { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("no_follow")]
        public bool NoFollow { get; set; }

        [JsonProperty("spam")]
        public bool Spam { get; set; }

        [JsonProperty("is_crosspostable")]
        public bool IsCrosspostable { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("over_18")]
        public bool Over18 { get; set; }

        [JsonProperty("preview", NullValueHandling = NullValueHandling.Ignore)]
        public Preview Preview { get; set; }

        [JsonProperty("all_awardings")]
        public object[] AllAwardings { get; set; }

        [JsonProperty("awarders")]
        public object[] Awarders { get; set; }

        [JsonProperty("media_only")]
        public bool MediaOnly { get; set; }

        [JsonProperty("can_gild")]
        public bool CanGild { get; set; }

        [JsonProperty("removed")]
        public bool Removed { get; set; }

        [JsonProperty("spoiler")]
        public bool Spoiler { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("author_flair_text")]
        public object AuthorFlairText { get; set; }

        [JsonProperty("visited")]
        public bool Visited { get; set; }

        [JsonProperty("removed_by")]
        public object RemovedBy { get; set; }

        [JsonProperty("num_reports")]
        public long NumReports { get; set; }

        [JsonProperty("distinguished")]
        public object Distinguished { get; set; }

        [JsonProperty("subreddit_id")]
        public string SubredditId { get; set; }

        [JsonProperty("mod_reason_by")]
        public object ModReasonBy { get; set; }

        [JsonProperty("removal_reason")]
        public object RemovalReason { get; set; }

        [JsonProperty("link_flair_background_color")]
        public string LinkFlairBackgroundColor { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_robot_indexable")]
        public bool IsRobotIndexable { get; set; }

        [JsonProperty("report_reasons")]
        public object[] ReportReasons { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("discussion_type")]
        public object DiscussionType { get; set; }

        [JsonProperty("num_comments")]
        public long NumComments { get; set; }

        [JsonProperty("send_replies")]
        public bool SendReplies { get; set; }

        [JsonProperty("whitelist_status")]
        public object WhitelistStatus { get; set; }

        [JsonProperty("contest_mode")]
        public bool ContestMode { get; set; }

        [JsonProperty("mod_reports")]
        public object[] ModReports { get; set; }

        [JsonProperty("author_patreon_flair")]
        public bool AuthorPatreonFlair { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("author_flair_text_color")]
        public object AuthorFlairTextColor { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("parent_whitelist_status")]
        public object ParentWhitelistStatus { get; set; }

        [JsonProperty("stickied")]
        public bool Stickied { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("subreddit_subscribers")]
        public long SubredditSubscribers { get; set; }

        [JsonProperty("created_utc")]
        public long CreatedUtc { get; set; }

        [JsonProperty("num_crossposts")]
        public long NumCrossposts { get; set; }

        [JsonProperty("media")]
        public object Media { get; set; }

        [JsonProperty("is_video")]
        public bool IsVideo { get; set; }

    }
}
