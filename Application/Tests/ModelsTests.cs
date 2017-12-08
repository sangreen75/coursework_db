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
        private const string pattern = "dd.MM.yyyy HH:mm:ss";
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

        [Test]
        public void CorrectManagerCanWorkFunction()
        {
            var startTimeWork = GetTime("20.11.2009 13:00:00", pattern);
            var endTimeWork = GetTime("20.11.2009 13:45:00", pattern);
            var manager = new Manager(1, new CallCenter(3), 3, 3, startTimeWork, endTimeWork, 1500);
            var correctTime = GetTime("20.11.2009 13:45:00", pattern);
            var incorrectTime = GetTime("20.11.2009 12:59:59", pattern);
            Assert.IsTrue(manager.CanWork(correctTime));
            Assert.IsFalse(manager.CanWork(incorrectTime));
            Assert.IsFalse(manager.CanWork(incorrectTime + TimeSpan.FromHours(2)));
        }

        [Test]
        public void CorrectRegisterCallManager()
        {
            var startWorkTime = GetTime("01.01.2007 09:00:00", pattern);
            var endWorkTime = GetTime("01.01.2007 19:00:00", pattern);
            var manager = new Manager(0, new CallCenter(0), 3, 3, startWorkTime, endWorkTime, 1500);
            Action incorrectMove = () => manager.RegisterCall(null, startWorkTime, endWorkTime);
            incorrectMove.ShouldThrow<ArgumentNullException>();
            Assert.IsNull(manager.RegisterCall(new Client(0, 0, ""), startWorkTime, endWorkTime + TimeSpan.FromMinutes(1)));
        }

        private DateTime GetTime(string dateTime, string pattern) => DateTime.ParseExact(dateTime, pattern, CultureInfo.InvariantCulture);
    }
}
