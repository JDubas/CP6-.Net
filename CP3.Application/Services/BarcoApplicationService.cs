using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using CP3.Domain.Interfaces.Dtos;

namespace CP3.Application.Services
{
    public class BarcoApplicationService : IBarcoApplicationService
    {
        private readonly IBarcoRepository _repository;

        public BarcoApplicationService(IBarcoRepository repository)
        {
            _repository = repository;
        }

        public BarcoEntity AdicionarBarco(IBarcoDto entity)
        {
       return _repository.Adicionar(new BarcoEntity
       {
                Nome = entity.Nome,
                Modelo = entity.Modelo,
                Ano = entity.Ano,
                Tamanho = entity.Tamanho
            });

        }

        public BarcoEntity EditarBarco(int id, IBarcoDto entity)
        {
            return _repository.Editar(new BarcoEntity
            {
                Id = id,
                Nome = entity.Nome,
                Modelo = entity.Modelo,
                Ano = entity.Ano,
                Tamanho = entity.Tamanho
            });

        }

        public BarcoEntity ObterBarcoPorId(int id)
        {
            return _repository.ObterPorId(id);



        }

        public IEnumerable<BarcoEntity> ObterTodosBarcos()
        {
            return _repository.ObterTodos();
        }

        public BarcoEntity RemoverBarco(int id)
        {
            return _repository.Remover(id);
        }
    }
}
