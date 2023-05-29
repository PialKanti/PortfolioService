using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PortfolioService.Infrastructure.Data.Dtos
{
    public abstract class BaseDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
