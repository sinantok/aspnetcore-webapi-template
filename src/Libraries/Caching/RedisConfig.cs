using System;
using System.Collections.Generic;
using System.Text;

namespace Caching
{
    public class RedisConfig
    {
        public string RedisDataProtectionKey { get; set; }
        public int CacheTime { get; set; }
        public string RedisConnectionString { get; set; }
        public int? RedisDatabaseId { get; set; }
    }
}
