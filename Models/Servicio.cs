using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RostrosFelices.Models
{
    public class Servicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Servicio es requerido.")]
        [DataType(DataType.Date)]
        [DisplayName("Fecha del Servicio:")]
        public DateTime FechaServicio { get; set; }

        [Required(ErrorMessage = "El campo Descripción de Servicio es requerido.")]
        [DataType(DataType.Text)]
        [DisplayName("Descripción del Servicio:")]
        public string DescripcionServicio { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Empleado es requerido.")]
        [DataType(DataType.Text)]
        [DisplayName("Nombre del Empleado:")]
        public string NombreEmpleado { get; set; }

        [Required]
        [DisplayName("Nombre del Cliente:")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
