using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Model
{
    public class Reserva
    {
        public int Id { get; set; }

        public DateOnly DataReserva { get; set; }

        public int FkMembros { get; set; }

        public int FkLivros { get; set; }

        public virtual TbMembro Id1 { get; set; } = null!;

        public virtual TbLivro IdNavigation { get; set; } = null!;
    }
}
