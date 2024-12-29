using FluentValidation;

namespace TechnicalAPI.DTO
{
    public class PaymentsDTOValidator : AbstractValidator<PaymentsDTO>
    {
        public PaymentsDTOValidator()
        {
            RuleFor(pay => pay.IdCard).GreaterThan(0).WithMessage("El IdCard debe ser mayor que 0.");
            RuleFor(pay => pay.Fecha).NotNull().WithMessage("La fecha es obligatoria.");
            RuleFor(pay => pay.Amount).GreaterThan(0).WithMessage("Debe abonar por lo menos 1 dolar");
        }
    }
}
