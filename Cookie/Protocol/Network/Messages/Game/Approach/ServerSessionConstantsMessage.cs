using Cookie.IO;
using Cookie.Protocol.Network.Types.Game.Approach;
using System.Collections.Generic;

namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    class ServerSessionConstantsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6434;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ServerSessionConstant> Variables;

        public ServerSessionConstantsMessage() { }

        public ServerSessionConstantsMessage(List<ServerSessionConstant> variables)
        {
            Variables = variables;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)(Variables.Count));
            for (int i = 0; i < Variables.Count; i++)
            {
                ServerSessionConstant objectToSend = Variables[i];
                writer.WriteShort((short)objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            int length = reader.ReadUShort();
            Variables = new List<ServerSessionConstant>();
            for (int i = 0; i < length; i++)
            {
                ServerSessionConstant objectToAdd = new ServerSessionConstant(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Variables.Add(objectToAdd);
            }
        }
    }
}
