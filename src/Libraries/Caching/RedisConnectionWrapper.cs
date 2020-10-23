using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Caching
{
    public class RedisConnectionWrapper : IRedisConnectionWrapper, ILocker
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void FlushDatabase(RedisDatabaseNumber db)
        {
            throw new NotImplementedException();
        }

        public IDatabase GetDatabase(int db)
        {
            throw new NotImplementedException();
        }

        public EndPoint[] GetEndPoints()
        {
            throw new NotImplementedException();
        }

        public IServer GetServer(EndPoint endPoint)
        {
            throw new NotImplementedException();
        }

        public bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action)
        {
            throw new NotImplementedException();
        }
    }
}
