using NetworkTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkTracker.Core.Models
{
    public class Liability : LineItem
    {
        public LiabilityType Type { get; set; }
    }
}
