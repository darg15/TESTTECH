using FluentValidation;

namespace TechnicalAPI.DTO
{
    public class MovsDTOValidator : AbstractValidator<MovDTO>
    {
        public MovsDTOValidator()
        {
            RuleFor(mov => mov.IdCard).GreaterThan(0).WithMessage("El IdCard debe ser mayor que 0.");
            RuleFor(mov => mov.Fecha).NotNull().WithMessage("La fecha es obligatoria.");
            RuleFor(mov => mov.Descrip).NotEmpty().WithMessage("La descripción es obligatoria.");
            RuleFor(mov => mov.Price).GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");
        }
    }
}
