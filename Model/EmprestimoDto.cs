using ProjetoWebApiNatan.ORM3;
namespace ProjetoWebApiNatan.Model
{
    public class EmprestimoDto
    {
        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }

        public int FkMembros { get; set; }

        public int FkLivros { get; set; }
    }
}
