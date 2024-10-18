using System;
using System.Collections.Generic;

namespace ProjetoWebApiNatan.ORM3;

public partial class TbReserva
{
    public int Id { get; set; }

    public DateOnly DataReserva { get; set; }

    public int FkMembros { get; set; }

    public int FkLivros { get; set; }

    public virtual TbMembro Id1 { get; set; } = null!;

    public virtual TbLivro IdNavigation { get; set; } = null!;
}
