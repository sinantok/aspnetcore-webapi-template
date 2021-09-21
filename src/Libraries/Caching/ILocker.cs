using System;

namespace Caching
{
    public interface ILocker
    {
        bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action);
    }
}
