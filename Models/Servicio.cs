using System.ComponentModel.DataAnnotations;

namespace RostrosFelices.Models
{
    public class Servicio
    {
            public int Id { get; set; }

            [Required(ErrorMessage = "El campo Fecha de Servicio es requerido.")]
            [DataType(DataType.Date)]
            public DateTime FechaServicio { get; set; }

            [Required(ErrorMessage = "El campo Descripción de Servicio es requerido.")]
            [DataType(DataType.Text)]
            public string DescripcionServicio { get; set; }

            [Required(ErrorMessage = "El campo Nombre del Empleado es requerido.")]
            [DataType(DataType.Text)]
            public string NombreEmpleado { get; set; }

            [Required]
            public int ClientId { get; set; }

            public int ClienteId { get; set; }
    }
}
