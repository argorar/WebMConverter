using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMConverter.Objects
{
    public class UserDetailsResponse
    {
        public string followers { get; set; }
        public string name { get; set; }
        public string profileImageUrl { get; set; }
        public int publishedGfycats { get; set; }
        public int totalGfycats { get; set; }
        public int views { get; set; }
    }
}
