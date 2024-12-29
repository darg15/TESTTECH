using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Reflection;
using TechnicalAPI.Connection;
using TechnicalAPI.DTO;
using TechnicalAPI.UoW;

namespace TechnicalAPI.Repo.Movs
{
    public class MovRepository : IMovsRepository
    {
        //public Task<MovDTO> Post(MovDTO model)
        //{
        //    MovDTO movDTO = new MovDTO();
        //    Hashtable parametros = new Hashtable()
        //    {
        //        { "@idCard", model.IdCard },
        //        { "@date", model.Fecha},
        //        { "@description", model.Descrip  },
        //        { "@price", model.Price}
        //    };

        //    using (ConnectionDB con = new ConnectionDB())
        //    {
        //        movDTO = con.Read<MovDTO>("newMov", parametros);
        //    }

        //    return Task.FromResult(movDTO);
        //}


        private readonly IUnitOfWork _unitOfWork;

        public MovRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<MovDTO>> GetAll(int id)
        {
            List<MovDTO> list = new List<MovDTO>();

            Hashtable parametros = new Hashtable()
            {
            { "@idCard", id },
        };

            using (var con = _unitOfWork.Connection)
            {
               list = con.ReadL<MovDTO>("getMovs", parametros);
            }
            return Task.FromResult(list);
        }

        public  Task<MovDTO> Post(MovDTO model)
        {
            MovDTO movDTO = new MovDTO();
            Hashtable parametros = new Hashtable()
        {
            { "@idCard", model.IdCard },
            { "@date", model.Fecha },
            { "@description", model.Descrip },
            { "@price", model.Price }
        };

            using (var con = _unitOfWork.Connection)
            {
                movDTO =  con.Read<MovDTO>("newMov", parametros);
            }

            return Task.FromResult(movDTO);
        }
    }
}
