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
        [HttpPost]
        public bool Post(documentos doc)
        {
            BD.documentos.Add(doc);
            return BD.SaveChanges() > 0;
            
        }
        [HttpPut]
        public bool Put(documentos doc)
        {
            var docActualizar = BD.documentos.FirstOrDefault(x => x.doc_id == doc.doc_id);
            docActualizar.doc_nombre = doc.doc_nombre;
            docActualizar.doc_autor = doc.doc_autor;
            docActualizar.doc_institucion = doc.doc_institucion;
            docActualizar.doc_No_paginas = doc.doc_No_paginas;
            docActualizar.doc_tipo = doc.doc_tipo;
            docActualizar.doc_tema = doc.doc_tema;
            docActualizar.doc_prestamo = doc.doc_prestamo;
            docActualizar.doc_pais = doc.doc_pais;
            
            return BD.SaveChanges() > 0;

        }
        [HttpDelete]
        public bool DELETE(int id)
        {
            var documento = BD.documentos.FirstOrDefault(x => x.doc_id == id);
            BD.documentos.Remove(documento);
            return BD.SaveChanges() > 0;
        }
    }
}
