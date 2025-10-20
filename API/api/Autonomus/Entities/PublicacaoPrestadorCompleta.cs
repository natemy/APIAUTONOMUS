namespace Autonomus.Entities
{
    public class PublicacaoPrestadorCompleta
    {
        public PublicacaoPrestador PublicacaoPrestador { get; set; }

        public List<PublicacaoPrestadorAbordagem> PublicacaoPrestadorAbordagens { get; set; }

        public List<PublicacaoPrestadorExperiencias> PublicacaoPrestadorExperiencias { get; set; }

        public List<PublicacaoPrestadorHabilidades> PublicacaoPrestadorHabilidades { get; set; }

        public List<PublicacaoPrestadorQualidades> PublicacaoPrestadorQualidades { get; set; }

        public List<PublicacaoPrestadorSubcategoria> PublicacaoPrestadorSubcategorias { get; set; }

    }
}
