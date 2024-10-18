using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.Repositorio;

namespace ProjetoWebApiNatan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmprestimoController : ControllerBase
    {
        private readonly EmprestimoRepositorio _emprestimoRepositorio;

        public EmprestimoController(EmprestimoRepositorio emprestimoRepo)
        {
            _emprestimoRepositorio = emprestimoRepo;
        }

        // GET: api/Emprestimo
        [HttpGet]
        public ActionResult<List<Emprestimo>> GetAll()
        {
            try
            {
                var emprestimos = _emprestimoRepositorio.GetAll();

                if (emprestimos == null || !emprestimos.Any())
                {
                    return NotFound(new { Mensagem = "Nenhum Emprestimo encontrado." });
                }

                var listaComUrl = emprestimos.Select(emprestimo => new Emprestimo
                {
                    Id = emprestimo.Id,
                    DataEmprestimo = emprestimo.DataEmprestimo,
                    DataDevolucao = emprestimo.DataDevolucao,
                    FkMembros = emprestimo.FkMembros,
                    FkLivros = emprestimo.FkLivros,
                }).ToList();

                return Ok(listaComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar empréstimos.", Erro = ex.Message });
            }
        }

        // GET: api/Emprestimo/{id}
        [HttpGet("{id}")]
        public ActionResult<Emprestimo> GetById(int id)
        {
            try
            {
                var emprestimo = _emprestimoRepositorio.GetById(id);

                if (emprestimo == null)
                {
                    return NotFound(new { Mensagem = "Empréstimo não encontrado." });
                }

                var emprestimoComUrl = new Emprestimo
                {
                    Id = emprestimo.Id,
                    DataEmprestimo = emprestimo.DataEmprestimo,
                    DataDevolucao = emprestimo.DataDevolucao,
                    FkMembros = emprestimo.FkMembros,
                    FkLivros = emprestimo.FkLivros,
                };

                return Ok(emprestimoComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar empréstimo.", Erro = ex.Message });
            }
        }

        // POST api/Emprestimo        
        [HttpPost]
        public ActionResult<object> Post(EmprestimoDto novoEmprestimo)
        {
            try
            {
                var emprestimo = new Emprestimo
                {
                    DataEmprestimo = novoEmprestimo.DataEmprestimo,
                    DataDevolucao = novoEmprestimo.DataDevolucao,
                    FkMembros = novoEmprestimo.FkMembros,
                    FkLivros = novoEmprestimo.FkLivros,
                };

                // Chama o método de adicionar do repositório
                _emprestimoRepositorio.Add(emprestimo);

                var resultado = new
                {
                    Mensagem = "Empréstimo cadastrado com sucesso!",
                    Id = emprestimo.Id,
                    DataEmprestimo = emprestimo.DataEmprestimo,
                    DataDevolucao = emprestimo.DataDevolucao,
                    FkMembros = emprestimo.FkMembros,
                    FkLivros = emprestimo.FkLivros,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao cadastrar empréstimo.", Erro = ex.Message });
            }
        }

        // PUT api/Emprestimo/{id}        
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, EmprestimoDto emprestimoAtualizado)
        {
            try
            {
                var emprestimoExistente = _emprestimoRepositorio.GetById(id);

                if (emprestimoExistente == null)
                {
                    return NotFound(new { Mensagem = "Empréstimo não encontrado." });
                }

                emprestimoExistente.DataEmprestimo = emprestimoAtualizado.DataEmprestimo;
                emprestimoExistente.DataDevolucao = emprestimoAtualizado.DataDevolucao;
                emprestimoExistente.FkLivros = emprestimoAtualizado.FkLivros;
                emprestimoExistente.FkMembros = emprestimoAtualizado.FkMembros;

                _emprestimoRepositorio.Update(emprestimoExistente);

                var resultado = new
                {
                    Mensagem = "Empréstimo atualizado com sucesso!",
                    Id = emprestimoExistente.Id,
                    DataEmprestimo = emprestimoExistente.DataEmprestimo,
                    DataDevolucao = emprestimoExistente.DataDevolucao,
                    FkLivros = emprestimoExistente.FkLivros,
                    FkMembros = emprestimoExistente.FkMembros,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao atualizar empréstimo.", Erro = ex.Message });
            }
        }

        // DELETE api/Emprestimo/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var emprestimoExistente = _emprestimoRepositorio.GetById(id);

                if (emprestimoExistente == null)
                {
                    return NotFound(new { Mensagem = "Empréstimo não encontrado." });
                }

                _emprestimoRepositorio.Delete(id);

                var resultado = new
                {
                    Mensagem = "Empréstimo excluído com sucesso!",
                    Id = emprestimoExistente.Id,
                    DataEmprestimo = emprestimoExistente.DataEmprestimo,
                    DataDevolucao = emprestimoExistente.DataDevolucao,
                    FkLivros = emprestimoExistente.FkLivros,
                    FkMembros = emprestimoExistente.FkMembros,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao excluir empréstimo.", Erro = ex.Message });
            }
        }
    }
}
