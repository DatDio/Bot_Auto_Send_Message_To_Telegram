using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using Tool_Auto_Send_Coupon_To_Telegram.Helpers;
using WTelegram;

namespace Tool_Auto_Send_Coupon_To_Telegram.Services
{
    public static class TelegramUpdateService
    {
        static WTelegram.Client Client;
        static UpdateManager Manager;
        static Config config;
        static User My;
        static string apiId = ""; // Thay bằng api_id của bạn
        static string apiHash = ""; // Thay bằng api_hash của bạn
        static string phoneNumber = ""; // Số điện thoại đăng ký
        static string SourceChannel = "nhommoisanmagiamgiashopeelazada"; // Username của kênh nguồn
        static string DestinationChannel = "chanelmagiamgiavadeal"; // Username của kênh đích
        static string DestinationGroup = "groupmagiamgiavadealsoc"; // Username của kênh đích

        public static async Task ExecuteSendTele()
        {

            try
            {
                await CreateAndConnect();
                Console.ReadKey();
            }
            finally
            {
                if (Client != null) await Client.DisposeAsync();
            }
        }
        private static async Task CreateAndConnect()
        {
            // Đường dẫn session tùy chỉnh (nếu cần)
            string sessionPathFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sessions");
            Directory.CreateDirectory(sessionPathFolder);
            Environment.SetEnvironmentVariable("WTELEGRAM_SESSION", Path.Combine(sessionPathFolder, "WTelegram.session"));
            var sessionPath = Path.GetFullPath(Path.Combine(sessionPathFolder, "WTelegram.session"));
            // Khởi tạo WTelegram.Client với lambda cho cấu hình
            Client = new WTelegram.Client(configKey =>
            {
                return configKey switch
                {
                    "api_id" => apiId,
                    "api_hash" => apiHash,
                    "phone_number" => phoneNumber,
                    "session_pathname" => sessionPath,
                    _ => null
                };
            });
            await using (Client)
            {
                Manager = Client.WithUpdateManager(OnUpdate);
                Client.OnOther += Client_OnOther;
                My = await Client.LoginUserIfNeeded();
                Console.WriteLine($"On Update From {SourceChannel}");
                while (true)
                {
                    await Task.Delay(1000); 
                }
            }
        }


        private static async Task OnUpdate(Update update)
        {
            switch (update)
            {
                case UpdateNewChannelMessage { message: Message message } newMessage:
                    // Kiểm tra nếu message là Message và lấy thông tin peer_id
                    if (message.peer_id is PeerChannel { channel_id: var channelId } &&
                        Manager.Chats.TryGetValue(channelId, out var chat) && chat.MainUsername == SourceChannel)
                    {

                        var editedMessage = await EditMessageContent(message.message);
                        Console.WriteLine($"Đã gửi tin nhắn {editedMessage} lúc {DateTime.Now.ToString()}");
                        await SendEditedMessageToDestination(editedMessage, message);
                        await SendEditedMessageToDestinationGroup(editedMessage, message);
                        Console.WriteLine($"Đang đợi new massage ...");
                    }
                    break;
            }
        }

        private static async Task Client_OnOther(IObject arg)
        {
            if (arg is ReactorError err)
            {
                // typically: network connection was totally lost
                Console.WriteLine($"Fatal reactor error: {err.Exception.Message}");
                while (true)
                {
                    Console.WriteLine("Disposing the client and trying to reconnect in 5 seconds...");
                    if (Client != null) await Client.DisposeAsync();
                    Client = null;
                    await Task.Delay(5000);
                    try
                    {
                        await CreateAndConnect();
                        break;
                    }
                    catch (Exception ex) when (ex is not ObjectDisposedException)
                    {
                        Console.WriteLine("Connection still failing: " + ex.Message);
                    }
                }
            }
            else
                Console.WriteLine("Other: " + arg.GetType().Name);
        }

        private static async Task<string> EditMessageContent(string originalMessage)
        {
            string editedMessage = "";
            // Chỉnh sửa nội dung tin nhắn tại đây
            var listShortLinks = FunctionHelper.ExtractShopeeUrls(originalMessage);
            if (listShortLinks.Count > 0)
            {
                var myShortLinks = await ShopeeApiService.GetShortLink(listShortLinks);
                if (myShortLinks.Count == 0)
                {
                    return "";
                }
                editedMessage = FunctionHelper.ReplaceToMyShortLink(originalMessage, myShortLinks);
                if (!String.IsNullOrEmpty(editedMessage))
                {
                    return editedMessage;
                }
            }

            return originalMessage;
        }

        private static async Task SendEditedMessageToDestination(string editedMessage, Message sourceMessage)
        {
            try
            {
                // Lấy thông tin peer của kênh đích
                var peer = await Client.Contacts_ResolveUsername(DestinationChannel);

                // Tạo random_id
                var randomId = DateTime.UtcNow.Ticks;

                // Nếu tin nhắn có media, gửi kèm media
                if (sourceMessage.media != null)
                {
                    var inputMedia = sourceMessage.media.ToInputMedia(); // Chuyển đổi media
                    await Client.Messages_SendMedia(peer, inputMedia, message: editedMessage, randomId, entities: sourceMessage.entities);

                }
                else
                {
                    // Nếu không có media, chỉ gửi nội dung văn bản
                    await Client.Messages_SendMessage(peer, editedMessage, randomId, entities: sourceMessage.entities);

                }
            }
            catch
            {

            }
        }

        private static async Task SendEditedMessageToDestinationGroup(string editedMessage, Message sourceMessage)
        {
            try
            {
                // Lấy thông tin peer của kênh đích
                var peer = await Client.Contacts_ResolveUsername(DestinationGroup);

                // Tạo random_id
                var randomId = DateTime.UtcNow.Ticks;

                // Nếu tin nhắn có media, gửi kèm media
                if (sourceMessage.media != null)
                {
                    var inputMedia = sourceMessage.media.ToInputMedia(); // Chuyển đổi media
                    await Client.Messages_SendMedia(peer, inputMedia, message: editedMessage, randomId, entities: sourceMessage.entities);

                }
                else
                {
                    // Nếu không có media, chỉ gửi nội dung văn bản
                    await Client.Messages_SendMessage(peer, editedMessage, randomId, entities: sourceMessage.entities);

                }
            }
            catch
            {

            }
        }







    }
}
