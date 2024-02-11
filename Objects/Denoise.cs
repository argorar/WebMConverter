using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMConverter.Objects
{
    public class Denoise
    {

        public Denoise(string nameValue, int levelValue)
        {
            this.name = nameValue;
            this.level = levelValue;
        }

        public string name { get; set; }
        public int level { get; set; }
    }
}
