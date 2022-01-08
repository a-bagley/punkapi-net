using System;

namespace PunkApiNet.Configuration
{
    public interface IExternalWebApiConfiguration
    {
        public Uri BaseUrl { get; set; }
        public int TimeoutSeconds { get; set; }
    }
}
