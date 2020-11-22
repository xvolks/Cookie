using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MimicryObjectFeedAndAssociateRequestMessage : SymbioticObjectAssociateRequestMessage
    {
        public new const uint ProtocolId = 6460;
        public override uint MessageID { get { return ProtocolId; } }

        public int FoodUID = 0;
        public byte FoodPos = 0;
        public bool Preview = false;

        public MimicryObjectFeedAndAssociateRequestMessage(): base()
        {
        }

        public MimicryObjectFeedAndAssociateRequestMessage(
            int symbioteUID,
            byte symbiotePos,
            int hostUID,
            byte hostPos,
            int foodUID,
            byte foodPos,
            bool preview
        ): base(
            symbioteUID,
            symbiotePos,
            hostUID,
            hostPos
        )
        {
            FoodUID = foodUID;
            FoodPos = foodPos;
            Preview = preview;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(FoodUID);
            writer.WriteByte(FoodPos);
            writer.WriteBoolean(Preview);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            FoodUID = reader.ReadVarInt();
            FoodPos = reader.ReadByte();
            Preview = reader.ReadBoolean();
        }
    }
}