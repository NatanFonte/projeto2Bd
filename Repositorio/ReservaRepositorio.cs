﻿using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Repositorio
{
    public class ReservaRepositorio
    {
        private readonly BdBibliotecaNatanContext _context;

        public ReservaRepositorio(BdBibliotecaNatanContext context)
        {
            _context = context;
        }

        // Adiciona um novo cliente
        public void Add(Reserva reserva)
        {
            var tbReserva = new TbReserva()
            {
                Id = reserva.Id,
                DataReserva = reserva.DataReserva,
            };

            // Adiciona a entidade ao contexto
            _context.TbReservas.Add(tbReserva);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbReserva = _context.TbReservas.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbReserva != null)
            {
                // Remove a entidade do contexto
                _context.TbReservas.Remove(tbReserva);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Reserva não encontrada.");
            }
        }

        public List<Reserva> GetAll()
        {
            List<Reserva> listFun = new List<Reserva>();

            var listTb = _context.TbReservas.ToList();

            foreach (var item in listTb)
            {
                var reserva = new Reserva
                {
                    Id = item.Id,
                    DataReserva = item.DataReserva,
                };

                listFun.Add(reserva);
            }

            return listFun;
        }

        public Reserva GetById(int id)
        {
            // Busca o funcionário pelo ID no banco de dados
            var item = _context.TbReservas.FirstOrDefault(f => f.Id == id);

            // Verifica se o funcionário foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Funcionario
            var reserva = new Reserva
            {
                Id = item.Id,
                DataReserva = item.DataReserva,
            };

            return reserva; // Retorna o funcionário encontrado
        }

        public void Update(Reserva reserva)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbReserva = _context.TbReservas.FirstOrDefault(f => f.Id == reserva.Id);

            // Verifica se a entidade foi encontrada
            if (tbReserva != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                tbReserva.Id = reserva.Id;
                tbReserva.DataReserva = reserva.DataReserva;



                // Atualiza as informações no contexto
                _context.TbReservas.Update(tbReserva);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Reserva não encontrado.");
            }
        }
    }
}
