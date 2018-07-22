using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AksonBank());
            Console.ReadKey();
        }

        private static String AksonBank()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            String Response = wc.DownloadString("http://www.atbmarket.com/ru/hot/akcii/economy/");
            //id="conv0" value="(64.25)" 60</span>
            String Rate = System.Text.RegularExpressions.Regex.Match(Response, @"<div class=""promo_price"">([0-9]+)<span>([0-9]+)").Groups[1].Value;
            return "АТБ: " + Rate + " р. \r\n";
        }

        private static String RSBank()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            String Response = wc.DownloadString("http://www.rshb.ru/branches/saratov/");
            File.WriteAllText(@"C:\text.txt", Response);
            String Rate = System.Text.RegularExpressions.Regex.Match(Response, @"<td>([0-9]+\.[0-9]+)</td>").Groups[1].Value;
            return "Россельхозбанк: " + Rate + " р. \r\n";
        }
    }
}
