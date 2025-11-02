using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class AgendaCliente
    {
        [Key]
        [Column("id_agenda_cliente")]
        public int idAgendaCliente { get; set; }

        [Column("id_cliente")]
        public int? idCliente { get; set; }

        [Column("diasemana")]
        public int diaSemana { get; set; }

        [Column("horario")]
        public string horario { get; set; }
    }
}
