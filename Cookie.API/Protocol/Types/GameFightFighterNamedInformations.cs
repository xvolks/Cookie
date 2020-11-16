using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightFighterNamedInformations : GameFightFighterInformations
    {
        public new const ushort ProtocolId = 158;

        public override ushort TypeID => ProtocolId;

        public string Name { get; set; }
        public PlayerStatus Status { get; set; }
        public short LeagueId { get; set; }
        public int LadderPosition { get; set; }
        public bool HiddenInPrefight { get; set; }
        public GameFightFighterNamedInformations() { }

        public GameFightFighterNamedInformations( string Name, PlayerStatus Status, short LeagueId, int LadderPosition, bool HiddenInPrefight ){
            this.Name = Name;
            this.Status = Status;
            this.LeagueId = LeagueId;
            this.LadderPosition = LadderPosition;
            this.HiddenInPrefight = HiddenInPrefight;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            Status.Serialize(writer);
            writer.WriteVarShort(LeagueId);
            writer.WriteInt(LadderPosition);
            writer.WriteBoolean(HiddenInPrefight);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
            LeagueId = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
            HiddenInPrefight = reader.ReadBoolean();
        }
    }
}
