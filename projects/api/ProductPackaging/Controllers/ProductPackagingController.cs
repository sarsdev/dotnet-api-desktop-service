using Microsoft.AspNetCore.Mvc;
using ProductPackaging.Models;
using ProductPackaging.Services;

namespace ProductPackaging.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductPackagingController : ControllerBase {

    private readonly ProductPackagingService _productPackagingService;

    public ProductPackagingController(ProductPackagingService productPackagingService) {
        _productPackagingService = productPackagingService;
    }

    [HttpGet("product/packaging")]
    public ActionResult<MResponseData> GetAllProductPackaging([FromQuery] int? qtdpage, int? skip) => _productPackagingService.Get(skip, qtdpage);

    [HttpGet("product/packaging/{code}")]
    public MResponseData GetOneProductPackaging(int code) => _productPackagingService.Get(code);

    [HttpPost("product/packaging")]
    public MResponseExecution PostProductPackaging([FromBody] MProductPackaging productPackaging) => _productPackagingService.Create(productPackaging);

    [HttpPut("product/packaging")]
    public MResponseExecution PutProductPackaging([FromBody] MProductPackaging productPackaging) => _productPackagingService.Update(productPackaging);

    [HttpDelete("product/packaging/{code}")]
    public MResponseExecution DeleteProductPackaging(int code) => _productPackagingService.Remove(code);
}