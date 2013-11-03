using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
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

            this.tcMain.SelectedIndexChanged += new EventHandler(tcMain_SelectedIndexChanged);

            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
        }

        #endregion

        #region Declaration
        //Declaration

        delegate void SetItemsCallback(string text);

        private String sAppPath = Application.StartupPath;

        private SetConfig tmpSetConfig = new SetConfig();
        private Controller tmpController = new Controller();
        private GetIpAdress tmpGetIpAdress = new GetIpAdress();

        #endregion

        #region Load Form
        //Load Form

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.tmpSetConfig.Init(this.sAppPath);

            this.tmpController.ProgressChanged += new Controller.EventHandler(tmpController_ProgressChanged);
            this.tmpController.Completed += new Controller.EventHandler(tmpController_Completed);

            this.tmpGetIpAdress.Completed += new GetIpAdress.EventHandler(tmpGetIpAdress_Completed);

            this.tmpGetIpAdress.Init();

            this.SetControls();

            this.Text = String.Format("{0}{1}", this.Text, File.GetLastWriteTime(this.sAppPath + "\\TerrariaDedicatedServerGUI.vshost.exe")); //dirty dont use absolute String TerrariaDedicatedServerGUI.exe

            DoubleBufferControl.Buffer(this.lbController, true);

            if (Directory.Exists(this.tmpSetConfig.WorldPath))
            {//retrieve all Maps
                String[] sBuffer = Directory.GetFiles(this.tmpSetConfig.WorldPath, "*.wld");
                this.lbMaps.Items.AddRange(sBuffer);
            }

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

        #region Controls - Settings - Server
        //Controls - Settings - Server

        private void btnServerPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdServer = new FolderBrowserDialog())
            {
                string sProgramX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

                if (Directory.Exists(sProgramX86 + "\\Steam\\SteamApps\\common\\Terraria\\"))
                {
                    fbdServer.SelectedPath = sProgramX86 + "\\Steam\\SteamApps\\common\\Terraria\\";
                    fbdServer.Description = sProgramX86 + "\\Steam\\SteamApps\\common\\Terraria\\";
                }

                fbdServer.ShowDialog();

                if (fbdServer.SelectedPath != null && !String.IsNullOrEmpty(fbdServer.SelectedPath) && File.Exists(fbdServer.SelectedPath + "\\TerrariaServer.exe"))
                {
                    this.tmpSetConfig.ServerPath = fbdServer.SelectedPath;
                    this.tbServerPath.Text = this.tmpSetConfig.ServerPath;
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
                    this.tmpSetConfig.WorldPath = fbdMaps.SelectedPath;
                    this.tbWorldPath.Text = this.tmpSetConfig.WorldPath;
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
            this.tmpSetConfig.Error = false;

            if (this.tmpSetConfig.WriteConfig()) //if WriteConfig throw Error
            {
                MessageBox.Show("an Error occured during Save Config", "Error Save Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Controls - Load - Config
        //Controls - Load - Config

        private void tsmiLoad_Click(object sender, EventArgs e)
        {

            this.tmpSetConfig.Error = false;

            if (this.tmpSetConfig.ReadConfig()) //if ReadConfig throw Error
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
            this.tbServerPath.Text = this.tmpSetConfig.ServerPath;
            this.tbWorldPath.Text = this.tmpSetConfig.WorldPath;
            this.chbAutoCreate.Checked = this.tmpSetConfig.AutoCreate;
            this.cbAutoCreate.SelectedIndex = this.tmpSetConfig.AutoCreateValue;
            this.tbConfig.Text = this.tmpSetConfig.Config;
            this.tbBanlist.Text = this.tmpSetConfig.BanList;
            this.tbPort.Text = this.tmpSetConfig.Port.ToString();
            this.tbPassword.Text = this.tmpSetConfig.Password;
            this.tbMaxPlayer.Text = this.tmpSetConfig.Players.ToString();
            this.chbSecure.Checked = this.tmpSetConfig.Secure;
            this.chbUpnp.Checked = this.tmpSetConfig.NoUPNP;
            this.cbLangauge.SelectedIndex = this.tmpSetConfig.Language;
            this.cbPriority.SelectedIndex = this.tmpSetConfig.Priority;
            this.tbNpcStream.Text = this.tmpSetConfig.NpcStream.ToString();
            this.chbAutoShutDown.Checked = this.tmpSetConfig.AutoShutdown;
        }

        #endregion

        #region Controls - Validated
        //Controls - Validated

        private void chbAutoshutdown_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.AutoShutdown = this.chbAutoShutDown.Checked;
        }

        private void tbNpcStream_Validated(object sender, EventArgs e)
        {
            Int32 iBuffer = 60;

            if (Int32.TryParse(this.tbNpcStream.Text, out iBuffer))
            {
                this.tmpSetConfig.NpcStream = iBuffer;
            }
        }

        private void cbPriority_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.Priority = this.cbPriority.SelectedIndex;
        }

        private void cbLangauge_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.Language = this.cbLangauge.SelectedIndex;
        }

        private void chbUpnp_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.NoUPNP = this.chbUpnp.Checked;
        }

        private void chbSecure_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.Secure = this.chbSecure.Checked;
        }

        private void tbPassword_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.Password = this.tbPassword.Text;
        }

        private void tbPort_Validated(object sender, EventArgs e)
        {
            Int32 iBuffer = 7777;

            if (Int32.TryParse(this.tbPort.Text, out iBuffer))
            {
                this.tmpSetConfig.Port = iBuffer;
            }
        }

        void tbBanlist_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.BanList = this.tbBanlist.Text;
        }

        void tbConfig_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.Config = this.tbConfig.Text;
        }

        void tbAutoCreateName_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.AutoCreateName = this.tbAutoCreateName.Text;
        }

        void cbAutoCreate_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.AutoCreateValue = this.cbAutoCreate.SelectedIndex;
        }

        void chbAutoCreate_Validated(object sender, EventArgs e)
        {
            this.tmpSetConfig.AutoCreate = this.chbAutoCreate.Checked;
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

        #region Controls - ToolStripMenuItem - StartServer
        //Controls - ToolStripMenuItem - StartServer

        private void tsmiStartServer_Click(object sender, EventArgs e)
        {
            if (!this.tmpController.Running)
            {
                this.tcMain.SelectedTab = this.tbConsole;

                this.lbController.Items.Add("start Server...");
                this.lbController.Items.Add("");

                this.tmpController.Arguments = "-config " + this.tmpSetConfig.ServerPath + "\\serverconfig.txt";
                this.tmpController.Arguments = "-port " + this.tmpSetConfig.Port.ToString();
                this.tmpController.Arguments = "-players " + this.tmpSetConfig.Players.ToString();
                if (this.tmpSetConfig.Password.Length >= 1)
                {
                    this.tmpController.Arguments = "-password " + this.tmpSetConfig.Password;
                }
                if (this.lbMaps.SelectedIndex != -1)
                {
                    this.tmpController.Arguments = "-world " + "\"" + this.lbMaps.SelectedItem.ToString() + "\"";
                }
                this.tmpController.Arguments = "-banlist " + this.tmpSetConfig.ServerPath + "banlist.txt";
                if (this.tmpSetConfig.Secure)
                {
                    this.tmpController.Arguments = "-secure";
                }
                this.tmpController.FileName = this.tmpSetConfig.ServerPath;

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
