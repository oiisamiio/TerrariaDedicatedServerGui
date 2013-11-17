using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
using Local.Server;
using Local.UIClass;
using Local.WebClass;

namespace TerrariaDedicatedServerGUI
{
    public partial class frmMain : Form
    {

        #region Initialize Component
        //Initialize Component

        public frmMain()
        {
            InitializeComponent();

            //create EventHandler for Controls
            this.AddEventHandler();
        }

        #endregion

        #region Declaration
        //Declaration

        delegate void SetItemsCallback(string text);

        private String sAppPath = Application.StartupPath;

        private SetConfig tmpConfig = new SetConfig();
        private Controller tmpController = new Controller();
        private GetIpAdress tmpGetIpAdress = new GetIpAdress();

        #endregion

        #region Controls - Add - Eventhandler
        //Controls - Events

        private void AddEventHandler()
        {
            this.cbAutoCreate.SelectedIndex = 0;
            this.cbLangauge.SelectedIndex = 0;
            this.cbPriority.SelectedIndex = 2;

            this.chbAutoCreate.Validated += new EventHandler(chbAutoCreate_Validated);
            this.cbAutoCreate.Validated += new EventHandler(cbAutoCreate_Validated);
            this.tbAutoCreateName.Validated += new EventHandler(tbAutoCreateName_Validated);
            this.tbConfig.Validated += new EventHandler(tbConfig_Validated);
            this.tbBanlist.Validated += new EventHandler(tbBanlist_Validated);
            this.tbPort.Validated += new EventHandler(tbPort_Validated);
            this.tbPassword.Validated += new EventHandler(tbPassword_Validated);
            this.chbSecure.Validated += new EventHandler(chbSecure_Validated);
            this.chbUpnp.Validated += new EventHandler(chbUpnp_Validated);
            this.cbLangauge.Validated += new EventHandler(cbLangauge_Validated);
            this.cbPriority.Validated += new EventHandler(cbPriority_Validated);
            this.tbNpcStream.Validated += new EventHandler(tbNpcStream_Validated);
            this.chbAutoShutDown.Validated += new EventHandler(chbAutoshutdown_Validated);

            this.tbAdmin.TextChanged += new EventHandler(tbAdmin_TextChanged);

            this.tcMain.SelectedIndexChanged += new EventHandler(tcMain_SelectedIndexChanged);

            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
        }

        #endregion

        #region Load Form
        //Load Form

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.tmpConfig.Init(this.sAppPath);

            this.tmpController.ProgressChanged += new Controller.EventHandler(tmpController_ProgressChanged);
            this.tmpController.Completed += new Controller.EventHandler(tmpController_Completed);

            this.tmpGetIpAdress.Completed += new GetIpAdress.EventHandler(tmpGetIpAdress_Completed);

            this.tmpGetIpAdress.Init();

            this.SetControls();

            this.Text = String.Format("{0}{1}", this.Text, File.GetLastWriteTime(Application.ExecutablePath));

            DoubleBufferControl.Buffer(this.lbController, true);

            this.GetMaps();

            this.cbConsole.SelectedIndex = 0;
        }

        #endregion

        #region GetIPADress - Completed
        //GetIPADress - Completed

        private void tmpGetIpAdress_Completed()
        {
            if (this.tmpGetIpAdress.Exception == null)
            {
                this.tsslIpAdress.Text = this.tmpGetIpAdress.IPAdress;
            }
            else
            {
                MessageBox.Show("Error retrieve IP Adress:\n" + this.tmpGetIpAdress.Exception.Message, "Error retrieve IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tsslIpAdress.Text = "unknown IP / try 127.0.0.1";
            }
        }

        #endregion

        #region Function - GetMaps
        //Function - GetMaps

        private void GetMaps()
        {
            if (Directory.Exists(this.tmpConfig.WorldPath))
            {//retrieve all Maps
                String[] sBuffer = Directory.GetFiles(this.tmpConfig.WorldPath, "*.wld");
                this.lbMaps.Items.AddRange(sBuffer);
            }
        }

        #endregion

        #region Controls - TabControl - SelectedIndexChanged
        //Controls - TabControl - SelectedIndexChanged

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tcMain.SelectedIndex)
            {
                case 3:
                    this.AcceptButton = this.btnCommandText;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Controls - Settings - Server
        //Controls - Settings - Server

        private void btnServerPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdServer = new FolderBrowserDialog())
            {
                String sProgramX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                String sServerPath = String.Empty;

                if (Directory.Exists(sProgramX86 + "\\Steam\\SteamApps\\common\\Terraria\\"))
                {
                    sServerPath = sProgramX86 + "\\Steam\\SteamApps\\common\\Terraria\\";
                }
                else
                {
                    sServerPath = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "").ToString();
                    if (!String.IsNullOrEmpty(sServerPath))
                    {
                        sServerPath = sServerPath.Replace("/", "\\") + "\\SteamApps\\common\\Terraria\\";
                    }
                }

