using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Model
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }

        public int FkMembros { get; set; }

        public int FkLivros { get; set; }

        public virtual TbMembro Id1 { get; set; } = null!;

        public virtual TbLivro IdNavigation { get; set; } = null!;
    }
}
