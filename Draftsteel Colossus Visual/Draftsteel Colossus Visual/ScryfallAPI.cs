using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing;
using System.Threading;
using System.Security.Policy;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace Draftsteel_Colossus_Visual
{
    class ScryfallAPI
    {
        private static readonly HttpClient client;
        private static string URL = "https://api.scryfall.com/cards/named?fuzzy=";
        static ScryfallAPI()
        {
            client = new HttpClient();
        }

        // THANK YOU PROFESSOR HALL FOR HELPING ME WITH THE API STUFF
        private static async Task<Bitmap> APICall(string URL)
        {
            var cardRequest = new HttpRequestMessage(HttpMethod.Get, URL);
            var cardResponse = client.SendAsync(cardRequest);

            cardResponse.Wait();

            if (cardResponse.Result.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            var jsonResponse = cardResponse.Result.Content.ReadAsStringAsync();
            jsonResponse.Wait();


            // Card data found, now try to get the card image from it
            string myString = jsonResponse.Result;
            JObject obj = JObject.Parse(jsonResponse.Result);

            if (obj == null)
                return null;

            string imageURL = "";

            if (obj["image_uris"] == null)
            {
                if (obj["card_faces"][0] != null)
                {
                    imageURL = (string)obj["card_faces"][0]["image_uris"]["small"];
                }
                else
                {
                    return null;
                }
            }

            else
            {
                imageURL = (string)obj["image_uris"]["small"];
            }

            cardRequest = new HttpRequestMessage(HttpMethod.Get, imageURL);
            cardResponse = client.SendAsync(cardRequest);

            if (cardResponse.Result.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            var imageTask = cardResponse.Result.Content.ReadAsStreamAsync();
            imageTask.Wait();

            Bitmap image = new Bitmap(imageTask.Result);

            return image;
        }

        public static Bitmap GetCardImage(string cardname)
        {
            // Sleep for a bit to not overload Scryfall's API
            Thread.Sleep(50);

            string cardURL = URL + cardname;
            Bitmap cardimage = APICall(cardURL).Result;

            return cardimage;
        }
    }
}
