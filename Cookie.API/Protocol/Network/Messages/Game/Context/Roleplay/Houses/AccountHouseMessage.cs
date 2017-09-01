using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.House;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class AccountHouseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6315;

        public AccountHouseMessage(List<AccountHouseInformations> houses)
        {
            Houses = houses;
        }

        public AccountHouseMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<AccountHouseInformations> Houses { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Houses.Count);
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