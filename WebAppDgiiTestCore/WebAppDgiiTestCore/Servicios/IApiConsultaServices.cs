using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppDgiiTestCore.Models;

namespace WebAppDgiiTestCore.Servicios
{
    public interface IApiConsultaServices
    {
        Task<List<ComprobantesFiscalesElectronicos  >> GetComprobantesFiscalesElectronicos();
        Task<List<ComprobantesFiscalesElectronicos>> GetComprobantesFiscalesElectronicosById(string rncCedula);
        Task<List<Contribuyentes>> GetContribuyentes();
        Task<List<Contribuyentes>> GetContribuyentesById(string rncCedula);
    }
}