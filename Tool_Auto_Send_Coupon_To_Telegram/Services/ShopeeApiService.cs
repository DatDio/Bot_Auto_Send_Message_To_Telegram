using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Tool_Auto_Send_Coupon_To_Telegram.Models;

namespace Tool_Auto_Send_Coupon_To_Telegram.Services
{
    public static class ShopeeApiService
    {
        public static async Task<List<string>> GetShortLink(List<string> shortLinks)
        {
            ResponeShortLinkShopee responeShortLinkShopee = new ResponeShortLinkShopee();
            var options = new RestClientOptions("https://affiliate.shopee.vn")
            {
                MaxTimeout = -1,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36",
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/v3/gql", Method.Post);
            request.AddHeader("accept", "application/json, text/plain, */*");
            request.AddHeader("accept-language", "vi-VN,vi;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5");
        
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("x-sap-ri", "3c4f6567375d40c056a2eb33030143081280363dccd06b96b30b");
            request.AddHeader("x-sap-sec", "5KVGBjlw4wQbJwQbI2QzJwIbI2QbJwIbJwQwJwQbowIbJlDxJwRwJpQbIwQbJyAIYInzJwQbvwKbJiDxJwc/vajw0mFoiDbBKTWf1RN9fFUoHC1qc+wbwBYQ/dLWezepj+wjza2hG3o6QNTf4dHJpsmq4X6ZOHS84LQzwGggy8SAm/gaXJIo2BJPggK2Sb9b747qeqnl8tV9TpI+3sQzeaFph++EK3cfRopTXddYLiatYNnPFswmJsOSrsjg9EgtmLAcO2gNJyp5npI2/qDQc0NMXcicklI817EJGRSAYz26qaNha1ZHZjNFG4FVrIyXiHQecQmDmWnGvBcnCKr1IEe+UeBkJdp53hn1Zdcstb++GwP+fkHrd5ctXKe6FuE2Dn/7iJbtcxu4pnGqFZYmKTAJHyTjtSwoIaXQtDT/9aMnxg0sDIucGa9PcdllbqmikTQkTggrkFfBopu+zpUxQ2BBRY/2NcjgKxqRA362ieAo732D/UNiwzskertZvC2dSNdXrMBfAn2tgOF6M78OcFvbNUXvtFOjwQcJmThSowDVfCnU1euPLZnUjZz0wUR6jxbD6oqYQ6+E/QXAvZh1M+n5splppqaegycLaoO6vzS8fFpeey8diSfCCc+xk0bqmOlhlsKhM30vO+w2tdG1ZIhkUifcG0TJOCKFgMARWMQHMwmaKinrAOiZI4R+Wb2vHwRAr9kghvkkbuawbA5KuXStMmFnr70yxYBqIsdyj+8PFBdnwGkOfRwwK//daq0McFzIrn0iPPzAwpXoDLEKsR1ovF+wE1YlVIytJYglLod/HzSVrQTfIPlI4iH+2pSRJDLrQpgy33+9G9LxAVF4XFuarcmp1JRXG9dKhZSwMIqd0CCbMzHOcGEFplmbfU88vp+izG4TAiRtHP6I+j2CIItq9k3tculNdUc4Ub7aBM79/UT/CyDWDyeWNfBHxQnM9j00jCX7I9BRB77trJy2mZ9Ble5kGCRt+Gr1YDKXtZ21885g0DdlCrM2VxOkk0y+W5GIABrMg3OJJfH5oeOC+MW53gYD93bAhQhtbO71xFbkPyw72xx67qtZ8OLvW2L+0OuIb+7TTEIkvn4SLuL86HQjW0sAHw5wgWleu/J+yBwPyOTdH5ilfROEzGrjkZrggDa8BHrCEC44EDu3i51CYd37Xr873hYHT3lknznyx57CT8QR/vFukAnPyMhJN6G2vdysIw5y19d7g5xRC8JBOr4mMFASesngZ24BC3klkO2SZtpalwnkIyGsMbDzgt52YklpOe8whQZVSiFH3KGMQCke57U3oJ9/OOWzJwQbhnl5hKlE/KsbJwQbXluOYplbJwQXJwQbOwQbJjfQblxJHcPyHDcDoSeBugkTIG9l5wQbJCM7hsBSpZeLJwQbJzAOYInzJwQbkwQbJYIbJwR8O1Zhm50hd2SUsI5wwgRBPxkJiulbJwc2/n/4sUP0spQbJwQzJwDb5wQwJwlbJwQzJwQbkwQbJYIbJwcZSBZEuy/1PXEtM6iQob887nd5SwlbJwQEssc2hCL/3pQbJwQ=");
            request.AddHeader("x-sz-sdk-version", "1.10.15");
            //			var body = @"{
            //" + "\n" +
            //			@"    ""operationName"": ""batchGetCustomLink"",
            //" + "\n" +
            //			@"    ""query"": ""\n    query batchGetCustomLink($linkParams: [CustomLinkParam!], $sourceCaller: SourceCaller){\n      batchCustomLink(linkParams: $linkParams, sourceCaller: $sourceCaller){\n        shortLink\n        longLink\n        failCode\n      }\n    }\n    "",
            //" + "\n" +
            //			@"    ""variables"": {
            //" + "\n" +
            //			@"        ""linkParams"": [
            //" + "\n" +
            //			@"            {
            //" + "\n" +
            //			@"                ""originalLink"": ""https://s.shopee.vn/8pVTkDuk53"",
            //" + "\n" +
            //			@"                ""advancedLinkParams"": {}
            //" + "\n" +
            //			@"            },
            //" + "\n" +
            //			@"            {
            //" + "\n" +
            //			@"                ""originalLink"": ""https://s.shopee.vn/8zotwWu6k6"",
            //" + "\n" +
            //			@"                ""advancedLinkParams"": {}
            //" + "\n" +
            //			@"            }
            //" + "\n" +
            //			@"        ],
            //" + "\n" +
            //			@"        ""sourceCaller"": ""CUSTOM_LINK_CALLER""
            //" + "\n" +
            //			@"    }
            //" + "\n" +
            //			@"}";
            var listLinkParam = new List<LinkParam>();
            foreach (var shortLink in shortLinks)
            {
                listLinkParam.Add(new LinkParam
                {
                    originalLink = shortLink,
                    advancedLinkParams = new AdvancedLinkParams()
                });
            }

            var body = new PayLoadGetShortLinkShopee()
            {
                operationName = "batchGetCustomLink",
                query = "\n    query batchGetCustomLink($linkParams: [CustomLinkParam!], $sourceCaller: SourceCaller){\n      batchCustomLink(linkParams: $linkParams, sourceCaller: $sourceCaller){\n        shortLink\n        longLink\n        failCode\n      }\n    }\n    ",
                variables = new Variables()
                {
                    linkParams = listLinkParam,
                    sourceCaller = "CUSTOM_LINK_CALLER"
                }
            };
            var bodyString = JsonConvert.SerializeObject(body);
            request.AddParameter("application/json", bodyString, ParameterType.RequestBody);
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    RestResponse response = await client.ExecuteAsync(request);
                    responeShortLinkShopee = JsonConvert.DeserializeObject<ResponeShortLinkShopee>(response.Content.ToString());
                    break;
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }


            var myShortLink = new List<string>();
            foreach (var batchCustomLink in responeShortLinkShopee.data.batchCustomLink)
            {
                myShortLink.Add(batchCustomLink.shortLink);
            }
            return myShortLink;

        }
    }
}
