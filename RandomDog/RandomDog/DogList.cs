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
        /// <summary>
        /// Get an array of dogs sub-breeds via <see cref="DogBreeds"/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string[] this[DogBreeds index]
        {
            get
            {
                switch (index)
                {
                    case DogBreeds.affenpinscher:
                        return affenpinscher;
                    case DogBreeds.african:
                        return african;
                    case DogBreeds.airedale:
                        return airedale;
                    case DogBreeds.akita:
                        return akita;
                    case DogBreeds.appenzeller:
                        return appenzeller;
                    case DogBreeds.australian:
                        return australian;
                    case DogBreeds.basenji:
                        return basenji;
                    case DogBreeds.beagle:
                        return beagle;
                    case DogBreeds.bluetick:
                        return bluetick;
                    case DogBreeds.borzoi:
                        return borzoi;
                    case DogBreeds.bouvier:
                        return bouvier;
                    case DogBreeds.boxer:
                        return boxer;
                    case DogBreeds.brabancon:
                        return brabancon;
                    case DogBreeds.briard:
                        return briard;
                    case DogBreeds.bulldog:
                        return bulldog;
                    case DogBreeds.bullterrier:
                        return bullterrier;
                    case DogBreeds.cairn:
                        return cairn;
                    case DogBreeds.cattledog:
                        return cattledog;
                    case DogBreeds.chihuahua:
                        return chihuahua;
                    case DogBreeds.chow:
                        return chow;
                    case DogBreeds.clumber:
                        return clumber;
                    case DogBreeds.cockapoo:
                        return cockapoo;
                    case DogBreeds.collie:
                        return collie;
                    case DogBreeds.coonhound:
                        return coonhound;
                    case DogBreeds.corgi:
                        return corgi;
                    case DogBreeds.cotondetulear:
                        return cotondetulear;
                    case DogBreeds.dachshund:
                        return dachshund;
                    case DogBreeds.dalmatian:
                        return dalmatian;
                    case DogBreeds.dane:
                        return dane;
                    case DogBreeds.deerhound:
                        return deerhound;
                    case DogBreeds.dhole:
                        return dhole;
                    case DogBreeds.dingo:
                        return dingo;
                    case DogBreeds.doberman:
                        return doberman;
                    case DogBreeds.elkhound:
                        return elkhound;
                    case DogBreeds.entlebucher:
                        return entlebucher;
                    case DogBreeds.eskimo:
                        return eskimo;
                    case DogBreeds.finnish:
                        return finnish;
                    case DogBreeds.frise:
                        return frise;
                    case DogBreeds.germanshepherd:
                        return germanshepherd;
                    case DogBreeds.greyhound:
                        return greyhound;
                    case DogBreeds.groenendael:
                        return groenendael;
                    case DogBreeds.havanese:
                        return havanese;
                    case DogBreeds.hound:
                        return hound;
                    case DogBreeds.husky:
                        return husky;
                    case DogBreeds.keeshond:
                        return keeshond;
                    case DogBreeds.kelpie:
                        return kelpie;
                    case DogBreeds.komondor:
                        return komondor;
                    case DogBreeds.kuvasz:
                        return kuvasz;
                    case DogBreeds.labradoodle:
                        return labradoodle;
                    case DogBreeds.labrador:
                        return labrador;
                    case DogBreeds.leonberg:
                        return leonberg;
                    case DogBreeds.lhasa:
                        return lhasa;
                    case DogBreeds.malamute:
                        return malamute;
                    case DogBreeds.malinois:
                        return malinois;
                    case DogBreeds.maltese:
                        return maltese;
                    case DogBreeds.mastiff:
                        return mastiff;
                    case DogBreeds.mexicanhairless:
                        return mexicanhairless;
                    case DogBreeds.mix:
                        return mix;
                    case DogBreeds.mountain:
                        return mountain;
                    case DogBreeds.newfoundland:
                        return newfoundland;
                    case DogBreeds.otterhound:
                        return otterhound;
                    case DogBreeds.ovcharka:
                        return ovcharka;
                    case DogBreeds.papillon:
                        return papillon;
                    case DogBreeds.pekinese:
                        return pekinese;
                    case DogBreeds.pembroke:
                        return pembroke;
                    case DogBreeds.pinscher:
                        return pinscher;
                    case DogBreeds.pitbull:
                        return pitbull;
                    case DogBreeds.pointer:
                        return pointer;
                    case DogBreeds.pomeranian:
                        return pomeranian;
                    case DogBreeds.poodle:
                        return poodle;
                    case DogBreeds.pug:
                        return pug;
                    case DogBreeds.puggle:
                        return puggle;
                    case DogBreeds.pyrenees:
                        return pyrenees;
                    case DogBreeds.redbone:
                        return redbone;
                    case DogBreeds.retriever:
                        return retriever;
                    case DogBreeds.ridgeback:
                        return ridgeback;
                    case DogBreeds.rottweiler:
                        return rottweiler;
                    case DogBreeds.saluki:
                        return saluki;
                    case DogBreeds.samoyed:
                        return samoyed;
                    case DogBreeds.schipperke:
                        return schipperke;
                    case DogBreeds.schnauzer:
                        return schnauzer;
                    case DogBreeds.setter:
                        return setter;
                    case DogBreeds.sheepdog:
                        return sheepdog;
                    case DogBreeds.shiba:
                        return shiba;
                    case DogBreeds.shihtzu:
                        return shihtzu;
                    case DogBreeds.spaniel:
                        return spaniel;
                    case DogBreeds.springer:
                        return springer;
                    case DogBreeds.stbernard:
                        return stbernard;
                    case DogBreeds.terrier:
                        return terrier;
                    case DogBreeds.vizsla:
                        return vizsla;
                    case DogBreeds.waterdog:
                        return waterdog;
                    case DogBreeds.weimaraner:
                        return weimaraner;
                    case DogBreeds.whippet:
                        return whippet;
                    case DogBreeds.wolfhound:
                        return wolfhound;
                    default:
                        return Array.Empty<string>();
                }
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
            bool a = Enum.TryParse(name, out DogBreeds res);

            error = a;

            if (!a)
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
