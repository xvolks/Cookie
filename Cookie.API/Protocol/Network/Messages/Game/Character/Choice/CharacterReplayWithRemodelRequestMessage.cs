using Cookie.API.Protocol.Network.Messages.Game.Character.Replay;
using Cookie.API.Protocol.Network.Types.Game.Character.Choice;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharacterReplayWithRemodelRequestMessage : CharacterReplayRequestMessage
    {
        public new const ushort ProtocolId = 6551;

        public CharacterReplayWithRemodelRequestMessage(RemodelingInformation remodel)
        {
            Remodel = remodel;
        }

        public CharacterReplayWithRemodelRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public RemodelingInformation Remodel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Remodel.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Remodel = new RemodelingInformation();
            Remodel.Deserialize(reader);
        }
    }
}