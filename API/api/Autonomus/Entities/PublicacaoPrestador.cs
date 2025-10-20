using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class PublicacaoPrestador
    {
        [Key]
        [Column("id_publicacao_prestador")]
        public int IdPublicacaoPrestador { get; set; }

        [Column("id_prestador")]
        [ForeignKey("Prestador")]
        public int IdPrestador { get; set; }

        [Column("categoria_prestador")]
        public required string CategoriaPublicacaoPrestador { get; set; }

        [Column("descricao_publicacao_prestador")]
        public required string DescricaoPublicacaoPrestador { get; set; }

        [Column("valor_prestador")]
        public double ValorPublicacaoPrestador { get; set; }

        [Column("forma_de_atendimento_prestador")]
        public required string FormaDeAtendimentoPrestador { get; set; }

        [Column("data_publicacao_prestador")]
        public DateTime DataPublicacaoPrestador { get; set; }

    }
}