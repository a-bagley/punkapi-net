using System;

namespace PunkApiNet.Configuration
{
    public class ExternalWebApiConfiguration : IExternalWebApiConfiguration
    {
        /// <summary>
        /// The base Url for the web service.
        /// </summary>
        public Uri BaseUrl { get; set; }

        /// <summary>
        /// Default timeout in seconds for requests to the web service.
        /// </summary>
        public int TimeoutSeconds { get; set; }
    }
}
