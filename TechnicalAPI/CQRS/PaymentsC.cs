using FluentValidation;
using MediatR;
using TechnicalAPI.DTO;
using TechnicalAPI.Repo.Movs;
using TechnicalAPI.Repo.Payments;

namespace TechnicalAPI.CQRS
{
    public class PaymentsC
    {
        public class CreatePayCommand : IRequest<PaymentsDTO>
        {
            public PaymentsDTO Pay { get; set; }

            public CreatePayCommand(PaymentsDTO pay)
            {
                Pay = pay;
            }
        }

        public class CreatePayCommandHandler : IRequestHandler<CreatePayCommand, PaymentsDTO>
        {
            private readonly IPaymentRepository _repository;
            private readonly IValidator<PaymentsDTO> _validator;

            public CreatePayCommandHandler(IPaymentRepository repository, IValidator<PaymentsDTO> validator)
            {
                _repository = repository;
                _validator = validator;
            }

            public async Task<PaymentsDTO> Handle(CreatePayCommand request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync(request.Pay, cancellationToken);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                return await _repository.Post(request.Pay);
            }
        }





        public class GetAllPaysQuery : IRequest<List<PaymentsDTO>>
        {
            public int IdCard { get; set; }

            public GetAllPaysQuery(int id)
            {
                IdCard = id;
            }
        }

        public class GetAllPaysQueryHandler : IRequestHandler<GetAllPaysQuery, List<PaymentsDTO>>
        {
            private readonly IPaymentRepository _repository;

            public GetAllPaysQueryHandler(IPaymentRepository repository)
            {
                _repository = repository;
            }

            public async Task<List<PaymentsDTO>> Handle(GetAllPaysQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll(request.IdCard);
            }
        }
    }
}
