using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace RandomDog
{
    /// <summary>
    /// Represents Info on dogs, these may contain images as well.
    /// <para>Inherits <see cref="EnumerableDogAPI"/></para>
    /// </summary>
    public sealed class DogInfo : EnumerableDogAPI
    {
        private const string DogCollection = "https://dog.ceo/api/breeds/image/random/";

        /// <summary>
        /// Get a collection of random dogs.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static async Task<DogInfo> GetRandomDogsAsync(int count)
        {
            string apiReq = DogCollection + count.ToString();

            string json = await (await ApiRequester.RequestAPIAsync(apiReq, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            if (JsonError(json, out BadRequest request))
                return new DogInfo()
                {
                    Code = request.Code,
                    Message = new string[] { "No information provided" },
                    Status = request.Status
                };

            return JsonConvert.DeserializeObject<DogInfo>(json);
        }

        /// <summary>
        /// Get a collection of random dogs.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static DogInfo GetRandomDogs(int count) => GetRandomDogsAsync(count).Result;


        /// <summary>
        /// Returns an array of all the images from a breed, e.g. hound
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        public static async Task<DogInfo> GetAllByBreedAsync(string breed)
        {
            string req = $"https://dog.ceo/api/breed/{breed}/images";

            string json = await (await ApiRequester.RequestAPIAsync(req, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DogInfo>(json);
        }

        /// <summary>
        /// Returns an array of all the images from a breed, e.g. hound
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        public static DogInfo GetAllByBreed(string breed) => GetAllByBreedAsync(breed).Result;


        /// <summary>
        /// Return multiple random dog images from a breed, e.g. hound
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static async Task<DogInfo> GetDogsOfBreedAsync(string breed, int count)
        {
            if (string.IsNullOrWhiteSpace(breed))
            {
                throw new ArgumentException($"'{nameof(breed)}' cannot be null or whitespace.", nameof(breed));
            }

            string req = $"https://dog.ceo/api/breed/{breed}/images/random/{count}";

            string json = await (await ApiRequester.RequestAPIAsync(req, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            if (JsonError(json, out BadRequest request))
                return new DogInfo()
                {
                    Code = request.Code,
                    Message = new string[] { "No information provided" },
                    Status = request.Status
                };

            return JsonConvert.DeserializeObject<DogInfo>(json);
        }

        /// <summary>
        /// Return multiple random dog images from a breed, e.g. hound
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static DogInfo GetDogsOfBreed(string breed, int count) => GetDogsOfBreedAsync(breed, count).Result;

        /// <summary>
        /// Returns an array of all the sub-breeds from a breed
        /// </summary>
        /// <returns></returns>
        public static async Task<DogInfo> GetSubBreedsAsync(string breed)
        {
            if (string.IsNullOrWhiteSpace(breed))
            {
                throw new ArgumentException($"'{nameof(breed)}' cannot be null or whitespace.", nameof(breed));
            }

            string req = $"https://dog.ceo/api/breed/{breed}/list";

            string json = await (await ApiRequester.RequestAPIAsync(req, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            if (JsonError(json, out BadRequest request))
                return new DogInfo()
                {
                    Code = request.Code,
                    Message = new string[] { "No information provided" },
                    Status = request.Status
                };

            return JsonConvert.DeserializeObject<DogInfo>(json);
        }


        /// <summary>
        /// Returns an array of all the sub-breeds from a breed
        /// </summary>
        /// <returns></returns>
        public static DogInfo GetSubBreeds(string breed) => GetSubBreedsAsync(breed).Result;

        /// <summary>
        /// Returns an array of all the images from the sub-breed
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="subBreed"></param>
        /// <returns></returns>
        public static async Task<DogInfo> GetSubImagesAsync(string breed, string subBreed)
        {
            if (string.IsNullOrWhiteSpace(breed))
            {
                throw new ArgumentException($"'{nameof(breed)}' cannot be null or whitespace.", nameof(breed));
            }

            if (string.IsNullOrWhiteSpace(subBreed))
            {
                throw new ArgumentException($"'{nameof(subBreed)}' cannot be null or whitespace.", nameof(subBreed));
            }

            string req = $"https://dog.ceo/api/breed/{breed}/{subBreed}/images";

            string json = await (await ApiRequester.RequestAPIAsync(req, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            if (JsonError(json, out BadRequest request))
                return new DogInfo()
                {
                    Code = request.Code,
                    Message = new string[] { "No information provided" },
                    Status = request.Status
                };

            return JsonConvert.DeserializeObject<DogInfo>(json);
        }

        /// <summary>
        /// Returns an array of all the images from the sub-breed
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="subBreed"></param>
        /// <returns></returns>
        public DogInfo GetSubImages(string breed, string subBreed) => GetSubImagesAsync(breed, subBreed).Result;

        /// <summary>
        /// Return multiple random dog images from a sub-breed, e.g. Afghan Hound
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="subBreed"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static async Task<DogInfo> GetDogsOfSubAsync(string breed, string subBreed, int count)
        {
            if (string.IsNullOrWhiteSpace(breed))
            {
                throw new ArgumentException($"'{nameof(breed)}' cannot be null or whitespace.", nameof(breed));
            }

            if (string.IsNullOrWhiteSpace(subBreed))
            {
                throw new ArgumentException($"'{nameof(subBreed)}' cannot be null or whitespace.", nameof(subBreed));
            }

            string req = $"https://dog.ceo/api/breed/{breed}/{subBreed}/images/random/{count}";

            string json = await (await ApiRequester.RequestAPIAsync(req, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            if (JsonError(json, out BadRequest request))
                return new DogInfo() 
                {
                    Code = request.Code,
                    Message = new string[] { "No information provided" },
                    Status = request.Status
                };

            return JsonConvert.DeserializeObject<DogInfo>(json);
        }

        /// <summary>
        /// Return multiple random dog images from a sub-breed, e.g. Afghan Hound
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="subBreed"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static DogInfo GetDogsOfSub(string breed, string subBreed, int count) => GetDogsOfSubAsync(breed, subBreed, count).Result;

        private static bool JsonError(string json, out BadRequest request)
        {
            request = JsonConvert.DeserializeObject<BadRequest>(json);
            return request.HasError;
        }
    }

}
