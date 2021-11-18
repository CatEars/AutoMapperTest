using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Mime;
using AutoMapperTest.Domain;

namespace AutoMapperTest.Test
{
    public static class SampleCases
    {

        public static DateTime Now = DateTime.Now;
        
        private static Room[] Rooms = Enumerable
            .Range(0, 100)
            .Select(x => new Room((1 % 3) + 1, $"Room #{x}"))
            .ToArray();

        private static PatientAdmittance Admitted(string patId, int addHours, int roomIdx)
        {
            return new PatientAdmittance(
                new Patient(patId),
                Now.AddHours(addHours),
                Rooms[roomIdx]
            );
        }

        private static PatientDischarge Discharge(string patId, int addHours)
        {
            return new PatientDischarge(
                new Patient(patId),
                Now.AddHours(addHours)
            );
        }

        private static RoomTransfer Transfer(string patId, int addHours, int roomIdx)
        {
            return new RoomTransfer(
                new Patient(patId),
                Now.AddHours(addHours),
                Rooms[roomIdx]
            );
        }
        
        private static HospitalEvents PatientJourneys(params object[] events)
        {
            var res = HospitalEvents.Empty;
            foreach (var evt in events)
            {
                if (evt is PatientAdmittance adm)
                {
                    res = res with { Admittances = res.Admittances.Add(adm) };
                }
                else if (evt is PatientDischarge dis)
                {
                    res = res with { Discharges = res.Discharges.Add(dis) };
                }
                else if (evt is RoomTransfer tra)
                {
                    res = res with { Transfers = res.Transfers.Add(tra) };
                }
            }
            return res;
        }

        public static (Hospital Hospital, HospitalEvents Events) Case1 = (
            new Hospital("Splattenburg Institute", Rooms.ToImmutableList()),
            PatientJourneys(
                // "123" is admitted, then discharged, then transferred to room 2
                Admitted("123", -13, 1),
                Discharge("123", -10),
                Admitted("123", -6, 1),
                Transfer("123", -5, 2),
            
                // "789" is admitted, then transferred, then discharged
                Admitted("789", -4, 50),
                Transfer("789", 0, 53),
                Discharge("789", 1),
                
                // "1212" is admitted, then transferred a few times, still in hospital
                Admitted("1212", 0, 41),
                Transfer("1212", 1, 42),
                Transfer("1212", 3, 43),
                Transfer("1212", 4, 44),
                Transfer("1212", 5, 45),
                
                // "8989" is admitted once only
                Admitted("8989", 14, 6),
                
                // "56" is admitted and then discharged
                Admitted("56", 15, 7),
                Discharge("56", 16)
            )
            );

    }
}