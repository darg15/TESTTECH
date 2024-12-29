using TechnicalAPI.DTO;

namespace TechnicalAPI.Repo.Estado
{
    public interface IEstadoRepository
    {
        Task<List<EstadoDTO>> Get(int id);
    }
}
