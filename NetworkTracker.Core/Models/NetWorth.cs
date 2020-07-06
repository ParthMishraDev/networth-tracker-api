using NetworkTracker.Core.Models;
using System.Collections.Generic;

namespace NetworkTracker.Core
{
    public class NetWorth
    {
        public int Id { get; set; }
        public double NetWorthAmount { get; set; }
        public double TotalAssetsAmount { get; set; }
        public double TotalLiabilitiesAmount { get; set; }
        public List<Asset> Assets { get; set; }
        public List<Liability> Liabilities { get; set; }
    }
}
