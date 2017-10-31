namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameActionFightTackledMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 1004;
        public override ushort MessageID => ProtocolId;
        public List<double> TacklersIds { get; set; }

        public GameActionFightTackledMessage(List<double> tacklersIds)
        {
            TacklersIds = tacklersIds;
        }

        public GameActionFightTackledMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)TacklersIds.Count);
            for (var tacklersIdsIndex = 0; tacklersIdsIndex < TacklersIds.Count; tacklersIdsIndex++)
            {
                writer.WriteDouble(TacklersIds[tacklersIdsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var tacklersIdsCount = reader.ReadUShort();
            TacklersIds = new List<double>();
            for (var tacklersIdsIndex = 0; tacklersIdsIndex < tacklersIdsCount; tacklersIdsIndex++)
            {
                TacklersIds.Add(reader.ReadDouble());
            }
        }

    }
}
