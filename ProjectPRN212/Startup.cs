using Microsoft.Extensions.DependencyInjection;
using ProjectPRN212.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN212
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register HttpClient with base URL
            services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7257/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            // Register services that use HttpClient
            services.AddTransient<ProductApiService>();

            return services.BuildServiceProvider();
        }
    }
}
