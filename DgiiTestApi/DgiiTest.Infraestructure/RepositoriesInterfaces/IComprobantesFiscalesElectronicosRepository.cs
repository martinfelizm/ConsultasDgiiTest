using DgiiTest.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DgiiTest.Core.Repositories
{
    public interface IComprobantesFiscalesElectronicosRepository
    {
        Task<IEnumerable<ComprobantesFiscalesElectronicosDto>> GetComprobantesFiscalesElectronicos();
        Task<IEnumerable<ComprobantesFiscalesElectronicosDto>> GetComprobantesFiscalesElectronicosById(string RncCedula);
    }
}