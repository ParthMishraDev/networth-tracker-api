using NetworkTracker.Core.Enums;
using System;

namespace NetworkTracker.Core.Models
{
    public class LineItem
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public double Amount { get; set; }
        public string NetworthType { get; set; }
    }
}
