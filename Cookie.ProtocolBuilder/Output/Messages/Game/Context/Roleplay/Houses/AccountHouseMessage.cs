namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    using Types.Game.House;
    using System.Collections.Generic;
    using Utils.IO;

    public class AccountHouseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6315;
        public override ushort MessageID => ProtocolId;
        public List<AccountHouseInformations> Houses { get; set; }

        public AccountHouseMessage(List<AccountHouseInformations> houses)
        {
            Houses = houses;
        }

        public AccountHouseMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Houses.Count);
            for (var housesIndex = 0; housesIndex < Houses.Count; housesIndex++)
            {
                var objectToSend = Houses[housesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var housesCount = reader.ReadUShort();
            Houses = new List<AccountHouseInformations>();
            for (var housesIndex = 0; housesIndex < housesCount; housesIndex++)
            {
                var objectToAdd = new AccountHouseInformations();
                objectToAdd.Deserialize(reader);
                Houses.Add(objectToAdd);
            }
        }

    }
}
