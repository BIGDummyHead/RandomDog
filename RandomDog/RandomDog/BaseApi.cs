using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RandomDog
{
    /// <summary>
    /// The base for all Dog API request
    /// </summary>
    public abstract class BaseApi<T> : BadRequest
    {
        /// <summary>
        /// The message from the api
        /// </summary>
        public T Message { get; set; }

    }
}