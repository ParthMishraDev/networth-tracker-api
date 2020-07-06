using NetworkTracker.Core;
using System.Collections;

public interface INetWorthRepository
{
    NetWorth GetNetWorthById(int netWorthId);
    void InsertNetworth(NetWorth netWorth);
    void DeleteNetWorth(int netWorthId);
    void UpdateNetWorth(NetWorth netWorth);
}