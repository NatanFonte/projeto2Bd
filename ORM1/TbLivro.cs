using System;
using System.Collections.Generic;

namespace ProjetoWebApiNatan.ORM3;

public partial class TbLivro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public DateTime AnoPublicacao { get; set; }

    public int FkCategoria { get; set; }

    public bool Disponibilidade { get; set; }

    public virtual TbCategoria IdNavigation { get; set; } = null!;

    public virtual TbEmprestimo? TbEmprestimo { get; set; }

    public virtual TbReserva? TbReserva { get; set; }
}
