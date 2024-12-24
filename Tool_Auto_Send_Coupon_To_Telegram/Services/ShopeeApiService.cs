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
            request.AddHeader("af-ac-enc-dat", "251944b40007744f");
            request.AddHeader("af-ac-enc-sz-token", "R86N3rAYbZm2eKG4FwnGPw==|UK7n5w1jqWiqLPgnb6hRemCpEDo4rcLm2l8I0I+Ekhu/NiKrMDHySSQn37Or2Nsw9hMqEGkgIW8=|9/926nYGHuwc2YD9|08|3");
            request.AddHeader("affiliate-program-type", "1");
            request.AddHeader("content-type", "application/json; charset=UTF-8");
            request.AddHeader("cookie", "_fbp=fb.1.1636621368850.1057657494; _hjSessionUser_868286=eyJpZCI6IjRhNGI4YWFlLWNjYjAtNWViZi1iMzA2LTNiYjNmN2UzOTVmOSIsImNyZWF0ZWQiOjE2MzgyNTE0NTQ4MTMsImV4aXN0aW5nIjp0cnVlfQ==; _ga_M32T05RVZT=GS1.1.1702364912.331.1.1702364956.16.0.0; __zi=3000.SSZzejyD2zOackkldWi0aIREzU6G4qFDDCJgyz81LTr_rwszsGKHbdxKfR_SJn6LUvwiiTXD4PqvD3O.1; _ga_44R8KFLXBB=GS1.1.1712396945.2.1.1712396968.0.0.0; _ga_FV78QC1144=GS1.1.1715785147.7.0.1715785152.55.0.0; _ga_QLZF8ZGF0S=GS1.1.1721757271.1.1.1721757340.58.0.0; _QPWSDCXHZQA=19ebec1d-2b96-4b50-9697-679f588307b5; REC7iLP4Q=1514f04d-6680-4944-becc-b9803851edc4; _fbc=fb.1.1725468709029.IwY2xjawFFb2xleHRuA2FlbQIxMAABHf7283TkV70GrKA5-IC4EmtkHdAYyrvdKSrEmYWtBrcyXsAgaHvDcIeFaw_aem_bBedMC1-M_CtFs9TEPCzvg; _gcl_au=1.1.1720509177.1734164577; SPC_F=kFBhnmEdVgtujOqxbeUAtWjxUuIfaufR; REC_T_ID=a045bacb-b9f4-11ef-bc52-6afbb3430f2e; SPC_EC=.dVVoVFE4RkUySzVkUVZuU71cvTzw+4mD8DyyzoFSzqTUgH1hxCR2NyFLNOKCjdOg8miEnQhPh9eJWzguldzXkkwcDIIeomihrNYBxE1UefR97RzO1YaEokwS6CA/2QBMGL9Bv7z32PfqvTKoQCgGuG1xiWO7wNF1ifm+/LECjnW0oSlIWZzI9AjdqA8QG3W0psh34iUU9IZrkyLwgcN9oUM7DWCNGTK5+gm+01Rq8Par3uV31stQJrzIgBwkkYLb; SPC_ST=.dVVoVFE4RkUySzVkUVZuU71cvTzw+4mD8DyyzoFSzqTUgH1hxCR2NyFLNOKCjdOg8miEnQhPh9eJWzguldzXkkwcDIIeomihrNYBxE1UefR97RzO1YaEokwS6CA/2QBMGL9Bv7z32PfqvTKoQCgGuG1xiWO7wNF1ifm+/LECjnW0oSlIWZzI9AjdqA8QG3W0psh34iUU9IZrkyLwgcN9oUM7DWCNGTK5+gm+01Rq8Par3uV31stQJrzIgBwkkYLb; SPC_CLIENTID=a0ZCaG5tRWRWZ3R1cphfddkpgkkjinpr; SPC_U=887514957; SPC_T_ID=7FTxqebuRR6vDeTpmXw+rr/IsGDi0IKHEJt7OGA4IRj4vvszQ47h4Jk8vU5hlGNQmEFPn4JZzfyiuO9bUQVkQVehOK5VZ6zCCoGcuQx4RruL4GGD9ySeCPZQi/FyctrVCtDBpr9R4shlvfy0n6UeBffz2xqdqtyGyCfwWjsee5M=; SPC_T_IV=S0xLTzk3OXhLYXd5SGswcQ==; SPC_R_T_ID=7FTxqebuRR6vDeTpmXw+rr/IsGDi0IKHEJt7OGA4IRj4vvszQ47h4Jk8vU5hlGNQmEFPn4JZzfyiuO9bUQVkQVehOK5VZ6zCCoGcuQx4RruL4GGD9ySeCPZQi/FyctrVCtDBpr9R4shlvfy0n6UeBffz2xqdqtyGyCfwWjsee5M=; SPC_R_T_IV=S0xLTzk3OXhLYXd5SGswcQ==; _gcl_gs=2.1.k1$i1734436021$u212945110; _med=cpc; _gcl_aw=GCL.1734436029.CjwKCAiA34S7BhAtEiwACZzv4ZEi_CphrAPPKXQgnQQ1Ql807ni9WWT7Nu5BXmpLs85Svg_4a7KtZxoCEh4QAvD_BwE; _gac_UA-61914164-6=1.1734436030.CjwKCAiA34S7BhAtEiwACZzv4ZEi_CphrAPPKXQgnQQ1Ql807ni9WWT7Nu5BXmpLs85Svg_4a7KtZxoCEh4QAvD_BwE; _med=refer; _gid=GA1.2.10689783.1734692006; language=vi; _sapid=0c2e3023085ef345aab76da938aa270ec04079e5ae446af42981cb34; MYJ_MKTG_yosu7anwoc=JTdCJTdE; SPC_SI=+TxhZwAAAABLT0V5TFM0QXtHHgAAAAAASjRGQUJLcWE=; SPC_CDS_CHAT=13000447-83d6-4d0b-8f07-6d9d77e2c051; _hjSession_868286=eyJpZCI6ImI3OGM5ZTFkLTdkMDEtNDMyOS1hMDc1LTJhZGQxMTU5NzA5NiIsImMiOjE3MzQ2OTI0MTE5NDMsInMiOjAsInIiOjAsInNiIjowLCJzciI6MCwic2UiOjAsImZzIjowLCJzcCI6MH0=; AMP_TOKEN=%24NOT_FOUND; SPC_SC_SESSION=2e1fe80d76b0fabb6e81e4bb9641e03a_1_887514957; SPC_STK=A/2cR4UVyKrhsOxFLB++GPLPV+WJBzIPNv1ntLPa9l324n7EjhNBEBSXyg94D4BdrWOuvmJf0gMssOzg1UHAwCWnbsnVArqhV3nXAL9sJ8otXaENeOCbAJ6ZMTTYMY6neLvl4fTlVS39tv9WT+2XqL79swuIPJrXk846/RtsMmQ=; SC_DFP=fGIHdsDanwSvZDQKdJnwFFyVUkmbcRgF; _ga_3XVGTY3603=GS1.1.1734692508.17.1.1734692562.6.0.0; shopee_webUnique_ccd=%2Fd8lNtBQvaCwScX4mQRLkg%3D%3D%7CUa7n5w1jqWiqLPgnb6hRemCpEDo4rcLm2l8I0C0zmhu%2FNiKrMDHySSQn37Or2Nsw9hMqEGkgIW8%3D%7C9%2F926nYGHuwc2YD9%7C08%7C3; ds=32e9805974a507cbc74809933f9b088d; MYJ_yosu7anwoc=JTdCJTIyZGV2aWNlSWQlMjIlM0ElMjI4NzNhMjM5Ni0yNTM5LTQ2NDAtYjY2YS04MWI5MmJkZDY4ZDUlMjIlMkMlMjJ1c2VySWQlMjIlM0ElMjIlMjIlMkMlMjJwYXJlbnRJZCUyMiUzQSUyMiUyMiUyQyUyMnNlc3Npb25JZCUyMiUzQTE3MzQ2OTI0MDY2NDklMkMlMjJvcHRPdXQlMjIlM0FmYWxzZSUyQyUyMmxhc3RFdmVudFRpbWUlMjIlM0ExNzM0NjkyNDA3MjA1JTJDJTIybGFzdEV2ZW50SWQlMjIlM0EwJTdE; _ga=GA1.2.1490402714.1636621372; _dc_gtm_UA-61914164-6=1; _ga_4GPP1ZXG63=GS1.1.1734692006.397.1.1734692668.55.0.0");
            request.AddHeader("csrf-token", "SKpFbjBI-j4RQZG_ni8GjxgPIZyku8G_J7N0");
            request.AddHeader("origin", "https://affiliate.shopee.vn");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("referer", "https://affiliate.shopee.vn/offer/custom_link");
            request.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"131\", \"Chromium\";v=\"131\", \"Not_A Brand\";v=\"24\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
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
