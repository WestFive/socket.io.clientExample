using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Model.Domain
{
    public class Container
    {
        public string position { get; set; }

        public string containerNumber { get; set; }

        public string ocrContainerNumber { get; set; }

        public string isoCode { get; set; }

        public string reliability { get; set; }

        public List<Damage> damages { get; set; }
    }
}
