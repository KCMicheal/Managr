using Managr_API.Data.Context;
using Managr_API.Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Managr_API.Services
{
    public class ListService
    {
        private readonly IMongoCollection<List> _lists;
        public ListService(MongoContext context)
        {
            _lists = context.Lists;
        }

        public async Task<List<List>> GetAllListsAsync()
        {
            return await _lists.Find(list => true).ToListAsync();
        }

        public async Task<List> GetListByIdAsync(string id)
        {
            return await _lists.Find(list => list.Id == new ObjectId(id)).FirstOrDefaultAsync();
        }

        public async Task CreateListAsync(List list)
        {
            await _lists.InsertOneAsync(list);
        }

        public async Task UpdateListAsync(string id, List updatedList)
        {
            await _lists.ReplaceOneAsync(list => list.Id == new ObjectId(id), updatedList);
        }

        public async Task DeleteListAsync(string id)
        {
            await _lists.DeleteOneAsync(list => list.Id == new ObjectId(id));
        }
    }
}
