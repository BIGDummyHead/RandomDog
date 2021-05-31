using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RandomDog
{
    /// <summary>
    /// Represents the base dog api that has an <see cref="IEnumerable{T}"/> message
    /// </summary>
    public abstract class EnumerableDogAPI : BadRequest
    {
        /// <summary>
        /// The Enumerable message
        /// </summary>
        public string[] Message { get; set; }
    }
}
