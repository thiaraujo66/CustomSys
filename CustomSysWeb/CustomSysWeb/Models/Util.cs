using System.Text.RegularExpressions;

namespace CustomSysWeb.Models
{
    public static class Util
    {
        public static string RemoveCaracteresEspeciais(string str)
        {
            return Regex.Replace(str, "[^0-9a-zA-Z]+", "");
        }
    }
}
