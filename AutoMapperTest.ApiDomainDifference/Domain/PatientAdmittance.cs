using System;

namespace AutoMapperTest.ApiDomainDifference.Domain
{
    public record PatientAdmittance(Patient Patient, DateTime AdmittedAtUtc, Room RoomAdmittedInto);
}