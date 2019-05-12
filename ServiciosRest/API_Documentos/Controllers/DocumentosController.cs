using ServiciosREST.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Documentos.Controllers
{
    public class DocumentosController : ApiController
    {
        documentosConecction BD = new documentosConecction();
        [HttpGet]
        public IEnumerable<documentos> GET()
        {
            var listado = BD.documentos.ToList();
            return listado;
        }
        [HttpGet]
        public documentos GET(int id)
        {
            var documento = BD.documentos.FirstOrDefault(x => x.doc_id == id);
            return documento;
        }
        [HttpDelete]
        public documentos DELETE(int id)
        {
            var documento = BD.documentos.FirstOrDefault(x => x.doc_id == id);
            return documento;
        }
    }
}
