using System;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RandomDog
{
    /// <summary>
    /// A single dog that has been requested.
    /// </summary>
    public sealed class Dog : DogAPI<string>
    {
        /// <summary>
        /// Fetch a random dog via their breed/sub-breed. Or leave null for any dog.
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="subBreed"></param>
        /// <returns></returns>
        public static async Task<Dog> FetchAsync(string breed = null, string subBreed = null)
        {
            string _base = string.Empty;

            bool breedVal = string.IsNullOrEmpty(breed);
            bool subBreedVal = string.IsNullOrEmpty(subBreed);

            if (breedVal && !subBreedVal)
                throw new Exception("You cannot get a dog by a Sub-breed alone. Breed must not be null or Empty!");

            if (breedVal && subBreedVal)
                _base = "https://dog.ceo/api/breeds/image/random";
            else if (!breedVal && subBreedVal)
                _base = $"https://dog.ceo/api/breed/{breed}/images/random";
            else
                _base = $"https://dog.ceo/api/breed/{breed}/{subBreed}/images/random";

            string json = await (await ApiRequester.RequestAPIAsync(_base, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Dog>(json);
        }
    }
}
