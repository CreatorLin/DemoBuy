using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBuy.Models
{
    /// <summary>
    /// 商品
    /// </summary>
    public class ProductApiModel
    {
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string[] Descriptions { get; set; }

        /// <summary>
        /// 圖片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 圖片標題
        /// </summary>
        public string ImgTitle { get; set; }

        /// <summary>
        /// 連結
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 原價
        /// </summary>
        public string OriginolPrice { get; set; }

        /// <summary>
        /// 售價
        /// </summary>
        public string BargainPrice { get; set; }

        /// <summary>
        /// 到期時間
        /// </summary>
        public string ExpTime { get; set; }
    }
}