using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Delay
{
    public class GameRolePlayDelayedObjectUseMessage : GameRolePlayDelayedActionMessage
    {
        public new const ushort ProtocolId = 6425;

        public GameRolePlayDelayedObjectUseMessage(ushort objectGID)
        {
            ObjectGID = objectGID;
        }

        public GameRolePlayDelayedObjectUseMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ObjectGID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarUhShort();
        }
    }
}