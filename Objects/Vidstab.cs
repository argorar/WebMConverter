using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMConverter.Objects
{
    public class Vidstab
    {

        public Vidstab(string shakiness, string zoom, string smoothing, string desc)
        {
            this.shakiness = shakiness;
            this.zoom = zoom;
            this.smoothing = smoothing;
            this.desc = desc;
        }

        public string shakiness { get; set; }
        public string zoom { get; set; }
        public string smoothing { get; set; }
        public string desc { get; set; }
    }
}
