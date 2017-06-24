using Cookie.Commands.Interfaces;
using Cookie.Core;
using Cookie.Gamedata;

namespace Cookie.Commands.Commands
{
    public class JobsCommands : ICommand
    {
        public string CommandName => "jobs";

        public void OnCommand(DofusClient client, string[] args)
        {
            client.Account.Character.Jobs.ForEach(job =>
                client.Logger.Log(
                    D2OParsing.GetJobName(job.JobId) + " | Level: " + job.JobLevel + " | Exp: " + job.JobXP,
                    LogMessageType.Admin));
        }
    }
}