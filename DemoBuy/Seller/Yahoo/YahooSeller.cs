using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBuy.Seller.Yahoo
{
    static public class YahooSeller
    {
        static public IEnumerable<BestBuy> Data
        {
            get
            {
                const string URL = "https://tw.buy.yahoo.com/bestbuy";
                var node = new HtmlWeb().Load(URL).DocumentNode;

                var alt = GetAlt(node);
                var img = GetImg(node);
                var href = GetHref(node);
                var descTitle = GetDescTitle(node);
                var nameTitle = GetNameTitle(node);
                var descList = GetDescList(node);
                var srPrice = GetSrPrice(node);
                var spPrice = GetSpPrice(node);

                for (var i = 0; i < alt.Count(); i++)
                {
                    yield return new BestBuy()
                    {
                        Alt = alt?[i],
                        Img = img?[i],
                        Href = href?[i],
                        DescTitle = descTitle?[i],
                        NameTitle = nameTitle?[i],
                        DescList = descList?[i],
                        SrPrice = srPrice?[i],
                        SpPrice = spPrice[i]
                    };
                }
            }
        }

        static private string[] GetAlt(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//div[@class='yui3-u pd-img']/a/img")
                                .Select(p => p.Attributes["alt"].Value).ToArray();
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
                return node.SelectNodes(@"//div[@class='yui3-u pd-img']/a/img")
                                .Select(p => p.Attributes["_src"].Value ).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetHref(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//li[@class='desc title']/a")
                                    .Select(p => p.Attributes["href"].Value ).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetDescTitle(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//li[@class='desc title']/a")
                                    .Select(p => p.InnerText ).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetNameTitle(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//li[@class='name title']/a").Select(p => p.InnerText).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[][] GetDescList(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//div[@class='desc-list yui3-u yui3-g']/ul")
                                    .Select(p => p.ChildNodes.Where(c => c.Name == "li").Select(n => n.InnerText).ToArray()).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetSrPrice(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//span[@class='sr-price']").Select(p => p.InnerText).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private string[] GetSpPrice(HtmlNode node)
        {
            try
            {
                return node.SelectNodes(@"//div[@class='sp-price yui3-u']/a/span[@class='nums']").Select(p => p.InnerText).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}