# Here-DotNet

[![Build status](https://ci.appveyor.com/api/projects/status/6sft8oq9spmxex0t?svg=true)](https://ci.appveyor.com/project/463728946/here-dotnet)


### Hello World

```c#
using System.Threading.Tasks;
using HereDotNet.Core.Configuration;
using HereDotNet.Core.Model;
using HereDotNet.Core.Request;
using HereDotNet.Core.Services;

namespace MyConsoleApp
{
    class Program
    {
        private static async Task Main()
        {            
            var searchService = new SearchService(new HereConfiguration("<Your ApiKey>"));
            var result = await searchService.SearchAsync(new GeocodeRequest("WARM SPRINGS BLVD FREMONT CA 94000"));
        }
    }
}
```



### Microsoft DependencyInjection

```c#
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HereDotNet.Core.Configuration;
using HereDotNet.Core.Model;
using HereDotNet.Core.Request;
using HereDotNet.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MyConsoleApp
{
    class Program
    {
        private static async Task Main()
        {
            var services = new ServiceCollection()
                .AddHereDotNet(cfg => cfg
                    .UseApiKey("<Your ApiKey>")
                    .AddRouteService())
                .BuildServiceProvider();
            
            var request = new FindSequenceRequest(
                DateTime.UtcNow.AddDays(1),
                new List<Waypoint> { new Waypoint(33.99450952, -118.2264696) },
                new Coordinates(33.98269305, -118.1723896)
                );
            
            await route.FindsequenceAsync(request);
        }
    }
}
```



### Autofac

```c#
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HereDotNet.Core.Configuration;
using HereDotNet.Core.Model;
using HereDotNet.Core.Request;
using HereDotNet.Core.Services;
using Autofac;

namespace MyConsoleApp
{
    class Program
    {
        private static async Task Main()
        {
           、、
            
            await route.FindsequenceAsync(request);
        }
    }
}
```

## Roadmap

HERE Routing API v8

- [x] Findsequence
- [ ] More....




HERE Geocoding & Search API v7

- [x] Endpoint (Discvoer Geocode Autocomplete Autosuggest Browse)
- [ ] More....