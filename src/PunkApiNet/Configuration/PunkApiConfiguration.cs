using System;

namespace PunkApiNet.Configuration
{
    /// <summary>
    /// Default PunkApi service configuration with
    /// BaseUrl: https://api.punkapi.com/v2/
    /// Timeout: 5 seconds
    /// </summary>
    public class PunkApiConfiguration : ExternalWebApiConfiguration
    {
        public PunkApiConfiguration()
        {
            BaseUrl = new Uri("https://api.punkapi.com/v2/");
            TimeoutSeconds = 5;
        }
    }
}
