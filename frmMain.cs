using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using Server;

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

        #endregion

        #region Load Form
        //Load Form

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.GetExternalIP(); //retrieve external ip adress
            this.tmpSetConfig.Init(this.sAppPath);

            this.tmpController.ProgressChanged += new Controller.EventHandler(tmpController_ProgressChanged);
            this.tmpController.Completed += new Controller.EventHandler(tmpController_Completed);

            this.SetControls();

            UIModClass.DoubleBufferControl.Buffer(this.lbController, true);

            if (Directory.Exists(this.tmpSetConfig.WorldPath))
            {
                String[] sBuffer = Directory.GetFiles(this.tmpSetConfig.WorldPath, "*.wld");

                //foreach (string s in sBuffer)
                //{
                //    this.lbMaps.Items.Add(s);
                //}
                this.lbMaps.Items.AddRange(sBuffer);
            }

            this.cbConsole.SelectedIndex = 0;
        }

        #endregion

        #region Controls - Settings - Server
        //Controls - Settings - Server

        private void btnServerPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdServer = new OpenFileDialog())
            {
                string sProgramX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

                if (Directory.Exists(sProgramX86 + "\\Steam\\SteamApps\\common\\Terraria\\"))
                {
                    ofdServer.InitialDirectory = sProgramX86 + "\\Steam\\SteamApps\\common\\Terraria\\";
                }

                ofdServer.CheckFileExists = true;
                ofdServer.CheckPathExists = true;
                ofdServer.Multiselect = false;
                ofdServer.Filter = "TerrariaServer.exe|*.exe";

                ofdServer.ShowDialog();

                if (ofdServer.FileName != null && !String.IsNullOrEmpty(ofdServer.FileName))
                {
                    this.tmpSetConfig.ServerPath = ofdServer.FileName;
                    this.tbServerPath.Text = this.tmpSetConfig.ServerPath;
                }
            }
        }

        private void btnSearchServer_Click(object sender, EventArgs e)
        {

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
                fbdMaps.Description = "World Map Path. \\Terraria\\Worlds\\";

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

        #region Function - Retrieve - External IP Adress
        //Function - Retrieve - External IP Adress

        private void GetExternalIP()
        {
            try
            {
                string sExtIpAdress = string.Empty;

                using (WebClient wcGetString = new WebClient())
                {
                    Regex rexFilter = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");

                    sExtIpAdress = wcGetString.DownloadString("http://checkip.dyndns.org/");
                    sExtIpAdress = rexFilter.Matches(sExtIpAdress)[0].ToString();

                    if (!String.IsNullOrEmpty(sExtIpAdress))
                    {
                        this.tsslIpAdress.Text = sExtIpAdress;
                    }
                    else
                    {
                        this.tsslIpAdress.Text = "External IP Adress unknown";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieve External IP Adress\n" + ex.Message, "Error External IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            string sRunning = "Server offline";

            if (this.tmpController.Running)
            {
                sRunning = "Server online";
            }
            this.tsslServerValue.Text = String.Format("{0} Player, {1}", this.tmpController.Player, sRunning);
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

        #region Controls - ToolStripMenuItem - StartServer
        //Controls - ToolStripMenuItem - StartServer

        private void tsmiStartServer_Click(object sender, EventArgs e)
        {
            this.tcMain.SelectedTab = this.tbConsole;
            this.lbController.Items.Add("start Server...");
            this.lbController.Items.Add("");
            this.tmpController.FileName = this.tmpSetConfig.ServerPath;
            this.tmpController.DoJobAsync();
            this.tbCommand.Select();
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

        #region Controls - ToolStripMenuItem - TopMenu - Exit
        //Controls - ToolStripMenuItem - TopMenu - Exit

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tmpController.RequestExit();
        }

        #endregion

    }
}
