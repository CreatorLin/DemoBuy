using DemoBuy.Models;
using DemoBuy.Seller;
using DemoBuy.Seller.Pchome;
using DemoBuy.Seller.Tkec;
using DemoBuy.Seller.Yahoo;
using System;
using System.Linq;

namespace DemoBuy.Services
{
    static public class SellerService
    {
        static public ProductApiModel[] GetProduct(Shop key)
        {
            switch (key)
            {
                case Shop.Pchome:
                    return GetPchome();
                case Shop.Tkec:
                    return GetTkec();
                case Shop.Yahoo:
                default:
                    return GetYahoo();
            }
        }
        
        static private ProductApiModel[] GetPchome()
        {
            try
            {
                return PchomeSeller.Data.Nodes.Select(p => new ProductApiModel()
                {
                    Name = p.Link.Text1,
                    Img = p.Img.Src,
                    Link = p.Link.Url,
                    Descriptions = new[] { p.Link.Text },
                    BargainPrice = p.Link.Text2,
                    ExpTime = p.ExtraData.Time
                }).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        static private ProductApiModel[] GetYahoo()
        {
            try
            {
                return YahooSeller.Data.Select(p => new ProductApiModel()
                {
                    Name = p.NameTitle,
                    Img = p.Img,
                    ImgTitle = p.Alt,
                    Descriptions = new[] { p.DescTitle }.Concat(p.DescList).ToArray(),
                    Link = p.Href,
                    OriginolPrice = p.SrPrice,
                    BargainPrice = p.SpPrice,
                    //ExpTime = ""
                }).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        static private ProductApiModel[] GetTkec()
        {
            try
            {
                return TkecSeller.Data.Select(p => new ProductApiModel()
                {
                    Name = p.Text01,
                    Descriptions = new[] { p.Text02 },
                    Link = p.Href,
                    Img = p.Img,
                    OriginolPrice = p.PnPrice,
                    BargainPrice = p.Price,
                    //ExpTime = ""
                }).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}