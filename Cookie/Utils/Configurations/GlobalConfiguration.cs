using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Cookie.Utils.Configurations
{
    public class GlobalConfiguration
    {
        // Fields
        private const string ConfigPath = "config.cookie";

        private bool _initialized;


        // Constructor
        public GlobalConfiguration()
        {
            _initialized = false;

            Accounts = new List<AccountConfiguration>();
        }

        // Properties
        public string DofusPath { get; private set; }

        public List<AccountConfiguration> Accounts { get; }


        public void Initialize()
        {
            if (_initialized)
                return;

            // If the config file doesn't exist yet = first use
            if (!File.Exists(ConfigPath))
                using (var fuf = new FirstUseForm())
                {
                    if (fuf.ShowDialog() != DialogResult.OK)
                        Environment.Exit(-1);

                    DofusPath = fuf.DofusPath;
                    _initialized = true;
                    SaveConfiguration();
                }
            else
                LoadConfiguration();
        }

        public void AddAccount(string username, string password)
        {
            var ac = new AccountConfiguration(username, password);
            Accounts.Add(ac);
            SaveConfiguration();
        }

        public void removeAccount(int index)
        {
            Accounts.RemoveAt(index);
            SaveConfiguration();
        }

        private void SaveConfiguration()
        {
            if (!_initialized)
                return;

            using (var bw = new BinaryWriter(File.Open(ConfigPath, FileMode.Create)))
            {
                bw.Write(DofusPath);

                bw.Write((byte) Accounts.Count);
                Accounts.ForEach(f => f.Save(bw));
            }
        }

        private void LoadConfiguration()
        {
            using (var br = new BinaryReader(File.Open(ConfigPath, FileMode.Open)))
            {
                DofusPath = br.ReadString();
                var x = br.ReadByte();
                for (var i = 0; i < x; i++)
                    Accounts.Add(AccountConfiguration.Load(br));

                _initialized = true;
            }
        }

        #region Singleton

        private static GlobalConfiguration configuration;

        public static GlobalConfiguration Instance => configuration ?? (configuration = new GlobalConfiguration());

        #endregion
    }
}