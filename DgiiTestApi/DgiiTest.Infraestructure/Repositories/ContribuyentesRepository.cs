using AutoMapper;
using DgiiTest.Core.DTOs;
using DgiiTest.Core.Entities;
using DgiiTest.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DgiiTest.Infraestructure.Repositories
{
    public class ContribuyentesRepository : IContribuyentesRepository
    {
        private readonly IMapper _mapper;

        public ContribuyentesRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
    public async Task<IEnumerable<ContribuyentesDto>> GetContribuyentes()
        {
            var response = new List<Contribuyentes>();
            var result = new List<ContribuyentesDto>();
            try
            {
                response.Add(new Contribuyentes
                {
                    RncCedula = "98754321012",
                    Nombre = "JUAN PEREZ",
                    Tipo = "PERSONA FISICA",
                    Estatus = "activo"
                });
                response.Add(new Contribuyentes
                {
                    RncCedula = "123456789",
                    Nombre = "FARMACIA TU SALUD",
                    Tipo = "PERSONA JURIDICA",
                    Estatus = "inactivo"
                });

                 result = _mapper.Map<List<ContribuyentesDto>>(response);
                await Task.Delay(10);
            }
            catch (Exception ex)
            {

                throw new ExceptionResponse(ex.Message);
            }
            
            return result;
        }

        public async Task<IEnumerable<ContribuyentesDto>> GetContribuyentesByCedula(string RncCedula)
        {
            var response = new List<Contribuyentes>();
            var result = new List<ContribuyentesDto>();
            try
            {
                response.Add(new Contribuyentes
                {
                    RncCedula = "98754321012",
                    Nombre = "JUAN PEREZ",
                    Tipo = "PERSONA FISICA",
                    Estatus = "activo"
                });
                response.Add(new Contribuyentes
                {
                    RncCedula = "123456789",
                    Nombre = "FARMACIA TU SALUD",
                    Tipo = "PERSONA JURIDICA",
                    Estatus = "inactivo"
                });

                response = response.Where(p => p.RncCedula == RncCedula).ToList();
                result = _mapper.Map<List<ContribuyentesDto>>(response);
                await Task.Delay(10);
            }
            catch (Exception ex)
            {

                throw new ExceptionResponse(ex.Message);
            }
            
            return result;
        }
    }
}
