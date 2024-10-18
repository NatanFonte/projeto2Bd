using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.Repositorio;

namespace ProjetoWebApiNatan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepositorio _livroRepositorio;

        public LivroController(LivroRepositorio livroRepo)
        {
            _livroRepositorio = livroRepo;
        }

        // GET: api/Livro
        [HttpGet]
        public ActionResult<List<Livro>> GetAll()
        {
            try
            {
                var livros = _livroRepositorio.GetAll();

                if (livros == null || !livros.Any())
                {
                    return NotFound(new { Mensagem = "Nenhum Livro encontrado." });
                }

                var listaComUrl = livros.Select(livro => new Livro
                {
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    AnoPublicacao = livro.AnoPublicacao,
                    Disponibilidade = livro.Disponibilidade,
                }).ToList();

                return Ok(listaComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar livros.", Erro = ex.Message });
            }
        }

        // GET: api/Livro/{id}
        [HttpGet("{id}")]
        public ActionResult<Livro> GetById(int id)
        {
            try
            {
                var livro = _livroRepositorio.GetById(id);

                if (livro == null)
                {
                    return NotFound(new { Mensagem = "Livro não encontrado." });
                }

                var livroComUrl = new Livro
                {
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    AnoPublicacao = livro.AnoPublicacao,
                    Disponibilidade = livro.Disponibilidade,
                };

                return Ok(livroComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar livro.", Erro = ex.Message });
            }
        }

        // POST api/Livro        
        [HttpPost]
        public ActionResult<object> Post(LivroDto novoLivro)
        {
            try
            {
                var livro = new Livro
                {
                    Titulo = novoLivro.Titulo,
                    Autor = novoLivro.Autor,
                    AnoPublicacao = novoLivro.AnoPublicacao,
                    Disponibilidade = novoLivro.Disponibilidade,
                    FkCategoria = novoLivro.FkCategoria,
                };

                _livroRepositorio.Add(livro);

                var resultado = new
                {
                    Mensagem = "Livro cadastrado com sucesso!",
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    AnoPublicacao = livro.AnoPublicacao,
                    Disponibilidade = livro.Disponibilidade,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao cadastrar livro.", Erro = ex.Message });
            }
        }

        // PUT api/Livro/{id}        
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, LivroDto livroAtualizado)
        {
            try
            {
                var livroExistente = _livroRepositorio.GetById(id);

                if (livroExistente == null)
                {
                    return NotFound(new { Mensagem = "Livro não encontrado." });
                }

                livroExistente.Titulo = livroAtualizado.Titulo;
                livroExistente.Autor = livroAtualizado.Autor;
                livroExistente.AnoPublicacao = livroAtualizado.AnoPublicacao;
                livroExistente.Disponibilidade = livroAtualizado.Disponibilidade;

                _livroRepositorio.Update(livroExistente);

                var resultado = new
                {
                    Mensagem = "Livro atualizado com sucesso!",
                    Id = livroExistente.Id,
                    Titulo = livroExistente.Titulo,
                    Autor = livroExistente.Autor,
                    AnoPublicacao = livroExistente.AnoPublicacao,
                    Disponibilidade = livroExistente.Disponibilidade,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao atualizar livro.", Erro = ex.Message });
            }
        }

        // DELETE api/Livro/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var livroExistente = _livroRepositorio.GetById(id);

                if (livroExistente == null)
                {
                    return NotFound(new { Mensagem = "Livro não encontrado." });
                }

                _livroRepositorio.Delete(id);

                var resultado = new
                {
                    Mensagem = "Livro excluído com sucesso!",
                    Id = livroExistente.Id,
                    Titulo = livroExistente.Titulo,
                    Autor = livroExistente.Autor,
                    AnoPublicacao = livroExistente.AnoPublicacao,
                    Disponibilidade = livroExistente.Disponibilidade,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao excluir livro.", Erro = ex.Message });
            }
        }
    }
}
