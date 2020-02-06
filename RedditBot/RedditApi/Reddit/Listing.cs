using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedditApi.Reddit
{
    public partial class Listing
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public ListingData Data { get; set; }

        public IEnumerable<Thing> GetChildrenOfKind(Thing.ThingKind kind)
        {
            return Data.Children.Where(child => child.Kind == kind);
        }
    }

    public partial class ListingData
    {
        [JsonProperty("modhash")]
        public object Modhash { get; set; }

        [JsonProperty("dist")]
        public int Dist { get; set; }

        [JsonProperty("children")]
        public Thing[] Children { get; set; }

        [JsonProperty("after")]
        public object After { get; set; }

        [JsonProperty("before")]
        public object Before { get; set; }
    }


    public partial class Gildings
    {
    }

    public partial class Preview
    {
        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("resolutions")]
        public Source[] Resolutions { get; set; }

        [JsonProperty("variants")]
        public Gildings Variants { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Source
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }


}
