using TechnicalAPI.DTO;

namespace TechnicalAPI.Repo.Transacciones
{
    public interface IRepositoryTransacciones
    {
        Task<List<TransaccionesDTO>> GetTransacciones(int id);
    }
}
