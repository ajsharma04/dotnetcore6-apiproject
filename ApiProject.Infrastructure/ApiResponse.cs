using System;

namespace ApiProject.Infrastructure
{
    /// <summary>
    /// Base class for building Api response following naming conventions from the Google Json style-guide
    /// https://google.github.io/styleguide/jsoncstyleguide.xml
    /// </summary>
    public abstract class ApiResponse
    {
        /// <summary>
        /// Unique id of the response that can be used for tracing/debug purposes
        /// </summary>
        public Guid Id { get; set; }

    }
}