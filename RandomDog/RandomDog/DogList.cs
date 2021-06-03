using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomDog
{
    /// <summary>
    /// </summary>
    [JsonObject]
    public class DogList : BaseApi<AllDog>, IEnumerable<string[]>
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
            string json = await (await ApiRequester.RequestAPIAsync(ListAll, RequestType.Get)).Content.ReadAsStringAsync();

            _last = JsonConvert.DeserializeObject<DogList>(json);
            return _last;
        }

        /// <summary>
        /// Get every single dog! | NOT IMAGES
        /// </summary>
        /// <returns></returns>
        public static DogList GetAll() => GetAllAsync().Result;

        /// <summary>
        /// You can use this to get all the dogs you want.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string[]> GetEnumerator()
        {
            foreach (string[] item in Message.AllDogs)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// All dogs in the form of a <see cref="string"/>[]
    /// </summary>
    public sealed class AllDog
    {
        /// <summary>
        /// Get an array of dogs sub-breeds via <see cref="DogBreeds"/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string[] this[DogBreeds index]
        {
            get
            {
                return index switch
                {
                    DogBreeds.affenpinscher => affenpinscher,
                    DogBreeds.african => african,
                    DogBreeds.airedale => airedale,
                    DogBreeds.akita => akita,
                    DogBreeds.appenzeller => appenzeller,
                    DogBreeds.australian => australian,
                    DogBreeds.basenji => basenji,
                    DogBreeds.beagle => beagle,
                    DogBreeds.bluetick => bluetick,
                    DogBreeds.borzoi => borzoi,
                    DogBreeds.bouvier => bouvier,
                    DogBreeds.boxer => boxer,
                    DogBreeds.brabancon => brabancon,
                    DogBreeds.briard => briard,
                    DogBreeds.bulldog => bulldog,
                    DogBreeds.bullterrier => bullterrier,
                    DogBreeds.cairn => cairn,
                    DogBreeds.cattledog => cattledog,
                    DogBreeds.chihuahua => chihuahua,
                    DogBreeds.chow => chow,
                    DogBreeds.clumber => clumber,
                    DogBreeds.cockapoo => cockapoo,
                    DogBreeds.collie => collie,
                    DogBreeds.coonhound => coonhound,
                    DogBreeds.corgi => corgi,
                    DogBreeds.cotondetulear => cotondetulear,
                    DogBreeds.dachshund => dachshund,
                    DogBreeds.dalmatian => dalmatian,
                    DogBreeds.dane => dane,
                    DogBreeds.deerhound => deerhound,
                    DogBreeds.dhole => dhole,
                    DogBreeds.dingo => dingo,
                    DogBreeds.doberman => doberman,
                    DogBreeds.elkhound => elkhound,
                    DogBreeds.entlebucher => entlebucher,
                    DogBreeds.eskimo => eskimo,
                    DogBreeds.finnish => finnish,
                    DogBreeds.frise => frise,
                    DogBreeds.germanshepherd => germanshepherd,
                    DogBreeds.greyhound => greyhound,
                    DogBreeds.groenendael => groenendael,
                    DogBreeds.havanese => havanese,
                    DogBreeds.hound => hound,
                    DogBreeds.husky => husky,
                    DogBreeds.keeshond => keeshond,
                    DogBreeds.kelpie => kelpie,
                    DogBreeds.komondor => komondor,
                    DogBreeds.kuvasz => kuvasz,
                    DogBreeds.labradoodle => labradoodle,
                    DogBreeds.labrador => labrador,
                    DogBreeds.leonberg => leonberg,
                    DogBreeds.lhasa => lhasa,
                    DogBreeds.malamute => malamute,
                    DogBreeds.malinois => malinois,
                    DogBreeds.maltese => maltese,
                    DogBreeds.mastiff => mastiff,
                    DogBreeds.mexicanhairless => mexicanhairless,
                    DogBreeds.mix => mix,
                    DogBreeds.mountain => mountain,
                    DogBreeds.newfoundland => newfoundland,
                    DogBreeds.otterhound => otterhound,
                    DogBreeds.ovcharka => ovcharka,
                    DogBreeds.papillon => papillon,
                    DogBreeds.pekinese => pekinese,
                    DogBreeds.pembroke => pembroke,
                    DogBreeds.pinscher => pinscher,
                    DogBreeds.pitbull => pitbull,
                    DogBreeds.pointer => pointer,
                    DogBreeds.pomeranian => pomeranian,
                    DogBreeds.poodle => poodle,
                    DogBreeds.pug => pug,
                    DogBreeds.puggle => puggle,
                    DogBreeds.pyrenees => pyrenees,
                    DogBreeds.redbone => redbone,
                    DogBreeds.retriever => retriever,
                    DogBreeds.ridgeback => ridgeback,
                    DogBreeds.rottweiler => rottweiler,
                    DogBreeds.saluki => saluki,
                    DogBreeds.samoyed => samoyed,
                    DogBreeds.schipperke => schipperke,
                    DogBreeds.schnauzer => schnauzer,
                    DogBreeds.setter => setter,
                    DogBreeds.sheepdog => sheepdog,
                    DogBreeds.shiba => shiba,
                    DogBreeds.shihtzu => shihtzu,
                    DogBreeds.spaniel => spaniel,
                    DogBreeds.springer => springer,
                    DogBreeds.stbernard => stbernard,
                    DogBreeds.terrier => terrier,
                    DogBreeds.vizsla => vizsla,
                    DogBreeds.waterdog => waterdog,
                    DogBreeds.weimaraner => weimaraner,
                    DogBreeds.whippet => whippet,
                    DogBreeds.wolfhound => wolfhound,
                    _ => Array.Empty<string>(),
                };
            }
        }

        /// <summary>
        /// Every single dog
        /// </summary>
        public IEnumerable<string[]> AllDogs
        {
            get
            {
                foreach (DogBreeds dog in AllBreeds)
                    yield return this[dog];
            }
        }

        /// <summary>
        /// Get a sub-breed of dogs by their name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public string[] GetByName(string name, out bool error)
        {
            error = !Enum.TryParse(name, true, out DogBreeds res);

            if (error)
                return Array.Empty<string>();

            return this[res];
        }

        public string[] stbernard { get; set; }
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

        /// <summary>
        /// All breeds that can be used in a foreach statement
        /// </summary>
        public IEnumerable<DogBreeds> AllBreeds
        {
            get
            {
                var vals = Enum.GetValues(typeof(DogBreeds));

                foreach (var item in vals)
                    yield return (DogBreeds)item;
            }
        }
    }

    public enum DogBreeds
    {
        affenpinscher,
        african,
        airedale,
        akita,
        appenzeller,
        australian,
        basenji,
        beagle,
        bluetick,
        borzoi,
        bouvier,
        boxer,
        brabancon,
        briard,
        bulldog,
        bullterrier,
        cairn,
        cattledog,
        chihuahua,
        chow,
        clumber,
        cockapoo,
        collie,
        coonhound,
        corgi,
        cotondetulear,
        dachshund,
        dalmatian,
        dane,
        deerhound,
        dhole,
        dingo,
        doberman,
        elkhound,
        entlebucher,
        eskimo,
        finnish,
        frise,
        germanshepherd,
        greyhound,
        groenendael,
        havanese,
        hound,
        husky,
        keeshond,
        kelpie,
        komondor,
        kuvasz,
        labradoodle,
        labrador,
        leonberg,
        lhasa,
        malamute,
        malinois,
        maltese,
        mastiff,
        mexicanhairless,
        mix,
        mountain,
        newfoundland,
        otterhound,
        ovcharka,
        papillon,
        pekinese,
        pembroke,
        pinscher,
        pitbull,
        pointer,
        pomeranian,
        poodle,
        pug,
        puggle,
        pyrenees,
        redbone,
        retriever,
        ridgeback,
        rottweiler,
        saluki,
        samoyed,
        schipperke,
        schnauzer,
        setter,
        sheepdog,
        shiba,
        shihtzu,
        spaniel,
        springer,
        stbernard,
        terrier,
        vizsla,
        waterdog,
        weimaraner,
        whippet,
        wolfhound

    }
}
