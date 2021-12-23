using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Data.Entities;

namespace CoreWebStore.Data
{
    public interface IWebStoreRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Users
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByLoginAndPasswordAsync(string login, string password);
        Task<User> GetUserByLoginAsync(string login);
       
        Task<Product[]> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);

        Task<Store> GetStoreAsync();
    }
}