using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ServiciosRest.Dominio;
using System.Net.Http.Formatting;

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
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(documentos doc)
        {
            //Invocar servicios REST
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:52040/");

            var request = clienteHttp.PostAsync("api/Documentos", doc, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                return View(doc);
            }
            return View(doc);
        }


        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            //Invocar servicios REST
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:52040/");

            var request = clienteHttp.GetAsync("api/Documentos?id="+ id ).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<documentos>(resultString);
                return View(informacion);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Actualizar(documentos doc)
        {
            //Invocar servicios REST
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:52040/");

            var request = clienteHttp.PutAsync("api/Documentos", doc, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                return View(doc);
            }
            return View(doc);
        }
        [HttpGet]
        public ActionResult Eliminar (int id)
        {

            //Invocar servicios REST
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:52040/");

            var request = clienteHttp.DeleteAsync("api/Documentos?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Detalle(int id)
        {
            //Invocar servicios REST
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:52040/");

            var request = clienteHttp.GetAsync("api/Documentos?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<documentos>(resultString);
                return View(informacion);
            }
            return View();
        }
    }
}