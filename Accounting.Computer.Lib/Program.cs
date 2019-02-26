using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.Computer.Console;
using Accounting.Computer.Lib;
using Accounting.Computer.Lib.Models.Soft;
namespace Accounting.Computer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftWare softWare = new SoftWare();
            softWare.Price = 100;
            softWare.SoftwareTypes = Distribution.free;
            softWare.InstalDate = DateTime.Now;
            
            ServiceSoftware ss = new ServiceSoftware();
            ss.RegisterError(PrintMessage);
            ss.RegisterMessage(PrintMessage);
            ss.AddSoftware(softWare);
        }

        public static void PrintMessage(string str)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine(str);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        public static void PrintMessage(Exception ex)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(ex.Message);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        public static void SendNotification(SoftWare sw)
        {
            System.Console.WriteLine("Ты послал уведомления");
        }
    }
}
