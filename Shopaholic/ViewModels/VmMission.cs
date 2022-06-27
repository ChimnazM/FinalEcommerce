using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmMission
    {
        public Universal Universal { get; set; }
        public List<MissionFeature> MissionFeatures { get; set; }
        public MissionFile MissionFile { get; set; }
    }
}
