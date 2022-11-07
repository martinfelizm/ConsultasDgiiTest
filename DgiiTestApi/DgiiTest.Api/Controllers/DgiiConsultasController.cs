using DgiiTest.Api.Controllers.Response;
using DgiiTest.Core.DTOs;
using DgiiTest.Core.Repositories;
using DgiiTest.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DgiiTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DgiiConsultasController : ControllerBase
    {
        private readonly IContribuyentesRepository _contribuyentesRepository;
        private readonly IComprobantesFiscalesElectronicosRepository _comprobantesfiscalesRepository;

        public DgiiConsultasController(IContribuyentesRepository contribuyentesRepository
            , IComprobantesFiscalesElectronicosRepository comprobantesfiscalesRepository)
        {
            _contribuyentesRepository = contribuyentesRepository;
            _comprobantesfiscalesRepository = comprobantesfiscalesRepository;
        }

        [HttpGet("getcontribuyentes")]
        public async Task<IActionResult> GetContribuyentesAll()
        {
            var response = await _contribuyentesRepository.GetContribuyentes();
            return Ok(new BusinessResponse<IEnumerable<ContribuyentesDto>>(response));
        }

        [HttpGet("getcontribuyentes/{rncCedula}")]
        public async Task<IActionResult> GetContribuyentesById(string rncCedula)
        {
            var response = await _contribuyentesRepository.GetContribuyentesByCedula(rncCedula);

            return Ok(new BusinessResponse<IEnumerable<ContribuyentesDto>>(response));
        }

        [HttpGet("getcomprobantesfiscaleselectronicos")]
        public async Task<IActionResult> GetComprobantesFiscalesElectronicosAll()
        {
            var response = await _comprobantesfiscalesRepository.GetComprobantesFiscalesElectronicos();
            return Ok(new BusinessResponse<IEnumerable<ComprobantesFiscalesElectronicosDto>>(response));
        }

        [HttpGet("getcomprobantesfiscaleselectronicos/{rncCedula}")]
        public async Task<IActionResult> GetComprobantesFiscalesElectronicosById(string rncCedula)
        {
            var response = await _comprobantesfiscalesRepository.GetComprobantesFiscalesElectronicosById(rncCedula);

            return Ok(new BusinessResponse<IEnumerable<ComprobantesFiscalesElectronicosDto>>(response));
        }

    }
}
