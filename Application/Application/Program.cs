using Application.DataModel.InputData;
using Application.Parsers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            var result = GetClients().ToList();
            Console.WriteLine(result[1322]);
            Console.WriteLine(timer.ElapsedMilliseconds);
        }

        private static SortedSet<Client> GetClients()
        {
            var clientParser = new ClientPareser() { Pattern = Patterns.ClientLine };
            var clientTextLines = File.ReadLines(@"D:\CLOUD\OneDrive\coursework december 2017\clients.txt");
            return new SortedSet<Client>(clientParser.Parse(clientTextLines), new IncomeComparer());
        }

        private class IncomeComparer : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                return (x.Income - y.Income > 0) ? -1 : 1;
            }
        }
    }
}
