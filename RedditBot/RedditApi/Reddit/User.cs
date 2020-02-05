using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedditApi.Reddit
{
    public partial class User
    {
        [JsonProperty("is_employee")]
        public bool IsEmployee { get; set; }

        [JsonProperty("seen_layout_switch")]
        public bool SeenLayoutSwitch { get; set; }

        [JsonProperty("has_visited_new_profile")]
        public bool HasVisitedNewProfile { get; set; }

        [JsonProperty("pref_no_profanity")]
        public bool PrefNoProfanity { get; set; }

        [JsonProperty("has_external_account")]
        public bool HasExternalAccount { get; set; }

        [JsonProperty("pref_geopopular")]
        public string PrefGeopopular { get; set; }

        [JsonProperty("seen_redesign_modal")]
        public bool SeenRedesignModal { get; set; }

        [JsonProperty("pref_show_trending")]
        public bool PrefShowTrending { get; set; }

        [JsonProperty("subreddit")]
        public Subreddit Subreddit { get; set; }

        [JsonProperty("is_sponsor")]
        public bool IsSponsor { get; set; }

        [JsonProperty("gold_expiration")]
        public object GoldExpiration { get; set; }

        [JsonProperty("has_gold_subscription")]
        public bool HasGoldSubscription { get; set; }

        [JsonProperty("num_friends")]
        public long NumFriends { get; set; }

        [JsonProperty("features")]
        public Features Features { get; set; }

        [JsonProperty("has_android_subscription")]
        public bool HasAndroidSubscription { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("new_modmail_exists")]
        public object NewModmailExists { get; set; }

        [JsonProperty("pref_autoplay")]
        public bool PrefAutoplay { get; set; }

        [JsonProperty("coins")]
        public long Coins { get; set; }

        [JsonProperty("has_paypal_subscription")]
        public bool HasPaypalSubscription { get; set; }

        [JsonProperty("has_subscribed_to_premium")]
        public bool HasSubscribedToPremium { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("has_stripe_subscription")]
        public bool HasStripeSubscription { get; set; }

        [JsonProperty("seen_premium_adblock_modal")]
        public bool SeenPremiumAdblockModal { get; set; }

        [JsonProperty("can_create_subreddit")]
        public bool CanCreateSubreddit { get; set; }

        [JsonProperty("over_18")]
        public bool Over18 { get; set; }

        [JsonProperty("is_gold")]
        public bool IsGold { get; set; }

        [JsonProperty("is_mod")]
        public bool IsMod { get; set; }

        [JsonProperty("suspension_expiration_utc")]
        public object SuspensionExpirationUtc { get; set; }

        [JsonProperty("has_verified_email")]
        public bool HasVerifiedEmail { get; set; }

        [JsonProperty("is_suspended")]
        public bool IsSuspended { get; set; }

        [JsonProperty("pref_video_autoplay")]
        public bool PrefVideoAutoplay { get; set; }

        [JsonProperty("in_chat")]
        public bool InChat { get; set; }

        [JsonProperty("in_redesign_beta")]
        public bool InRedesignBeta { get; set; }

        [JsonProperty("icon_img")]
        public Uri IconImg { get; set; }

        [JsonProperty("has_mod_mail")]
        public bool HasModMail { get; set; }

        [JsonProperty("pref_nightmode")]
        public bool PrefNightmode { get; set; }

        [JsonProperty("oauth_client_id")]
        public string OauthClientId { get; set; }

        [JsonProperty("hide_from_robots")]
        public bool HideFromRobots { get; set; }

        [JsonProperty("link_karma")]
        public long LinkKarma { get; set; }

        [JsonProperty("force_password_reset")]
        public bool ForcePasswordReset { get; set; }

        [JsonProperty("seen_give_award_tooltip")]
        public bool SeenGiveAwardTooltip { get; set; }

        [JsonProperty("inbox_count")]
        public long InboxCount { get; set; }

        [JsonProperty("pref_top_karma_subreddits")]
        public bool PrefTopKarmaSubreddits { get; set; }

        [JsonProperty("has_mail")]
        public bool HasMail { get; set; }

        [JsonProperty("pref_show_snoovatar")]
        public bool PrefShowSnoovatar { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pref_clickgadget")]
        public long PrefClickgadget { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("gold_creddits")]
        public long GoldCreddits { get; set; }

        [JsonProperty("created_utc")]
        public long CreatedUtc { get; set; }

        [JsonProperty("has_ios_subscription")]
        public bool HasIosSubscription { get; set; }

        [JsonProperty("pref_show_twitter")]
        public bool PrefShowTwitter { get; set; }

        [JsonProperty("in_beta")]
        public bool InBeta { get; set; }

        [JsonProperty("comment_karma")]
        public long CommentKarma { get; set; }

        [JsonProperty("has_subscribed")]
        public bool HasSubscribed { get; set; }

        [JsonProperty("seen_subreddit_chat_ftux")]
        public bool SeenSubredditChatFtux { get; set; }
    }

    public partial class Features
    {
        [JsonProperty("promoted_trend_blanks")]
        public bool PromotedTrendBlanks { get; set; }

        [JsonProperty("show_amp_link")]
        public bool ShowAmpLink { get; set; }

        [JsonProperty("chat")]
        public bool Chat { get; set; }

        [JsonProperty("twitter_embed")]
        public bool TwitterEmbed { get; set; }

        [JsonProperty("is_email_permission_required")]
        public bool IsEmailPermissionRequired { get; set; }

        [JsonProperty("mod_awards")]
        public bool ModAwards { get; set; }

        [JsonProperty("expensive_coins_package")]
        public bool ExpensiveCoinsPackage { get; set; }

        [JsonProperty("mweb_xpromo_revamp_v2")]
        public Mweb MwebXpromoRevampV2 { get; set; }

        [JsonProperty("awards_on_streams")]
        public bool AwardsOnStreams { get; set; }

        [JsonProperty("mweb_xpromo_modal_listing_click_daily_dismissible_ios")]
        public bool MwebXpromoModalListingClickDailyDismissibleIos { get; set; }

        [JsonProperty("chat_subreddit")]
        public bool ChatSubreddit { get; set; }

        [JsonProperty("modlog_copyright_removal")]
        public bool ModlogCopyrightRemoval { get; set; }

        [JsonProperty("do_not_track")]
        public bool DoNotTrack { get; set; }

        [JsonProperty("chat_user_settings")]
        public bool ChatUserSettings { get; set; }

        [JsonProperty("mweb_xpromo_interstitial_comments_ios")]
        public bool MwebXpromoInterstitialCommentsIos { get; set; }

        [JsonProperty("community_awards")]
        public bool CommunityAwards { get; set; }

        [JsonProperty("mweb_xpromo_modal_listing_click_daily_dismissible_android")]
        public bool MwebXpromoModalListingClickDailyDismissibleAndroid { get; set; }

        [JsonProperty("premium_subscriptions_table")]
        public bool PremiumSubscriptionsTable { get; set; }

        [JsonProperty("mweb_xpromo_interstitial_comments_android")]
        public bool MwebXpromoInterstitialCommentsAndroid { get; set; }

        [JsonProperty("delete_vod_when_post_is_deleted")]
        public bool DeleteVodWhenPostIsDeleted { get; set; }

        [JsonProperty("chat_group_rollout")]
        public bool ChatGroupRollout { get; set; }

        [JsonProperty("custom_feeds")]
        public bool CustomFeeds { get; set; }

        [JsonProperty("spez_modal")]
        public bool SpezModal { get; set; }

        [JsonProperty("mweb_sharing_clipboard")]
        public Mweb MwebSharingClipboard { get; set; }
    }

    public partial class Mweb
    {
        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("variant")]
        public string Variant { get; set; }

        [JsonProperty("experiment_id")]
        public long ExperimentId { get; set; }
    }
}
