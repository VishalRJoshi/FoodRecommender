// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodRecommender
{

    public class RecipeList
    {

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("recipes")]
        public IList<Recipe> Recipes { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
