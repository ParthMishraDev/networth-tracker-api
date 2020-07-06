using NetworkTracker.Core;
using NetworkTracker.Core.Enums;
using NetworkTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class NetWorthRepository : INetWorthRepository
{
    public List<NetWorth> NetWorths = new List<NetWorth>();
    public NetWorthRepository()
    {
        createMock();
    }

    public void DeleteNetWorth(int netWorthId)
    {
        throw new System.NotImplementedException();
    }

    public NetWorth GetNetWorthById(int netWorthId)
    {
        return NetWorths.SingleOrDefault(x => x.Id == netWorthId);
    }

    public void InsertNetworth(NetWorth netWorth)
    {
        if (netWorth != null)
        {
            NetWorths.Add(netWorth);
        }
    }

    public void UpdateNetWorth(NetWorth netWorth)
    {
        var netWorthItem = NetWorths.SingleOrDefault(x => x.Id == netWorth.Id);
        if (netWorthItem != null)
        {
            netWorthItem.Assets = netWorth.Assets;
            netWorthItem.Liabilities = netWorth.Liabilities;
            var assetSums = netWorth.Assets.Sum(x => x.Amount);
            var liabilitySums = netWorth.Liabilities.Sum(x => x.Amount);
            netWorthItem.TotalAssetsAmount = assetSums;
            netWorthItem.TotalLiabilitiesAmount = liabilitySums;
            netWorthItem.NetWorthAmount = assetSums - liabilitySums;
        }
    }

    public void createMock()
    {
        var netWorth = new NetWorth();
        netWorth.Liabilities = new List<Liability>()
        { new Liability { Type = LiabilityType.LongTermDebt, Id = Guid.NewGuid(), Amount = 250999.00, Label = "Mortage 1", NetworthType = "Liability"  },
          new Liability { Type = LiabilityType.LongTermDebt, Id = Guid.NewGuid(), Amount = 632251.00, Label = "Mortage 2", NetworthType = "Liability"  },
          new Liability { Type = LiabilityType.LongTermDebt, Id = Guid.NewGuid(), Amount = 520000.00, Label = "Line of Credit", NetworthType = "Liability"   },
          new Liability { Type = LiabilityType.ShortTermLiability, Id = Guid.NewGuid(), Amount = 2000.00, Label = "Credit Card 1", NetworthType = "Liability"   },
          new Liability { Type = LiabilityType.ShortTermLiability, Id = Guid.NewGuid(), Amount = 2000.00, Label = "Credit Card 1", NetworthType = "Liability"   }
        };
        netWorth.Assets = new List<Asset>()
        {
          new Asset { Type = AssetType.CashAndInvestments, Id = Guid.NewGuid(), Amount = 360000.00, Label = "Investment 1", NetworthType = "Asset" },
          new Asset { Type = AssetType.CashAndInvestments, Id = Guid.NewGuid(), Amount = 1360000.00, Label = "Investment 1", NetworthType = "Asset" },
          new Asset { Type = AssetType.LongTermAssets, Id = Guid.NewGuid(), Amount = 520024.00, Label = "Stuff", NetworthType = "Asset" },
        };



        netWorth.Id = 0;
        netWorth.TotalLiabilitiesAmount = netWorth.Liabilities.Sum(x => x.Amount);
        netWorth.TotalAssetsAmount = netWorth.Assets.Sum(x => x.Amount);
        netWorth.NetWorthAmount = netWorth.TotalAssetsAmount - netWorth.TotalLiabilitiesAmount;
        NetWorths.Add(netWorth);
    }
}