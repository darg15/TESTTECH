using TechnicalAPI.DTO;

namespace TechnicalAPI.Repo.Movs
{
    public interface IMovsRepository
    {
        Task<MovDTO> Post(MovDTO model);
        Task<List<MovDTO>> GetAll(int idCard);
    }
}
