using System;
using System.Collections.Generic;

namespace ProjetoWebApiNatan.ORM3;

public partial class TbEmprestimo
{
    public int Id { get; set; }

    public DateTime DataEmprestimo { get; set; }

    public DateTime DataDevolucao { get; set; }

    public int FkMembros { get; set; }

    public int FkLivros { get; set; }

    public virtual TbMembro Id1 { get; set; } = null!;

    public virtual TbLivro IdNavigation { get; set; } = null!;
}
