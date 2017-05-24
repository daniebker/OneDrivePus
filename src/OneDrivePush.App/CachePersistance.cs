using System.IO;
using Microsoft.Identity.Client;

namespace OneDrivePush
{
    internal class CachePersistence
    {
        private static readonly TokenCache UsertokenCache = new TokenCache();

        public static TokenCache GetUserCache()
        {
            lock (FileLock)
            {
                UsertokenCache.SetBeforeAccess(BeforeAccessNotification);
                UsertokenCache.SetAfterAccess(AfterAccessNotification);
                return UsertokenCache;
            }
        }

        public static string CacheFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location + "msalcache.txt";

        private static readonly object FileLock = new object();

        public static void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (FileLock)
            {
                args.TokenCache.Deserialize(File.Exists(CacheFilePath)
                    ? File.ReadAllBytes(CacheFilePath)
                    : null);
            }
        }

        public static void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if the access operation resulted in a cache update
            if (args.TokenCache.HasStateChanged)
            {
                lock (FileLock)
                {
                    // reflect changesgs in the persistent store
                    File.WriteAllBytes(CacheFilePath, args.TokenCache.Serialize());
                    // once the write operationtakes place restore the HasStateChanged bit to filse
                    args.TokenCache.HasStateChanged = false;
                }
            }
        }
    }
}