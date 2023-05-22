using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RostrosFelices.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre Completo es requerido.")]
        [DataType(DataType.Text)]
        [DisplayName("Nombre Completo del Cliente:")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El campo Cédula de Ciudadanía es requerido.")]
        [DataType(DataType.Text)]
        [DisplayName("Cédula de Ciudadanía del Cliente:")]
        public string CedulaCiudadania { get; set; }

        [Required(ErrorMessage = "El campo Número Telefónico es requerido.")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Número Telefónico del Cliente:")]
        public string NumeroTelefonico { get; set; }

        [Required(ErrorMessage = "El campo Correo Electrónico es requerido.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Correo Electrónico del Cliente:")]
        public string CorreoElectronico { get; set; }
    }
}
