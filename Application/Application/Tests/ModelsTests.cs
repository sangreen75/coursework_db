using Application.DataModel.ResultData;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Application.DataModel;
using Application.DataModel.InputData;

namespace Application.Tests
{
    [TestFixture]
    public class ModelsTests
    {
        [Test]
        public void CallDistributorCorrectAdd()
        {
            var startCall = DateTime.ParseExact("20.11.2009 13:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            var endCall = DateTime.ParseExact("20.11.2009 13:45:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            var roundedEndCall = DateTime.ParseExact("20.11.2009 14:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            var ac = new AppointmentCall(new Client(12, 30000, string.Empty),new Manager(1,new CallCenter(), 2, 2, new DateTime(), new DateTime(), 100),
                new CallCenter(),startCall,endCall);
            var distribution = new CallCenterDistribution(ac);

            distribution.StartWork.ShouldBeEquivalentTo(startCall);
            distribution.EndWork.ShouldBeEquivalentTo(roundedEndCall);

            Assert.IsTrue(distribution.MediumSkillManagerCount == 1);
            Assert.IsTrue(distribution.LowSkillManagerCount == 0);
            Assert.IsTrue(distribution.HighSkillManagerCount == 0);
        }
    }
}
