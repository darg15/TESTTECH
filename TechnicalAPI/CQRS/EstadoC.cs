using MediatR;
using TechnicalAPI.DTO;
using TechnicalAPI.Repo.Estado;
using TechnicalAPI.Repo.Transacciones;

namespace TechnicalAPI.CQRS
{
    public class EstadoC
    {
        public class GetEstadoQuery : IRequest<List<EstadoDTO>>
        {
            public int IdCard { get; set; }

            public GetEstadoQuery(int id)
            {
                IdCard = id;
            }
        }

        public class GetEstadoQueryHandler : IRequestHandler<GetEstadoQuery, List<EstadoDTO>>
        {
            private readonly IEstadoRepository _repository;

            public GetEstadoQueryHandler(IEstadoRepository repository)
            {
                _repository = repository;
            }

            public async Task<List<EstadoDTO>> Handle(GetEstadoQuery request, CancellationToken cancellationToken)
            {
                return await _repository.Get(request.IdCard);
            }
        }
    }
}
