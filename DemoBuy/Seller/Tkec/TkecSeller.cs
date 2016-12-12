using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoBuy.Seller.Tkec
{
    static public class TkecSeller
    {
        static public IEnumerable<OnTimeSale> Data
        {
            get
            {
                var url = "http://www.tkec.com.tw/ontimesale/index.aspx";
                var node = new HtmlWeb().Load(url).DocumentNode;

                var href = GetHref(node);
                var img = GetImg(node);
                var text01 = GetText01(node);
                var text02 = GetText02(node);
                var PnPrice = GetPnPrice(node);
                var price = GetPrice(node);

                for (var i = 0; i < href.Count(); i++)
                {
                    yield return new OnTimeSale()
                    {
                        Href = href[i],
                        Img = img[i],
                        Text01 = text01[i],
                        Text02 = text02[i],
                        PnPrice = PnPrice[i],
                        Price = price[i]
                    };
                }
            }
        }
        static private string[] GetHref(HtmlNode node)
        {
            try
            {
                const string URL = "http://www.tkec.com.tw/";
                return node.SelectNodes(@"//div[@class='item01_on']").Select(p => $"{URL}{p.ParentNode.Attributes["href"].Value.Substring(3)}").ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetImg(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//div[@class='Texbox']/img").Select(p => p.Attributes["src"].Value).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetText01(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//div[@class='text01_2 Texbox']").Select(p => p.InnerText).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetText02(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//div[@class='text02_2 Texbox']").Select(p => p.InnerText).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetPnPrice(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//div[@class='text03_2 Texbox']/span").Select(p => p.InnerText).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetPrice(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//div[@class='text04_2 Texbox']/span").Select(p => p.InnerText).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}