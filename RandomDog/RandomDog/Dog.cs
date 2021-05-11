using System;
using Newtonsoft.Json;
using System.Net;

namespace RandomDog
{
    /// <summary>
    /// DOG!
    /// </summary>
    public sealed class Dog
    {
        /// <summary>
        /// Doggy Image
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; private set; }

        /// <summary>
        /// The status of dog
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }

        /// <summary>
        /// Get Dog
        /// </summary>
        /// <returns></returns>
        public static Dog Fetch()
        {
            using (WebClient client = new WebClient())
            {
                string html = client.DownloadString("https://dog.ceo/api/breeds/image/random");

                return JsonConvert.DeserializeObject<Dog>(html);
            }
        }
    }
}
