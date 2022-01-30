using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMConverter.Objects
{
    internal class PrivateGfycatsResponse
    {
        public List<Gfycats> gfycats { get; set; }

        public class Gfycats
        {
            public string gfyId { get; set; }
            public string title { get; set; }
        }
    }
}
