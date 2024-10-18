using System;
using System.Collections.Generic;

namespace ProjetoWebApiNatan.ORM3;

public partial class TbCategoria
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public virtual TbLivro? TbLivro { get; set; }
}
