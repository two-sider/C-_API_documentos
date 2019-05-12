using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ServiciosRest.Dominio;
namespace ServiciosRest.ClienteWeb.Controllers
{
    public class DocumentoController : Controller
    {
        // GET: Documento
        public ActionResult Index()
        {
            //Invocar servicios REST
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:52040/");

            var request = clienteHttp.GetAsync("api/Documentos").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<documentos>>(resultString);
                return View(listado);
            }
            return View(new List<documentos>());
        }
    }
}