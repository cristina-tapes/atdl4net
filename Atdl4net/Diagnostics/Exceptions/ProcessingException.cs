using System;

namespace Atdl4net.Diagnostics.Exceptions
{
    public class ProcessingException : Atdl4netException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessingException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ProcessingException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessingException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ProcessingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}