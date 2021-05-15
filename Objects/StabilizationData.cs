using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMConverter.Objects
{
    class StabilizationData
    {
        public string TempName { get; set; }
        public string Name { get; set; }

        public StabilizationData(string text, string tempName)
        {
            Name = text;
            TempName = tempName;
        }
    }
}
