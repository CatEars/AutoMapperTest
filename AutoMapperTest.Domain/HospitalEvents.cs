using System.Collections.Immutable;

namespace AutoMapperTest.Domain
{
    public record HospitalEvents(
        ImmutableList<PatientAdmittance> Admittances,
        ImmutableList<PatientDischarge> Discharges,
        ImmutableList<RoomTransfer> Transfers)
    {
        public static HospitalEvents Empty => new (
                ImmutableList<PatientAdmittance>.Empty, 
                ImmutableList<PatientDischarge>.Empty, 
                ImmutableList<RoomTransfer>.Empty
            );
    }
}