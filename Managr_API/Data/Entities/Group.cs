using MongoDB.Bson;

namespace Managr_API.Data.Entities
{
    public class Group
    {
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public List<string>? ListIds { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
