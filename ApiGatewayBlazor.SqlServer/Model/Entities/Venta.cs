namespace ApiGatewayBlazor.SqlServer.Model.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int Total { get; set; }

        public List<Producto> Productos { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}
