using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class AchievementFinishedInformationMessage : AchievementFinishedMessage
    {
        public new const ushort ProtocolId = 6381;

        public AchievementFinishedInformationMessage(string name, ulong playerId)
        {
            Name = name;
            PlayerId = playerId;
        }

        public AchievementFinishedInformationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }
        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            PlayerId = reader.ReadVarUhLong();
        }
    }
}