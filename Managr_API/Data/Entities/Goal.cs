using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Managr_API.Data.Entities
{
    public class Goal
    {
        public ObjectId Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public string? ListId { get; set; }
        public string? GroupId { get; set; }
        public List<string>? AssignedUsers { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
