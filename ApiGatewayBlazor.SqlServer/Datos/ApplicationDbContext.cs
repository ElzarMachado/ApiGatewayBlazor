using Microsoft.EntityFrameworkCore;
using ApiGatewayBlazor.SqlServer.Models;

namespace ApiGatewayBlazor.SqlServer.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        //aqui se agregan los modelos
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }   
        public DbSet<Venta> Venta { get; set; }
    }
}
