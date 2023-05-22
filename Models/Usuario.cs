using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RostrosFelices.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre Completo es requerido.")]
        [DataType(DataType.Text)]
        [DisplayName("Nombre Completo del Empleado:")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es requerido.")]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña:")]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "El campo Confirmar Contraseña es requerido.")]
        [DataType(DataType.Password)]
        [DisplayName("Confirme la Contraseña:")]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContraseña { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Sangre es requerido.")]
        [DataType(DataType.Text)]
        [DisplayName("Tipo de Sangre del Empleado:")]
        public string TipoSangre { get; set; }

        [Required(ErrorMessage = "El campo Cédula de Ciudadanía es requerido.")]
        [DataType(DataType.Text)]
        [DisplayName("Cédula de Ciudadanía del Empleado:")]
        public string CedulaCiudadania { get; set; }

        [Required(ErrorMessage = "El campo Número Telefónico es requerido.")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Número Telefónico del Empleado:")]
        public string NumeroTelefonico { get; set; }

        [Required(ErrorMessage = "El campo Correo Electrónico es requerido.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Correo Electrónico del Empleado:")]
        public string CorreoElectronico { get; set; }
    }
}

