﻿using System.Collections.Generic;
using Cookie.IO;
using Cookie.Network;
using Cookie.Protocol.Network.Types.Game.Character.Choice;

namespace Cookie.Protocol.Network.Messages.Game.Character.Choice
{
    public class BasicCharactersListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6475;

        public List<CharacterBaseInformations> Characters;

        public BasicCharactersListMessage()
        {
        }

        public BasicCharactersListMessage(List<CharacterBaseInformations> characters)
        {
            Characters = characters;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short) Characters.Count);
            int charactersIndex;
            for (charactersIndex = 0; charactersIndex < Characters.Count; charactersIndex = charactersIndex + 1)
            {
                var objectToSend = Characters[charactersIndex];
                writer.WriteUShort((ushort) objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            int charactersCount = reader.ReadUShort();
            Characters = new List<CharacterBaseInformations>();
            for (var i = 0; i < charactersCount; i++)
            {
                var objectToAdd =
                    ProtocolTypeManager.GetInstance<CharacterBaseInformations>((short) reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Characters.Add(objectToAdd);
            }
        }
    }
}