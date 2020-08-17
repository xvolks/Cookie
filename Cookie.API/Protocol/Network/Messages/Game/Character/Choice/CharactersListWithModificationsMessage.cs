using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character.Choice;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharactersListWithModificationsMessage : CharactersListMessage
    {
        public new const ushort ProtocolId = 6120;

        public CharactersListWithModificationsMessage(List<CharacterToRecolorInformation> charactersToRecolor,
            List<int> charactersToRename, List<int> unusableCharacters,
            List<CharacterToRelookInformation> charactersToRelook)
        {
            CharactersToRecolor = charactersToRecolor;
            CharactersToRename = charactersToRename;
            UnusableCharacters = unusableCharacters;
            CharactersToRelook = charactersToRelook;
        }

        public CharactersListWithModificationsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<CharacterToRecolorInformation> CharactersToRecolor { get; set; }
        public List<int> CharactersToRename { get; set; }
        public List<int> UnusableCharacters { get; set; }
        public List<CharacterToRelookInformation> CharactersToRelook { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) CharactersToRecolor.Count);
            for (var charactersToRecolorIndex = 0;
                charactersToRecolorIndex < CharactersToRecolor.Count;
                charactersToRecolorIndex++)
            {
                var objectToSend = CharactersToRecolor[charactersToRecolorIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) CharactersToRename.Count);
            for (var charactersToRenameIndex = 0;
                charactersToRenameIndex < CharactersToRename.Count;
                charactersToRenameIndex++)
                writer.WriteInt(CharactersToRename[charactersToRenameIndex]);
            writer.WriteShort((short) UnusableCharacters.Count);
            for (var unusableCharactersIndex = 0;
                unusableCharactersIndex < UnusableCharacters.Count;
                unusableCharactersIndex++)
                writer.WriteInt(UnusableCharacters[unusableCharactersIndex]);
            writer.WriteShort((short) CharactersToRelook.Count);
            for (var charactersToRelookIndex = 0;
                charactersToRelookIndex < CharactersToRelook.Count;
                charactersToRelookIndex++)
            {
                var objectToSend = CharactersToRelook[charactersToRelookIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var charactersToRecolorCount = reader.ReadUShort();
            CharactersToRecolor = new List<CharacterToRecolorInformation>();
            for (var charactersToRecolorIndex = 0;
                charactersToRecolorIndex < charactersToRecolorCount;
                charactersToRecolorIndex++)
            {
                var objectToAdd = new CharacterToRecolorInformation();
                objectToAdd.Deserialize(reader);
                CharactersToRecolor.Add(objectToAdd);
            }
            var charactersToRenameCount = reader.ReadUShort();
            CharactersToRename = new List<int>();
            for (var charactersToRenameIndex = 0;
                charactersToRenameIndex < charactersToRenameCount;
                charactersToRenameIndex++)
                CharactersToRename.Add(reader.ReadInt());
            var unusableCharactersCount = reader.ReadUShort();
            UnusableCharacters = new List<int>();
            for (var unusableCharactersIndex = 0;
                unusableCharactersIndex < unusableCharactersCount;
                unusableCharactersIndex++)
                UnusableCharacters.Add(reader.ReadInt());
            var charactersToRelookCount = reader.ReadUShort();
            CharactersToRelook = new List<CharacterToRelookInformation>();
            for (var charactersToRelookIndex = 0;
                charactersToRelookIndex < charactersToRelookCount;
                charactersToRelookIndex++)
            {
                var objectToAdd = new CharacterToRelookInformation();
                objectToAdd.Deserialize(reader);
                CharactersToRelook.Add(objectToAdd);
            }
        }
    }
}