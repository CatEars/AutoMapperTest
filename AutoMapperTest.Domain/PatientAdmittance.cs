using System;

namespace AutoMapperTest.Domain
{
    public record PatientAdmittance(Patient Patient, DateTime AdmittedAtUtc, Room RoomAdmittedInto);
}