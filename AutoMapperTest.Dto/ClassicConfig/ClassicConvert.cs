using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapperTest.Domain;
using AutoMapperTest.Dto.Interfaces;

namespace AutoMapperTest.Dto.ClassicConfig
{
    public class ClassicConvert : IDtoConvert
    {
        private Hospital? _hospital;

        private HospitalEvents _events = HospitalEvents.Empty;
        
        public IDtoConvert WithHospital(Hospital hospital)
        {
            _hospital = hospital;
            return this;
        }

        public IDtoConvert WithEvents(HospitalEvents events)
        {
            _events = events;
            return this;
        }

        private bool NoDischargesAfter(Patient patient, DateTime time)
        {
            return _events.Discharges
                .Where(x => x.Patient.PatientId == patient.PatientId)
                .All(x => x.DischargedAtUtc < time);
        }

        private RoomDto ConvertRoom(Room room)
        {
            return new RoomDto()
            {
                Name = $"{room.Floor} - {room.Name}"
            };
        }
        
        public HospitalDto GetHospital()
        {
            if (_hospital == null)
            {
                throw new Exception("No hospital");
            }

            var hospital = new HospitalDto();
            hospital.Name = _hospital.Name;
            hospital.Rooms = _hospital
                .Rooms
                .Select(ConvertRoom)
                .ToList();

            var admittedPatients = _events
                .Admittances
                .Where(x => NoDischargesAfter(x.Patient, x.AdmittedAtUtc))
                .Select(x => x.Patient);

            hospital.CurrentlyAdmittedPatients = admittedPatients
                .Select(x => GetPatient(x.PatientId))
                .ToList();

            return hospital;
        }

        private DateTime? LatestDate(IEnumerable<DateTime> times) =>
            times.Any() ? times.Aggregate((lhs, rhs) => lhs < rhs ? rhs : lhs) : null;
        
        public PatientDto GetPatient(string patientId)
        {
            if (_hospital == null)
            {
                throw new Exception("No hospital");
            }

            var patient = new PatientDto()
            {
                PatientId = patientId
            };

            var admittances = _events
                .Admittances
                .Where(x => x.Patient.PatientId == patientId)
                .Select(x => x.AdmittedAtUtc);
            var discharges = _events
                .Discharges
                .Where(x => x.Patient.PatientId == patientId)
                .Select(x => x.DischargedAtUtc);
            var lastAdmittance = LatestDate(admittances);
            var lastDischarge = LatestDate(discharges);
            patient.LastHospitalAdmittance = lastAdmittance;
            patient.LastHospitalDischarge = lastDischarge;

            if (lastAdmittance != null && (lastDischarge == null || lastDischarge < lastAdmittance))
            {
                // Patient is in hospital as they have not yet been discharged for their latest admittance.
                // The patient must be staying in a room.
                // Patient is in the room with the last event of [admittance, transfer]
                var transfers = _events
                    .Transfers
                    .Where(x => x.Patient.PatientId == patientId)
                    .Select(x => x.TransferOccuredAt);
                var lastTransfer = LatestDate(transfers);
                if (lastTransfer != null && lastAdmittance < lastTransfer)
                {
                    patient.StayingInRoom = ConvertRoom(
                        _events
                            .Transfers
                            .First(x => x.Patient.PatientId == patientId && x.TransferOccuredAt == lastTransfer)
                            .RoomTransferedTo
                    );
                }
                else
                {
                    patient.StayingInRoom = ConvertRoom(
                        _events
                            .Admittances
                            .First(x => x.Patient.PatientId == patientId && x.AdmittedAtUtc == lastAdmittance)
                            .RoomAdmittedInto
                    );
                }
            }

            return patient;
        }

    }
}