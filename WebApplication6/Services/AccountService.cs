using WebApplication6.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Services;

public class AccountService
{
    private readonly ShopContext.AppDbContext _context;
    
    public AccountService(ShopContext.AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<object> GetAccountByIdAsync(int accountId)
    {
        var account = await _context.Accounts
            .Include(a => a.Role)
            .Include(a => a.ShoppingCarts)
            .ThenInclude(sc => sc.Product)
            .FirstOrDefaultAsync(a => a.PK_account == accountId);

        if (account == null)
        {
            return null;
        }

        var result = new
        {
            firstName = account.first_name,
            lastName = account.last_name,
            email = account.email,
            phone = account.phone,
            role = account.Role.name,
            cart = account.ShoppingCarts.Select(sc => new 
            {
                productId = sc.FK_product,
                productName = sc.Product.name,
                amount = sc.amount
            }).ToList()
        };

        return result;
    }
    
    public async Task<bool> AddProductAsync(string productName, decimal productWeight, decimal productWidth, decimal productHeight, decimal productDepth, List<int> productCategories)
    {
        var product = new Products
        {
            name = productName,
            weight = productWeight,
            width = productWidth,
            height = productHeight,
            depth = productDepth
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        foreach (var categoryId in productCategories)
        {
            var productCategory = new Products_Categories()
            {
                FK_product = product.PK_product,
                FK_category = categoryId
            };

            _context.ProductsCategories.Add(productCategory);
        }

        await _context.SaveChangesAsync();

        return true;
    }
}