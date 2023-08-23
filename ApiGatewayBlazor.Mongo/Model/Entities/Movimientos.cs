using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Diagnostics.Contracts;


namespace ApiGatewayBlazor.Mongo.Model.Entities


{
    public class Movimientos
    {

        ////Conectar a la base de datos
        //MongoClient client = new MongoClient("mongodb://localhost:27017");
        //IMongoDatabase database = client.GetDatabase("agenda");
        ////Coleccion = tabla
        //IMongoCollection<Contacto> collection = database.GetCollection<Contacto>("contactos");


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("productoId")]
        public string? ProductoId { get; set; }

        [BsonElement("ProductoDescripcion")]
        public string? ProductoDescripcion { get; set; }

        //[BsonRepresentation("like")]
        //public string Like { get; set; } = string.Empty;
        //[BsonRepresentation("dislike")]
        [BsonElement("Venta")]
        public string? Venta { get; set; }
        [BsonElement("clienteId")]

        public string? ClienteId { get; set; }
        [BsonElement("clienteNombre")]

        public string? ClienteNombre { get; set; }

        [BsonElement("tipoDeMovimiento")]
        public bool Likes { get; set; }
        public bool DisLikes { get; set; }

    }
}
