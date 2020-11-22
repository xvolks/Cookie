using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachStateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6799;

        public override ushort MessageID => ProtocolId;

        public CharacterMinimalInformations Owner { get; set; }
        public List<ObjectEffectInteger> Bonuses { get; set; }
        public uint Bugdet { get; set; }
        public bool Saved { get; set; }
        public BreachStateMessage() { }

        public BreachStateMessage( CharacterMinimalInformations Owner, List<ObjectEffectInteger> Bonuses, uint Bugdet, bool Saved ){
            this.Owner = Owner;
            this.Bonuses = Bonuses;
            this.Bugdet = Bugdet;
            this.Saved = Saved;
        }

        public override void Serialize(IDataWriter writer)
        {
            Owner.Serialize(writer);
			writer.WriteShort((short)Bonuses.Count);
			foreach (var x in Bonuses)
			{
				x.Serialize(writer);
			}
            writer.WriteVarUhInt(Bugdet);
            writer.WriteBoolean(Saved);
        }

        public override void Deserialize(IDataReader reader)
        {
            Owner = new CharacterMinimalInformations();
            Owner.Deserialize(reader);
            var BonusesCount = reader.ReadShort();
            Bonuses = new List<ObjectEffectInteger>();
            for (var i = 0; i < BonusesCount; i++)
            {
                var objectToAdd = new ObjectEffectInteger();
                objectToAdd.Deserialize(reader);
                Bonuses.Add(objectToAdd);
            }
            Bugdet = reader.ReadVarUhInt();
            Saved = reader.ReadBoolean();
        }
    }
}
