using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AccountHouseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6315;

        public override ushort MessageID => ProtocolId;

        public List<AccountHouseInformations> Houses { get; set; }
        public AccountHouseMessage() { }

        public AccountHouseMessage( List<AccountHouseInformations> Houses ){
            this.Houses = Houses;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Houses.Count);
			foreach (var x in Houses)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var HousesCount = reader.ReadShort();
            Houses = new List<AccountHouseInformations>();
            for (var i = 0; i < HousesCount; i++)
            {
                var objectToAdd = new AccountHouseInformations();
                objectToAdd.Deserialize(reader);
                Houses.Add(objectToAdd);
            }
        }
    }
}
