using Microsoft.AspNetCore.Mvc;
using WebApplication6.Services;

namespace WebApplication6;

[Route("api/[controller]")]
[ApiController]
public class Endpoints : ControllerBase
{
    private readonly AccountService _accountService;


    public Endpoints(AccountService accountService)
    {
        _accountService = accountService;
     
    }
    
    
    

    [HttpGet("{accountId:int}")]
    public async Task<IResult> GetAccount(int accountId)
    {
        var account = await _accountService.GetAccountByIdAsync(accountId);

        if (account == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(account);
    }

    [HttpPost]
    public async Task<IResult> CreateProduct([FromBody] ProductRequest request)
    {
        try
        {
            var success = await _accountService.AddProductAsync(
                request.ProductName,
                request.ProductWeight,
                request.ProductWidth,
                request.ProductHeight,
                request.ProductDepth,
                request.ProductCategories
            );

            if (!success)
            {
                return Results.BadRequest("Failed to add product.");
            }

            return Results.Ok("Product added successfully.");
        }
        catch (Exception e)
        {
            return Results.BadRequest(e.Message);
        }
    }


    public class ProductRequest
    {
        public string ProductName { get; set; }
        public decimal ProductWeight { get; set; }
        public decimal ProductWidth { get; set; }
        public decimal ProductHeight { get; set; }
        public decimal ProductDepth { get; set; }
        public List<int> ProductCategories { get; set; }
    }
}

