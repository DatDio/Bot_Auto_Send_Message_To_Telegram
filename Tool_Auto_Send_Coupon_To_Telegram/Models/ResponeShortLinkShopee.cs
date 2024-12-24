using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Auto_Send_Coupon_To_Telegram.Models
{
    public class ResponeShortLinkShopee
    {
        public Data data { get; set; }
    }
    public class BatchCustomLink
    {
        public string shortLink { get; set; }
        public string longLink { get; set; }
        public int failCode { get; set; }
    }

    public class Data
    {
        public List<BatchCustomLink> batchCustomLink { get; set; }
    }
}
