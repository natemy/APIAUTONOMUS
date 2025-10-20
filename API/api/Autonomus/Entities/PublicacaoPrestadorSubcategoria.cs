using Autonomus.Business;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    [Table("publicacao_prestador_subcategoria")]
    public class PublicacaoPrestadorSubcategoria
    {
        [Key]
        [Column("id_publicacao_prestador_subcategoria")]
        public int IdPublicacaoPrestadorSubcategoria { get; set; }

        [Column("id_publicacao_prestador")]
        [ForeignKey("PublicacaoPrestador")]
        public int IdPublicacaoPrestador { get; set; }

        [Column("subcategoria_prestador")]
        public required string SubcategoriaPrestador { get; set; }

        // Relacionamento com PublicacaoPrestador
        //public PublicacaoPrestador? PublicacaoPrestador { get; set; }
    }
}