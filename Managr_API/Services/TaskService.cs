using Managr_API.Data.Context;
using Managr_API.Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Managr_API.Services
{
    public class TaskService
    {
        private readonly IMongoCollection<Goal> _tasks;

        public TaskService(MongoContext context)
        {
            _tasks = context.Tasks;
        }

        public async Task<List<Goal>> GetAllTasksAsync()
        {
            return await _tasks.Find(task => true).ToListAsync();
        }

        public async Task<Goal> GetTaskByIdAsync(string id)
        {
            return await _tasks.Find(task => task.Id == new ObjectId(id)).FirstOrDefaultAsync();
        }

        public async Task CreateTaskAsync(Goal task)
        {
            await _tasks.InsertOneAsync(task);
        }

        public async Task UpdateTaskAsync(string id, Goal updatedTask)
        {
            await _tasks.ReplaceOneAsync(task => task.Id == new ObjectId(id), updatedTask);
        }

        public async Task DeleteTaskAsync(string id)
        {
            await _tasks.DeleteOneAsync(task => task.Id == new ObjectId(id));
        }
    }

}
