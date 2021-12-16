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
    //Task<Camp[]> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false);

    // Products
    //Task<Talk> GetTalkByMonikerAsync(string moniker, int talkId, bool includeSpeakers = false);
    Task<Product[]> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);

    Task<Store> GetStoreAsync();

    // Speaker
    //Task<Speaker[]> GetSpeakersByMonikerAsync(string moniker);
    //Task<Speaker> GetSpeakerAsync(int speakerId);
    //Task<Speaker[]> GetAllSpeakersAsync();
  }
}