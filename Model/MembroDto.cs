namespace ProjetoWebApiNatan.Model
{
    public class MembroDto
    {
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public DateTime DataCadastro { get; set; }
    }
}
