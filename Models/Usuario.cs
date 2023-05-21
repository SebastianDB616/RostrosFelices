using System.ComponentModel.DataAnnotations;

namespace RostrosFelices.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre Completo es requerido.")]
        [DataType(DataType.Text)]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es requerido.")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "El campo Confirmar Contraseña es requerido.")]
        [DataType(DataType.Password)]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContraseña { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Sangre es requerido.")]
        [DataType(DataType.Text)]
        public string TipoSangre { get; set; }

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

