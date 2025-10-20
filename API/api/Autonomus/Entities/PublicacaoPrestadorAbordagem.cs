using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class PublicacaoPrestadorAbordagem
    {
        [Key]
        [Column("id_publicacao_prestador_abordagem")]
        public int IdPrestadorAbordagem { get; set; }

        [Column("id_publicacao_prestador")]
        [ForeignKey("PublicacaoPrestador")]
        public int IdPublicacaoPrestador { get; set; }

        [Column("descricao_abordagem_prestador")]
        public required string DescricaoAbordagemPrestador { get; set; }
    }
}
