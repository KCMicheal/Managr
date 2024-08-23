using MongoDB.Bson;

namespace Managr_API.Data.Entities
{
    public class List
    {
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public List<string>? TaskIds { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
