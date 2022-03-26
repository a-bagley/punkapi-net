using Microsoft.Extensions.DependencyInjection;
using PunkApiNet;
using PunkApiNet.Extensions;

Console.WriteLine("Welcome to PunkApi-Net Demo!");

var serviceCollection = new ServiceCollection();

serviceCollection.AddPunkApiClient();
var serviceProvider = serviceCollection.BuildServiceProvider();

var punkApiClient = serviceProvider.GetRequiredService<IPunkApiClient>();

Console.WriteLine("Fetching all beers (25 by default)");

var beers = await punkApiClient.GetAllBeersAsync();

Console.WriteLine("Fetched 25 beers:");

foreach (var beer in beers)
{
    Console.WriteLine($"{beer.Id}: {beer.Name} ({beer.Abv}%) : {beer.Tagline} ");
}

