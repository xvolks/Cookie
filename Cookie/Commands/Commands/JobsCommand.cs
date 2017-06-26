using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Gamedata;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class JobsCommands : ICommand
    {
        public string CommandName => "jobs";

        public void OnCommand(IDofusClient client, string[] args)
        {
            client.Account.Character.Jobs.ForEach(job =>
                Logger.Default.Log(
                    D2OParsing.GetJobName(job.JobId) + " | Level: " + job.JobLevel + " | Exp: " + job.JobXP,
                    LogMessageType.Admin));
        }
    }
}