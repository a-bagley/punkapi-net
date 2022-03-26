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

Console.WriteLine($"Fetched {beers.Count()} beers:");

foreach (var beer in beers)
{
    Console.WriteLine($"{beer.Id}: {beer.Name} ({beer.Abv}%) : {beer.Tagline} ");
}


var requestParams = new PunkApiRequestParamsBuilder()
    .WithAbvGreatherThan(6)
    .WithMaxResultsPerPage(5)
    .WithPage(2)
    .Build();

Console.WriteLine(Environment.NewLine);
Console.WriteLine("Fetching page 2 of beers with Abv over 5%");

var SecondSetOfBeersOverSixPercentAbv = await punkApiClient.GetAllBeersWithFilterAsync(requestParams);

foreach (var beer in SecondSetOfBeersOverSixPercentAbv)
{
    Console.WriteLine($"{beer.Id}: {beer.Name} ({beer.Abv}%) : {beer.Tagline} ");
}