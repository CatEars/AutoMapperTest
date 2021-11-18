using System;

namespace AutoMapperTest.Domain
{
    public record PatientDischarge(Patient Patient, DateTime DischargedAtUtc);

}