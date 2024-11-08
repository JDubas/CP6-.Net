using CP3.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP3.Application.Dtos
{
    public class BarcoDto : IBarcoDto
    {

        public string Nome { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public double Tamanho { get; set; }







        public void Validate()
        {
            var validator = new BarcoDtoValidando().Validate(this);
            if (!validator.IsValid)
            {
                throw new ValidationException(validator.Errors);
            }
            

        }
    }

        


    internal class BarcoDtoValidando : AbstractValidator<BarcoDto>
    {
        public BarcoDtoValidando()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Preencha o nome");
            RuleFor(x => x.Modelo).NotEmpty().WithMessage("Preencha o modelo");
            RuleFor(x => x.Ano).GreaterThan(0).WithMessage("Ano não pode ser 0");
            RuleFor(x => x.Tamanho).GreaterThan(0).WithMessage("Tamanho não pode ser 0");

        }
    }

}
