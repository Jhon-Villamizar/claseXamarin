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
	public partial class CarteleraPage : ContentPage
	{
		public CarteleraPage ()
		{
			InitializeComponent ();
            CargarPeliculasAsync();
		}

        private async void CargarPeliculasAsync()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");



            // Generar el stringContent
            var request = await cliente.GetAsync("/api/Cartelera");
            if(request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<List<Pelicula>>(responseJson);
                listPeliculas.ItemsSource = respuesta;
            }
            else
            {
                await DisplayAlert("lo sentimos!", "se ha generado", "Ok");
            }
        }

        private void Pelicula_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var pelicula =(Pelicula)e.SelectedItem;
            Navigation.PushAsync(new FuncionesPage(pelicula));
        }
    }
}