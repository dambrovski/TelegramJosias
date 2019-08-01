using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramJosias
{
    class Program
    {


        private static TelegramBotClient Bot = new TelegramBotClient("756360761:AAE5Za8z7XkFbwKtPJRE3UkVHNchTSiClFQ");
        static void Main(string[] args)
        {

           
            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();

        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)

                try
                {

                    StreamWriter mensagem = new StreamWriter("D:\\conversas\\" + e.Message.Chat.Username + ".txt", true, Encoding.ASCII);
                    mensagem.Write(("[") + e.Message.Chat.Id + e.Message.Date + ("] ") + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ": " + e.Message.Text + "\r\n");
                    


                    mensagem.Close();
                }
                catch (Exception)
                {

                    throw;
                }

            Console.WriteLine(e.Message.Text);

        }
    }
}
