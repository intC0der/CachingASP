using System;
using System.Web.Caching;

namespace CacheTesting
{
    public class CacheModel
    {
        private static Cache _cache = null;
        private static Cache cache 
        {

            get {

                if (_cache == null)
                    _cache = (System.Web.HttpContext.Current == null) ? System.Web.HttpRuntime.Cache : System.Web.HttpContext.Current.Cache;

                return _cache;
            }
            set 
            {
                _cache = value;
            }


        }

        public static object Get(string key) 
        {
            return cache.Get(key);
        }

        public static void Add(string key, object value) 
        {
            //CacheItemPriority priority = CacheItemPriority.NotRemovable;
            //var expiration = TimeSpan.FromMinutes(10);
            cache.Insert(key, value);
        }

        public static void Remove(string key) 
        {
            cache.Remove(key);
        }



    }
}