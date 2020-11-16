using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MimicryObjectFeedAndAssociateRequestMessage : SymbioticObjectAssociateRequestMessage
    {
        public new const ushort ProtocolId = 6460;

        public override ushort MessageID => ProtocolId;

        public uint FoodUID { get; set; }
        public byte FoodPos { get; set; }
        public bool Preview { get; set; }
        public MimicryObjectFeedAndAssociateRequestMessage() { }

        public MimicryObjectFeedAndAssociateRequestMessage( uint FoodUID, byte FoodPos, bool Preview ){
            this.FoodUID = FoodUID;
            this.FoodPos = FoodPos;
            this.Preview = Preview;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(FoodUID);
            writer.WriteByte(FoodPos);
            writer.WriteBoolean(Preview);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FoodUID = reader.ReadVarUhInt();
            FoodPos = reader.ReadByte();
            Preview = reader.ReadBoolean();
        }
    }
}
