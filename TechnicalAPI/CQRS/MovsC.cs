using FluentValidation;
using MediatR;
using TechnicalAPI.DTO;
using TechnicalAPI.Repo.Movs;
using TechnicalAPI.UoW;

namespace TechnicalAPI.CQRS
{
    public class CreateMovCommand : IRequest<MovDTO>
    {
        public MovDTO Mov { get; set; }

        public CreateMovCommand(MovDTO mov)
        {
            Mov = mov;
        }
    }

    public class CreateMovCommandHandler : IRequestHandler<CreateMovCommand, MovDTO>
    {
        private readonly IMovsRepository _repository;
        private readonly IValidator<MovDTO> _validator;

        public CreateMovCommandHandler(IMovsRepository repository, IValidator<MovDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<MovDTO> Handle(CreateMovCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.Mov, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return await _repository.Post(request.Mov);
        }
    }

    /// ///////////////////////////////////////////////////////////////////
  
 
    public class GetAllMovsQuery : IRequest<List<MovDTO>>
    {
        public int IdCard { get; set; }

        public GetAllMovsQuery(int id)
        {
            IdCard = id;
        }
    }

    public class GetAllMovsQueryHandler : IRequestHandler<GetAllMovsQuery, List<MovDTO>>
    {
        private readonly IMovsRepository _repository;

        public GetAllMovsQueryHandler(IMovsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MovDTO>> Handle(GetAllMovsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll(request.IdCard);
        }
    }


}
