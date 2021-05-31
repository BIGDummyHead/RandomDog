namespace RandomDog
{
    /// <summary>
    /// The base for all DogAPI request
    /// </summary>
    public abstract class DogAPI<T> : BadRequest
    {
        /// <summary>
        /// The message from the api
        /// </summary>
        public T Message { get; set; }
        
    }
}