using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachBranchesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6812;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ExtendedBreachBranch> Branches;

        public BreachBranchesMessage()
        {
        }

        public BreachBranchesMessage(
            List<ExtendedBreachBranch> branches
        )
        {
            Branches = branches;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Branches.Count());
            foreach (var current in Branches)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countBranches = reader.ReadShort();
            Branches = new List<ExtendedBreachBranch>();
            for (short i = 0; i < countBranches; i++)
            {
                ExtendedBreachBranch type = new ExtendedBreachBranch();
                type.Deserialize(reader);
                Branches.Add(type);
            }
        }
    }
}