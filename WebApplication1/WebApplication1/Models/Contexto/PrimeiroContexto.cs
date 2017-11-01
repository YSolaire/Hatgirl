using System.Data.Entity;

namespace WebApplication1.Models.Contexto
{
    public class PrimeiroContexto : DbContext
    {
        public PrimeiroContexto() : base("strConnYouil")
        {

        }

        public System.Data.Entity.DbSet<WebApplication1.Models.Personagem> Personagems { get; set; }
    }
}