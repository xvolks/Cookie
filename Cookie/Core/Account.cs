using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cookie.API.Core;
using Cookie.API.Core.Frames;
using Cookie.API.Core.Network;
using Cookie.API.Messages;
using Cookie.API.Network;
using Cookie.API.Plugins;
using Cookie.API.Utils;
using Cookie.Core.Frames;

namespace Cookie.Core
{
    public class Account : IAccount
    {
        public Account(string login, string password, IClient connection, MessageDispatcher dispatcher,
            MainForm mainForm)
        {
            Login = login;
            Password = password;

            Network = new Network.Network(this, connection, dispatcher);

            MainForm = mainForm;

            Character = new Character(this);

            LatencyFrame = new LatencyFrame();
            BasicFrame = new BasicFrame(this);

            LoadPlugins();
        }

        public MainForm MainForm { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

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

        public IBasicFrame BasicFrame { get; set; }

        public INetwork Network { get; set; }

        public void LogPacket(string origin, string name, string id)
        {
            MainForm.AddPacketsListView(origin, name, id);
        }

        public void PerformAction(Action action, int delay)
        {
            PerformCancelableAction(action, delay);
        }

        public void CreatePage(string name, UserControl control)
        {
            MainForm.AddPluginListBox(name, control);
        }

        private void LoadPlugins()
        {
            try
            {
                const string path = @"./plugins";
                if (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
                    Directory.CreateDirectory(path);

                foreach (var file in Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories))
                {
                    var ass2 = Assembly.Load(File.ReadAllBytes(file));
                    var types = ass2.GetTypes().Where(f => !f.IsAbstract && f.IsPublic).ToArray();
                    foreach (var type in types)
                    {
                        var t = ass2.GetType(type.FullName);
                        if (t.GetInterface(typeof(IPlugin).FullName) == null) continue;
                        var instance = (IPlugin) Activator.CreateInstance(t);
                        instance.Account = this;
                        instance.OnLoad();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void PerformCancelableAction(Action action, int delay)
        {
            var cts = new CancellationTokenSource();
            Task.Run(async delegate
            {
                await Task.Delay(delay, cts.Token);
                if (!cts.IsCancellationRequested)
                    try
                    {
                        action.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Logger.Default.Log(ex.ToString());
                    }
            }, cts.Token);
        }
    }
}