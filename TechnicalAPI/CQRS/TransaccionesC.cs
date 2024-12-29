using MediatR;
using TechnicalAPI.DTO;
using TechnicalAPI.Repo.Payments;
using TechnicalAPI.Repo.Transacciones;

namespace TechnicalAPI.CQRS
{
    public class TransaccionesC
    {
        public class GetTransaccionesQuery : IRequest<List<TransaccionesDTO>>
        {
            public int IdCard { get; set; }

            public GetTransaccionesQuery(int id)
            {
                IdCard = id;
            }
        }

        public class GetTransaccionesQueryHandler : IRequestHandler<GetTransaccionesQuery, List<TransaccionesDTO>>
        {
            private readonly IRepositoryTransacciones _repository;

            public GetTransaccionesQueryHandler(IRepositoryTransacciones repository)
            {
                _repository = repository;
            }

            public async Task<List<TransaccionesDTO>> Handle(GetTransaccionesQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetTransacciones(request.IdCard);
            }
        }
    }
}
