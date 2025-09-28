

namespace GestionTareas.Domain.Dto
{
    public class TareaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaLimite { get; set; }

        // Ids para relacionar
        public int EstudianteId { get; set; }
        public int AdminId { get; set; }

        //// Nombres referenciales (opcional)
        //public string EstudianteNombre { get; set; }
        //public string AdminNombre { get; set; }
    }
}
