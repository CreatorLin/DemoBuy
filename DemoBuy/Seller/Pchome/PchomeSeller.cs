using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace DemoBuy.Seller.Pchome
{
    static public class PchomeSeller
    {
        static public Welcome Data {
            get
            {
                var onsaleUri = "http://24h.pchome.com.tw/onsale/v2";

                const string XPATH = @"//script";
                var path = new HtmlWeb().Load(onsaleUri).DocumentNode.SelectNodes(XPATH)
                                    .FirstOrDefault(p => p.Attributes["src"]?.Value.StartsWith("/cdnm") ?? false)
                                    .Attributes["src"].Value;

                var dataUri = $"http://24h.pchome.com.tw{path}";
                var dataStr = new WebClient().DownloadString(dataUri);

                const string PATTERN = "WelcomeJson = \\[(\\{.{1,9999999}\\})\\];[\b]*var";
                var json = Regex.Match(dataStr, PATTERN).Groups[1].Value;
                
                return JsonConvert.DeserializeObject<Welcome>(json);
            }
        }
    }
}