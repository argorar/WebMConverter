using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMConverter.Objects
{
    public class ReleaseInfo
    {
        public string tag_name { get; set; }
        public List<Asset> assets { get; set; }
    }
}
