using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cookie.API.Core;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Gamedata.D2p;
using Cookie.API.Gamedata.Icons;
using Cookie.API.Messages;
using Cookie.API.Protocol;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Chat;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Commands.Managers;
using Cookie.FullSocket;
using Cookie.Game.Chat;
using Cookie.Properties;
using Cookie.Utils.Configurations;
using MoonSharp.Interpreter;

namespace Cookie
{
    public partial class MainForm : Form
    {
        private readonly History _chatHistory = new History();
        private IAccount _account;

        private FullSocket.FullSocket _fullSocket;

        public MainForm()
        {
            InitializeComponent();

            LogTextBox.Font = new Font("Tahoma", 8, FontStyle.Regular);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalConfiguration.Instance.Initialize();

                AccountConfiguration accountToConnect;

                using (var af = new AccountsForm())
                {
                    if (af.ShowDialog() != DialogResult.OK)
                        Environment.Exit(-1);

                    accountToConnect = af.AccountToConnect;
                }

                Task.Factory.StartNew(() =>
                {
                    UserData.RegisterAssembly();
                    CommandManager.Build();
                    ProtocolTypeManager.Initialize();

                    Logger.Default.OnLog += Logger_OnLog;

                    Settings.Default.DofusPath = GlobalConfiguration.Instance.DofusPath;
                    Settings.Default.Save();

                    MapsManager.Init(Settings.Default.DofusPath + @"\app\content\maps");
                    IconsManager.Instance.Initialize(Settings.Default.DofusPath + @"\app\content\gfx\items");
                    ObjectDataManager.Instance.AddReaders(Settings.Default.DofusPath + @"\app\data\common");

                    FastD2IReader.Instance.Init(Settings.Default.DofusPath + @"\app\data\i18n" +
                                                "\\i18n_fr.d2i");

                    ImageManager.Init(Settings.Default.DofusPath);
                }).ContinueWith(p =>
                {
                    var fullSocketConfiguration = new FullSocketConfiguration
                    {
                        RealAuthHost = "213.248.126.40",
                        RealAuthPort = 443
                    };

                    var messageReceiver = new MessageReceiver();
                    messageReceiver.Initialize();
                    _fullSocket = new FullSocket.FullSocket(fullSocketConfiguration, messageReceiver);
                    var dispatcherTask = new DispatcherTask(new MessageDispatcher(), _fullSocket);
                    _account = _fullSocket.Connect(accountToConnect.Username, accountToConnect.Password, this);
                    LogWelcomeMessage();
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Environment.Exit(-1);
            }
        }

        private void LogWelcomeMessage()
        {
            Logger.Default.Log("===============================", LogMessageType.Help);
            Logger.Default.Log("||                                                                              ||",
                LogMessageType.Help);
            Logger.Default.Log("||    Type '.help' to see all available commands !     ||", LogMessageType.Help);
            Logger.Default.Log("||                                                                              ||",
                LogMessageType.Help);
            Logger.Default.Log("===============================", LogMessageType.Help);
        }

        private void Logger_OnLog(string log, LogMessageType logType)
        {
            Console.WriteLine(log);

            void LogCallback()
            {
                LogTextBox.SelectionStart = LogTextBox.Text.Length;
                LogTextBox.SelectionLength = 0;
                var text = $"[{DateTime.Now.ToLongTimeString()}] {log}";

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
                    case LogMessageType.Error:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#FF0033");
                        break;
                    case LogMessageType.Help:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#2DB796");
                        break;
                    case LogMessageType.Command:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#969696");
                        text = $"$-> [{_chatHistory.Total()}] {log}";
                        break;
                    default:
                        LogTextBox.SelectionColor = ColorTranslator.FromHtml("#E8890D");
                        break;
                }

                LogTextBox.SelectedText = text + "\r\n";
                LogTextBox.SelectionColor = LogTextBox.ForeColor;
                LogTextBox.ScrollToCaret();
            }

            LogTextBox.Invoke((Action) LogCallback);
        }

        public void AddPluginListBox(string name, UserControl uc)
        {
            if (TabPlugin.InvokeRequired)
            {
                Invoke(new InsertIntoListBox(AddPluginListBox), name, uc);
            }
            else
            {
                var tabPage = new TabPage(name);
                tabPage.Controls.Add(uc);
                TabPlugin.Controls.Add(tabPage);
                tabPage.Select();
            }
        }

