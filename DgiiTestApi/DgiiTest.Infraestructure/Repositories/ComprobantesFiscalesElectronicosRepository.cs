using AutoMapper;
using DgiiTest.Api.Controllers.Response;
using DgiiTest.Core.DTOs;
using DgiiTest.Core.Entities;
using DgiiTest.Core.Repositories;
using DgiiTest.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgiiTest.Infraestructure.Repositories
{
    public class ComprobantesFiscalesElectronicosRepository : IComprobantesFiscalesElectronicosRepository
    {
        private readonly IMapper _mapper;

        public ComprobantesFiscalesElectronicosRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComprobantesFiscalesElectronicosDto>> GetComprobantesFiscalesElectronicos()
        {
            var response = new List<ComprobantesFiscalesElectronicos>();
            var result = new List<ComprobantesFiscalesElectronicosDto>();
            try
            {
                response.Add(new ComprobantesFiscalesElectronicos
                {
                    RncCedula = "98754321012",
                    ENcf = "E310000000001",
                    Monto = "200.00",
                    Itbis18 = "36.00"
                });
                response.Add(new ComprobantesFiscalesElectronicos
                {
                    RncCedula = "98754321012",
                    ENcf = "E310000000002",
                    Monto = "1000.00",
                    Itbis18 = "180.00"
                });

                result = _mapper.Map<List<ComprobantesFiscalesElectronicosDto>>(response);
                await Task.Delay(10);
            }
            catch (Exception ex)
            {
                throw new ExceptionResponse(ex.Message);
            }
            
            return result;
        }

        public async Task<IEnumerable<ComprobantesFiscalesElectronicosDto>> GetComprobantesFiscalesElectronicosById(string RncCedula)
        {
            var response = new List<ComprobantesFiscalesElectronicos>();
            var resultPostDto = new List<ComprobantesFiscalesElectronicosDto>();
            try
            {
                response.Add(new ComprobantesFiscalesElectronicos
                {
                    RncCedula = "98754321012",
                    ENcf = "E310000000001",
                    Monto = "200.00",
                    Itbis18 = "36.00"
                });
                response.Add(new ComprobantesFiscalesElectronicos
                {
                    RncCedula = "98754321012",
                    ENcf = "E310000000002",
                    Monto = "1000.00",
                    Itbis18 = "180.00"
                });

                response = response.Where(p => p.RncCedula == RncCedula).ToList();
                resultPostDto = _mapper.Map<List<ComprobantesFiscalesElectronicosDto>>(response);
                await Task.Delay(10);
            }
            catch (Exception ex )
            {

                throw new ExceptionResponse(ex.Message);
            }
            
            
            return resultPostDto;
        }
    }
}
