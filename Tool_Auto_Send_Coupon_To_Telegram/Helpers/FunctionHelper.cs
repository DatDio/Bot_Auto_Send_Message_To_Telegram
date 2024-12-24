using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tool_Auto_Send_Coupon_To_Telegram.Helpers
{
    public static class FunctionHelper
    {
        public static List<string> ExtractShopeeUrls(string inputText)
        {
            // Biểu thức chính quy để tìm các URL
            string pattern = @"https://s\.shopee\.vn/\S+";

            // Tìm tất cả các URL trong chuỗi
            MatchCollection matches = Regex.Matches(inputText, pattern);

            // Lưu các URL vào danh sách
            List<string> urls = new List<string>();
            foreach (Match match in matches)
            {
                urls.Add(match.Value);
            }

            return urls;
        }

        public static string ReplaceToMyShortLink(string inputText, List<string> myShortLinks)
        {
            // Biểu thức chính quy để tìm các URL
            string pattern = @"https://s\.shopee\.vn/\S+";

            // Tìm tất cả các URL trong chuỗi
            MatchCollection matches = Regex.Matches(inputText, pattern);
            try
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    inputText = inputText.Replace(matches[i].Value, myShortLinks[i]);
                }
            }
            catch
            {

            }

            return inputText;
        }
    }
}