                fbdServer.SelectedPath = sServerPath;
                fbdServer.Description = sServerPath;

                fbdServer.ShowDialog();

                if (fbdServer.SelectedPath != null && !String.IsNullOrEmpty(fbdServer.SelectedPath))
                {
                    sServerPath = fbdServer.SelectedPath;
                }

                if (File.Exists(fbdServer.SelectedPath + "\\TerrariaServer.exe"))
                {
                    this.tmpConfig.ServerPath = fbdServer.SelectedPath;
                    this.tbServerPath.Text = this.tmpConfig.ServerPath;
                }
            }
        }

        private void btnSearchServer_Click(object sender, EventArgs e)
        {//ToDo:

        }

        #endregion

        #region Controls - Settings - Map
        //Controls - Settings - Map

        private void btnMapPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdMaps = new FolderBrowserDialog())
            {
                String sUserMyDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (Directory.Exists(sUserMyDocs + "\\My Games\\Terraria\\Worlds\\"))
                {
                    fbdMaps.SelectedPath = sUserMyDocs + "\\My Games\\Terraria\\Worlds\\";
                }
                fbdMaps.Description = sUserMyDocs + "\\My Games\\Terraria\\Worlds\\";

                fbdMaps.ShowDialog();

                if (fbdMaps.SelectedPath != null && !String.IsNullOrEmpty(fbdMaps.SelectedPath))
                {
                    this.tmpConfig.WorldPath = fbdMaps.SelectedPath;
                    this.tbWorldPath.Text = this.tmpConfig.WorldPath;

                    this.GetMaps();
                }
            }
        }

        private void btnSearchMap_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Controls - Save - Config
        //Controls - Save - Config

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            this.tmpConfig.Error = false;

            if (this.tmpConfig.WriteConfig()) //if WriteConfig throw Error
            {
                MessageBox.Show("an Error occured during Save Config", "Error Save Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Controls - Load - Config
        //Controls - Load - Config

        private void tsmiLoad_Click(object sender, EventArgs e)
        {

            this.tmpConfig.Error = false;

            if (this.tmpConfig.ReadConfig()) //if ReadConfig throw Error
            {
                MessageBox.Show("an Error occured during Load Config", "Error Load Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.SetControls();
            }
        }

        #endregion

        #region Controls - Setup - Controls
        //Controls - Setup - Controls

        private void SetControls()
        {
            this.tbServerPath.Text = this.tmpConfig.ServerPath;
            this.tbWorldPath.Text = this.tmpConfig.WorldPath;
            this.chbAutoCreate.Checked = this.tmpConfig.AutoCreate;
            this.cbAutoCreate.SelectedIndex = this.tmpConfig.AutoCreateValue;
            this.tbConfig.Text = this.tmpConfig.Config;
            this.tbBanlist.Text = this.tmpConfig.BanList;
            this.tbPort.Text = this.tmpConfig.Port.ToString();
            this.tbPassword.Text = this.tmpConfig.Password;
            this.tbMaxPlayer.Text = this.tmpConfig.Players.ToString();
            this.chbSecure.Checked = this.tmpConfig.Secure;
            this.chbUpnp.Checked = this.tmpConfig.NoUPNP;
            this.cbLangauge.SelectedIndex = this.tmpConfig.Language;
            this.cbPriority.SelectedIndex = this.tmpConfig.Priority;
            this.tbNpcStream.Text = this.tmpConfig.NpcStream.ToString();
            this.chbAutoShutDown.Checked = this.tmpConfig.AutoShutdown;

            this.chbUserInteract.Checked = this.tmpConfig.AllowUserInteract;
            this.chbAdmin.Checked = this.tmpConfig.AllowAdmin;
            this.tbAdmin.Text = this.tmpConfig.AdminName;
        }

        #endregion

        #region Controls - Validated
        //Controls - Validated

        private void chbAutoshutdown_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.AutoShutdown = this.chbAutoShutDown.Checked;
        }

        private void tbNpcStream_Validated(object sender, EventArgs e)
        {
            Int32 iBuffer = 60;

            if (Int32.TryParse(this.tbNpcStream.Text, out iBuffer))
            {
                this.tmpConfig.NpcStream = iBuffer;
            }
        }

        private void cbPriority_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.Priority = this.cbPriority.SelectedIndex;
        }

        private void cbLangauge_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.Language = this.cbLangauge.SelectedIndex;
        }

        private void chbUpnp_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.NoUPNP = this.chbUpnp.Checked;
        }

        private void chbSecure_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.Secure = this.chbSecure.Checked;
        }

        private void tbPassword_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.Password = this.tbPassword.Text;
        }

        private void tbPort_Validated(object sender, EventArgs e)
        {
            Int32 iBuffer = 7777;

            if (Int32.TryParse(this.tbPort.Text, out iBuffer))
            {
                this.tmpConfig.Port = iBuffer;
            }
        }

        private void tbBanlist_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.BanList = this.tbBanlist.Text;
        }

        private void tbConfig_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.Config = this.tbConfig.Text;
        }

        private void tbAutoCreateName_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.AutoCreateName = this.tbAutoCreateName.Text;
        }

        private void cbAutoCreate_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.AutoCreateValue = this.cbAutoCreate.SelectedIndex;
        }

        private void chbAutoCreate_Validated(object sender, EventArgs e)
        {
            this.tmpConfig.AutoCreate = this.chbAutoCreate.Checked;
        }

        #endregion

        #region Controls - ToolStripMenuItem - StartServer
        //Controls - ToolStripMenuItem - StartServer

        private void tsmiStartServer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tmpConfig.ServerPath))
            {
                MessageBox.Show("Setup Server Path first!", "Server Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (String.IsNullOrEmpty(this.tmpConfig.WorldPath))
            {
                MessageBox.Show("Setup World Path first!", "World Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.lbMaps.SelectedIndex != -1)
            {
                this.tmpController.Arguments = "-world " + "\"" + this.lbMaps.SelectedItem.ToString() + "\"";
            }
            else
            {
                DialogResult drMessageBox;
                drMessageBox = MessageBox.Show("No Map selected, wan`t select a Map?", "no Map", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (drMessageBox == System.Windows.Forms.DialogResult.Yes)
                {
                    this.tcMain.SelectedIndex = 2;
                    return;
                }
            }

            if (!this.tmpController.Running)
            {
                if (!File.Exists(this.tmpConfig.AppPath + "config.xml"))
                {
                    this.tmpConfig.Error = false;

                    if (this.tmpConfig.WriteConfig()) //if WriteConfig throw Error
                    {
                        MessageBox.Show("an Error occured during Save Config", "Error Save Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                this.tcMain.SelectedTab = this.tbConsole;

                this.lbController.Items.Add("");
                this.lbController.Items.Add("start Server... Please wait...");
                this.lbController.Items.Add("");
                this.lbController.SelectedIndex = this.lbController.Items.Count - 1;

                this.tmpController.Arguments = "-config " + this.tmpConfig.ServerPath + "\\serverconfig.txt";
                this.tmpController.Arguments = "-port " + this.tmpConfig.Port.ToString();
                this.tmpController.Arguments = "-players " + this.tmpConfig.Players.ToString();
                this.tmpController.Arguments = "-motd \"" + this.tbMotd.Text + "\"";

                if (this.tmpConfig.Password.Length >= 1)
                {
                    this.tmpController.Arguments = "-password " + this.tmpConfig.Password;
                }

                this.tmpController.Arguments = "-banlist " + this.tmpConfig.ServerPath + "banlist.txt";

                if (this.tmpConfig.Secure)
                {
                    this.tmpController.Arguments = "-secure";
                }

                if (this.tmpConfig.NoUPNP)
                {
                    this.tmpController.Arguments = "-noupnp";
                }

                this.tmpController.Priority = this.tmpConfig.Priority;

                this.tmpController.WorkingPath = this.tmpConfig.ServerPath;
                this.tmpController.FileName = "\\TerrariaServer.exe";

                this.tmpController.DoJobAsync();
                this.tbCommand.Select();
            }
        }

        #endregion

        #region Controls - Command - Buttons
        //Controls - Command - Buttons

        private void btnCommandText_Click(object sender, EventArgs e)
        {
            this.tmpController.Command = this.tbCommand.Text;
            this.tbCommand.Clear();
            this.tbCommand.Select();
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            this.tmpController.Command = this.cbConsole.SelectedItem.ToString();
        }

        private void btnCommandExit_Click(object sender, EventArgs e)
        {
            this.tmpController.Command = "exit";
        }

        private void btnCommandExitNoS_Click(object sender, EventArgs e)
        {
            this.tmpController.Command = "exit-nosave";
        }

        private void btnChatText_Click(object sender, EventArgs e)
        {
            this.tmpController.Command = "say " + this.tbCommandChat.Text;
        }

        private void btnCommandSave_Click(object sender, EventArgs e)
        {
            this.tmpController.Command = "save";
        }

        #endregion

        #region Controls - Admin
        //Controls - Admin

        private void tbAdmin_TextChanged(object sender, EventArgs e)
        {
            this.tmpConfig.AdminName = this.tbAdmin.Text;
            this.tmpController.Admin = this.tbAdmin.Text;
        }

        private void chbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            this.tmpConfig.AllowAdmin = this.chbAdmin.Checked;
            this.tmpController.AllowAdmin = this.chbAdmin.Checked;
        }

        #endregion

        #region Controls - Allow User Time
        //Allow User Time       

        private void chbUserTime_CheckedChanged(object sender, EventArgs e)
        {
            this.tmpConfig.AllowUserInteract = this.chbUserInteract.Checked;
            this.tmpController.AllowUserTime = this.chbUserInteract.Checked;
        }

        #endregion

        #region Controller - ProgressChanged
        //Controller - ProgressChanged

        private void tmpController_ProgressChanged()
        {
            SetListBox(this.tmpController.Buffer);

            string sRunning = "Server offline";

            if (this.tmpController.Running)
            {
                sRunning = "Server online";
            }
            this.tsslServerValue.Text = String.Format("{0} Player, {1}", this.tmpController.Player, sRunning);
        }

        #endregion

        #region Controller - Completed
        //Controller - Completed

        private void tmpController_Completed()
        {
            string sRunning = String.Empty;

            if (this.tmpController.Running)
            {
                sRunning = "Server online";
            }
            else
            {
                sRunning = "Server offline";
            }
            this.tsslServerValue.Text = String.Format("{0} Player, {1}", this.tmpController.Player, sRunning);
            this.lbController.Items.Add(sRunning);
            this.lbController.SelectedIndex = this.lbController.Items.Count - 1;
        }

        #endregion

        #region Control - Invoke
        //Control - Invoke

        private void SetListBox(String sInput)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lbController.InvokeRequired)
            {
                SetItemsCallback d = new SetItemsCallback(SetListBox);
                this.Invoke(d, new object[] { sInput });
            }
            else
            {
                this.lbController.Items.Add(sInput);
                this.lbController.SelectedIndex = this.lbController.Items.Count - 1;
            }
        }

        #endregion

        #region Controls - ToolStripMenuItem - TopMenu - Exit
        //Controls - ToolStripMenuItem - TopMenu - Exit

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Form - Closing
        //Form - Closing

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.tmpController.Running)
            {
                MessageBox.Show("Server is still running!\nPlease Shutdown Server by Console with exit or exit-nosave", "Server still running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        #endregion

    }
}
