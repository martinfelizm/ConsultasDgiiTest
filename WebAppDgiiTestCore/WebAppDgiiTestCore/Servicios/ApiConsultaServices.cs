using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppDgiiTestCore.Models;

namespace WebAppDgiiTestCore.Servicios
{

    public class ApiConsultaServices : IApiConsultaServices
    {

        private static string apiconsultasurl;
        private readonly IConfiguration _config;

        public ApiConsultaServices(IConfiguration config)
        {
            _config = config;
            apiconsultasurl = _config.GetSection("ApiConsultas:apiurl").Value;
        }

        public async Task<List<Contribuyentes>> GetContribuyentes()
        {
            List<Contribuyentes> contribuyentes = new List<Contribuyentes>();
            apiconsultasurl = _config.GetSection("ApiConsultas:apiurl").Value;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(apiconsultasurl);

            var response = await cliente.GetAsync("api/DgiiConsultas/getcontribuyentes");            

            if (response.IsSuccessStatusCode)
            {
                var jsonresponse = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<ContribuyentesResponse>(jsonresponse);
                contribuyentes = resultApi.Result.ToList();
            }
            
            return contribuyentes;
        }

        public async Task<List<Contribuyentes>> GetContribuyentesById(string rncCedula)
        {
            List<Contribuyentes> contribuyentes = new List<Contribuyentes>();
            apiconsultasurl = _config.GetSection("ApiConsultas:apiurl").Value;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(apiconsultasurl);

            var response = await cliente.GetAsync($"api/DgiiConsultas/getcontribuyentes/{rncCedula}");

            if (response.IsSuccessStatusCode)
            {
                var jsonresponse = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<ContribuyentesResponse>(jsonresponse);
                contribuyentes = resultApi.Result.ToList();
                
            }

            return contribuyentes;
           
        }

        public async Task<List<ComprobantesFiscalesElectronicos>> GetComprobantesFiscalesElectronicos()
        {
            List<ComprobantesFiscalesElectronicos> comprobantes = new List<ComprobantesFiscalesElectronicos>();
            apiconsultasurl = _config.GetSection("ApiConsultas:apiurl").Value;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(apiconsultasurl);

            var response = await cliente.GetAsync("api/DgiiConsultas/getcomprobantesfiscaleselectronicos");

            if (response.IsSuccessStatusCode)
            {
                var jsonresponse = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<ComprobantesFiscalesElectronicosResponse>(jsonresponse);
                comprobantes = resultApi.Result.ToList();
                comprobantes.First().MontoTotal = comprobantes.Select(p => Convert.ToDecimal(p.Monto)).Sum();
                comprobantes.First().ItbisTotal = comprobantes.Select(p => Convert.ToDecimal(p.Itbis18)).Sum();
            }        
                        

            return comprobantes;
        }
        public async Task<List<ComprobantesFiscalesElectronicos>> GetComprobantesFiscalesElectronicosById(string rncCedula)
        {
            List<ComprobantesFiscalesElectronicos> comprobantes = new List<ComprobantesFiscalesElectronicos>();
            apiconsultasurl = _config.GetSection("ApiConsultas:apiurl").Value;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(apiconsultasurl);

            var response = await cliente.GetAsync($"api/DgiiConsultas/getcomprobantesfiscaleselectronicos/{rncCedula}");

            if (response.IsSuccessStatusCode)
            {
                var jsonresponse = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<ComprobantesFiscalesElectronicosResponse>(jsonresponse);
                comprobantes = resultApi.Result.ToList();
                comprobantes.First().MontoTotal = comprobantes.Sum(p => decimal.Parse(p.Monto, CultureInfo.InvariantCulture));
                comprobantes.First().ItbisTotal = comprobantes.Select(p => decimal.Parse(p.Itbis18, CultureInfo.InvariantCulture)).Sum();
            }


            return comprobantes;            
        }
    }
}
