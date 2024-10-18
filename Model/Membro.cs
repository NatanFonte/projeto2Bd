using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Model
{
    public class Membro
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public DateTime DataCadastro { get; set; }

        public string TipoMembro { get; set; } = null!;

        public virtual TbEmprestimo? TbEmprestimo { get; set; }

        public virtual TbReserva? TbReserva { get; set; }
    }
}
