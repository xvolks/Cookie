namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    using Utils.IO;

    public class InteractiveUseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5001;
        public override ushort MessageID => ProtocolId;
        public uint ElemId { get; set; }
        public uint SkillInstanceUid { get; set; }

        public InteractiveUseRequestMessage(uint elemId, uint skillInstanceUid)
        {
            ElemId = elemId;
            SkillInstanceUid = skillInstanceUid;
        }

        public InteractiveUseRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ElemId);
            writer.WriteVarUhInt(SkillInstanceUid);
        }

        public override void Deserialize(IDataReader reader)
        {
            ElemId = reader.ReadVarUhInt();
            SkillInstanceUid = reader.ReadVarUhInt();
        }

    }
}
