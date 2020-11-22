﻿using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Gamedata;
using Cookie.API.Protocol;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Core;
using Cookie.Game.Party;
using System.Threading;
using System.Threading.Tasks;

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
            {
                account.Network.SendToServer(new PartyInvitationRequestMessage(args[0]));
                ((Party)account.Character.Party).PartyNewMemberEvent += Party_PartyNewMember;
            }
        }

        
        private async void Party_PartyNewMember(IAccount account, bool message)
        {
            ((Party)account.Character.Party).PartyNewMemberEvent -= Party_PartyNewMember;
            var textMessage = new ChatClientMultiMessage()
            {
                Content = ".chef",
                Channel = (sbyte)ChatChannelsMultiEnum.CHANNEL_GLOBAL
            };
            account.Network.SendToServer(textMessage);
            textMessage = new ChatClientMultiMessage()
            {
                Content = ".pret",
                Channel = (sbyte)ChatChannelsMultiEnum.CHANNEL_GLOBAL
            };
            account.Network.SendToServer(textMessage);
            ushort[] CloseRangeIdols = { 32, 33, 34, 62, 63, 64 }; //Dynamos & Yoches 
            foreach (var Idol in CloseRangeIdols)
            {
                if (!await SendAndWait(account, new IdolSelectRequestMessage(true, true, Idol), 1000))
                {
                    Logger.Default.Log($"Failure while equiping idols.", LogMessageType.Error);
                    return;
                }
            }
            Logger.Default.Log($"Party Idols equipped with success.", LogMessageType.Party);
        }
        private async Task<bool> SendAndWait(IAccount account, NetworkMessage message, int timeout)
        {
            var TaskToDo = Task.Run(() => { account.Network.SendToServer(message); })
                .ContinueWith(t => { account.Character.Idols.IdolsResetEvent.WaitOne(2 * timeout); },
                    TaskContinuationOptions.OnlyOnRanToCompletion);

            // Task TimeoutAfter logic
            return await Task.WhenAny(TaskToDo, Task.Delay(timeout)) == TaskToDo;
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
    public class PartyEquipIdols : ICommand
    {
        public string CommandName => "partyEquipIdols";
        public string ArgsName => "void";
        public ushort[] CloseRangeIdols = { 32, 33, 34, 62, 63, 64 }; //Dynamos & Yoches 
        public async void OnCommand(IAccount account, string[] args)
        {
            foreach(var Idol in CloseRangeIdols)
            {
                if(!await SendAndWait(account, new IdolSelectRequestMessage(true, true, Idol), 1000))
                {
                    Logger.Default.Log($"Failure while equiping idols.",LogMessageType.Error);
                    return;
                }
            }
            Logger.Default.Log($"Party Idols equipped with success.", LogMessageType.Party);
        }
        private async Task<bool> SendAndWait(IAccount account, NetworkMessage message, int timeout)
        {
            var TaskToDo = Task.Run(() => { account.Network.SendToServer(message); })
                .ContinueWith(t => { account.Character.Idols.IdolsResetEvent.WaitOne(2 * timeout); },
                    TaskContinuationOptions.OnlyOnRanToCompletion);

            // Task TimeoutAfter logic
            return await Task.WhenAny(TaskToDo, Task.Delay(timeout)) == TaskToDo;
        }
    }
}