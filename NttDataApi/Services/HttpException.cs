using System;
using System.Runtime.Serialization;

namespace NttDataApi.Services
{
    [Serializable]
    internal class HttpException : Exception
    {
        private string message;
        private string friendlyMessage;
        private int httpStatusCode;
        private Exception innerException;

        public HttpException()
        {
        }

        public HttpException(string message) : base(message)
        {
        }

        public HttpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public HttpException(string message, string friendlyMessage, int httpStatusCode, Exception innerException)
        {
            this.message = message;
            this.friendlyMessage = friendlyMessage;
            this.httpStatusCode = httpStatusCode;
            this.innerException = innerException;
        }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public object FriendlyMessage { get; internal set; }
    }
}
