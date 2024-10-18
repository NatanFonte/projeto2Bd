using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Model
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Categoria1 { get; set; } = null!;

        public virtual TbLivro? TbLivro { get; set; }
    }
}
