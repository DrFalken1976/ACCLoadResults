using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACCLoadResults.Forms
{
    public partial class frmMeteo : Form
    {
        public frmMeteo()
        {
            InitializeComponent();

            List<Tracks> Tracks = (from Datos in Globals.oData.Tracks select Datos).ToList();

            cboTracks.DataSource = Tracks;
            cboTracks.ValueMember = "Id";
            cboTracks.DisplayMember = "TrackName";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string TrackLat = ((ACCLoadResults.Models.Tracks)cboTracks.Items[cboTracks.SelectedIndex]).Lat;
            string TrackLon = ((ACCLoadResults.Models.Tracks)cboTracks.Items[cboTracks.SelectedIndex]).Lon;

            if (TrackLat != null && TrackLon != null) 
            {

                HttpClient client = new HttpClient();

                // Put the following code where you want to initialize the class
                // It can be the static constructor or a one-time initializer
                client.BaseAddress = new Uri("https://www.meteosource.com/api/v1/free/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Task<string> response = client.GetAsync("point?lat=" + TrackLat + "N&lon=" + TrackLon + "E&sections=current&language=en&units=metric&key=nop15udqetuhrp8ptajrz2kbuz7x5snth92e7izx").GetAwaiter().GetResult().Content.ReadAsStringAsync();
                Root MetoData = JsonConvert.DeserializeObject<Root>(response.Result.ToString());

                //Search Rain level
                List<TypeWeather> oData = (from Data in Globals.oData.TypeWeather where Data.Name == MetoData.current.summary.Trim() select Data).ToList();

                string cloudLevel = "0." + MetoData.current.cloud_cover.ToString().Substring(0, 1);
                string Rain = oData[0].ACCValue.Trim();
                string ambientTemp = MetoData.current.temperature.ToString("##");

                txtJSON.Text = string.Format(Globals.Weather, Rain, cloudLevel, ambientTemp);
                txtInfo.Text = response.Result.ToString();
            }

            //"rain": 0, va de 0 a 1.0 de menys a mes cal desactivar 
            //"cloudLevel": 0, va de 0 a 1.0 de menys a mes
            //"ambientTemp": 26,
            //"trackTemp": 30, NO CAL es calcula per el joc segons la temperatura del circuit
            //"weatherRandomness" : 0 (0 = static weather; 1-4 fairly realistic weather; 5-7 more sensational)
        }
    }
}
