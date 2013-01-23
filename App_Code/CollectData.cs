using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for CollectData
/// </summary>
public class CollectData
{
    #region Categories
    static string[] cuisines =
        new string[] { 
                        "French", 
                        "Italian", 
                        "Chinese", 
                        "Indian", 
                        "Thai", 
                        "Mexican", 
                        "Japanese", 
                        "Spanish", 
                        "Greek", 
                        "Lebanese", 
                        "Ethiopian", 
                        "Afghan", 
                        "African", 
                        "American", 
                        "Mediterranean",
                        "Russian"
                         };

    static string[] tags =
        new string[] {
            //Batch 1 - Done 1/21/2013 at 9:47pm
                        //"Beef",
                        //"Prawn",
                        //"Shrimp",
                        //"Biscuit",
                        //"Casserole",
                        //"Chicken",
                        //"Chocolate ",
                        //"Cookies",
                        //"Curry",
                        //"Cake",
                        //"Egg",
                        //"Fish",
                        //"Fruit",
                        //"Salad",
                        //"Lamb",
            ////Batch 2 - Done 1/22/2013 at 12:26 am
            //          "Noodles",
            //            "Pasta",
            //            "Cheese",
            //            "Paneer",
            //            "Pickles",
            //            "Pizza",
            //            "Puddings",
            //            "Burger",
            //            "Rice",
            //            "Salad",
            //            "Pastry",
            //            "Sandwich",
            //            "Sauce",
            //            "Sizzler",
            //            "Smoothie",
            //Batch 3
                        "Soup",
                        "Tofu",
                        "Turkey",
                        "Vegetable",
                        "Duck",
                        "Veal",
                        "Pork",
                        "Steak",
                        "Rabbit",
                        "Pho",
                        "Sushi",
                        "Milk",
                        "Yogurt",
                        "Bread",
                        "Cream"
                        };
    #endregion

    public static void Go()
    {
        var db = Database.Open("foodRecommenderGold");
        foreach (string cuisine in cuisines)
        {
            if (cuisine != null)
            {
                foreach (string tag in tags)
                {
                    if (tag != null)
                    {
                        RunQuery(db, BuildQuery(cuisine, tag), cuisine, tag);
                    }
                }
            }
        }
    }

    public static string BuildQuery(string cuisine, string tag)
    {
        string searchQuery = String.Empty;
        string c = String.IsNullOrEmpty(cuisine) ? String.Empty : HttpUtility.UrlEncode(cuisine);
        string t = String.IsNullOrEmpty(tag) ? String.Empty : HttpUtility.UrlEncode(tag);
        searchQuery = c + "+" + t;
        string query = "&q=" + searchQuery;
        return query;
    }

    public static void RunQuery(Database db, string query, string cuisine, string tag)
    {
        if (!String.IsNullOrEmpty(query) && db != null)
        {
            FoodRecommender.RecipeList deserializedProduct;
            HttpWebRequest request = WebRequest.Create("http://api.punchfork.com/recipes?key=707887fe5103a7cb" + query + "&count=50") as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string json = reader.ReadToEnd();
                deserializedProduct = Newtonsoft.Json.JsonConvert.DeserializeObject<FoodRecommender.RecipeList>(json);
            }
            if (deserializedProduct != null && deserializedProduct.Recipes != null && deserializedProduct.Recipes.Count > 0)
            {
                foreach (FoodRecommender.Recipe r in deserializedProduct.Recipes)
                {
                    db.Execute(@"INSERT INTO recipes
                        (rating, source_name, thumb, title, source_url, pf_url, published, source_img, shortcode,twc,fbc,suc, tags,cuisine) VALUES 
                        (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12,@13)", r.Rating, r.SourceName, r.Thumb, r.Title, r.SourceUrl, r.PfUrl, r.Published, r.SourceImg, r.Shortcode, r.Twc, r.Fbc, r.Suc, tag, cuisine);
                }
            }
        }
    }

}