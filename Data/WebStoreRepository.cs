using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.Data;
using WebStore.Data.Entities;

namespace CoreWebStore.Data
{
    public class WebStoreRepository : IWebStoreRepository
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<WebStoreRepository> _logger;

        public WebStoreRepository(WebStoreContext context, ILogger<WebStoreRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            var query = _context.Users;

            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var query = _context.Users.Where(u => u.Id == id);

            return await query.FirstAsync();
        }

        public async Task<User> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            var query = _context.Users.Where(u => u.Login == login && u.Password == password);
            return await query.FirstAsync();
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            var query = _context.Users.Where(u => u.Login == login);
            return await query.FirstAsync();
        }

        public async Task<Product[]> GetAllProductsAsync()
        {
            var query = _context.Products.Include(p => p.Opinions).ThenInclude(p => p.Critic);

            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var query = _context.Products.Where(p => p.Id == id).Include(p => p.Opinions).ThenInclude(p => p.Critic);

            return await query.FirstAsync();
        }

        public async Task<Store> GetStoreAsync()
        {
            var query = _context.Store.Where(s => s.Id == 1)
                .Include(s => s.StoreDescription)
                .Include(s => s.StoreOpenedHours)
                .Include(s => s.TelephoneNumbers)
                .Include(s => s.EMails);

            return await query.FirstAsync();
        }
    }
}
