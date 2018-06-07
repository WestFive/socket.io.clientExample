using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Model.Domain
{
    public class Picture
    {
        public string vehiclePictureUrl { get; set; }
        public string licencePlatePictureUrl { get; set; }
        public string frontTopPictureUrl { get; set; }
        public string backTopPictureUrl { get; set; }
        public string leftFrontPictureUrl { get; set; }
        public string leftBackPictureUrl { get; set; }
        public string rightFrontPictureUrl { get; set; }
        public string rightBackPictureUrl { get; set; }
        public string leftFrontDamagePictureUrl { get; set; }
        public string leftBackDamagePictureUrl { get; set; }
        public string rightFrontDamagePictureUrl { get; set; }
        public string rightBackDamagePictureUrl { get; set; }
        public string leftMosaicPictureUrl { get; set; }
        public string rightMosaicPictureUrl { get; set; }
        public string topMosaicPictureUrl { get; set; }
    }
}
