using System.ComponentModel.DataAnnotations;

namespace PsicosoftPuntoNet.Models
{
    public class Pacientes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatoria")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Edad es obligatorio")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo Cedula es obligatorio")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string Direccion { get; set; }

        public string Acudiente { get; set; }



    }
}
