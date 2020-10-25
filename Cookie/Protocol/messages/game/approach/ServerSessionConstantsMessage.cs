using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ServerSessionConstantsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6434;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ServerSessionConstant> Variables;

        public ServerSessionConstantsMessage()
        {
        }

        public ServerSessionConstantsMessage(
            List<ServerSessionConstant> variables
        )
        {
            Variables = variables;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Variables.Count());
            foreach (var current in Variables)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countVariables = reader.ReadShort();
            Variables = new List<ServerSessionConstant>();
            for (short i = 0; i < countVariables; i++)
            {
                var variablestypeId = reader.ReadShort();
                ServerSessionConstant type = new ServerSessionConstant();
                type.Deserialize(reader);
                Variables.Add(type);
            }
        }
    }
}