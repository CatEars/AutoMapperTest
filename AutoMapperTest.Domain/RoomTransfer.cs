using System;

namespace AutoMapperTest.Domain
{
    public record RoomTransfer(Patient Patient, DateTime TransferOccuredAt, Room RoomTransferedTo);
}