namespace RandomDog
{
    /// <summary>
    /// Represents something that could have a bad request
    /// </summary>
    public class BadRequest
    {
        /// <summary>
        /// The status of the request
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The status of code of the request.
        /// <para>200 == 0</para>
        /// </summary>
        public int Code { get; set; } = 200;

        /// <summary>
        /// Returns | Code != 200
        /// </summary>
        public bool HasError => Code != 200;
    }
}
