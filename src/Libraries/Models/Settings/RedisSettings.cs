using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Settings
{
    public class RedisSettings
    {
        public string RedisDataProtectionKey { get; set; }
        public int CacheTime { get; set; }
        public string RedisConnectionString { get; set; }
        public int? RedisDatabaseId { get; set; }
    }
}
