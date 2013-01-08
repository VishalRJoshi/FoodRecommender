// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodRecommender
{

    public class Recipe
    {

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("source_name")]
        public string SourceName { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("pf_url")]
        public string PfUrl { get; set; }

        [JsonProperty("published")]
        public string Published { get; set; }

        [JsonProperty("source_img")]
        public string SourceImg { get; set; }

        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("twc")]
        public int Twc { get; set; }

        [JsonProperty("fbc")]
        public int Fbc { get; set; }

        [JsonProperty("suc")]
        public int Suc { get; set; }

        
    }
}