        private void ChatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                HandleSendChatMessage();
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                ChatTextBox.Text = _chatHistory.Prev();
                ChatTextBox.SelectionStart = ChatTextBox.Text.Length;
            }
            else if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                ChatTextBox.Text = _chatHistory.Next();
                ChatTextBox.SelectionStart = ChatTextBox.Text.Length;
            }
        }

        private void HandleSendChatMessage()
        {
            if (_account.Character.Status == CharacterStatus.Disconnected) return;
            if (string.IsNullOrWhiteSpace(ChatTextBox.Text))
            {
                Logger.Default.Log("Vous ne pouvez pas envoyer un texte vide.", LogMessageType.Public);
            }
            else
            {
                _chatHistory.Add(ChatTextBox.Text);
                Logger.Default.Log(ChatTextBox.Text, LogMessageType.Command);
                if (ChatTextBox.Text.Length > 2 && ChatTextBox.Text[0] == '.')
                {
                    var txt = ChatTextBox.Text.Substring(1);
                    try
                    {
                        CommandManager.ParseAndCall(_account, txt);
                    }
                    catch (Exception e)
                    {
                        Logger.Default.Log(e.Message);
                        Logger.Default.Log("Commande Incorrecte ou qui a échouée.", LogMessageType.Public);
                    }

                    ChatTextBox.BeginInvoke(new Action(() => ChatTextBox.Text = ""));
                    return;
                }


                if (ChatTextBox.Text.Length < 2)
                {
                    var ccmm = new ChatClientMultiMessage
                    {
                        Channel = (byte) ChatChannelsMultiEnum.CHANNEL_GLOBAL,
                        Content = ChatTextBox.Text
                    };

                    _account.Network.SendToServer(ccmm);
                }
                else
                {
                    var txt = ChatTextBox.Text.Substring(0, 2);
                    var chattxt = ChatTextBox.Text.Replace(txt, "");

                    var ccmm = new ChatClientMultiMessage
                    {
                        Channel = (byte) ChatChannelsMultiEnum.CHANNEL_GLOBAL,
                        Content = chattxt
                    };

                    switch (txt)
                    {
                        case "/g":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                ccmm.Channel = (byte) ChatChannelsMultiEnum.CHANNEL_GUILD;
                            break;
                        case "/s":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                ccmm.Channel = (byte) ChatChannelsMultiEnum.CHANNEL_GLOBAL;
                            break;
                        case "/t":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                ccmm.Channel = (byte) ChatChannelsMultiEnum.CHANNEL_TEAM;
                            break;
                        case "/a":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                ccmm.Channel = (byte) ChatChannelsMultiEnum.CHANNEL_ALLIANCE;
                            break;
                        case "/p":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                ccmm.Channel = (byte) ChatChannelsMultiEnum.CHANNEL_PARTY;
                            break;
                        case "/k":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                ccmm.Channel = (byte) ChatChannelsMultiEnum.CHANNEL_ARENA;
                            break;
                        case "/b":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                ccmm.Channel = (byte) ChatChannelsMultiEnum.CHANNEL_SALES;
                            break;
                        case "/r":
                            if (string.IsNullOrWhiteSpace(chattxt))
                                ccmm.Channel = (byte) ChatChannelsMultiEnum.CHANNEL_SEEK;
                            break;
                        default:
                            ccmm.Channel = (byte) ChatChannelsMultiEnum.CHANNEL_GLOBAL;
                            break;
                    }
                    _account.Network.SendToServer(ccmm);
                    ChatTextBox.BeginInvoke(new Action(() => ChatTextBox.Text = ""));
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    WindowState = FormWindowState.Normal;
                    break;
                case FormWindowState.Normal:
                    WindowState = FormWindowState.Maximized;
                    break;
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void AddPacketsListView(string origin, string name, string id)
        {
            if (PacketsListView.InvokeRequired)
            {
                Invoke(new InsertIntoListDelegate(AddPacketsListView), origin, name, id);
            }
            else
            {
                var time = DateTime.Now.ToLongTimeString();
                var rows = new[] {time, origin, id, name};
                var listViewItem = new ListViewItem(rows);
                PacketsListView.Items.Add(listViewItem);
                switch (origin)
                {
                    case "Client":
                        PacketsListView.Items[PacketsListView.Items.Count - 1].ForeColor =
                            ColorTranslator.FromHtml("#F16392");
                        break;
                    case "Server":
                        PacketsListView.Items[PacketsListView.Items.Count - 1].ForeColor =
                            ColorTranslator.FromHtml("#9EC79D");
                        break;
                }

                PacketsListView.EnsureVisible(PacketsListView.Items.Count - 1);
            }
        }

        private delegate void InsertIntoListDelegate(string origin, string name, string id);

        private delegate void InsertIntoListBox(string name, UserControl uc);
    }
}