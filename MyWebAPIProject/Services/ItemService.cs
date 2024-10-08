using MongoDB.Driver;
using MyWebAPIProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPIProject.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _itemsCollection;

        public ItemService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("MyDatabase");
            _itemsCollection = database.GetCollection<Item>("Items");
        }

        public async Task<List<Item>> GetAllAsync() => await _itemsCollection.Find(item => true).ToListAsync();

        public async Task<Item> GetByIdAsync(string id) => await _itemsCollection.Find(item => item.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Item newItem) => await _itemsCollection.InsertOneAsync(newItem);

        public async Task UpdateAsync(string id, Item updatedItem) => 
            await _itemsCollection.ReplaceOneAsync(item => item.Id == id, updatedItem);

        public async Task DeleteAsync(string id) => 
            await _itemsCollection.DeleteOneAsync(item => item.Id == id);
    }
}
