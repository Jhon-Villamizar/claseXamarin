using cinemas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cinemas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Ingresar_Click(object sender, EventArgs e)
        {
            string usuario, password;
            usuario = txtUsuario.Text;
            password = txtPassword.Text;

            if (string.IsNullOrEmpty(usuario))
            {
                await DisplayAlert("Validacion", "Debe ingresar el nombre del usuario", "OK");
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Validacion", "Debe ingresar el password", "OK");
                txtPassword.Focus();
                return;
            }

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var autenticacion = new Autenticacion
            {
                Usuario = usuario,
                Password = password
            };

            var json = JsonConvert.SerializeObject(autenticacion);

            // Generar el stringContent
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = await cliente.PostAsync("/api/Seguridad", content);
            if(request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<Respuesta>(responseJson);

                if (respuesta.EsPermitido)
                {
                    Navigation.PushAsync(new CarteleraPage());
                }
                else
                {
                    await DisplayAlert("lo sentimos", respuesta.Mensaje, "OK");
                }
            }
            else
            {
                await DisplayAlert("lo sentimos", "Se ha generado un error con la cominicacion", "OK");
            }
        }
	}
}