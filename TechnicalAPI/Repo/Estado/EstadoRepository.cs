using System.Collections;
using System.Collections.Generic;
using TechnicalAPI.DTO;
using TechnicalAPI.UoW;

namespace TechnicalAPI.Repo.Estado
{
    public class EstadoRepository :IEstadoRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EstadoDTO>> Get(int id)
        {
            List<EstadoDTO> listEs = new List<EstadoDTO>();
            List<MovDTO> listMov = new List<MovDTO>();

            Hashtable parametros = new Hashtable()
                 {
        {           "@idCard", id }
                 };

            using (var con = _unitOfWork.Connection)
            {
                listEs = con.ReadL<EstadoDTO>("getEstado", parametros);
            }
            using (var con = _unitOfWork.Connection)
            {
                listMov = con.ReadL<MovDTO>("getMovs", parametros);
            }
            
            foreach (var estado in listEs)
            {
                estado.Movs = listMov;
            }

            return await Task.FromResult(listEs);
        }
    }
}
