# punkapi-net ![example workflow](https://github.com/a-bagley/punkapi-net/actions/workflows/build.yml/badge.svg)

.Net client library for PUNK API (https://punkapi.com)

See the [Demo](https://github.com/a-bagley/punkapi-net/blob/main/demo/PunkApiNetDemo/Program.cs) console app or follow the instructions below to get started.

## Configuration
Punkapi-net can easily be configured for use with your .Net application using the Service Collections Extension Pattern.
```cs
using PunkApiNet;

// Default config
public void ConfigureServices(IServiceCollection services)
{
	services.AddPunkApiClient();
}

// Or customise config
public void ConfigureServices(IServiceCollection services)
{
	services.AddPunkApiClient((config) => 
    {
        config.BaseUrl = new Uri("https://some-other-punkapi-location");
        config.TimeoutSeconds = 10;
    });
}
```

## Inject into your class and use
```cs
public class MyClass
{
    private readonly IPunkApiClient _punkApiClient;

    public MyClass(IPunkApiClient punkApiClient)
    {
        _punkApiClient = punkApiClient;
    }

    public async IEnumerable<Beer> GetBeersAsync()
    {
        return await _punkApiClient.GetAllBeersAsync();
    }
}
```
