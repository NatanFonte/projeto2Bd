﻿using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Repositorio
{
    public class FuncionarioRepositorio
    {
        private readonly BdBibliotecaNatanContext _context;

        public FuncionarioRepositorio(BdBibliotecaNatanContext context)
        {
            _context = context;
        }

        // Adiciona um novo cliente
        public void Add(Funcionario funcionario)    
        {
            var tbFuncionario = new TbFuncionario()
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Email = funcionario.Email,
                Telefone = funcionario.Telefone,
                Cargo = funcionario.Cargo,

            };

            // Adiciona a entidade ao contexto
            _context.TbFuncionarios.Add(tbFuncionario);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbFuncionario = _context.TbFuncionarios.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbFuncionario != null)
            {
                // Remove a entidade do contexto
                _context.TbFuncionarios.Remove(tbFuncionario);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Funcionario não encontrado.");
            }
        }

        public List<Funcionario> GetAll()
        {
            List<Funcionario> listFun = new List<Funcionario>();

            var listTb = _context.TbFuncionarios.ToList();

            foreach (var item in listTb)
            {
                var funcionario = new Funcionario
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Email = item.Email,
                    Telefone = item.Telefone,
                    Cargo = item.Cargo,
                };

                listFun.Add(funcionario);
            }

            return listFun;
        }

        public Funcionario GetById(int id)
        {
            // Busca o funcionário pelo ID no banco de dados
            var item = _context.TbFuncionarios.FirstOrDefault(f => f.Id == id);

            // Verifica se o funcionário foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Funcionario
            var funcionario = new Funcionario
            {
                Id = item.Id,
                Nome = item.Nome,
                Email = item.Email,
                Telefone = item.Telefone,
                Cargo = item.Cargo,
            };

            return funcionario; // Retorna o funcionário encontrado
        }

        public void Update(Funcionario funcionario)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbFuncionario = _context.TbFuncionarios.FirstOrDefault(f => f.Id == funcionario.Id);

            // Verifica se a entidade foi encontrada
            if (tbFuncionario != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                tbFuncionario.Id = funcionario.Id;
                tbFuncionario.Nome = funcionario.Nome;
                tbFuncionario.Email = funcionario.Email;
                tbFuncionario.Telefone = funcionario.Telefone;
                tbFuncionario.Cargo = funcionario.Cargo;



                // Atualiza as informações no contexto
                _context.TbFuncionarios.Update(tbFuncionario);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Funcionario não encontrado.");
            }
        }
    }
}
