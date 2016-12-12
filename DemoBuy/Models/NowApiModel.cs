using DemoBuy.Seller;

namespace DemoBuy.Models
{
    /// <summary>
    /// 現有活動
    /// </summary>
    public class NowApiModel
    {
        public Shop Shop { get; set; }
        public ProductApiModel[] Products { get; set; }
    }
}