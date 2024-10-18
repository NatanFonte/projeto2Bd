using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.Repositorio;

namespace ProjetoWebApiNatan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(CategoriaRepositorio enderecoRepo)
        {
            _categoriaRepositorio = enderecoRepo;
        }

        // GET: api/Categoria
        [HttpGet]
        public ActionResult<List<Categoria>> GetAll()
        {
            try
            {
                var categorias = _categoriaRepositorio.GetAll();

                if (categorias == null || !categorias.Any())
                {
                    return NotFound(new { Mensagem = "Nenhuma Categoria encontrado." });
                }

                var listaComUrl = categorias.Select(categoria => new Categoria
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                    Categoria1 = categoria.Categoria1,
                    TbLivro = categoria.TbLivro,
                }).ToList();

                return Ok(listaComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar categorias.", Erro = ex.Message });
            }
        }

        // GET: api/Categoria/{id}
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(int id)
        {
            try
            {
                var categoria = _categoriaRepositorio.GetById(id);

                if (categoria == null)
                {
                    return NotFound(new { Mensagem = "Categoria não encontrado." });
                }

                var categoriaComUrl = new Categoria
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                    Categoria1 = categoria.Categoria1,
                    TbLivro = categoria.TbLivro,
                };

                return Ok(categoriaComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar categoria.", Erro = ex.Message });
            }
        }

        // POST api/Categoria        
        [HttpPost]
        public ActionResult<object> Post(CategoriaDto novoCategoria)
        {
            try
            {
                var categoria = new Categoria
                {
                    Nome = novoCategoria.Nome,
                    Categoria1 = novoCategoria.Categoria,
                };

                // Chama o método de adicionar do repositório
                _categoriaRepositorio.Add(categoria);

                var resultado = new
                {
                    Mensagem = "Categoria cadastrada com sucesso!",
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                    Categoria = categoria.Categoria1,
                    TbLivro = categoria.TbLivro,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao cadastrar categoria.", Erro = ex.Message });
            }
        }

        // PUT api/Categoria/{id}        
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, CategoriaDto categoriaAtualizado)
        {
            try
            {
                var categoriaExistente = _categoriaRepositorio.GetById(id);

                if (categoriaExistente == null)
                {
                    return NotFound(new { Mensagem = "Categoria não encontrada." });
                }

                categoriaExistente.Nome = categoriaAtualizado.Nome;
                categoriaExistente.Categoria1 = categoriaAtualizado.Categoria;

                _categoriaRepositorio.Update(categoriaExistente);

                var resultado = new
                {
                    Mensagem = "Categoria atualizada com sucesso!",
                    Id = categoriaExistente.Id,
                    Nome = categoriaExistente.Nome,
                    Categoria = categoriaExistente.Categoria1,
                    TbLivro = categoriaExistente.TbLivro,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao atualizar categoria.", Erro = ex.Message });
            }
        }

        // DELETE api/Categoria/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var categoriaExistente = _categoriaRepositorio.GetById(id);

                if (categoriaExistente == null)
                {
                    return NotFound(new { Mensagem = "Categoria não encontrada." });
                }

                _categoriaRepositorio.Delete(id);

                var resultado = new
                {
                    Mensagem = "Categoria excluída com sucesso!",
                    Id = categoriaExistente.Id,
                    Nome = categoriaExistente.Nome,
                    Categoria = categoriaExistente.Categoria1,
                    TbLivro = categoriaExistente.TbLivro,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao excluir categoria.", Erro = ex.Message });
            }
        }
    }
}
