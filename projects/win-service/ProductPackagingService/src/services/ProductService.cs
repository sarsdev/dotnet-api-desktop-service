using System.Net.Http.Json;
using System.Text.Json;
using ProductPackagingService.Models;

namespace ProductPackagingService.Services;

public class ProductService
{
    private const string ApiUrl = "https://localhost:7053/ProductPackaging/product/packaging?qtdpage=100&skip=0";
    
    private readonly HttpClient _httpClient;
    
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public ProductService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<string> GetProductPackagingAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<MResponse>(ApiUrl, _options);
            if (response is not null) {
                CreateFile(response.Payload);
                return "Product packaging file was successfully generated";
            }
            return "Request return was null";
        }
        catch (Exception ex)
        {
            return $"Product Packaging file did not generate. Error: {ex}";
        }
    }

    private void CreateFile(List<MProductPackaging> pListProduct) 
    {
        string path = @"c:\Temp\ProductPackagingTest.txt";

        try
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach(var csv in pListProduct.Select(s => s.GetCSVData())) 
                {
                    sw.WriteLine(csv);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}