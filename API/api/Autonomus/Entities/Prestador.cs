using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class Prestador
    {
        [Key]
        [Column("id_prestador")]
        public int IdPrestador { get; set; }

        [Column("nome_prestador")]
        public required string NomePrestador { get; set; }

        [Column("sobrenome_prestador")]
        public required string SobrenomePrestador { get; set; }

        [Column("email_prestador")]
        public required string EmailPrestador { get; set; }

        [Column("genero_prestador")]
        public required string GeneroPrestador { get; set; }

        [Column("estado_prestador")]
        public required string EstadoPrestador { get; set; } 

        [Column("tel_prestador")]
        public required string TelefonePrestador { get; set; }

        [Column("senha_prestador")]
        public required string SenhaPrestador { get; set; }

        [Column("avaliacao_prestador")]
        public decimal AvaliacaoPrestador { get; set; }
    }
}
