using CP3.Data.AppData;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;

namespace CP3.Data.Repositories
{
    public class BarcoRepository : IBarcoRepository
    {
        private readonly ApplicationContext _context;

        public BarcoRepository(ApplicationContext context)
        {
            _context = context;
        }

        BarcoEntity? IBarcoRepository.Adicionar(BarcoEntity cliente)
        {
            _context.Barco.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        BarcoEntity? IBarcoRepository.Editar(BarcoEntity cliente)
        {
            var entity = _context.Barco.Find(cliente.Id);
            if (entity is not null)
            {
                entity.Nome = cliente.Nome;
                entity.Modelo = cliente.Modelo;
                entity.Ano = cliente.Ano;
                entity.Tamanho = cliente.Tamanho;
                _context.Barco.Update(entity);
                _context.SaveChanges();
            }
            return null;


        }

        BarcoEntity? IBarcoRepository.ObterPorId(int id)
        {
            var entity = _context.Barco.Find(id);
            if (entity is not null)
            {
                return entity;
            }
            return null;

        }

        IEnumerable<BarcoEntity>? IBarcoRepository.ObterTodos()
        {
            var entity = _context.Barco.ToList();
            if (entity is not null)
            {
                return entity;
            }
            return null;

        }

        BarcoEntity? IBarcoRepository.Remover(int id)
        {
            var entity = _context.Barco.Find(id);
            if (entity is not null)
            {
                _context.Barco.Remove(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }
    }
}
