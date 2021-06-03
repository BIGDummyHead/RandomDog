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
    class Program
    {
        static async Task Main()
        {
            var x = DogList.LastRequested ?? await DogList.GetAllAsync();
            foreach (var item in x)
            {
                foreach (var sub in item)
                {
                    Console.WriteLine(sub);
                }

                Console.WriteLine();
                Console.WriteLine("Different Dog");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();

            await Main();
        }
    }


    /// <summary>
    /// A single dog that has been requested.
    /// </summary>
    public sealed class Dog : BaseApi<string>
    {


        /// <summary>
        /// Fetch a random dog via their breed/sub-breed. Or leave null for any dog.
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="subBreed"></param>
        /// <returns></returns>
        public static async Task<Dog> FetchAsync(string breed = null, string subBreed = null)
        {
            string _base;

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

            string json = await (await ApiRequester.RequestAPIAsync(_base, RequestType.Get)).Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Dog>(json);
        }

        /// <summary>
        /// Fetch a random dog via their breed/sub-breed. Or leave null for any dog.
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="subBreed"></param>
        /// <returns></returns>
        public static Dog Fetch(string breed = null, string subBreed = null) => FetchAsync(breed, subBreed).Result;
    }
}

