namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Mount;
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeStartOkMountWithOutPaddockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5991;
        public override ushort MessageID => ProtocolId;
        public List<MountClientData> StabledMountsDescription { get; set; }

        public ExchangeStartOkMountWithOutPaddockMessage(List<MountClientData> stabledMountsDescription)
        {
            StabledMountsDescription = stabledMountsDescription;
        }

        public ExchangeStartOkMountWithOutPaddockMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)StabledMountsDescription.Count);
            for (var stabledMountsDescriptionIndex = 0; stabledMountsDescriptionIndex < StabledMountsDescription.Count; stabledMountsDescriptionIndex++)
            {
                var objectToSend = StabledMountsDescription[stabledMountsDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var stabledMountsDescriptionCount = reader.ReadUShort();
            StabledMountsDescription = new List<MountClientData>();
            for (var stabledMountsDescriptionIndex = 0; stabledMountsDescriptionIndex < stabledMountsDescriptionCount; stabledMountsDescriptionIndex++)
            {
                var objectToAdd = new MountClientData();
                objectToAdd.Deserialize(reader);
                StabledMountsDescription.Add(objectToAdd);
            }
        }

    }
}
