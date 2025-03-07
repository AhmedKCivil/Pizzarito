//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Newtonsoft.Json;
//using PizzaritoShop.Helpers;
//using PizzaritoShop.Model;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Net.Http;

//namespace PizzaritoShop.Data.Services.Base

    //public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    //{
    //    private readonly ApplicationDbContext _context;
    //    private readonly IHttpContextAccessor _httpContextAccessor;
    //    private readonly IHttpClientFactory _httpClientFactory;
    //    private ApplicationDbContext context;

    //    public EntityBaseRepository(ApplicationDbContext context)
    //    {
    //        this.context = context;
    //    }

    //    public EntityBaseRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    //    {
    //        _context = context;
    //        _httpContextAccessor = httpContextAccessor; // Initialize IHttpContextAccessor
    //    }

    //    public async Task AddAsync(T entity)
    //    {
    //        await _context.Set<T>().AddAsync(entity);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task AddToCartAsync(int pizzaId, string imageTitle, string pizzaName, double pizzaPrice, string cartSessionKey)
    //    {
    //        // Retrieve the existing cart from session or create a new one
    //        var cart = _httpContextAccessor.HttpContext.Session.GetObject<List<CartItem>>(cartSessionKey) ?? new List<CartItem>();

    //        // Check if the pizza already exists in the cart
    //        var existingItem = cart.FirstOrDefault(c => c.PizzaId == pizzaId);
    //        if (existingItem != null)
    //        {
    //            // If the pizza already exists, increase the quantity
    //            existingItem.Quantity++;
    //        }
    //        else
    //        {
    //            // If not, add the new CartItem to the cart
    //            var cartItem = new CartItem
    //            {
    //                PizzaId = pizzaId,
    //                PizzaName = pizzaName,
    //                PizzaPrice = pizzaPrice,
    //                Quantity = 1,
    //                ImageTitle = imageTitle
    //            };
    //            cart.Add(cartItem);
    //        }

    //        // Save the updated cart back to the session
    //        _httpContextAccessor.HttpContext.Session.SetObject(cartSessionKey, cart);
    //    }

    //    public async Task DeleteAsync(int id)
    //    {
    //        var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
    //        if (entity != null)
    //        {
    //            _context.Remove(entity);
    //            await _context.SaveChangesAsync();

    //        }
    //    }

    //    public async Task<List<PizzasModel>> GetAllPizzasAsync(string apiUrl)
    //    {
    //        List<PizzasModel> pizzas = null;

    //        try
    //        { 
    //            // Attempt to fetch data from the API
    //            var client = _httpClientFactory.CreateClient();
    //            var response = await client.GetAsync(apiUrl);

    //            if (response.IsSuccessStatusCode)
    //            {
    //                var pizzasJson = await response.Content.ReadAsStringAsync();
    //                pizzas = JsonConvert.DeserializeObject<List<PizzasModel>>(pizzasJson);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
                
    //        }

    //        // If the API call fails, fallback to fetching from the database
    //        if (pizzas == null || !pizzas.Any())
    //        {
    //            pizzas = (await GetAllAsync<PizzasModel>()).ToList();
    //        }

    //        return pizzas;
    //    }

    //    //For example, if you have a Movie entity that has related Actors and Producers, you can eagerly load them. (Below)
    //    //This would ensure that when you retrieve the Movie entities, the related Actors and Producers are also fetched as part of the same query.
    //    //public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
    //    //{
    //    //    IQueryable<T> query = _context.Set<T>();
    //    //    query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    //    //    return await query.ToListAsync();
    //    //}

    //    public async Task<T> GetByIdAsync(int id)
    //    {
    //        return await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
    //    }

    //    public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    //    {
    //        IQueryable<T> query = _context.Set<T>();
    //        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    //        return await query.FirstOrDefaultAsync(n => n.Id == id);
    //    }

    //    public async Task UpdateAsync(int id, T entity)
    //    {
    //        var entityToUpdate = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

    //        if (entityToUpdate != null)
    //        {
    //            _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);

    //            await _context.SaveChangesAsync();

    //        }

    //    }

    //    public async Task<IEnumerable<TModel>> GetAllAsync<TModel>() where TModel : class
    //    {
    //        return await _context.Set<TModel>().ToListAsync();
    //    }
    //}

