using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.ContextNameSpace
{
    public class NovoClienteResultado
    {
        [Key]
        public decimal NovoIdCliente { get; set; }
    }
    public class NovoPrestadorResultado
    {
        [Key]
        public decimal NovoIdPrestador { get; set; }
    }

    public class NovoSubcategoriaPrestadorResultado
    {
        [Key]
        public decimal NovoIdSubcategoriaPrestador { get; set; }
    }

    public class NovoExperienciaPrestadorResultado
    {
        [Key]
        public decimal NovoIdPrestadorExperiencia { get; set; }
    }

    public class NovoHabilidadePrestadorResultado
    {
        [Key]
        public decimal NovoIdPrestadorHabilidade { get; set; }
    }

    public class NovoQualidadePrestadorResultado
    {
        [Key]
        public decimal NovoIdPrestadorQualidade { get; set; }
    }

    public class NovoAbordagemPrestadorResultado
    {
        [Key]
        public decimal NovoIdPrestadorAbordagem{ get; set; }
    }

    public class NovoPublicacaoPrestadorResultado
    {
        [Key]
        public decimal NovoIdPrestadorPublicacao { get; set; }
    }

    public class NovoAgendaPrestadorResultado
    {
        [Key]
        public decimal NovoIdAgendaPrestador { get; set; }
    }

    public class NovoAgendaClienteResultado
    {
        [Key]
        public decimal NovoIdAgendaCliente { get; set; }
    }



    public class Context : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Prestador> Prestador { get; set; }

        [NotMapped]
        public DbSet<NovoClienteResultado> NovoCliente { get; set; }

        [NotMapped]
        public DbSet<NovoPrestadorResultado> NovoPrestador { get; set; }

        [NotMapped]
        public DbSet<NovoSubcategoriaPrestadorResultado> NovoSubcategoriaPrestadorResultados { get; set; }

        [NotMapped]
        public DbSet<NovoExperienciaPrestadorResultado> NovoExperienciaPrestadorResultados { get; set; }

        [NotMapped]
        public DbSet<NovoHabilidadePrestadorResultado> NovoHabilidadePrestadorResultados { get; set; }

        [NotMapped]
        public DbSet<Login> Login { get; set; }

        [NotMapped]
        public DbSet<NovoQualidadePrestadorResultado> NovoQualidadePrestadorResultados { get; set; }

        [NotMapped]
        public DbSet<NovoPublicacaoPrestadorResultado> NovoPublicacaoPrestadorResultados { get; set; }

        [NotMapped]
        public DbSet<NovoAbordagemPrestadorResultado> NovoAbordagemPrestadorResultados { get; set; }

        [NotMapped]
        public DbSet<NovoAgendaPrestadorResultado> NovoAgendaPrestadorResultados { get; set; }
        [NotMapped]
        public DbSet<NovoAgendaClienteResultado> NovoAgendaClienteResultados { get; set; }



        public DbSet<PublicacaoPrestadorSubcategoria> PublicacaoPrestadorSubcategoria { get; set; }

        public DbSet<PublicacaoPrestadorExperiencias> PublicacaoPrestadorExperiencias { get; set; }

        public DbSet<PublicacaoPrestadorHabilidades> PublicacaoPrestadorHabilidades { get; set; }

        public DbSet<PublicacaoPrestadorQualidades> PublicacaoPrestadorQualidades { get; set; }

        public DbSet<PublicacaoPrestadorAbordagem> PublicacaoPrestadorAbordagem { get; set; }

        public DbSet<PublicacaoPrestador> PublicacaoPrestador { get; set; }


        public DbSet<AgendaPrestador> AgendaPrestador { get; set; }
        public DbSet<AgendaCliente> AgendaCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NovoClienteResultado>().HasNoKey();
            modelBuilder.Entity<NovoPrestadorResultado>().HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=EMYNATHALIA;Database=Autonomusbanco;Trusted_Connection=True;Encrypt=false");

        }
    }

}
