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
            client.Account.Character.Jobs.ForEach(Job =>            
                client.Logger.Log(D2OParsing.GetJobName(Job.JobId) + " | Level: " + Job.JobLevel + " | Exp: " + Job.JobXP, LogMessageType.Admin));
        }
    }
}