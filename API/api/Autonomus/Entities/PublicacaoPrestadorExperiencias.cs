using Autonomus.Business;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class PublicacaoPrestadorExperiencias
    {

        [Key]
        [Column("id_publicacao_prestador_experiencias")]
        public int IdPublicacaoPrestadorExperiencia { get; set; }

        [Column("id_publicacao_prestador")]
        [ForeignKey("PublicacaoPrestador")]
        public int IdPublicacaoPrestador { get; set; }

        [Column("descricao_experiencia_prestador")]
        public required string DescricaoExperienciaPrestador { get; set; }

        // Relacionamento com PublicacaoPrestador
        //public PublicacaoPrestador? PublicacaoPrestador { get; set; }
    }
}
