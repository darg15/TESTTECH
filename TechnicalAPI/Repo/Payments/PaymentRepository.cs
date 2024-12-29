using System.Collections;
using TechnicalAPI.DTO;
using TechnicalAPI.UoW;

namespace TechnicalAPI.Repo.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<PaymentsDTO>> GetAll(int id)
        {
            List<PaymentsDTO> list = new List<PaymentsDTO>();

            Hashtable parametros = new Hashtable()
            {
            { "@idCard", id },
        };

            using (var con = _unitOfWork.Connection)
            {
                list = con.ReadL<PaymentsDTO>("getPayments", parametros);
            }
            return Task.FromResult(list);
        }

        public Task<PaymentsDTO> Post(PaymentsDTO model)
        {
            PaymentsDTO payDTO = new PaymentsDTO();
            Hashtable parametros = new Hashtable()
        {
            { "@idCard", model.IdCard },
            { "@date", model.Fecha },
            { "@amount", model.Amount }
        };

            using (var con = _unitOfWork.Connection)
            {
                payDTO = con.Read<PaymentsDTO>("newPayment", parametros);
            }

            return Task.FromResult(payDTO);
        }
    }
}
