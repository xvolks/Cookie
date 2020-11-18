using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Gamedata;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class PartyInvite : ICommand
    {
        public string CommandName => "partyInvite";
        public string ArgsName => "string [characterName]";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
                Logger.Default.Log("You have to specify the CharacterName that you want to invite.", LogMessageType.Public);
            else
                account.Network.SendToServer(new PartyInvitationRequestMessage(args[0]));
        }
    }
    public class PartyPassLeader : ICommand
    {
        public string CommandName => "partyPassLeader";
        public string ArgsName => "string [characterName]";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log("You have to specify the CharacterName that you want to make the new leader.", LogMessageType.Public);
            }
            else
            {
                if(account.Character.Party.PassOnThrone(account, args[0]))
                    Logger.Default.Log($"Success! {args[0]} is the new Party Leader.", LogMessageType.Public);
                else
                    Logger.Default.Log($"Failure! {args[0]} could not be found.", LogMessageType.Public);
            }
        }
    }
    public class PartyMemberList : ICommand
    {
        public string CommandName => "partyMemberList";
        public string ArgsName => "void";

        public void OnCommand(IAccount account, string[] args)
        {
            foreach (var member in account.Character.Party.PartyMembers.Values)
                Logger.Default.Log($"{member.Name} - Level[{member.Level}], Breed[{member.Breed}], Location[{member.WorldX}, {member.WorldY}]");
        }
    }
}