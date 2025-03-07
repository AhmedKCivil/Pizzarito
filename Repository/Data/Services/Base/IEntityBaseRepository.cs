//using PizzaritoShop.Model;
//using System.Linq.Expressions;

//namespace PizzaritoShop.Data.Services.Base
//{
    //public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    //{
    //    Task<IEnumerable<TModel>> GetAllAsync<TModel>() where TModel : class;
    //    Task<List<PizzasModel>> GetAllPizzasAsync(string apiUrl);
    //    //Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    //    Task AddToCartAsync(int pizzaId, string imageTitle, string pizzaName, double pizzaPrice, string cartSessionKey);
    //    Task<T> GetByIdAsync(int id);
    //    Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
    //    Task AddAsync(T entity);
    //    Task UpdateAsync(int id, T entity);
    //    Task DeleteAsync(int id);
    //}

