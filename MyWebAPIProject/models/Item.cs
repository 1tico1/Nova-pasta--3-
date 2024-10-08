using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyWebAPIProject.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;  // Inicialização com valor padrão

        public string Name { get; set; } = string.Empty;  // Inicialização com valor padrão

        public string Description { get; set; } = string.Empty;  // Inicialização com valor padrão

        public decimal Price { get; set; }
    }
}
