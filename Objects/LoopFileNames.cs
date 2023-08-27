using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMConverter.Objects
{
    class LoopFileNames
    {
        public string LoopName { get; set; }
        public string Name { get; set; }

        public LoopFileNames(string name, string loopName)
        {
            Name = name;
            LoopName = loopName;
        }
    }
}
