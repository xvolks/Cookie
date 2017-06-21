using Cookie.Core;
using Cookie.Gamedata.D2o;
using Cookie.Gamedata.D2p;
using Cookie.Gamedata.I18n;
using Cookie.Gamedata.Icons;
using Cookie.Network;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cookie.Commands.Managers;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Game.Chat;
using Cookie.Utils.Enums;


namespace Cookie
{
    public partial class MainForm : Form
    {
        private DofusClient _client;

        public MainForm()
        {
            InitializeComponent();

            LogTextBox.Font = new Font("Tahoma", 8, FontStyle.Regular);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var accountFile = File.ReadAllText(Directory.GetCurrentDirectory() + "/config/account.txt");
                var dofusPath = File.ReadAllText(Directory.GetCurrentDirectory() + "/config/dofuspath.txt");

                var accountName = accountFile.Split(':')[0];
                var accountPassword = accountFile.Split(':')[1];

                Task.Factory.StartNew(() =>
                {
                    CommandManager.Build();
                    MessageReceiver.Initialize();
                    ProtocolTypeManager.Initialize();

                    Properties.Settings.Default.DofusPath = dofusPath;
                    Properties.Settings.Default.Save();

                    MapsManager.Init(Properties.Settings.Default.DofusPath + @"\app\content\maps");
                    IconsManager.Instance.Initialize(Properties.Settings.Default.DofusPath + @"\app\content\gfx\items");
                    ObjectDataManager.Instance.AddReaders(Properties.Settings.Default.DofusPath + @"\app\data\common");
                    I18nDataManager.Instance.AddReaders(Properties.Settings.Default.DofusPath + @"\app\data\i18n");
                    I18nDataManager.Instance.DefaultLanguage = Languages.French;
                    ImageManager.Init(Properties.Settings.Default.DofusPath);

                }).ContinueWith(p =>
                {
                    _client = new DofusClient(accountName, accountPassword)
                    {
                        Debug = true
                    };

                    _client.Logger.OnLog += Logger_OnLog;
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Environment.Exit(-1);
            }
        }

        private void Logger_OnLog(string log, LogMessageType logType)
        {
            Console.WriteLine(log);

            void LogCallback()
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
                var valueOrig = string.Empty;

                if (log.Contains("Received:") || log.Contains("Send"))
                {
                    switch (log.Split(':')[0])
                    {
                        case "Received":
                            valueOrig = "Serveur";
                            break;
                        case "Send":
                            valueOrig = "Client";
                            break;
                    }
                    string[] row1 = {DateTime.Now.ToLongTimeString(), valueOrig, log.Split('(')[1].Split(')')[0], log.Split('-')[1].Replace(" ", "")};
                    var listViewItem = new ListViewItem(row1);
                    PacketsListView.Items.Add(listViewItem);

                    if (log.Contains("Send")) PacketsListView.Items[PacketsListView.Items.Count - 1].ForeColor = ColorTranslator.FromHtml("#F16392");
                    if (log.Contains("Received")) PacketsListView.Items[PacketsListView.Items.Count - 1].ForeColor = ColorTranslator.FromHtml("#9EC79D");

                    PacketsListView.EnsureVisible(PacketsListView.Items.Count - 1);
                }
                else if (log.Contains("NO HANDLER"))
                {
                    NoHandlersListBox.Items.Add(log.Split(':')[1].Replace(" ", ""));
                }
                else
                {
                    var text = $"[{DateTime.Now.ToLongTimeString()}] {log}";
                    LogTextBox.SelectedText = text + "\r\n";
                    LogTextBox.SelectionColor = LogTextBox.ForeColor;
                    LogTextBox.ScrollToCaret();
                }
            }

            LogTextBox.Invoke((Action) LogCallback);

        }

        private void ChatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleSendChatMessage();
        }

        private void HandleSendChatMessage()
        {
            if (_client.Account.Character.Status == CharacterStatus.Disconnected) return;
            if (string.IsNullOrWhiteSpace(ChatTextBox.Text))
                _client.Logger.Log("Vous ne pouvez pas envoyer un texte vide.", LogMessageType.Public);
            else
            {


                if (ChatTextBox.Text.Length > 2 && ChatTextBox.Text[0] == '.')
                {
                    var txt = ChatTextBox.Text.Substring(1);
                    CommandManager.ParseAndCall(_client, txt);
                    ChatTextBox.BeginInvoke(new Action(() => ChatTextBox.Text = ""));
                    return;
                }


                if (ChatTextBox.Text.Length < 2)
                {
                    _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_GLOBAL, ChatTextBox.Text));
                }
                else
                {
                    var txt = ChatTextBox.Text.Substring(0, 2);
                    var chattxt = ChatTextBox.Text.Replace(txt, "");
                    switch (txt)
                    {
                        case "/g":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_GUILD, chattxt));
                            break;
                        case "/s":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_GLOBAL, chattxt));
                            break;
                        case "/t":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_TEAM, chattxt));
                            break;
                        case "/a":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_ALLIANCE, chattxt));
                            break;
                        case "/p":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_PARTY, chattxt));
                            break;
                        case "/k":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_ARENA, chattxt));
                            break;
                        case "/b":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_SALES, chattxt));
                            break;
                        case "/r":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_SEEK, chattxt));
                            break;
                        default:
                            _client.Send(new ChatClientMultiMessage((byte)ChatChannelsMultiEnum.CHANNEL_GLOBAL, ChatTextBox.Text));
                            break;
                    }
                    ChatTextBox.BeginInvoke(new Action(() => ChatTextBox.Text = ""));
                }
            }
        }
    }
}
