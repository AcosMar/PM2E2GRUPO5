using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;

namespace PM2E2GRUPO5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var localizacion = CrossGeolocator.Current;
            if (localizacion.IsGeolocationEnabled)//Servicio de Geolocalizacion existente
            {

            }
            else
            {
                DisplayAlert("Permisos Geolocalizacion", "Por favor, de Acceso a su ubicacion/geolocalizacion de manera manual en dispositivo", "OK");
            }
        }


        //Funcion con Validacion

        private async void Localizacion()
        {

            var Gps = CrossGeolocator.Current;

            if (Gps.IsGeolocationEnabled)//VALIDA QUE EL GPS ESTA ENCENDIDO
            {
                var localizacion = CrossGeolocator.Current;
                var posicion = await localizacion.GetPositionAsync();
                txtLongitud.Text = posicion.Longitude.ToString();
                txtLatitud.Text = posicion.Latitude.ToString();
            }

            else
            {
                await DisplayAlert("Gps Desactivado", "Por favor, Active su GPS/Ubicacion", "OK");
            }

        }

        //Evento para capturar la ubicacion
        private void btnNewUbication_Clicked(object sender, EventArgs e)
        {
            Localizacion();
            txtDescripcion.Text = "";            
        }
    }
}
