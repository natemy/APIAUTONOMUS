using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class PublicacaoPrestadorQualidades
    {
        [Key]
        [Column("id_publicacao_prestador_qualidades")]
        public int IdPrestadorQualidades{ get; set; }

        [Column("id_publicacao_prestador")]
        [ForeignKey("PublicacaoPrestador")]
        public int IdPublicacaoPrestador { get; set; }

        [Column("descricao_qualidade_prestador")]
        public required string DescricaoQualidadePrestador { get; set; }
    }
}
