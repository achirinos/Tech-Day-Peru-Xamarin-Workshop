using Newtonsoft.Json;
using SimpleApp.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;


namespace SimpleApp.Services
{
    public class PosicionesService
    {
        public IEnumerable<Equipo> Posiciones { get; set; }

        public event EventHandler<PosicionesEventArgs> LoadPosicionesCompleted;

        public async void LoadPosiciones()
        {
            var client = new System.Net.Http.HttpClient();

            client.BaseAddress = new Uri("http://adivinamisempresas.gear.host/");

            var response = await client.GetAsync("/Content/FutbolPeroPosiciones.txt");

            var content = response.Content.ReadAsStringAsync().Result;

            var posiciones = JsonConvert.DeserializeObject<List<Equipo>>(content);

            if (response.IsSuccessStatusCode)
            {
                if (LoadPosicionesCompleted != null)
                {
                    LoadPosicionesCompleted(this, new PosicionesEventArgs(posiciones));
                    this.Posiciones = posiciones;
                }
            }
        }
    }
}
