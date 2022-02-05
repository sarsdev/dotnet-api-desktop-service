using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductPackaging.Models;

public class MProductPackaging
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public int Code { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;
}