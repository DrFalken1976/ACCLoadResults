using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCLoadResults.Classes
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Current
    {
        public string icon { get; set; }
        public int icon_num { get; set; }
        public string summary { get; set; }
        public double temperature { get; set; }
        public Wind wind { get; set; }
        public Precipitation precipitation { get; set; }
        public double cloud_cover { get; set; }
    }

    public class Precipitation
    {
        public double total { get; set; }
        public string type { get; set; }
    }

    public class Root
    {
        public string lat { get; set; }
        public string lon { get; set; }
        public int elevation { get; set; }
        public string timezone { get; set; }
        public string units { get; set; }
        public Current current { get; set; }
        public object hourly { get; set; }
        public object daily { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int angle { get; set; }
        public string dir { get; set; }
    }


}
