using ProductPackagingService.Models;
using ProductPackagingService.Services;

namespace ProductPackagingService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    private readonly ProductService _productPackaging;

    public Worker(
        ProductService productPackaging,
        ILogger<Worker> logger
    ) {
        _productPackaging = productPackaging;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            string response = await _productPackaging.GetProductPackagingAsync();
            _logger.LogInformation($"Product Packaging execution finish. Status: {response}");

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
