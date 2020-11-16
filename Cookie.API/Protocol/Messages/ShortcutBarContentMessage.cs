using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ShortcutBarContentMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6231;

        public override ushort MessageID => ProtocolId;

        public sbyte BarType { get; set; }
        public List<Shortcut> Shortcuts { get; set; }
        public ShortcutBarContentMessage() { }

        public ShortcutBarContentMessage( sbyte BarType, List<Shortcut> Shortcuts ){
            this.BarType = BarType;
            this.Shortcuts = Shortcuts;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(BarType);
			writer.WriteShort((short)Shortcuts.Count);
			foreach (var x in Shortcuts)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadSByte();
            var ShortcutsCount = reader.ReadShort();
            Shortcuts = new List<Shortcut>();
            for (var i = 0; i < ShortcutsCount; i++)
            {
                Shortcut objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Shortcuts.Add(objectToAdd);
            }
        }
    }
}
