using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Model
{
    public class LivroDto
    {
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public DateTime AnoPublicacao { get; set; }
        public bool Disponibilidade { get; set; }
        public int FkCategoria { get; set; }

    }
}
