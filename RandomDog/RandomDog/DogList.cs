using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RandomDog
{
    /// <summary>
    /// Different from the <see cref="EnumerableDogAPI"/> as in it request only from a certain link <see cref="ListAll"/>
    /// </summary>
    public class DogList : DogAPI<AllDog>
    {
        private const string ListAll = "https://dog.ceo/api/breeds/list/all";

        private static DogList _last;

        /// <summary>
        /// The last requested <see cref="DogList"/> | CAN BE NULL
        /// </summary>
        public static DogList LastRequested => _last;

        /// <summary>
        /// Get every single dog! | NOT IMAGES
        /// </summary>
        /// <returns></returns>
        public static async Task<DogList> GetAllAsync()
        {
            string json = await (await ApiRequester.RequestAPIAsync(ListAll, ApiRequester.RequestType.Get)).Content.ReadAsStringAsync();

            _last = JsonConvert.DeserializeObject<DogList>(json);
            return _last;
        }

        /// <summary>
        /// Get every single dog! | NOT IMAGES
        /// </summary>
        /// <returns></returns>
        public static DogList GetAll() => GetAllAsync().Result;
    }

    /// <summary>
    /// All dogs in the form of a <see cref="string"/>[]
    /// </summary>
    public sealed class AllDog
    {
        public string[] affenpinscher { get; set; }
        public string[] african { get; set; }
        public string[] airedale { get; set; }
        public string[] akita { get; set; }
        public string[] appenzeller { get; set; }
        public string[] australian { get; set; }
        public string[] basenji { get; set; }
        public string[] beagle { get; set; }
        public string[] bluetick { get; set; }
        public string[] borzoi { get; set; }
        public string[] bouvier { get; set; }
        public string[] boxer { get; set; }
        public string[] brabancon { get; set; }
        public string[] briard { get; set; }
        public string[] buhund { get; set; }
        public string[] bulldog { get; set; }
        public string[] bullterrier { get; set; }
        public string[] cairn { get; set; }
        public string[] cattledog { get; set; }
        public string[] chihuahua { get; set; }
        public string[] chow { get; set; }
        public string[] clumber { get; set; }
        public string[] cockapoo { get; set; }
        public string[] collie { get; set; }
        public string[] coonhound { get; set; }
        public string[] corgi { get; set; }
        public string[] cotondetulear { get; set; }
        public string[] dachshund { get; set; }
        public string[] dalmatian { get; set; }
        public string[] dane { get; set; }
        public string[] deerhound { get; set; }
        public string[] dhole { get; set; }
        public string[] dingo { get; set; }
        public string[] doberman { get; set; }
        public string[] elkhound { get; set; }
        public string[] entlebucher { get; set; }
        public string[] eskimo { get; set; }
        public string[] finnish { get; set; }
        public string[] frise { get; set; }
        public string[] germanshepherd { get; set; }
        public string[] greyhound { get; set; }
        public string[] groenendael { get; set; }
        public string[] havanese { get; set; }
        public string[] hound { get; set; }
        public string[] husky { get; set; }
        public string[] keeshond { get; set; }
        public string[] kelpie { get; set; }
        public string[] komondor { get; set; }
        public string[] kuvasz { get; set; }
        public string[] labradoodle { get; set; }
        public string[] labrador { get; set; }
        public string[] leonberg { get; set; }
        public string[] lhasa { get; set; }
        public string[] malamute { get; set; }
        public string[] malinois { get; set; }
        public string[] maltese { get; set; }
        public string[] mastiff { get; set; }
        public string[] mexicanhairless { get; set; }
        public string[] mix { get; set; }
        public string[] mountain { get; set; }
        public string[] newfoundland { get; set; }
        public string[] otterhound { get; set; }
        public string[] ovcharka { get; set; }
        public string[] papillon { get; set; }
        public string[] pekinese { get; set; }
        public string[] pembroke { get; set; }
        public string[] pinscher { get; set; }
        public string[] pitbull { get; set; }
        public string[] pointer { get; set; }
        public string[] pomeranian { get; set; }
        public string[] poodle { get; set; }
        public string[] pug { get; set; }
        public string[] puggle { get; set; }
        public string[] pyrenees { get; set; }
        public string[] redbone { get; set; }
        public string[] retriever { get; set; }
        public string[] ridgeback { get; set; }
        public string[] rottweiler { get; set; }
        public string[] saluki { get; set; }
        public string[] samoyed { get; set; }
        public string[] schipperke { get; set; }
        public string[] schnauzer { get; set; }
        public string[] setter { get; set; }
        public string[] sheepdog { get; set; }
        public string[] shiba { get; set; }
        public string[] shihtzu { get; set; }
        public string[] spaniel { get; set; }
        public string[] springer { get; set; }
        public string[] terrier { get; set; }
        public string[] vizsla { get; set; }
        public string[] waterdog { get; set; }
        public string[] weimaraner { get; set; }
        public string[] whippet { get; set; }
        public string[] wolfhound { get; set; }
    }
}
