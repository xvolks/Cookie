namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    using Utils.IO;

    public class InteractiveUseErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6384;
        public override ushort MessageID => ProtocolId;
        public uint ElemId { get; set; }
        public uint SkillInstanceUid { get; set; }

        public InteractiveUseErrorMessage(uint elemId, uint skillInstanceUid)
        {
            ElemId = elemId;
            SkillInstanceUid = skillInstanceUid;
        }

        public InteractiveUseErrorMessage() { }

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
