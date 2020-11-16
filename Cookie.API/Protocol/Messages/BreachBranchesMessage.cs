using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachBranchesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6812;

        public override ushort MessageID => ProtocolId;

        public List<ExtendedBreachBranch> Branches { get; set; }
        public BreachBranchesMessage() { }

        public BreachBranchesMessage( List<ExtendedBreachBranch> Branches ){
            this.Branches = Branches;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Branches.Count);
			foreach (var x in Branches)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var BranchesCount = reader.ReadShort();
            Branches = new List<ExtendedBreachBranch>();
            for (var i = 0; i < BranchesCount; i++)
            {
                var objectToAdd = new ExtendedBreachBranch();
                objectToAdd.Deserialize(reader);
                Branches.Add(objectToAdd);
            }
        }
    }
}
