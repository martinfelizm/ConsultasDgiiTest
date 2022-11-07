using DgiiTest.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DgiiTest.Infraestructure.Repositories
{
    public interface IContribuyentesRepository
    {
        Task<IEnumerable<ContribuyentesDto>> GetContribuyentes();
        Task<IEnumerable<ContribuyentesDto>> GetContribuyentesByCedula(string RncCedula);
    }
}