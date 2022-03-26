using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PunkApiNet.Configuration;
using System;
using System.Net.Http;

namespace PunkApiNet.Extensions
{
    public static class ServicesCollectionExtensions
    {
        /// <summary>
        /// Adds a typed HttpClient for <see cref="IPunkApiClient"/> implemented by <see cref="PunkApiClient"/> with a default URL for the PunkApi service.
        /// </summary>
        /// <param name="services">The IServiceCollection instance</param>
        /// <param name="punkApiConfigurationAction">Action to configure the PunkApiClient</param>
        /// <returns>The IServiceCollection instance</returns>
        public static IServiceCollection AddPunkApiClient(this IServiceCollection services, Action<PunkApiConfiguration> punkApiConfigurationAction)
        {
            services.AddOptions();
            services.Configure(punkApiConfigurationAction);
            services.AddTypedHttpClient<IPunkApiClient, PunkApiClient, PunkApiConfiguration>();

            return services;
        }

        /// <summary>
        /// Adds a typed HttpClient for <see cref="IPunkApiClient"/> implemented by <see cref="PunkApiClient"/> with a default URL for the PunkApi service.
        /// </summary>
        /// <param name="services">The IServiceCollection instance</param>
        /// <returns>The IServiceCollection instance</returns>
        public static IServiceCollection AddPunkApiClient(this IServiceCollection services)
        {
            return AddPunkApiClient(services, null);
        }

        public static IHttpClientBuilder AddTypedHttpClient<T, TImpl, TOptions>(
            this IServiceCollection services)
            where T : class
            where TImpl : class, T
            where TOptions : class, IExternalWebApiConfiguration, new()
            => services.AddHttpClient<T, TImpl>(SetupHttpClient<TOptions>);

        private static void SetupHttpClient<TOptions>(IServiceProvider serviceProvider, HttpClient client)
        where TOptions : class, IExternalWebApiConfiguration, new()
        {
            var iOptions = serviceProvider.GetRequiredService<IOptions<TOptions>>();
            var httpClientOptions = iOptions.Value;
            client.ConfigureHttpClient(httpClientOptions);
        }

        private static void ConfigureHttpClient(this HttpClient httpClient, IExternalWebApiConfiguration options)
        {
            httpClient.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            httpClient.BaseAddress = options.BaseUrl;
        }
    }   
}
