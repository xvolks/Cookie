using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AccountHouseMessage : NetworkMessage
    {
        public const uint ProtocolId = 6315;
        public override uint MessageID { get { return ProtocolId; } }

        public List<AccountHouseInformations> Houses;

        public AccountHouseMessage()
        {
        }

        public AccountHouseMessage(
            List<AccountHouseInformations> houses
        )
        {
            Houses = houses;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Houses.Count());
            foreach (var current in Houses)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countHouses = reader.ReadShort();
            Houses = new List<AccountHouseInformations>();
            for (short i = 0; i < countHouses; i++)
            {
                AccountHouseInformations type = new AccountHouseInformations();
                type.Deserialize(reader);
                Houses.Add(type);
            }
        }
    }
}