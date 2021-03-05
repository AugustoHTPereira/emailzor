using Emailzor.Core;
using System;

namespace Emailzor.Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var mailzor = new EmailService();
                mailzor
                    .SetDestinatary("augustohtp@outlook.com")
                    .SetHtml("<h1>HELLO WORLD</h1>")
                    .SetSubject("Hello world")
                    .SendAsync();

                Console.WriteLine("Email sended successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
