using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Cookie.API.Core;
using Cookie.API.Core.Frames;
using Cookie.API.Plugins;
using Cookie.Core.Frames;

namespace Cookie.Core
{
    public class Account : IAccount
    {
        public Account(string login, string password, IDofusClient client)
        {
            Login = login;
            Password = password;

            Client = client;

            Character = new Character(Client);

            LatencyFrame = new LatencyFrame();

            LoadPlugins();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public IDofusClient Client { get; set; }

        public int Id { get; set; }
        public string Ticket { get; set; }
        public string Nickname { get; set; }
        public string SecretQuestion { get; set; }
        public double AccountCreation { get; set; }
        public byte CommunityId { get; set; }
        public double SubscriptionElapsedDuration { get; set; }
        public double SubscriptionEndDate { get; set; }

        public ICharacter Character { get; set; }

        public ILatencyFrame LatencyFrame { get; set; }

        private void LoadPlugins()
        {
            const string path = @"./plugins";
            foreach (var file in Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories))
            {
                var ass2 = Assembly.Load(File.ReadAllBytes(file));
                var types = ass2.GetTypes().Where(f => !f.IsAbstract && f.IsPublic).ToArray();

                foreach (var type in types)
                {
                    var t = ass2.GetType(type.FullName);
                    if (t.GetInterface(typeof(IPlugin).FullName) == null) continue;
                    var instance = (IPlugin) Activator.CreateInstance(t);
                    instance.OnLoad(Client);
                }
            }
        }
    }
}