using System.Collections;
using TechnicalAPI.Connection;
using TechnicalAPI.DTO;
using TechnicalAPI.UoW;

namespace TechnicalAPI.Repo.Transacciones
{
    public class RepositoryTransacciones : IRepositoryTransacciones
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryTransacciones(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<TransaccionesDTO>> GetTransacciones(int id)
        {
            List<TransaccionesDTO> list = new List<TransaccionesDTO>();

            Hashtable parametros = new Hashtable()
            {
            { "@idCard", id },
        };

            using (var con = _unitOfWork.Connection)
            {
                list = con.ReadL<TransaccionesDTO>("getTransacciones", parametros);
            }
            return Task.FromResult(list);
        }
    }
}
