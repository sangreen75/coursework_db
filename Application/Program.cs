﻿using Application.DataModel;
using Application.DataModel.InputData;
using Application.DataModel.ResultData;
using Application.Parsers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    //newline
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<CallCenter> collection = new List<CallCenter>();
            using (var dbContext = new CallsContext())
            {
                collection = dbContext.CallCenters.ToArray();
            }

        }
    }
}
