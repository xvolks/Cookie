using System;
using System.Collections.Generic;
using System.IO;

namespace Cookie.Utils.Configurations
{
    public class GlobalConfiguration
    {

        #region Singleton

        private static GlobalConfiguration configuration;
        public static GlobalConfiguration Instance
        {
            get
            {
                if (configuration == null)
                    configuration = new GlobalConfiguration();

                return configuration;
            }
        }

        #endregion

        // Properties
        public string DofusPath { get; private set; }
        public List<AccountConfiguration> Accounts { get; private set; }


        // Fields
        private const string configPath = "config.cookie";
        private const string accountsPath = "Accounts";
        private bool initialized;


        // Constructor
        public GlobalConfiguration()
        {
            initialized = false;

            Accounts = new List<AccountConfiguration>();
        }


        public void Initialize()
        {
            if (initialized)
                return;

            // If the config file doesn't exist yet = first use
            if (!File.Exists(configPath))
            {
                using (FirstUseForm fuf = new FirstUseForm())
                {
                    if (fuf.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        Environment.Exit(-1);

                    DofusPath = fuf.DofusPath;
                    initialized = true;
                    SaveConfiguration();
                }
            }
            else
            {
                LoadConfiguration();
            }
        }

        public void AddAccount(string username, string password)
        {
            AccountConfiguration ac = new AccountConfiguration(username, password);
            Accounts.Add(ac);
            SaveConfiguration();
        }

        private void SaveConfiguration()
        {
            if (!initialized)
                return;

            using (BinaryWriter bw = new BinaryWriter(File.Open(configPath, FileMode.Create)))
            {
                bw.Write(DofusPath);

                bw.Write((byte)Accounts.Count);
                Accounts.ForEach(f => f.Save(bw));
            }
        }

        private void LoadConfiguration()
        {
            using (BinaryReader br = new BinaryReader(File.Open(configPath, FileMode.Open)))
            {
                DofusPath = br.ReadString();
                byte x = br.ReadByte();
                for (int i = 0; i < x; i++)
                {
                    Accounts.Add(AccountConfiguration.Load(br));
                }

                initialized = true;
            }
        }

    }
}
