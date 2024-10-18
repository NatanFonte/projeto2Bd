using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.Repositorio;

namespace ProjetoWebApiNatan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MembroController : ControllerBase
    {
        private readonly MembroRepositorio _membroRepositorio;

        public MembroController(MembroRepositorio membroRepo)
        {
            _membroRepositorio = membroRepo;
        }

        // GET: api/Membro
        [HttpGet]
        public ActionResult<List<Membro>> GetAll()
        {
            try
            {
                var membros = _membroRepositorio.GetAll();

                if (membros == null || !membros.Any())
                {
                    return NotFound(new { Mensagem = "Nenhum Membro encontrado." });
                }

                var listaComUrl = membros.Select(membro => new Membro
                {
                    Id = membro.Id,
                    Nome = membro.Nome,
                    Email = membro.Email,
                    Telefone = membro.Telefone,
                    DataCadastro = membro.DataCadastro,
                }).ToList();

                return Ok(listaComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar membros.", Erro = ex.Message });
            }
        }

        // GET: api/Membro/{id}
        [HttpGet("{id}")]
        public ActionResult<Membro> GetById(int id)
        {
            try
            {
                var membro = _membroRepositorio.GetById(id);

                if (membro == null)
                {
                    return NotFound(new { Mensagem = "Membro não encontrado." });
                }

                var membroComUrl = new Membro
                {
                    Id = membro.Id,
                    Nome = membro.Nome,
                    Email = membro.Email,
                    Telefone = membro.Telefone,
                    DataCadastro = membro.DataCadastro,
                };

                return Ok(membroComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar membro.", Erro = ex.Message });
            }
        }

        // POST api/Membro        
        [HttpPost]
        public ActionResult<object> Post(MembroDto novoMembro)
        {
            try
            {
                var membro = new Membro
                {
                    Nome = novoMembro.Nome,
                    Email = novoMembro.Email,
                    Telefone = novoMembro.Telefone,
                    DataCadastro = novoMembro.DataCadastro,
                };

                _membroRepositorio.Add(membro);

                var resultado = new
                {
                    Mensagem = "Membro cadastrado com sucesso!",
                    Id = membro.Id,
                    Nome = membro.Nome,
                    Email = membro.Email,
                    Telefone = membro.Telefone,
                    DataCadastro = membro.DataCadastro,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao cadastrar membro.", Erro = ex.Message });
            }
        }

        // PUT api/Membro/{id}        
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, MembroDto membroAtualizado)
        {
            try
            {
                var membroExistente = _membroRepositorio.GetById(id);

                if (membroExistente == null)
                {
                    return NotFound(new { Mensagem = "Membro não encontrado." });
                }

                membroExistente.Nome = membroAtualizado.Nome;
                membroExistente.Email = membroAtualizado.Email;
                membroExistente.Telefone = membroAtualizado.Telefone;
                membroExistente.DataCadastro = membroAtualizado.DataCadastro;

                _membroRepositorio.Update(membroExistente);

                var resultado = new
                {
                    Mensagem = "Membro atualizado com sucesso!",
                    Id = membroExistente.Id,
                    Nome = membroExistente.Nome,
                    Email = membroExistente.Email,
                    Telefone = membroExistente.Telefone,
                    DataCadastro = membroExistente.DataCadastro,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao atualizar membro.", Erro = ex.Message });
            }
        }

        // DELETE api/Membro/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var membroExistente = _membroRepositorio.GetById(id);

                if (membroExistente == null)
                {
                    return NotFound(new { Mensagem = "Membro não encontrado." });
                }

                _membroRepositorio.Delete(id);

                var resultado = new
                {
                    Mensagem = "Membro excluído com sucesso!",
                    Nome = membroExistente.Nome,
                    Email = membroExistente.Email,
                    Telefone = membroExistente.Telefone,
                    DataCadastro = membroExistente.DataCadastro,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao excluir membro.", Erro = ex.Message });
            }
        }
    }
}
