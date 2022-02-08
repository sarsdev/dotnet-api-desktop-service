using ProductPackagingService;
using ProductPackagingService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options => {
        options.ServiceName = "Product Packaging Service";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient<ProductService>();
    })
    .Build();

await host.RunAsync();
