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

        /// <summary>
        /// Metodo de consultas de todos los contribuyentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("getcontribuyentes")]
        public async Task<IActionResult> GetContribuyentesAll()
        {
            var response = await _contribuyentesRepository.GetContribuyentes();
            return Ok(new BusinessResponse<IEnumerable<ContribuyentesDto>>(response));
        }

        /// <summary>
        /// Metodo de consultas de todos los contribuyentes por su Rnc ó Cedula
        /// </summary>
        /// <returns></returns>
        [HttpGet("getcontribuyentes/{rncCedula}")]
        public async Task<IActionResult> GetContribuyentesById(string rncCedula)
        {
            var response = await _contribuyentesRepository.GetContribuyentesByCedula(rncCedula);

            return Ok(new BusinessResponse<IEnumerable<ContribuyentesDto>>(response));
        }

        /// <summary>
        /// Metodo de consultas de todos los Comprobantes Fiscales Electronicos
        /// </summary>
        /// <returns></returns>
        [HttpGet("getcomprobantesfiscaleselectronicos")]
        public async Task<IActionResult> GetComprobantesFiscalesElectronicosAll()
        {
            var response = await _comprobantesfiscalesRepository.GetComprobantesFiscalesElectronicos();
            return Ok(new BusinessResponse<IEnumerable<ComprobantesFiscalesElectronicosDto>>(response));
        }

        /// <summary>
        /// Metodo de consultas de los Comprobantes Fiscales Electronicos por su Rnc ó Cedula
        /// </summary>
        /// <returns></returns>
        [HttpGet("getcomprobantesfiscaleselectronicos/{rncCedula}")]
        public async Task<IActionResult> GetComprobantesFiscalesElectronicosById(string rncCedula)
        {
            var response = await _comprobantesfiscalesRepository.GetComprobantesFiscalesElectronicosById(rncCedula);

            return Ok(new BusinessResponse<IEnumerable<ComprobantesFiscalesElectronicosDto>>(response));
        }

    }
}
