using TechnicalAPI.DTO;

namespace TechnicalAPI.Repo.Payments
{
    public interface IPaymentRepository
    {
        Task<PaymentsDTO> Post(PaymentsDTO model);
        Task<List<PaymentsDTO>> GetAll(int id);
    }
}
