using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Model
{
    public class ReservaDto
    {
        public DateOnly DataReserva { get; set; }
        public int FkMembros { get; set; }

        public int FkLivros { get; set; }
    }
}
