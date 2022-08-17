using System.ComponentModel.DataAnnotations;

namespace APICliente.Models
{
    public class Cliente
    {
        // El simbolo "?" nos permite hacer que nuestra variable permita valores nulos.
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Cedula { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Apellido { get; set; }

        [Required]
        public string? Direccion { get; set; }

        [Required]
        public int? Edad { get; set; }

    }
}
