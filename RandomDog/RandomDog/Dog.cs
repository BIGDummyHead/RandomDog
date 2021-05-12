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
        public static Dog Fetch(string breed = null, string subBreed = null)
        {
            if (subBreed != null && breed == null)
                return null;

            using (WebClient client = new WebClient())
            {
                if (breed == null)
                {
                    string dog = client.DownloadString("https://dog.ceo/api/breeds/image/random");

                    return JsonConvert.DeserializeObject<Dog>(dog);
                }
                else if(breed != null && subBreed == null)
                {
                    string justBreed = client.DownloadString($"https://dog.ceo/api/breed/{breed}/images/random");
                    return JsonConvert.DeserializeObject<Dog>(justBreed);
                }

                string sub = client.DownloadString($"https://dog.ceo/api/breed/{breed}/{subBreed}/images/random");
                return JsonConvert.DeserializeObject<Dog>(sub);
            }
        }

    }
}
