using Application.DataModel;
using Application.DataModel.InputData;
using Application.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Includer
    {
        public void Init()
        {
            using (var context = new CallsContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                ClearDataBase(context);
                CreateCallCenters(context);
                ParseAndInstertData(context);

                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
            }
        }

        private void ClearDataBase(CallsContext context)
        {
            context.Database.Delete();
        }

        private void CreateCallCenters(CallsContext context)
        {
            callCentersId = new Dictionary<int, CallCenter>(8);
            for (var i = 1; i < 9; i++)
                callCentersId[i] = new CallCenter(i);
            context.CallCenters.AddRange(callCentersId.Values);
        }

        private void ParseAndInstertData(CallsContext context)
        {
            foreach (var client in GetClients())
                context.Clients.Add(client);

            foreach (var manager in GetManagers())
                context.Managers.Add(manager);
        }

        private IEnumerable<Client> GetClients()
        {
            var clientParser = new ClientPareser() { Pattern = Patterns.ClientLine };
            var clientTextLines = File.ReadLines(@"D:\CLOUD\OneDrive\coursework december 2017\clients.txt", Encoding.GetEncoding(1251));
            return clientParser.Parse(clientTextLines);
        }

        private IEnumerable<Manager> GetManagers()
        {
            var managerParser = new ManagerParser(callCentersId);
            var lines = File.ReadLines(@"D:\CLOUD\OneDrive\coursework december 2017\managers.txt", Encoding.GetEncoding(1251)).ToArray();
            var result = managerParser.Parse(lines);
            return result;
        }

        private Dictionary<int, CallCenter> callCentersId;

        private class IncomeComparer : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                return (x.Income - y.Income > 0) ? -1 : 1;
            }
        }
    }
}
