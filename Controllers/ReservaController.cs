using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.Repositorio;

namespace ProjetoWebApiNatan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaRepositorio _reservaRepositorio;

        public ReservaController(ReservaRepositorio reservaRepo)
        {
            _reservaRepositorio = reservaRepo;
        }

        // GET: api/Reserva
        [HttpGet]
        public ActionResult<List<Reserva>> GetAll()
        {
            try
            {
                var reservas = _reservaRepositorio.GetAll();

                if (reservas == null || !reservas.Any())
                {
                    return NotFound(new { Mensagem = "Nenhuma Reserva encontrada." });
                }

                var listaComUrl = reservas.Select(reserva => new Reserva
                {
                    Id = reserva.Id,
                    DataReserva = reserva.DataReserva,
                }).ToList();

                return Ok(listaComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar reservas.", Erro = ex.Message });
            }
        }

        // GET: api/Reserva/{id}
        [HttpGet("{id}")]
        public ActionResult<Reserva> GetById(int id)
        {
            try
            {
                var reserva = _reservaRepositorio.GetById(id);

                if (reserva == null)
                {
                    return NotFound(new { Mensagem = "Reserva não encontrada." });
                }

                var reservaComUrl = new Reserva
                {
                    Id = reserva.Id,
                    DataReserva = reserva.DataReserva,
                };

                return Ok(reservaComUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar reserva.", Erro = ex.Message });
            }
        }

        // POST api/Reserva        
        [HttpPost]
        public ActionResult<object> Post(ReservaDto novoReserva)
        {
            try
            {
                var reserva = new Reserva
                {
                    DataReserva = novoReserva.DataReserva,
                    FkMembros = novoReserva.FkMembros,
                    FkLivros = novoReserva.FkLivros,
                };

                _reservaRepositorio.Add(reserva);

                var resultado = new
                {
                    Mensagem = "Reserva cadastrada com sucesso!",
                    Id = reserva.Id,
                    DataReserva = reserva.DataReserva,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao cadastrar reserva.", Erro = ex.Message });
            }
        }

        // PUT api/Reserva/{id}        
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, ReservaDto reservaAtualizado)
        {
            try
            {
                var reservaExistente = _reservaRepositorio.GetById(id);

                if (reservaExistente == null)
                {
                    return NotFound(new { Mensagem = "Reserva não encontrada." });
                }

                reservaExistente.DataReserva = reservaAtualizado.DataReserva;
                reservaExistente.FkLivros = reservaAtualizado.FkLivros;
                reservaExistente.FkMembros = reservaAtualizado.FkMembros;

                _reservaRepositorio.Update(reservaExistente);

                var resultado = new
                {
                    Mensagem = "Reserva atualizada com sucesso!",
                    Id = reservaExistente.Id,
                    DataReserva = reservaExistente.DataReserva,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao atualizar reserva.", Erro = ex.Message });
            }
        }

        // DELETE api/Reserva/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var reservaExistente = _reservaRepositorio.GetById(id);

                if (reservaExistente == null)
                {
                    return NotFound(new { Mensagem = "Reserva não encontrada." });
                }

                _reservaRepositorio.Delete(id);

                var resultado = new
                {
                    Mensagem = "Reserva excluída com sucesso!",
                    Id = reservaExistente.Id,
                    DataReserva = reservaExistente.DataReserva,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao excluir reserva.", Erro = ex.Message });
            }
        }
    }
}
