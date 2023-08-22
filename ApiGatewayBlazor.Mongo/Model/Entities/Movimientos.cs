using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        public string Id { get; set; } = string.Empty;
        public string ProductoId { get; set; } = string.Empty;
        public string ProductoDescripcion { get; set; } = string.Empty;

        //[BsonRepresentation("like")]
        //public string Like { get; set; } = string.Empty;
        //[BsonRepresentation("dislike")]
        public string Dislike { get; set; } = string.Empty;
        public string Venta { get; set; } = string.Empty;

        public string ClienteId { get; set; } = string.Empty;

        public string ClienteNombre { get; set; } = string.Empty;

}
}
