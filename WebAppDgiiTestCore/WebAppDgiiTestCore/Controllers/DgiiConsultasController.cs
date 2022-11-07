using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppDgiiTestCore.Models;
using WebAppDgiiTestCore.Servicios;

namespace WebAppDgiiTestCore.Controllers
{
    public class DgiiConsultasController : Controller
    {
        private readonly IApiConsultaServices _consultaServices;

        public DgiiConsultasController(IApiConsultaServices consultaServices)
        {
            _consultaServices = consultaServices;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _consultaServices.GetContribuyentes();
            return View(response.ToList());
        }

        public async Task<IActionResult> GetComprobantesFiscalesElectronicoById(string rncCedula)
        {
            var response = await _consultaServices.GetComprobantesFiscalesElectronicosById(rncCedula);

            //RedirectToPage("GetComprobantesFiscalesElectronicoById");
            return View(response.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
