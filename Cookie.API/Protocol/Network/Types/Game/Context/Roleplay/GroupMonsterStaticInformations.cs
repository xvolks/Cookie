using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class GroupMonsterStaticInformations : NetworkType
    {
        public const ushort ProtocolId = 140;

        public GroupMonsterStaticInformations(MonsterInGroupLightInformations mainCreatureLightInfos,
            List<MonsterInGroupInformations> underlings)
        {
            MainCreatureLightInfos = mainCreatureLightInfos;
            Underlings = underlings;
        }

        public GroupMonsterStaticInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public MonsterInGroupLightInformations MainCreatureLightInfos { get; set; }
        public List<MonsterInGroupInformations> Underlings { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            MainCreatureLightInfos.Serialize(writer);
            writer.WriteShort((short) Underlings.Count);
            for (var underlingsIndex = 0; underlingsIndex < Underlings.Count; underlingsIndex++)
            {
                var objectToSend = Underlings[underlingsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            MainCreatureLightInfos = new MonsterInGroupLightInformations();
            MainCreatureLightInfos.Deserialize(reader);
            var underlingsCount = reader.ReadUShort();
            Underlings = new List<MonsterInGroupInformations>();
            for (var underlingsIndex = 0; underlingsIndex < underlingsCount; underlingsIndex++)
            {
                var objectToAdd = new MonsterInGroupInformations();
                objectToAdd.Deserialize(reader);
                Underlings.Add(objectToAdd);
            }
        }
    }
}