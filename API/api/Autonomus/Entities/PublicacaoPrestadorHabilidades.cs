using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class PublicacaoPrestadorHabilidades
    {
             [Key]
            [Column("id_publicacao_prestador_habilidades")]
            public int IdPrestadorHabilidades { get; set; }

            [Column("id_publicacao_prestador")]
            [ForeignKey("PublicacaoPrestador")]
            public int IdPublicacaoPrestador { get; set; }

            [Column("descricao_habilidade_prestador")]
            public required string DescricaoHabilidadePrestador { get; set; }

            // Relacionamento com PublicacaoPrestador
            // public PublicacaoPrestador? PublicacaoPrestador { get; set; }
    
    }
}
