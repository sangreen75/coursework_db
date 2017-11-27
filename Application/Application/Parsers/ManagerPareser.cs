using Application.DataModel;
using Application.DataModel.InputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Parsers
{
    public class ManagerParser : IParser<Manager>
    {
        public string Pattern { get; set; }

        private Dictionary<int, CallCenter> idToCallCenter;

        public ManagerParser(Dictionary<int, CallCenter> idToCallCenter)
        {
            this.idToCallCenter = idToCallCenter ?? throw new ArgumentNullException("idToCallCenter");
        }

        public IEnumerable<Manager> Parse(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var parseLine = line.Split();
                if (!int.TryParse(parseLine[(int)ParseIndex.ID], out int id)) continue;
                if (!int.TryParse(parseLine[(int)ParseIndex.CallCenterID], out int callCenterId)) continue;
                if (!int.TryParse(parseLine[(int)ParseIndex.Class], out int qualification)) continue;
                if (!DateTime.TryParse(parseLine[(int)ParseIndex.StartWork], out DateTime startCall)) continue;
                if (!DateTime.TryParse(parseLine[(int)ParseIndex.EndWork], out DateTime endCall)) continue;
                if (!float.TryParse(parseLine[(int)ParseIndex.Class], out float efficiency)) continue;
                if (!int.TryParse(parseLine[(int)ParseIndex.Salary], out int salary)) continue;
                if (!idToCallCenter.ContainsKey(callCenterId)) continue;

                yield return new Manager(
                    id, 
                    idToCallCenter[callCenterId], 
                    qualification, 
                    efficiency, 
                    startCall, 
                    endCall, 
                    salary);
            }
        }

        private enum ParseIndex
        {
            ID,
            CallCenterID,
            Class,
            StartWork,
            EndWork,
            Efficiency,
            Salary
        }
    }

}
