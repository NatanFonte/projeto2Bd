﻿using ProjetoWebApiNatan.Model;
using ProjetoWebApiNatan.ORM3;

namespace ProjetoWebApiNatan.Repositorio
{
    public class MembroRepositorio
    {
        private readonly BdBibliotecaNatanContext _context;

        public MembroRepositorio(BdBibliotecaNatanContext context)
        {
            _context = context;
        }

        // Adiciona um novo cliente
        public void Add(Membro membro)
        {
            var tbMembro = new TbMembro()
            {
                Id = membro.Id,
                Nome = membro.Nome,
                Email = membro.Email,
                Telefone = membro.Telefone,
                DataCadastro = membro.DataCadastro,
            };

            // Adiciona a entidade ao contexto
            _context.TbMembros.Add(tbMembro);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbMembro = _context.TbMembros.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbMembro != null)
            {
                // Remove a entidade do contexto
                _context.TbMembros.Remove(tbMembro);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Membro não encontrada.");
            }
        }

        public List<Membro> GetAll()
        {
            List<Membro> listFun = new List<Membro>();

            var listTb = _context.TbMembros.ToList();

            foreach (var item in listTb)
            {
                var membro = new Membro
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Email = item.Email,
                    Telefone = item.Telefone,
                    DataCadastro = item.DataCadastro,
                };

                listFun.Add(membro);
            }

            return listFun;
        }

        public Membro GetById(int id)
        {
            // Busca o funcionário pelo ID no banco de dados
            var item = _context.TbMembros.FirstOrDefault(f => f.Id == id);

            // Verifica se o funcionário foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Funcionario
            var membro = new Membro
            {
                Id = item.Id,
                Nome = item.Nome,
                Email = item.Email,
                Telefone = item.Telefone,
                DataCadastro = item.DataCadastro,
            };

            return membro; // Retorna o funcionário encontrado
        }

        public void Update(Membro membro)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbMembro = _context.TbMembros.FirstOrDefault(f => f.Id == membro.Id);

            // Verifica se a entidade foi encontrada
            if (tbMembro != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                tbMembro.Id = membro.Id;
                tbMembro.Nome = membro.Nome;
                tbMembro.Email = membro.Email;
                tbMembro.Telefone = membro.Telefone;
                tbMembro.DataCadastro = membro.DataCadastro;



                // Atualiza as informações no contexto
                _context.TbMembros.Update(tbMembro);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Membro não encontrado.");
            }
        }
    }
}
