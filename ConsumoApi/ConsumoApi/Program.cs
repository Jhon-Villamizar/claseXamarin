using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ConsumoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            invocarApi();
        }

        public static void invocarApi()
        {
            HttpClient cliente = new HttpClient();
            //se especifica el sitio al que se realizaran las peticiones
            cliente.BaseAddress = new Uri("http://mitiendaapis.azurewebsites.net/");

            var request =  cliente.GetAsync("/api/Producto").Result;
            if (request.IsSuccessStatusCode)
            {
                var responseJSON =  request.Content.ReadAsStringAsync().Result;
                var respuesta = JsonConvert.DeserializeObject<List<Producto>>(responseJSON);
            }
        }
    }
}
