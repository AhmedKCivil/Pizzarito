using Core.Entities;
using Core.Entities.Core_Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaritoShop.Data;
using Repository.Helpers;


namespace Service
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<List<Product>> GetAllProductsAsync(string apiUrl, string category = null)
        {
            List<Product> products = null;

            try
            {
                // Attempt to fetch data from the API
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var ProductsJson = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(ProductsJson);
                }
            }
            catch (Exception ex)
            {

            }

            // If the API call fails, fallback to fetching from the database
            if (products == null || !products.Any())
            {
                products = await _context.Products.ToListAsync();

            }

            return products;

        }
        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                ProductName = data.ProductName,
                Price = data.Price,
                Description = data.Description,
                ImageTitle = data.ImageTitle,
                CategoryId = data.CategoryId
            };

           await  _context.Products.AddAsync(newProduct);
           await _context.SaveChangesAsync();
        }
        public async Task AddToCartAsync(int productId, string imageTitle, string productName, double productPrice, string cartSessionKey)
        {
            // Retrieve the existing cart from session or create a new one
            var cart = _httpContextAccessor.HttpContext.Session.GetObject<List<CartItem>>(cartSessionKey) ?? new List<CartItem>();

            // Check if the product already exists in the cart
            var existingItem = cart.FirstOrDefault(c => c.ProductId == productId);
            if (existingItem != null)
            {
                // If the product already exists, increase the quantity
                existingItem.Quantity++;
            }
            else
            {
                // If not, add the new CartItem to the cart
                var cartItem = new CartItem
                { 
                    ProductId = productId,
                    ProductName = productName,
                    ProductPrice = productPrice,
                    Quantity = 1,
                };
                cart.Add(cartItem);
            }

            // Save the updated cart back to the session
            _httpContextAccessor.HttpContext.Session.SetObject(cartSessionKey, cart);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            return productDetails;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(int id, Product updatedProduct)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            // Update specific properties
            existingProduct.ProductName = updatedProduct.ProductName;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.ImageTitle = updatedProduct.ImageTitle;
            existingProduct.Category = updatedProduct.Category;

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

