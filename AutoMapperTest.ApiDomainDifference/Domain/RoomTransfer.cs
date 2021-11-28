using System;

namespace AutoMapperTest.ApiDomainDifference.Domain
{
    public record RoomTransfer(Patient Patient, DateTime TransferOccuredAt, Room RoomTransferedTo);
}