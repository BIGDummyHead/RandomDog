using System;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;

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
        /// Error Code if any, 200 if success
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; private set; } = 200;

        /// <summary>
        /// Get Dog
        /// </summary>
        /// <returns></returns>
        public static async Task<Dog> Fetch(string breed = null, string subBreed = null)
        {
            if (subBreed != null && breed == null)
                return new Dog() 
                {
                    Code = 404,
                    Status = "error",
                    Message = "You cannot get a dog via sub breed."
                };

            try
            {
                string downloadLink = string.Empty;

                using WebClient client = new WebClient();
                if (breed == null)
                    downloadLink = "https://dog.ceo/api/breeds/image/random";
                else if (breed != null && subBreed == null)
                    downloadLink = $"https://dog.ceo/api/breed/{breed}/images/random";
                else
                    downloadLink = $"https://dog.ceo/api/breed/{breed}/{subBreed}/images/random";

                string jsonConvertable = await client.DownloadStringTaskAsync(downloadLink);
                return JsonConvert.DeserializeObject<Dog>(jsonConvertable);
            }
            catch
            {
                return new Dog()
                {
                    Code = 404,
                    Message = "Dog Not Found",
                    Status = "error"
                };
            }

        }


    }

    /// <summary>
    /// Get all dog info.
    /// </summary>
    public sealed class DogInfo
    {
        /// <summary>
        /// A KeyValue dictionary of Dogs/Breeds/Sub-breeds.
        /// </summary>
        [JsonProperty("message")]
        public JObject Message { get; private set; }

        /// <summary>
        /// The status of the dog collection
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }

        /// <summary>
        /// An IEnumerable type list you can parse over to get specifics dogs and such
        /// </summary>
        public DogList Doggies
        {
            get
            {
                return (Message == null) ? null : new DogList(Message);
            }
        }

        /// <summary>
        /// Request for a DogInfo list.
        /// </summary>
        /// <returns></returns>
        public static async Task<DogInfo> Request()
        {
            try
            {
                using WebClient client = new WebClient();

                string downloaded = await client.DownloadStringTaskAsync("https://dog.ceo/api/breeds/list/all");

                _last = JsonConvert.DeserializeObject<DogInfo>(downloaded);
                return _last;
            }
            catch 
            {
                return new DogInfo
                {
                    Message = null,
                    Status = "Could not reach 'https://dog.ceo/api/breeds/list/all'"
                };
            }
        }

        private static DogInfo _last = null;
        /// <summary>
        /// Get the last requested <see cref="DogInfo"/> to save on performance - Does not include failed request
        /// </summary>
        public static DogInfo Requested
        {
            get
            {
                if(_last == null)
                {
                    return new DogInfo()
                    {
                        Message = null,
                        Status = "There has been zero former request."
                    };
                }

                return _last;
            }
        }
    }

    /// <summary>
    /// Represents a List of Dogs and their sub breeds in the forms of arrays.
    /// </summary>
    public sealed class DogList : IEnumerable<string>
    {
        private JObject Doggies { get; set; }
        internal DogList(JObject obj)
        {
            Doggies = obj;
            
        }

        /// <summary>
        /// Get all sub breeds of a dog via its name
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        public string[] this[string breed]
        {
            get
            {
                Doggies.TryGetValue(breed, StringComparison.OrdinalIgnoreCase, out JToken token);

                if (token == null)
                    return Array.Empty<string>();

                List<string> doggies = new List<string>();
                foreach (JToken sub in token.Values())
                {
                    doggies.Add($"{sub}");
                }

                return doggies.ToArray();
            }
        }

        /// <summary>
        /// Get all dog names
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string> GetEnumerator()
        {
            foreach (JProperty property in Doggies.Properties())
            {
                yield return property.Name;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
