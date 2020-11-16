using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ServerSessionConstantsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6434;

        public override ushort MessageID => ProtocolId;

        public List<ServerSessionConstant> Variables { get; set; }
        public ServerSessionConstantsMessage() { }

        public ServerSessionConstantsMessage( List<ServerSessionConstant> Variables ){
            this.Variables = Variables;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Variables.Count);
			foreach (var x in Variables)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var VariablesCount = reader.ReadShort();
            Variables = new List<ServerSessionConstant>();
            for (var i = 0; i < VariablesCount; i++)
            {
                ServerSessionConstant objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Variables.Add(objectToAdd);
            }
        }
    }
}
