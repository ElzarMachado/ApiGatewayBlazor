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
        public string Id { get; set; } 
        public string ProductoId { get; set; } 
        public string ProductoDescripcion { get; set; } 

        //[BsonRepresentation("like")]
        //public string Like { get; set; } = string.Empty;
        //[BsonRepresentation("dislike")]
        public string Dislike { get; set; } 
        public string Venta { get; set; } 

        public string ClienteId { get; set; } 

        public string ClienteNombre { get; set; } 

}
}
