using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Auto_Send_Coupon_To_Telegram.Models
{
    public class PayLoadGetShortLinkShopee
    {
        public string operationName { get; set; }
        public string query { get; set; }
        public Variables variables { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AdvancedLinkParams
    {
    }

    public class LinkParam
    {
        public string originalLink { get; set; }
        public AdvancedLinkParams advancedLinkParams { get; set; }
    }



    public class Variables
    {
        public List<LinkParam> linkParams { get; set; }
        public string sourceCaller { get; set; }
    }
}
