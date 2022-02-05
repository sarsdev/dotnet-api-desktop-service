using Microsoft.AspNetCore.Mvc;
using ProductPackaging.Models;

namespace ProductPackaging.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductPackagingController : ControllerBase {

    public ProductPackagingController() { }

    [HttpGet("product/packaging")]
    public MResponseData GetAllProductPackaging() {
        var productList = new List<MProductPackaging>() {
            new MProductPackaging() {
                Code = 100,
                Description = "Product One",
                Unit = "UN"
            },
            new MProductPackaging() {
                Code = 101,
                Description = "Product Two",
                Unit = "PCK"
            }
        };
        var footerList = new MFooter() {
            Page = 0,
            Skip = 0,
            hasNext = false,
            TotalRecords = 2
        };
        return new MResponseData() {
            Status = "SUCESS",
            Payload = productList,
            Footer = footerList
        };
    }

    [HttpGet("product/packaging/{code}")]
    public MResponseData GetOneProductPackaging() {
        var productList = new List<MProductPackaging>() {
            new MProductPackaging() {
                Code = 100,
                Description = "Product One",
                Unit = "UN"
            }
        };
        var footerList = new MFooter() {
            Page = 0,
            Skip = 0,
            hasNext = false,
            TotalRecords = 2
        };
        return new MResponseData() {
            Status = "SUCESS",
            Payload = productList,
            Footer = footerList
        };
    }

    [HttpPost("product/packaging")]
    public MResponseExecution PostProductPackaging() {
        return new MResponseExecution(){
            Status = "SUCESS",
            Message = "Product packaging created"
        };
    }

    [HttpPut("product/packaging")]
    public MResponseExecution PutProductPackaging() {
        return new MResponseExecution(){
            Status = "SUCESS",
            Message = "Product packaging updated"
        };
    }

    [HttpDelete("product/packaging")]
    public MResponseExecution DeleteProductPackaging() {
        return new MResponseExecution(){
            Status = "SUCESS",
            Message = "Product packaging deleted"
        };
    }
}