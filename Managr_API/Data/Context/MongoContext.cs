using Managr_API.Data.Entities;
using MongoDB.Driver;

namespace Managr_API.Data.Context
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
        }

        public IMongoCollection<Goal> Tasks => _database.GetCollection<Goal>("Goals");
        public IMongoCollection<List> Lists => _database.GetCollection<List>("Lists");
        public IMongoCollection<Group> Groups => _database.GetCollection<Group>("Groups");
    }

}
