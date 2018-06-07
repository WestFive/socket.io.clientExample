using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Model.Domain
{
    public class Damage
    {
        public string side { get; set; }
        public string damageCode { get; set; }

        public string damageGrade { get; set; }

        public string damagePart { get; set; }

        public string remark { get; set; }


    }
}
