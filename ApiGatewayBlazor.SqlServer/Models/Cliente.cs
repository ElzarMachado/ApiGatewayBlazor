using System.ComponentModel.DataAnnotations;

namespace ApiGatewayBlazor.SqlServer.Models
{
    public partial class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
