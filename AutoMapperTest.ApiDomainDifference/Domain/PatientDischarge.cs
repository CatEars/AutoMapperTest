using System;

namespace AutoMapperTest.ApiDomainDifference.Domain
{
    public record PatientDischarge(Patient Patient, DateTime DischargedAtUtc);

}