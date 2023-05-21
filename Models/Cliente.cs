using System.ComponentModel.DataAnnotations;

namespace RostrosFelices.Models
{
    public class Cliente
    {
            public int Id { get; set; }

            [Required(ErrorMessage = "El campo Nombre Completo es requerido.")]
            [DataType(DataType.Text)]
            public string NombreCompleto { get; set; }

            [Required(ErrorMessage = "El campo Cédula de Ciudadanía es requerido.")]
            [DataType(DataType.Text)]
            public string CedulaCiudadania { get; set; }

            [Required(ErrorMessage = "El campo Número Telefónico es requerido.")]
            [DataType(DataType.PhoneNumber)]
            public string NumeroTelefonico { get; set; }

            [Required(ErrorMessage = "El campo Correo Electrónico es requerido.")]
            [DataType(DataType.EmailAddress)]
            public string CorreoElectronico { get; set; }
    }
}
