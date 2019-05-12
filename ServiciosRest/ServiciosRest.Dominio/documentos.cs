using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosRest.Dominio
{
    public class documentos
    {
        public int doc_id { get; set; }
        public string doc_nombre { get; set; }
        public string doc_autor { get; set; }
        public string doc_institucion { get; set; }
        public string doc_tipo { get; set; }
        public Nullable<int> doc_No_paginas { get; set; }
        public string doc_prestamo { get; set; }
        public string doc_tema { get; set; }
        public string doc_pais { get; set; }
    }
}

