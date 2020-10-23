using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Caching
{
    public interface IRedisConnectionWrapper : IDisposable
    {
        IDatabase GetDatabase(int db);

        IServer GetServer(EndPoint endPoint);

        EndPoint[] GetEndPoints();

        void FlushDatabase(RedisDatabaseNumber db);

    }
}
