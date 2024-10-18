using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Repositorio
{
    public class EmprestimoRepositorio
    {
        private readonly BdBibliotecaNatanContext _context;

        public EmprestimoRepositorio(BdBibliotecaNatanContext context)
        {
            _context = context;
        }

        // Adiciona um novo cliente
        public void Add(Emprestimo emprestimo)
        {
            var tbEmprestimo = new TbEmprestimo()
            {
                Id = emprestimo.Id,
                DataEmprestimo = emprestimo.DataEmprestimo,
                DataDevolucao = emprestimo.DataDevolucao,
                FkMembros = emprestimo.FkMembros,
                FkLivros = emprestimo.FkLivros,

            };

            // Adiciona a entidade ao contexto
            _context.TbEmprestimos.Add(tbEmprestimo);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbEmprestimo = _context.TbEmprestimos.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbEmprestimo != null)
            {
                // Remove a entidade do contexto
                _context.TbEmprestimos.Remove(tbEmprestimo);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Emprestimo não encontrado.");
            }
        }

        public List<Emprestimo> GetAll()
        {
            List<Emprestimo> listFun = new List<Emprestimo>();

            var listTb = _context.TbEmprestimos.ToList();

            foreach (var item in listTb)
            {
                var emprestimo = new Emprestimo
                {
                    Id = item.Id,
                    DataEmprestimo =item.DataEmprestimo,
                    DataDevolucao = item.DataDevolucao,
                    FkMembros = item.FkMembros,
                    FkLivros = item.FkLivros,
                };

                listFun.Add(emprestimo);
            }

            return listFun;
        }

        public Emprestimo GetById(int id)
        {
            // Busca o funcionário pelo ID no banco de dados
            var item = _context.TbEmprestimos.FirstOrDefault(f => f.Id == id);

            // Verifica se o funcionário foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Funcionario
            var emprestimo = new Emprestimo
            {
                Id = item.Id,
                DataEmprestimo = item.DataEmprestimo,
                DataDevolucao = item.DataDevolucao,
                FkMembros = item.FkMembros,
                FkLivros = item.FkLivros,
            };

            return emprestimo; // Retorna o funcionário encontrado
        }

        public void Update(Emprestimo emprestimo)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbEmprestimo = _context.TbEmprestimos.FirstOrDefault(f => f.Id == emprestimo.Id);

            // Verifica se a entidade foi encontrada
            if (tbEmprestimo != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                tbEmprestimo.Id = emprestimo.Id;
                tbEmprestimo.DataEmprestimo = emprestimo.DataEmprestimo;
                tbEmprestimo.DataDevolucao = emprestimo.DataDevolucao;
                tbEmprestimo.FkMembros = emprestimo.FkMembros;
                tbEmprestimo.FkLivros = emprestimo.FkLivros;



                // Atualiza as informações no contexto
                _context.TbEmprestimos.Update(tbEmprestimo);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Emprestimo não encontrado.");
            }
        }
    }
}
