using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class AgendaPrestador
    {
        [Key]
        [Column("id_agenda_prestador")]
        public int idAgendaPrestador { get; set; }

        [Column("id_prestador")]
        public int? idPrestador { get; set; }

        [Column("diasemana")]
        public int diaSemana { get; set; }

        [Column("horario")]
        public string horario { get; set; }
    }
}
