using AutoMapper;
using DgiiTest.Core.DTOs;
using DgiiTest.Core.Entities;

namespace DgiiTest.Infraestructure.Mappings
{
    public class AutomapperRelations: Profile
    {
        public AutomapperRelations()
        {
            // Contribuyentes
            CreateMap<ContribuyentesDto, Contribuyentes>().ReverseMap();

            // ComprobantesFiscalesElectronicos
            CreateMap<ComprobantesFiscalesElectronicosDto, ComprobantesFiscalesElectronicos>().ReverseMap();
        }
    }
}
