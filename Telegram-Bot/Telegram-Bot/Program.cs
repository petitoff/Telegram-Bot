using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace Telegram_Bot
{
    class Program
    {
        private const string TelegramApiKey = "1928613200:AAELeeDAwNrvDDerW-_QB1XicezSGQD85Rc";

        private static readonly TelegramBotClient BotClient = new TelegramBotClient(TelegramApiKey);
        public static string AdminId = "1181399908";

        static void Main(string[] args)
        {
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage,
                }
            };


            BotClient.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions);
            SendMessageMethod();


            Console.ReadLine();
        }

        static async Task SendMessageMethod()
        {
            await BotClient.SendTextMessageAsync(
                chatId: AdminId,
                text: "I'm running!");
        }

        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private static async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            if (update.Type == UpdateType.Message)
            {
                if (update.Message.Type == MessageType.Text)
                {
                    Console.WriteLine(update.Message.Chat.Id);
                }
            }
        }
    }
}
