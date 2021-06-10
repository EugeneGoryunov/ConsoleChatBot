using MihaZupan;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ConsoleChatBot
{
    class Program
    {
        private static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            var proxy = new HttpToSocks5Proxy("138.68.60.8", 1080);
            botClient = new TelegramBotClient("1763121512:AAGBkYE2NaWMILP16rz8jVDpYmipsoAVBuk", proxy) /*{ Timeout = TimeSpan.FromSeconds(1000) }*/;

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Bot id: {me.Id}. Bot name: {me.FirstName}");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.ReadKey();
        }

        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;

            if (text == null)
            {
                return;
            }

            Console.WriteLine($"recived text message '{text}' in chat '{e.Message.Chat.Id}'");

            await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Рома дурак"
                ).ConfigureAwait(false);
        }
    }
}
