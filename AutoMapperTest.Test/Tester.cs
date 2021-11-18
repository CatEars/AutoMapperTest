using System;
using AutoMapperTest.Dto.ClassicConfig;
using AutoMapperTest.Dto.Interfaces;
using Xunit;

namespace AutoMapperTest.Test
{
    public class Tester
    {

        private IDtoConvert Convert { get; } = new ClassicConvert()
            .WithHospital(SampleCases.Case1.Hospital)
            .WithEvents(SampleCases.Case1.Events);

        [Fact]
        public void TestCanConvertHospitalName()
        {
            var hospital = Convert.GetHospital();
            Assert.Equal(SampleCases.Case1.Hospital.Name, hospital.Name);
        }

        [Fact]
        public void TestPatient123IsStillInHospital()
        {
            var patient = Convert.GetPatient("123");
            Assert.NotNull(patient.StayingInRoom);
            Assert.Equal("2 - Room #2", patient.StayingInRoom.Name);
        }

        [Fact]
        public void TestPatient789IsNotInHospital()
        {
            var patient = Convert.GetPatient("789");
            Assert.Null(patient.StayingInRoom);
        }

        [Fact]
        public void TestPatient789WasInHospitalFourHoursAgo()
        {
            var patient = Convert.GetPatient("789");
            var earlier = SampleCases.Now.AddHours(-4);
            Assert.NotNull(patient.LastHospitalAdmittance);
            Assert.Equal(earlier, patient.LastHospitalAdmittance);
        }

        [Fact]
        public void TestPatient789IsDischargedInOneHour()
        {
            var patient = Convert.GetPatient("789");
            var then = SampleCases.Now.AddHours(1);
            Assert.NotNull(patient.LastHospitalDischarge);
            Assert.Equal(then, patient.LastHospitalDischarge);
        }

        [Fact]
        public void TestPatient1212IsInRoom45()
        {
            
        }
    }
}