using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiciosREST.Datos.Modelos;

namespace ServiciosRest.ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Invocar servicios REST
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:52040/");

            var request = clienteHttp.GetAsync("api/Documentos").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<documentos>>(resultString);
                foreach (var item in listado)
                {
                    Console.WriteLine(item.doc_nombre);
                };
                Console.ReadLine();
            }
            //clienteHttp.PostAsync();
            //clienteHttp.PostAsync();
            //clienteHttp.DeleteAsync();


        }
    }
}
