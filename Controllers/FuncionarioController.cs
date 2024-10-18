using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.Repositorio;

namespace ProjetoWebApiNatan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioController(FuncionarioRepositorio funcionarioRepo)
        {
            _funcionarioRepositorio = funcionarioRepo;
        }

        // GET: api/Funcionario
        [HttpGet]
        public ActionResult<List<Funcionario>> GetAll()
        {
            try
            {
                var funcionarios = _funcionarioRepositorio.GetAll();

                if (funcionarios == null || !funcionarios.Any())
                {
                    return NotFound(new { Mensagem = "Nenhum Funcionário encontrado." });
                }

                var listaComUrl = funcionarios.Select(funcionario => new Funcionario
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    Email = funcionario.Email,
                    Telefone = funcionario.Telefone,
                    Cargo = funcionario.Cargo,
                }).ToList();

                return Ok(listaComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar funcionários.", Erro = ex.Message });
            }
        }

        // GET: api/Funcionario/{id}
        [HttpGet("{id}")]
        public ActionResult<Funcionario> GetById(int id)
        {
            try
            {
                var funcionario = _funcionarioRepositorio.GetById(id);

                if (funcionario == null)
                {
                    return NotFound(new { Mensagem = "Funcionário não encontrado." });
                }

                var funcionarioComUrl = new Funcionario
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    Email = funcionario.Email,
                    Telefone = funcionario.Telefone,
                    Cargo = funcionario.Cargo,
                };

                return Ok(funcionarioComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar funcionário.", Erro = ex.Message });
            }
        }

        // POST api/Funcionario        
        [HttpPost]
        public ActionResult<object> Post(FuncionarioDto novoFuncionario)
        {
            try
            {
                var funcionario = new Funcionario
                {
                    Nome = novoFuncionario.Nome,
                    Email = novoFuncionario.Email,
                    Telefone = novoFuncionario.Telefone,
                    Cargo = novoFuncionario.Cargo,
                };

                _funcionarioRepositorio.Add(funcionario);

                var resultado = new
                {
                    Mensagem = "Funcionário cadastrado com sucesso!",
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    Email = funcionario.Email,
                    Telefone = funcionario.Telefone,
                    Cargo = funcionario.Cargo,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao cadastrar funcionário.", Erro = ex.Message });
            }
        }

        // PUT api/Funcionario/{id}        
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, FuncionarioDto funcionarioAtualizado)
        {
            try
            {
                var funcionarioExistente = _funcionarioRepositorio.GetById(id);

                if (funcionarioExistente == null)
                {
                    return NotFound(new { Mensagem = "Funcionário não encontrado." });
                }

                funcionarioExistente.Nome = funcionarioAtualizado.Nome;
                funcionarioExistente.Email = funcionarioAtualizado.Email;
                funcionarioExistente.Telefone = funcionarioAtualizado.Telefone;
                funcionarioExistente.Cargo = funcionarioAtualizado.Cargo;

                _funcionarioRepositorio.Update(funcionarioExistente);

                var resultado = new
                {
                    Mensagem = "Funcionário atualizado com sucesso!",
                    Id = funcionarioExistente.Id,
                    Nome = funcionarioExistente.Nome,
                    Email = funcionarioExistente.Email,
                    Telefone = funcionarioExistente.Telefone,
                    Cargo = funcionarioExistente.Cargo,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao atualizar funcionário.", Erro = ex.Message });
            }
        }

        // DELETE api/Funcionario/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var funcionarioExistente = _funcionarioRepositorio.GetById(id);

                if (funcionarioExistente == null)
                {
                    return NotFound(new { Mensagem = "Funcionário não encontrado." });
                }

                _funcionarioRepositorio.Delete(id);

                var resultado = new
                {
                    Mensagem = "Funcionário excluído com sucesso!",
                    Id = funcionarioExistente.Id,
                    Nome = funcionarioExistente.Nome,
                    Email = funcionarioExistente.Email,
                    Telefone = funcionarioExistente.Telefone,
                    Cargo = funcionarioExistente.Cargo,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao excluir funcionário.", Erro = ex.Message });
            }
        }
    }
}
