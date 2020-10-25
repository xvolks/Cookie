using com.sun.xml.@internal.bind.marshaller;
using Cookie.Core;
using Cookie.Gamedata.D2o;
using Cookie.Gamedata.D2p;
using Cookie.Gamedata.I18n;
using Cookie.Gamedata.Icons;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cookie
{
    public partial class MainForm : Form
    {
        private DofusClient Client;

        public MainForm()
        {
            InitializeComponent();

            LogTextBox.Font = new Font("Tahoma", 8, FontStyle.Regular);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var DofusPath = @"C:\Users\NOM D'UTILISATEUR\AppData\Local\Ankama\Dofus";
            var AccountName = "NomDeCompte";
            var AccountPassword = "MotDePasse";

            Task.Factory.StartNew(() =>
            {
                MessageReceiver.Initialize();
                ProtocolTypeManager.Initialize();

                Properties.Settings.Default.DofusPath = DofusPath;
                Properties.Settings.Default.Save();

                MapsManager.Init(Properties.Settings.Default.DofusPath + @"\content\maps");
                IconsManager.Instance.Initialize(Properties.Settings.Default.DofusPath + @"\content\gfx\items");
                ObjectDataManager.Instance.AddReaders(Properties.Settings.Default.DofusPath + @"\data\common");
                I18nDataManager.Instance.AddReaders(Properties.Settings.Default.DofusPath + @"\data\i18n");
                I18nDataManager.Instance.DefaultLanguage = Languages.French;
                ImageManager.Init(Properties.Settings.Default.DofusPath);

            }).ContinueWith(p =>
            {
                Client = new DofusClient(AccountName, AccountPassword);
                Client.Logger.OnLog += Logger_OnLog;
            });      
        }

        private void Logger_OnLog(string log, LogMessageType logType)
        {
            Console.WriteLine(log);
            Action log_callback = delegate
            {
                LogTextBox.SelectionStart = LogTextBox.Text.Length;
                LogTextBox.SelectionLength = 0;

                switch (logType)
                {
                    case LogMessageType.Global:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#E9E9E9");
                        break;
                    case LogMessageType.Team:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#FF006C");
                        break;
                    case LogMessageType.Guild:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#975FFF");
                        break;
                    case LogMessageType.Alliance:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#FFAD42");
                        break;
                    case LogMessageType.Party:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#00E4FF");
                        break;
                    case LogMessageType.Sales:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#B3783E");
                        break;
                    case LogMessageType.Seek:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#E4A0D5");
                        break;
                    case LogMessageType.Noob:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#D3AA07");
                        break;
                    case LogMessageType.Admin:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#FF00FF");
                        break;
                    case LogMessageType.Private:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#7EC3FF");
                        break;
                    case LogMessageType.Info:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#46A324");
                        break;
                    case LogMessageType.FightLog:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#9DFF00");
                        break;
                    case LogMessageType.Public:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#EF3A3E");
                        break;
                    case LogMessageType.Arena:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#F16392");
                        break;
                    case LogMessageType.Community:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#9EC79D");
                        break;
                    case LogMessageType.Sender:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#1B96FF");
                        break;
                    case LogMessageType.Default:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#E8890D");
                        break;
                    case LogMessageType.Divers:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#3498db");
                        break;
                    default:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#E8890D");
                        break;
                }
                string text = $"[{DateTime.Now.ToLongTimeString()}] {log}";
                LogTextBox.SelectedText = text + "\r\n";
                LogTextBox.SelectionColor = LogTextBox.ForeColor;
                LogTextBox.ScrollToCaret();
            };
            LogTextBox.Invoke(log_callback);

    }
    }
}
