using System.Linq;

namespace Payment.Configuration
{
    internal class Common
    {
        public static int GetInt(System.Configuration.Configuration config, string key)
        {
            string value = GetKey(config, key);
            int re = 0;
            int.TryParse(value, out re);
            return re;
        }

        public static string GetKey(System.Configuration.Configuration config, string key)
        {
            var fkey = config.AppSettings.Settings.AllKeys.Where(p => p == key);
            if (fkey == null)
                return "";
            return config.AppSettings.Settings[key].Value;
        }
    }
}
